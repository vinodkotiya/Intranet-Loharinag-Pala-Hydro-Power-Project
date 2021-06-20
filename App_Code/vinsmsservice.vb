
' ASPDOTNETAJAXIM - Copyright 2010 Vinod Kotiya
' http://vinodkotiya.blogspot.com

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO.Ports
Imports System.Threading


<WebService(Namespace:="http://www.vinodkotiya.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class vinsmsservice
    Inherits System.Web.Services.WebService
    ' vinod kotiya , www.vinodkotiya.com

    Shared readNow As New AutoResetEvent(False)
    Shared port As SerialPort

    <WebMethod()> _
    Public Function sendSMS(ByVal cell As String, ByVal message As String, ByVal portname As String) As String
        ' will return something with DONE or ERROR or RETRY or PENDING
        Dim log As String = "Port opened <br/>"
        Try
            '"Enter the port name your phone is connected to  

            port = EstablishConnection(portname)
            Dim recievedData As String = ExecuteCommand("AT", 300)

            If recievedData.Contains("+CME") Then
                log = log + "<br/><font color=red> RETRY Busy sending previous message </font>" + recievedData
                Exit Try   'move to finally
            Else
                log = log + " Modem Free <br/>" + recievedData
            End If
            recievedData = ExecuteCommand(" AT+CREG?", 300)

            If recievedData.Contains("0,2") Then
                log = log + "<br/><font color=red> PENDING No Network </font>" + "<br/>" + recievedData
                Exit Try  'Return log + "<br/><font color=red> ERROR No Network </font>"
            ElseIf recievedData.Contains("0,1") Then
                log = log + "<br/> <font color=green> Network Login </font>" + "<br/>" + recievedData
            End If

            recievedData = ExecuteCommand("AT+CMGF=1", 300)
            log = log + "<br/>" + recievedData
            '"Enter the phone number you want to send message to:   
            Dim phoneNumber As [String] = cell '"+919411103810"
            Dim command As [String] = "AT+CMGS=""" & phoneNumber & """"


            recievedData = ExecuteCommand(command, 300)
            log = log + "<br/>" + recievedData

            '   "Enter the message you want to send 
            '    command = message & Char.ConvertFromUtf32(26) & vbCr
            command = message & vbCrLf & Chr(26)
            'command = "AT+CREG?"
            recievedData = ExecuteCommand(command, 300)
            log = log + "<br/>" + recievedData
            If recievedData.Contains(vbLf) Then 'vbCr & vbLf & "OK" & vbCr & vbLf
                ' recievedData = "DONE Message sent successfully"
                log = log + "<br/> DONE Message sent successfully"
            End If
            If recievedData.Contains("ERROR") Then
                Dim recievedError As String = recievedData
                recievedError = recievedError.Trim()
                ' recievedData = "Following ERROR occured while sending the message " & recievedError
                log = log + "<br/>Following ERROR occured while sending the message " & recievedError
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
        '  Application("modemlock") = 0  'modem can be used now
        Return log
    End Function
    <WebMethod()> _
    Private Function ExecuteCommand(ByVal command As String, ByVal timeout As Integer) As String
        port.DiscardInBuffer()
        port.DiscardOutBuffer()
        readNow.Reset()
        port.Write(command & vbCr)
        Dim recieved As String = receive(timeout)
        Return recieved
    End Function
    <WebMethod()> _
    Private Function receive(ByVal timeout As Integer) As String
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
    <WebMethod()> _
    Private Function EstablishConnection(ByVal portName As String) As SerialPort
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
    <WebMethod()> _
    Private Sub DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        If e.EventType = SerialData.Chars Then
            readNow.[Set]()
        End If
    End Sub
    <WebMethod()> _
    Public Function logSMS(ByVal eid As String, ByVal message As String, ByVal groupid As String, ByVal requesttime As String) As String
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
    <WebMethod()> _
    Public Function updateSMSstatus(ByVal requesttime As String, ByVal statusratio As String, ByVal status As String) As String
        Dim query As String
        query = " update smslog set  successratio = '" & statusratio & "' , status = '" & status & "' where requesttime = '" & requesttime & "' "

        If executeQuerydb3(query) Then
            Return "<font color=green> SMS status updated </font><br/> "
        Else
            Return " <font color=red>  Unable to update SMS status </font><br/>" + query
        End If
    End Function
    <WebMethod()> _
    Public Function getGroupCellNos(ByVal groupid As String) As String()
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
    <WebMethod()> _
    Public Function getGroupIdwithMessage(ByVal smsid As String) As String
        'return groupid logtime and  message seperated by hash#
        Dim temp As String

        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn3").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()



            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("select groupid, message, requesttime from smslog where smsid = " + smsid, connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)

                If dt.Rows.Count = 1 Then
                    temp = dt.Rows(0).Item("groupid").ToString + "#" + dt.Rows(0).Item("requesttime").ToString + "#" + dt.Rows(0).Item("message").ToString
                Else
                    temp = "ERROR: smsid not found"
                End If
                sqlComm.Dispose()
                connection.Close()
                Return temp

            Catch e As Exception

                connection.Close()
                ' cellnos(0) = "Databse fail: " + e.Message
                Return "ERROR Databse fail: " + e.Message
            End Try

        End Using

    End Function
    <WebMethod()> _
    Private Function executeQuerydb3(ByVal mysql As String) As Boolean

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
    <WebMethod()> _
    Public Sub rebindGridView3(ByVal query As String, ByVal gridViewControl As GridView)
        'Binds Paging/Sorting GridView with data from the specified query
        ' Bind GridView to current query & always store ur query into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery

        Using connection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn3").ConnectionString)

            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                connection.Open()
                sqlComm = New SqlCommand(query, connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count

                If dataTableRowCount > 0 Then
                    gridViewControl.DataSource = dt
                    gridViewControl.DataBind()
                End If
                sqlComm.Dispose()
                connection.Close()
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message

                connection.Close()
            End Try


            connection.Close()
        End Using
    End Sub

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


    ' CMS ERROR's (GSM Network related codes)
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
    '    CME ERROR's (GSM Equipment related codes)

    ' Error	 Description
    'CME ERROR: 0	 Phone failure
    'CME ERROR: 1	 No connection to phone
    'CME ERROR: 2	 Phone adapter link reserved
    'CME ERROR: 3	 Operation not allowed
    'CME ERROR: 4	 Operation not supported
    'CME ERROR: 5	 PH_SIM PIN required
    'CME ERROR: 6	 PH_FSIM PIN required
    'CME ERROR: 7	 PH_FSIM PUK required
    'CME ERROR: 10	 SIM not inserted
    'CME ERROR: 11	 SIM PIN required
    'CME ERROR: 12	 SIM PUK required
    'CME ERROR: 13	 SIM failure
    'CME ERROR: 14	 SIM busy
    'CME ERROR: 15	 SIM wrong
    'CME ERROR: 16	 Incorrect password
    'CME ERROR: 17	 SIM PIN2 required
    'CME ERROR: 18	 SIM PUK2 required
    'CME ERROR: 20	 Memory full
    'CME ERROR: 21	 Invalid index
    'CME ERROR: 22	 Not found
    'CME ERROR: 23	 Memory failure
    'CME ERROR: 24	 Text string too long
    'CME ERROR: 25	 Invalid characters in text string
    'CME ERROR: 26	 Dial string too long
    'CME ERROR: 27	 Invalid characters in dial string
    'CME ERROR: 30	 No network service
    'CME ERROR: 31	 Network timeout
    'CME ERROR: 32	 Network not allowed, emergency calls only
    'CME ERROR: 40	 Network personalization PIN required
    'CME ERROR: 41	 Network personalization PUK required
    'CME ERROR: 42	 Network subset personalization PIN required
    'CME ERROR: 43	 Network subset personalization PUK required
    'CME ERROR: 44	 Service provider personalization PIN required
    'CME ERROR: 45	 Service provider personalization PUK required
    'CME ERROR: 46	 Corporate personalization PIN required
    'CME ERROR: 47	 Corporate personalization PUK required
    'CME ERROR: 48	 PH-SIM PUK required
    'CME ERROR: 100	 Unknown error
    'CME ERROR: 103	 Illegal MS
    'CME ERROR: 106	 Illegal ME
    'CME ERROR: 107	 GPRS services not allowed
    'CME ERROR: 111	 PLMN not allowed
    'CME ERROR: 112	 Location area not allowed
    'CME ERROR: 113	 Roaming not allowed in this location area
    'CME ERROR: 126	 Operation temporary not allowed
    'CME ERROR: 132	 Service operation not supported
    'CME ERROR: 133	 Requested service option not subscribed
    'CME ERROR: 134	 Service option temporary out of order
    'CME ERROR: 148	 Unspecified GPRS error
    'CME ERROR: 149	 PDP authentication failure
    'CME ERROR: 150	 Invalid mobile class
    'CME ERROR: 256	 Operation temporarily not allowed
    'CME ERROR: 257	 Call barred
    'CME ERROR: 258	 Phone is busy
    'CME ERROR: 259	 User abort
    'CME ERROR: 260	 Invalid dial string
    'CME ERROR: 261	 SS not executed
    'CME ERROR: 262	 SIM Blocked
    'CME ERROR: 263	 Invalid block
    'CME ERROR: 772	 SIM powered down
End Class
