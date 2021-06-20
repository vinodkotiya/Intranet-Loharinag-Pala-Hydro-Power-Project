Imports System.Threading

Partial Class sms
    Inherits System.Web.UI.Page

    ' if error comes then kill the asp.net development server. may be accessing the com port
    Shared vinread As New AutoResetEvent(False)
    Shared failednos As Integer = 0
    Shared totalnos As Integer = 0 'no of cell to send sms
    Shared workingno As String = "" ' currently sending sms on this no
    Shared workingmessage As String = "" ' currently sending this message


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'this will be executed only first time any event happen on web page
            ' If IsNothing(Request.Params("mode")) Then
            lblCell.Visible = False
            txtCell.Visible = False
            Timer1.Enabled = False
            
            If Not IsNothing(Request.Params("mode")) Then
                Session("mode") = Request.Params("mode") '    'mono or group or smsid
                '   lblCellno.Text = Request.Params("mode")
            Else
                Session("mode") = "group"
            End If
            If Not IsNothing(Request.Params("portname")) Then
                Session("portname") = Request.Params("portname")
                ' lblCellno.Text = lblCellno.Text + Request.Params("portname")
            Else
                Session("portname") = "COM3"
            End If

            If Not Session("mode") = "mono" And Not Session("mode") = "group" Then
                ' if pending smsid has been given
                If IsNumeric(Session("mode")) Then
                    '' means smsid has been given
                    lblCellno.Text = sendPendingSMS(Session("mode"))

                End If
            End If

            '
            '   Session("eid") = "009383"
            'Session("name") = "Vinod K"
            'txtSMS.Text = Now.Second.ToString + Rnd(1000).ToString + " Random sms no for group sms "

        End If

        If Not String.IsNullOrEmpty(Session("eid")) Then
            btnSend.Enabled = True
            If (FileIO.FileSystem.FileExists(Server.MapPath("~/database/pics/") + "p" + Session("eid") + ".gif")) Then
                imgUser.ImageUrl = "database\pics\p" + Session("eid") + ".gif"
            Else
                lblName.Text = "Guest: " + Request.UserHostAddress
                imgUser.ImageUrl = "database\pics\anonymous.gif"
            End If
            lblName.Text = Session("name")
            lblEid.Text = "Eid : " + Session("eid")
            lblDept.Text = Session("dept") + "<br/><a href=login.aspx?signout=1> Log Out </a>"

        Else
            btnSend.Enabled = False
            imgUser.ImageUrl = "database\pics\anonymous.gif"
            lblDept.Text = "<a href=login.aspx> Log in </a>"
            lblName.Text = "Guest: " + Request.UserHostAddress
            lblLogin.Text = " Please Authorize First Click here to <a href=login.aspx?requestedpage=sms.aspx?mode=group%26portname=COM4> Log in </a>"
        End If

        Session("CurrentQuery") = "SELECT LEFT(message, 70) + '...' AS message,smsid, convert(varchar, requesttime, 104) as requesttime1, requestby, successratio, groupid, status from smslog ORDER BY status DESC, requesttime DESC"
        Dim vinservice As vinsmsservice = New vinsmsservice
        vinservice.rebindGridView3(Session("CurrentQuery"), gvSMSlog)
    End Sub


    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
        'Dim SMSEngine As New vinsms("COM3")
        'SMSEngine.Open()
        'lblStatus.Text = "starting <br/>"
        'lblStatus.Text = SMSEngine.SendSMS(txtSMS.Text, "+919411103810")
        lblExe.Text = "Execution"
        lblSent.Text = ""
        Dim vinservice As New vinsmsservice
        Dim logtime As DateTime = Now
        'SMSEngine.Close()
        If Session("mode") = "mono" Then
            lblCell.Visible = True
            txtCell.Visible = True
            If txtSMS.Text.Length < 160 Then

               

                If txtMasterPassword.Text = "123456" Or txtMasterPassword.Text = "ntpc123" Then
                    '##### first log the sms
                    lblStatus.Text = vinservice.logSMS(Session("eid"), txtSMS.Text.Trim, "0", logtime.ToString)

                    '#####now send sms
                    lblCellno.Text = "Working On: " + txtCell.Text
                    Dim temp As String = vinservice.sendSMS(txtCell.Text, txtSMS.Text.Trim, Session("portname"))
                    lblStatus.Text = lblStatus.Text + temp

                    '#####now update sms status
                    If temp.Contains("ERROR") Then  'to get here always use CAPS ERROR

                        lblStatus.Text = lblStatus.Text + "<font color=red> Unable to send message to " + txtCell.Text + " </font><br/>"
                        lblStatus.Text = lblStatus.Text + vinservice.updateSMSstatus(logtime.ToString, "0/1", "pending")
                        lblCellno.Text = lblCellno.Text + "<br/> <font color=red> UnSent: " + txtCell.Text
                    Else
                        lblStatus.Text = lblStatus.Text + " <font color=green> Message sent succesfully to " + txtCell.Text + " </font> <br/>"
                        lblStatus.Text = lblStatus.Text + vinservice.updateSMSstatus(logtime.ToString, "1/1", "done")
                        lblCellno.Text = lblCellno.Text + "<br/> <font color=green> Sent: " + txtCell.Text
                    End If
                ElseIf txtMasterPassword.Text = "review" Then
                    lblStatus.Text = lblStatus.Text + vinservice.logSMS(Session("eid"), txtSMS.Text.Trim, "0", logtime.ToString)
                    vinservice.rebindGridView3(Session("CurrentQuery"), gvSMSlog)
                    lblCellno.Text = "<font color=green> Thanks, Your SMS has been sent in queue, and will be delivered later after review. </font>"
                    'queue function
                Else
                    lblCellno.Text = "<font color=red> You have not provided any Master password </br> If dont have any. Use ''review'' as master password to send message in queue. </font>"
                    '    Response.Write("<script language='javascript'>window.alert(' You have not provided any Master password </br> If dont have any. Use [[ review ]] as master password to send message in queue. ');</script>")

                End If

            Else
                lblCellno.Text = "<font color=red>Your SMS length has " + txtSMS.Text.Length.ToString + " characters which exceeds limit of 160 Characters. <br/> plz make it short. </font>"
            End If

            ' repeat same for group SMS
        ElseIf Session("mode") = "group" Then
           
            If txtSMS.Text.Length < 160 Then  ' check SMS length
                If rblGroup.SelectedIndex >= 0 Then  ' check group is selected or not

                    If txtMasterPassword.Text = "ntpc123" Or txtMasterPassword.Text = "789101112" Then
                        Dim temp As String = sendGroupSMS(rblGroup.SelectedValue.ToString, txtSMS.Text.Trim, Session("portname"))
                        lblStatus.Text = lblStatus.Text + temp
                        lblExe.Text = "<font color=red> Wait.. Sending..</font> <img src=images/loaderbar.gif />"
                        Session("CurrentQuery") = "SELECT LEFT(message, 35) + '...' AS message,smsid, convert(varchar, requesttime, 104) as requesttime1, requestby, successratio, groupid, status from smslog ORDER BY status DESC, requesttime DESC"


                    ElseIf txtMasterPassword.Text = "review" Then

                        '##### first log the sms
                        lblStatus.Text = vinservice.logSMS(Session("eid"), txtSMS.Text.Trim, rblGroup.SelectedValue.ToString, logtime.ToString)
                        vinservice.rebindGridView3(Session("CurrentQuery"), gvSMSlog)
                        lblCellno.Text = "<font color=green> Thanks, Your SMS has been sent in queue, and will be delivered later after review. </font>"
                    Else
                        lblCellno.Text = "<font color=red> You have not provided any Master password </br> If dont have any. Use ''review'' as master password to send message in queue. </font>"
                        ' Response.Write("<script language='javascript'>window.alert(' You have not provided any Master password </br> If dont have any. Use [[ review ]] as master password to send message in queue. ');</script>")

                    End If
                Else
                    lblCellno.Text = "<font color=red>You have not selected any Group. Please select one from the list. </font>"
                End If    'group check ends

            Else
                lblCellno.Text = "<font color=red>Your SMS length has " + txtSMS.Text.Length.ToString + " characters which exceeds limit of 160 Characters. <br/> plz make it short. </font>"
            End If     'sms length end
            End If
    End Sub
    Private Function sendGroupSMS(ByVal groupid As String, ByVal message As String, ByVal portname As String) As String
        Dim vinservice As New vinsmsservice
        Session("message") = message
        ''### Now get the phone no list from groupid
        Session("cellnos") = vinservice.getGroupCellNos(groupid)
        ''## check that got all the nos. from database of group
        If Session("cellnos").ToString.Contains("ERROR") Then
            Return Session("cellnos").ToString + " <br/> Unable to retrive cell list from database. Quit"

        End If
        '##### first log the sms
        Dim logtime As DateTime = Now
        Session("logtime") = logtime

        lblStatus.Text = vinservice.logSMS(Session("eid"), message, groupid, Session("logtime").ToString)

        Session("cellnoindex") = 0
        Session("Call_Once") = True  'if true u can call for sending sms
        Session("status") = "done" ' done or pending
        Timer1.Enabled = True
        Timer1.Interval = 1000
        lblStatus.Text = ""
        lblCellno.Text = ""

        Return "Initiating Sending Process <br/>"
    End Function
    Function sendPendingSMS(ByVal smsid As String) As String
        Dim vinservice As New vinsmsservice
        Dim temp As String
        Dim groupid As String
        '### Now get the groupid with message first
        temp = vinservice.getGroupIdwithMessage(smsid)   'return groupid logtime and  message seperated by hash#
        If temp.Contains("ERROR") Then
            Return temp  'unable to get groupid logtime and  message
        Else
            Dim arr As String() = temp.Split("#")
            groupid = arr(0)
            Session("logtime") = arr(1)
            Session("message") = arr(2)
            'Return groupid + Session("logtime") + Session("message")
            ''### Now get the phone no list from groupid
            Session("cellnos") = vinservice.getGroupCellNos(groupid)
            ''## check that got all the nos. from database of group
            If Session("cellnos").ToString.Contains("ERROR") Then
                Return Session("cellnos").ToString + " <br/> Unable to retrive cell list from database. Quit"
            End If

            Session("cellnoindex") = 0
            Session("Call_Once") = True  'if true u can call for sending sms
            Session("status") = "done" ' done or pending
            Timer1.Enabled = True
            Timer1.Interval = 1000
            lblStatus.Text = ""
            lblCellno.Text = ""
            lblExe.Text = "<font color=red> Wait.. Sending..</font> <img src=images/loaderbar.gif />"
            Return "Initiating Sending Process <br/>"
        End If
    End Function

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Timer1.Enabled = False
        Dim vinservice As New vinsmsservice
        Dim temp As String = ""
       
        Dim cellnos() As String = Session("cellnos")



        '#####now send sms
        If Session("Call_Once") And Int(Session("cellnoindex")) < cellnos.Length - 1 Then  'And Application("modemlock") = 0
            ' Application("modemlock") = 1  'modem can't be used now
            Session("Call_Once") = False
            Dim i As Integer = Int(Session("cellnoindex"))
            temp = vinservice.sendSMS(cellnos(i), Session("message"), Session("portname"))  ' will return something with DONE or ERROR
            lblStatus.Text = lblStatus.Text + temp

            'Session("cellnoindex") =0 has been called so prepare for next one
            Session("cellnoindex") = i + 1
            lblCellno.Text = lblCellno.Text + "<br/>Working On: " + cellnos(i)


            'Check status
            If temp.Contains("RETRY") Then
                Session("cellnoindex") = i
                lblStatus.Text = lblStatus.Text + "<font color=red> Modem Busy. Now Retry For " + cellnos(i) + " </font><br/>"
                lblCellno.Text = lblCellno.Text + " <br/> <font color=red> Retry " + cellnos(i) + "</font>"
            ElseIf temp.Contains("PENDING") And Session("cellnoindex") = 0 Then   'when first no failed by network then quit
                Session("cellnoindex") = cellnos.Length - 1
                lblStatus.Text = lblStatus.Text + "<font color=red> No Network, Message Sent in queue. Try Later  </font><br/>"
                lblCellno.Text = lblCellno.Text + " <br/> <font color=red> No Network, Message Sent in queue. Try Later </font>"
                failednos = cellnos.Length   ' all sms failed
                Session("status") = "pending" ' done or pending
            ElseIf temp.Contains("PENDING") Then   'when network failed in between lets try other no
                lblStatus.Text = lblStatus.Text + "<font color=red> No Network, when sending " + cellnos(i) + " </font><br/>"
                ' count no of failed cell
                failednos = failednos + 1
                ' store no of failed cell no
                lblCellno.Text = lblCellno.Text + " <br/> <font color=red> Unsent " + cellnos(i) + "</font>"
            ElseIf temp.Contains("ERROR") Then  'to get here always use CAPS ERROR

                lblStatus.Text = lblStatus.Text + "<font color=red> Unable to send message to " + cellnos(i) + " </font><br/>"
                ' count no of failed cell
                failednos = failednos + 1
                ' store no of failed cell no
                lblCellno.Text = lblCellno.Text + " <br/> <font color=red> Unsent " + cellnos(i) + "</font>"
               
            ElseIf temp.Contains("DONE") Then
                lblStatus.Text = lblStatus.Text + " <font color=green> Message sent succesfully to " + cellnos(i) + " </font> <br/>"
                lblCellno.Text = lblCellno.Text + " <br/> <font color=green> Sent " + cellnos(i) + "</font>"
            
            End If
            Session("Call_Once") = True 'now u can send other no for sms
            lblSent.Text = "Sent: " + (Int(Session("cellnoindex")) - failednos).ToString + " out of " + (cellnos.Length - 1).ToString
        ElseIf Int(Session("cellnoindex")) = cellnos.Length - 1 Then
            ''###now update the sms status
            lblStatus.Text = lblStatus.Text + vinservice.updateSMSstatus(Session("logtime"), (cellnos.Length - failednos - 1).ToString + "/" + Session("cellnoindex").ToString, Session("status"))
            Session("Call_Once") = False
            vinservice.rebindGridView3(Session("CurrentQuery"), gvSMSlog)
            lblExe.Text = "<font color=green> Done: " + (cellnos.Length - failednos - 1).ToString + " out of " + Session("cellnoindex").ToString + " </font> message sent succesfully"
            Timer1.Enabled = False
        End If

     

    End Sub
    Protected Sub gvSMSlog_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvSMSlog.PageIndexChanging
        If gvSMSlog.DataSource.GetType().ToString = "System.Data.DataTable" Then
            ' gvSMSlog.DataSource = SortDataTable(gvSMSlog.DataSource, True)
            gvSMSlog.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvSMSlog.DataBind()
        End If
    End Sub
    Protected Sub gvSMSlog_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSMSlog.SelectedIndexChanged
        ' Bind current data
        '  gvSMSlog.DataSource = SortDataTable(gvSMSlog.DataSource, True)
        gvSMSlog.PageIndex = Session("CurrentPage")
        gvSMSlog.DataBind()

        ' Clear session variables
      
        Session("CurrentQuery") = Nothing

    End Sub
End Class
''.. ### Method 1 start
'    Private Function sendGroupSMS(ByVal groupid As String, ByVal message As String, ByVal portname As String) As String
'        ''### Now get the phone no list from groupid
'        Dim cellnos() As String = getGroupCellNos(groupid)
'        Dim i As Integer = 0
'        Dim temp As String = ""
'        Dim logtime As DateTime = Now
'        workingmessage = message

'        ''## check that got all the nos. from database of group
'        If cellnos(0).Contains("ERROR") Then
'            Return cellnos(0).ToString + " <br/> Unable to retrive cell list from database. Quit"
'        End If

'        '##### first log the sms
'        lblStatus.Text = logSMS(Session("eid"), txtSMS.Text.Trim, "0", logtime.ToString)

'        ''## now send sms one by one
'        While i < cellnos.Length - 1
'            ' temp = temp + cellnos(i).ToString + "<br/>"
'            workingno = cellnos(i).ToString
'            ThreadPool.QueueUserWorkItem(AddressOf worksms, vinread)
'            If vinread.WaitOne(New TimeSpan(0, 0, 5), False) Then
'                lblStatus.Text = lblStatus.Text + " Work method signaled."
'            Else
'                lblStatus.Text = lblStatus.Text + " Timed out waiting for work method to signal."
'            End If


'            i = i + 1
'        End While

'        ''###now update the sms status
'        lblStatus.Text = lblStatus.Text + updateSMSstatus(logtime.ToString, (i - failednos).ToString + "/" + i.ToString, "done")

'        Return temp
'    End Function
'    Private Sub worksms(ByVal stateInfo As Object)


'        '#####now send sms
'        Dim temp As String = ""
'        temp = sendSMS(workingno, workingmessage, Session("portname"))
'        lblStatus.Text = lblStatus.Text + temp

'        'Check status
'        If temp.Contains("ERROR") Then  'to get here always use CAPS ERROR

'            lblStatus.Text = lblStatus.Text + "<font color=red> Unable to send message to " + workingno + " </font><br/>"
'            ' count no of failed cell
'            failednos = failednos + 1
'            ' store no of failed cell no

'        Else
'            lblStatus.Text = lblStatus.Text + " <font color=green> Message sent succesfully to " + workingno + " </font> <br/>"

'        End If

'        ' Simulate time spent working.
'        Thread.Sleep(5000) 'Thread.Sleep(New Random().Next(1000, 2000))

'        ' Signal that work is finished.
'        lblStatus.Text = lblStatus.Text + "Work ending."
'        CType(stateInfo, AutoResetEvent).Set()

'    End Sub
'End Class
''.. ### Method 1 ends

'Imports System.IO.Ports
'Imports System.Threading
'Partial Class sms
'    Inherits System.Web.UI.Page



'    Shared readNow As New AutoResetEvent(False)
'    Shared port As SerialPort




'    Private Shared Function ExecuteCommand(ByVal command As String, ByVal timeout As Integer) As String
'        port.DiscardInBuffer()
'        port.DiscardOutBuffer()
'        readNow.Reset()
'        port.Write(command & vbCr)
'        Dim recieved As String = receive(Timeout)
'        Return recieved
'    End Function
'    Private Shared Function receive(ByVal timeout As Integer) As String
'        Dim buffer As String = String.Empty
'        Do
'            If readNow.WaitOne(timeout, False) Then
'                Dim t As String = port.ReadExisting()
'                buffer += t
'            End If
'        Loop While Not buffer.EndsWith(vbCr & vbLf & "OK" & vbCr & vbLf) AndAlso Not buffer.EndsWith(vbCr & vbLf & "> ") AndAlso Not buffer.Contains("ERROR")
'        'Loop While Not buffer.Contains("OK") AndAlso Not buffer.EndsWith(">") AndAlso Not buffer.Contains("ERROR")
'        Return buffer
'    End Function

'    Private Shared Function EstablishConnection(ByVal portName As String) As SerialPort
'        Dim port As New SerialPort()
'        port.PortName = portName
'        port.BaudRate = 115200
'        port.DataBits = 8
'        port.StopBits = StopBits.One
'        port.Parity = Parity.None
'        port.ReadTimeout = 300
'        port.WriteTimeout = 300
'        ' port.Encoding = Encoding.GetEncoding("iso-8859-1")
'        AddHandler port.DataReceived, New SerialDataReceivedEventHandler(AddressOf DataReceived)
'        port.Open()
'        port.DtrEnable = True
'        port.RtsEnable = True
'        Return port
'    End Function

'    Private Shared Sub DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
'        If e.EventType = SerialData.Chars Then
'            readNow.[Set]()
'        End If
'    End Sub



'    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
'        'Dim SMSEngine As New vinsms("COM3")
'        'SMSEngine.Open()
'        'lblStatus.Text = "starting <br/>"
'        'lblStatus.Text = SMSEngine.SendSMS(txtSMS.Text, "+919411103810")
'        'SMSEngine.Close()

'        Try
'            '"Enter the port name your phone is connected to  
'            Dim portname As String = "COM3"


'            port = EstablishConnection(portname)
'            Dim recievedData As String = ExecuteCommand("AT", 300)
'            lblStatus.Text = lblStatus.Text + "<br/>" + recievedData
'            recievedData = ExecuteCommand("AT+CMGF=1", 300)
'            lblStatus.Text = lblStatus.Text + "<br/>" + recievedData
'            '"Enter the phone number you want to send message to:   
'            Dim phoneNumber As [String] = txtCell.Text '"+919411103810"
'            Dim command As [String] = "AT+CMGS=""" & phoneNumber & """"

'            '"Enter the message you want to send  
'            recievedData = ExecuteCommand(command, 300)
'            lblStatus.Text = lblStatus.Text + "<br/>" + recievedData

'            Dim message As String = txtSMS.Text.Trim()
'            '    command = message & Char.ConvertFromUtf32(26) & vbCr
'            command = message & vbCrLf & Chr(26)
'            '  command = "AT+CMGR=1"
'            recievedData = ExecuteCommand(command, 300)
'            lblStatus.Text = lblStatus.Text + "<br/>" + recievedData
'            If recievedData.Contains("OK") Then 'vbCr & vbLf & "OK" & vbCr & vbLf
'                recievedData = "Message sent successfully"
'            End If
'            If recievedData.Contains("ERROR") Then
'                Dim recievedError As String = recievedData
'                recievedError = recievedError.Trim()
'                recievedData = "Following error occured while sending the message " & recievedError
'            End If
'            lblStatus.Text = lblStatus.Text + "<br/>" + recievedData
'        Catch ex As Exception
'            lblStatus.Text = lblStatus.Text + "<br/>" + "Error Message: " & ex.Message.Trim() & vbCr & vbLf & "Hit any key to Exit"
'        Finally
'            ' If port IsNot Nothing Then
'            port.Close()
'            RemoveHandler port.DataReceived, New SerialDataReceivedEventHandler(AddressOf DataReceived)
'            port = Nothing
'            lblStatus.Text = lblStatus.Text + "<br/>Port closed"
'            'End If
'        End Try
'    End Sub
'End Class

