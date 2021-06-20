Imports Microsoft.VisualBasic
Imports System.IO.Ports
Imports System.Threading
Imports System.Data
Imports System.Data.SqlClient

Public Class vinsms
    ' vinod kotiya , www.vinodkotiya.com
   
     Shared readNow As New AutoResetEvent(False)
    Shared port As SerialPort


    Public Shared Function sendSMS(ByVal cell As String, ByVal message As String, ByVal portname As String) As String
        Dim log As String = ""
        Try
            '"Enter the port name your phone is connected to  

            port = EstablishConnection(portname)
            Dim recievedData As String = ExecuteCommand("AT", 300)
            log = log + "<br/>" + recievedData
            recievedData = ExecuteCommand(" AT+CREG?", 300)
            log = log + "<br/>" + recievedData
            If recievedData.Contains("0,2") Then
                Return log + "<br/><font color=red> ERROR No Network </font>"
            ElseIf recievedData.Contains("0,1") Then
                log = log + "<br/> <font color=green> Network Login </font>"
            End If

            recievedData = ExecuteCommand("AT+CMGF=1", 300)
            log = log + "<br/>" + recievedData
            '"Enter the phone number you want to send message to:   
            Dim phoneNumber As [String] = cell '"+919411103810"
            Dim command As [String] = "AT+CMGS=""" & phoneNumber & """"

            '"Enter the message you want to send  
            recievedData = ExecuteCommand(command, 300)
            log = log + "<br/>" + recievedData


            '    command = message & Char.ConvertFromUtf32(26) & vbCr
            command = message & vbCrLf & Chr(26)
            'command = "AT+CREG?"
            recievedData = ExecuteCommand(command, 300)
            log = log + "<br/>" + recievedData
            If recievedData.Contains("OK") Then 'vbCr & vbLf & "OK" & vbCr & vbLf
                recievedData = "Message sent successfully"
            End If
            If recievedData.Contains("ERROR") Then
                Dim recievedError As String = recievedData
                recievedError = recievedError.Trim()
                recievedData = "Following ERROR occured while sending the message " & recievedError
                log = log + "<br/>" + recievedData
            End If


        Catch ex As Exception
            log = log + "<br/>" + "ERROR Message: " & ex.Message.Trim()

        Finally
            If port IsNot Nothing Then
                port.Close()
                RemoveHandler port.DataReceived, New SerialDataReceivedEventHandler(AddressOf DataReceived)
                port = Nothing
                log = log + "<br/> Port has been closed succesfully"
            Else
                log = log + "<br/> ERROR Port has been already open by some application."
            End If

        End Try
        Return log
    End Function

    Private Shared Function ExecuteCommand(ByVal command As String, ByVal timeout As Integer) As String
        port.DiscardInBuffer()
        port.DiscardOutBuffer()
        readNow.Reset()
        port.Write(command & vbCr)
        Dim recieved As String = receive(timeout)
        Return recieved
    End Function
    Private Shared Function receive(ByVal timeout As Integer) As String
        Dim buffer As String = String.Empty
        Do
            If readNow.WaitOne(timeout, False) Then
                Dim t As String = port.ReadExisting()
                buffer += t
            End If
        Loop While Not buffer.EndsWith(vbCr & vbLf & "OK" & vbCr & vbLf) AndAlso Not buffer.EndsWith(vbCr & vbLf & "> ") AndAlso Not buffer.Contains("ERROR")
        'Loop While Not buffer.Contains("OK") AndAlso Not buffer.EndsWith(">") AndAlso Not buffer.Contains("ERROR")
        Return buffer
    End Function

    Private Shared Function EstablishConnection(ByVal portName As String) As SerialPort
        Dim port As New SerialPort()
        port.PortName = portName
        port.BaudRate = 115200
        port.DataBits = 8
        port.StopBits = StopBits.One
        port.Parity = Parity.None
        port.ReadTimeout = 300
        port.WriteTimeout = 300
        ' port.Encoding = Encoding.GetEncoding("iso-8859-1")
        AddHandler port.DataReceived, New SerialDataReceivedEventHandler(AddressOf DataReceived)
        port.Open()
        port.DtrEnable = True
        port.RtsEnable = True
        Return port
    End Function

    Private Shared Sub DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        If e.EventType = SerialData.Chars Then
            readNow.[Set]()
        End If
    End Sub
    Public Shared Function logSMS(ByVal eid As String, ByVal message As String, ByVal groupid As String, ByVal requesttime As String) As String
        Dim query As String

        query = " insert into smslog (requestby, message, requesttime, groupid, status) " & _
 " VALUES  (  " & _
  "'" & Replace(eid, "'", "''") & "', " & _
                "'" & Replace(message, "'", "''") & "', " & _
                                 "'" & Replace(requesttime, "'", "''") & "', " & _
                                  "" & groupid & ", " & _
                               "'" & Replace("pending", "'", "''") & "') "
        If executeQuerydb3(query) Then
            Return "<font color=green> SMS queued </font> <br/> "
        Else
            Return " <font color=red>  Unable to queue SMS </font> <br/>" + query
        End If
    End Function
    Public Shared Function updateSMSstatus(ByVal requesttime As String, ByVal statusratio As String, ByVal status As String) As String
        Dim query As String
        query = " update smslog set  successratio = '" & statusratio & "' , status = '" & status & "' where requesttime = '" & requesttime & "' "

        If executeQuerydb3(query) Then
            Return "<font color=green> SMS status updated </font><br/> "
        Else
            Return " <font color=red>  Unable to update SMS status </font><br/>" + query
        End If
    End Function
    Public Shared Function getGroupCellNos(ByVal groupid As String) As String()
        Dim cellnos() As String

        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn3").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim i As Integer = 0


            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("select cell from usergroup where groupid = " + groupid, connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                ReDim cellnos(dt.Rows.Count)
                While i < dt.Rows.Count
                    cellnos(i) = dt.Rows(i).Item("cell").ToString
                    'temp = temp + dt.Rows(i).Item("cell").ToString

                    i = i + 1
                End While
                sqlComm.Dispose()
                connection.Close()
                Return cellnos

            Catch e As Exception

                connection.Close()
                ' cellnos(0) = "Databse fail: " + e.Message
                Return {"ERROR Databse fail: " + e.Message} 'cellnos
            End Try

        End Using

    End Function
    Private Shared Function executeQuerydb3(ByVal mysql As String) As Boolean

        'Create Connection String
        'Dim DBConn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\intradb.mdf;Integrated Security=True;User Instance=True")
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn3").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader


            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand(mysql, connection)
                sqlReader = sqlComm.ExecuteReader()
                'Add Insert Statement
                sqlComm.Dispose()

                connection.Close()
                executeQuerydb3 = True


            Catch exp As Exception
                'lbldebug.Text = exp.Message
                connection.Close()
                executeQuerydb3 = False

            End Try

        End Using

    End Function
   
    '    2. Using the HyperTerminal 

    'Hint :: By developing your AT commands using HyperTerminal, it will be easier for you to develop your actual program codes in VB, C, Java or other platforms.

    'Go to START\Programs\Accessories\Communications\HyperTerminal (Win 2000) to create a new connection, eg. "My USB GSM Modem". Suggested settings ::

    ' - COM Port :: As indicated in the T-Modem Control Tool 
    ' - Bits per second :: 115200 ( or slower )
    ' - Data Bits : 8 
    ' - Parity : None
    ' - Stop Bits : 1
    ' - Flow Control : Hardware

    'You are now ready to start working with AT commands. Type in "AT" and you should get a "OK", else you have not setup your HyperTerminal correctly. Check your port settings and also make sure your GSM modem is properly connected and the drivers installed.

    '3. Initial setup AT commands

    'We are ready now to start working with AT commands to setup and check the status of the GSM modem.

    'AT	 Returns a "OK" to confirm that modem is working
    'AT+CPIN="xxxx"  	 To enter the PIN for your SIM ( if enabled )
    'AT+CREG?	 A "0,1" means logged in reply confirms your modem is connected to GSM network
    'AT+CSQ	 Indicates the signal strength, 31.99 is maximum.
    '4. Sending SMS using AT commands

    'We suggest try sending a few SMS using the Control Tool above to make sure your GSM modem can send SMS before proceeding. Let's look at the AT commands involved ..

    'AT+CMGF=1	 To format SMS as a TEXT message
    'AT+CSCA="+xxxxx"  	 Set your SMS center's number. Check with your provider.
    'To send a SMS, the AT command to use is AT+CMGS ..

    'AT+CMGS="+yyyyy" <Enter>
    '> Your SMS text message here <Ctrl-Z>

    'The "+yyyyy" is your receipent's mobile number. Next, we will look at receiving SMS via AT commands.

    '5. Receiving SMS using AT commands

    'The GSM modem can be configured to response in different ways when it receives a SMS.

    'a) Immediate - when a SMS is received, the SMS's details are immediately sent to the host computer (DTE) via the +CMT command

    'AT+CMGF=1	 To format SMS as a TEXT message
    'AT+CNMI=1,2,0,0,0  	 Set how the modem will response when a SMS is received
    'When a new SMS is received by the GSM modem, the DTE will receive the following ..
    '    Example: Receive SMS

    'A SMS will be stored in the GSM modem / module and being send via RS232 to the peripherals. The  peripherals have to send commands to the GSM unit to receive SMS and to erase SMS from the  SIM card in order to clean memory.

    '+CMTI:"SM",x    X stands for the memory number of received SMS
    'AT+CMGR=X[Enter]    Read SMS on memory number X
    'AT+CMGD=X[Enter]    Erase SMS on memory number X
    '+CMT :  "+61xxxxxxxx" , , "04/08/30,23:20:00+40"    'This the text SMS message sent to the modem

    'Your computer (DTE) will have to continuously monitor the COM serial port, read and parse the message.

    'b) Notification - when a SMS is recieved, the host computer ( DTE ) will be notified of the new message. The computer will then have to read the message from the indicated memory location and clear the memory location.

    'AT+CMGF=1	 To format SMS as a TEXT message
    'AT+CNMI=1,1,0,0,0  	 Set how the modem will response when a SMS is received
    'When a new SMS is received by the GSM modem, the DTE will receive the following ..

    '+CMTI: "SM",3	 Notification sent to the computer. Location 3 in SIM memory
    'AT+CMGR=3 <Enter> 	 AT command to send read the received SMS from modem
    'The modem will then send to the computer details of the received SMS from the specified memory location ( eg. 3 ) ..

    '+CMGR: "REC READ","+61xxxxxx",,"04/08/28,22:26:29+40"
    'This is the new SMS received by the GSM modem

    'After reading and parsing the new SMS message, the computer (DTE) should send a AT command to clear the memory location in the GSM modem ..

    'AT+CMGD=3 <Enter>   To clear the SMS receive memory location in the GSM modem

    'If the computer tries to read a empty/cleared memory location, a +CMS ERROR : 321 will be sent to the computer.
    '    Important Commands
    'Note: The answers for networks and field strength can be delayed for several seconds.
    'ATZ;E[Enter]
    'Echo OFF
    'ATZ;E1[Enter]
    'Echo ON
    'AT+CSQ[Enter]
    'Show field strength. Field strength in dBm = -112 dBm+(2*X).  When X gets bigger, then the field strength is higher. -104 dBm is the lowest value for a voice  call. A data calls willfaulty because the noise is to high.
    'AT+CREG?[Enter]
    'Answer 0,x (X=2=log off, X=1=log in, X=0=donÃ‚Â´t know) please  refer to manual for further infos
    'AT+COPS?[Enter]
    'Shows which GSM operators is active. 
    '0,2,26201= T-Mobile  availiable
    'AT+COPS=?[Enter]
    'Shows all available networks

    '    Error	 Description
    'CMS ERROR: 1	 Unassigned number
    'CMS ERROR: 8	 Operator determined barring
    'CMS ERROR: 10	 Call bared
    'CMS ERROR: 21	 Short message transfer rejected
    'CMS ERROR: 27	 Destination out of service
    'CMS ERROR: 28	 Unindentified subscriber
    'CMS ERROR: 29	 Facility rejected
    'CMS ERROR: 30	 Unknown subscriber
    'CMS ERROR: 38	 Network out of order
    'CMS ERROR: 41	 Temporary failure
    'CMS ERROR: 42	 Congestion
    'CMS ERROR: 47	 Recources unavailable
    'CMS ERROR: 50	 Requested facility not subscribed
    'CMS ERROR: 69	 Requested facility not implemented
    'CMS ERROR: 81	 Invalid short message transfer reference value
    'CMS ERROR: 95	 Invalid message unspecified
    'CMS ERROR: 96	 Invalid mandatory information
    'CMS ERROR: 97	 Message type non existent or not implemented
    'CMS ERROR: 98	 Message not compatible with short message protocol
    'CMS ERROR: 99	 Information element non-existent or not implemente
    'CMS ERROR: 111	 Protocol error, unspecified
    'CMS ERROR: 127	 Internetworking , unspecified
    'CMS ERROR: 128	 Telematic internetworking not supported
    'CMS ERROR: 129	 Short message type 0 not supported
    'CMS ERROR: 130	 Cannot replace short message
    'CMS ERROR: 143	 Unspecified TP-PID error
    'CMS ERROR: 144	 Data code scheme not supported
    'CMS ERROR: 145	 Message class not supported
    'CMS ERROR: 159	 Unspecified TP-DCS error
    'CMS ERROR: 160	 Command cannot be actioned
    'CMS ERROR: 161	 Command unsupported
    'CMS ERROR: 175	 Unspecified TP-Command error
    'CMS ERROR: 176	 TPDU not supported
    'CMS ERROR: 192	 SC busy
    'CMS ERROR: 193	 No SC subscription
    'CMS ERROR: 194	 SC System failure
    'CMS ERROR: 195	 Invalid SME address
    'CMS ERROR: 196	 Destination SME barred
    'CMS ERROR: 197	 SM Rejected-Duplicate SM
    'CMS ERROR: 198	 TP-VPF not supported
    'CMS ERROR: 199	 TP-VP not supported
    'CMS ERROR: 208	 D0 SIM SMS Storage full
    'CMS ERROR: 209	 No SMS Storage capability in SIM
    'CMS ERROR: 210	 Error in MS
    'CMS ERROR: 211	 Memory capacity exceeded
    'CMS ERROR: 212	 Sim application toolkit busy
    'CMS ERROR: 213	 SIM data download error
    'CMS ERROR: 255	 Unspecified error cause
    'CMS ERROR: 300	 ME Failure
    'CMS ERROR: 301	 SMS service of ME reserved
    'CMS ERROR: 302	 Operation not allowed
    'CMS ERROR: 303	 Operation not supported
    'CMS ERROR: 304	 Invalid PDU mode parameter
    'CMS ERROR: 305	 Invalid Text mode parameter
    'CMS ERROR: 310	 SIM not inserted
    'CMS ERROR: 311	 SIM PIN required
    'CMS ERROR: 312	 PH-SIM PIN required
    'CMS ERROR: 313	 SIM failure
    'CMS ERROR: 314	 SIM busy
    'CMS ERROR: 315	 SIM wrong
    'CMS ERROR: 316	 SIM PUK required
    'CMS ERROR: 317	 SIM PIN2 required
    'CMS ERROR: 318	 SIM PUK2 required
    'CMS ERROR: 320	 Memory failure
    'CMS ERROR: 321	 Invalid memory index
    'CMS ERROR: 322	 Memory full
    'CMS ERROR: 330	 SMSC address unknown
    'CMS ERROR: 331	 No network service
    'CMS ERROR: 332	 Network timeout
    'CMS ERROR: 340	 No +CNMA expected
    'CMS ERROR: 500	 Unknown error
    'CMS ERROR: 512	 User abort
    'CMS ERROR: 513	 Unable to store
    'CMS ERROR: 514	 Invalid Status
    'CMS ERROR: 515	 Device busy or Invalid Character in string
    'CMS ERROR: 516	 Invalid length
    'CMS ERROR: 517	 Invalid character in PDU
    'CMS ERROR: 518	 Invalid parameter
    'CMS ERROR: 519	 Invalid length or character
    'CMS ERROR: 520	 Invalid character in text
    'CMS ERROR: 521	 Timer expired
    'CMS ERROR: 522	 Operation temporary not allowed
    'CMS ERROR: 532	 SIM not ready
    'CMS ERROR: 534	 Cell Broadcast error unknown
    'CMS ERROR: 535	 Protocol stack busy
    'CMS ERROR: 538	 Invalid parameter
End Class
