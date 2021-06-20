Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Xml

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ChatService As New ChatService
        Session("myIP") = Request.UserHostAddress   ' for LAN/WAN   or
        'Session("myIP") = Request.UserHostAddress + Request.Browser.Browser  'for single PC
        'Session("myIP") = Request.UserHostAddress + Str(Now.TimeOfDay.Seconds * Rnd(30))
        If Not Page.IsPostBack Then
            'this will be executed only first time any event happen on web page

            ChatService.trackOnlineVisitor(Session("myIP"))

            ' Clear user paging/sort
           

            Session("CurrentPage") = 0
            Session("SortExpression") = Nothing
            GridViewSortDirection = "ASC"
            ' Set current query
            Session("CurrentQuery") = "SELECT LEFT(sub, 35) + '...' AS sub,filename, convert(varchar, cdate, 104) as cdate1, cdate from circulars ORDER BY cdate DESC"
            Session("CurrentQuery1") = "SELECT LEFT(topic, 35) + '..  'as topic, filename from articles ORDER BY cdate DESC"
            '' setting to show popup should be made in web.config file : inside <configuration>  <appSettings>
            If System.Configuration.ConfigurationManager.AppSettings("showPopup") = "1" Then
                ModalPopupExtender1.Show()
            End If

            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblName.Text = "Welcome <font color='#9218AB'>" + Session("name") + "</font><br/> Your Visits : " + (trackVisitor(Request.UserHostAddress))
            Else
                lblName.Text = "Welcome Guest: <font color='#9218AB'>" + Request.UserHostAddress + "</font><br/> Your Visits : " + (trackVisitor(Request.UserHostAddress)) ' HttpContext.Current.User.Identity.Name +
            End If
            lblQuotes.Text = getQuotes()

           


        End If
        Dim oQuery = " SELECT        o.ipaddress as ipaddress, o.lastlogon, ISNULL(i.name, o.ipaddress) AS name " & _
"FROM            onlineusers AS o LEFT OUTER JOIN " & _
                     "iplist AS i ON o.ipaddress = i.ipaddress " & _
"ORDER BY o.lastlogon DESC"
        ChatService.rebindGridView2(oQuery, gvUsers)

        'this will be executed every time any event happen on web page

        ' Bind GridView to current query & always store ur queery into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery
        'Response.Write(loadwishes())
       
        If (Not ClientScript.IsStartupScriptRegistered(Me.GetType(), "vinscript")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "vinscript", loadwishes())
        End If
       

        ' Request.Browser.Browser
        ' Session("myIP") = Request.UserHostAddress '+ Str(Now.TimeOfDay.Seconds * Rnd(30))

        ' End If
        If Not String.IsNullOrEmpty(Session("myIP")) Then '  If Not String.IsNullOrEmpty(Page.User.Identity.Name) Then
            hiddenAppPath.Text = Request.ServerVariables("SERVER_NAME") & ":" & Request.ServerVariables("SERVER_PORT") & Request.ApplicationPath()

            Dim csname As String = "CheckChatReq"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript
            If (Not cs.IsClientScriptBlockRegistered(cstype, csname)) Then
                Dim cstext As New StringBuilder()
                cstext.Append("var DelayInSeconds = 12;" & vbCrLf)
                cstext.Append("function InitCheckChatReq(strMyUserID) {" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function CheckChatReq(strMyUserID) {" & vbCrLf)
                cstext.Append("    ret = ChatService.CheckChatReq(strMyUserID, CheckChatReqOnComplete, CheckChatReqOnTimeout);" & vbCrLf)
                cstext.Append("    document.getElementById('" & hiddenMyUserID.ClientID & "').value = strMyUserID;" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function CheckChatReqOnComplete(strSenderUserID) {" & vbCrLf)  'this will listen for request so init =0 and open a popup
                cstext.Append("    if (strSenderUserID != """")" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        var popupWindow = null;" & vbCrLf)
                cstext.Append("        document.getElementById('" & hiddenSenderUserID.ClientID & "').value = strSenderUserID;" & vbCrLf)
                cstext.Append("   //     document.getElementById('ChatRequest').innerHTML = ""<p style=\""text-align: center;\"">""" & vbCrLf)
                cstext.Append("  //          + ""You have an incoming chat request from: '"" + strSenderUserID + ""'<br/><br/>""" & vbCrLf)
                cstext.Append("  //          + ""Would you like to accept?</p>"";" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
                cstext.Append("     $get('chatframe').src='http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append("      var modalPopupBehavior = $find('programmaticModalPopupBehaviorChatReq');" & vbCrLf)
                cstext.Append("      modalPopupBehavior.show();" & vbCrLf)
                cstext.Append(" //  redirect('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
                cstext.Append("  // window.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append("  // popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
                cstext.Append("   setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
                cstext.Append("   }" & vbCrLf)
                cstext.Append("     else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("        setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function vinModal( strOther) {" & vbCrLf)  'this will call other person window so init =1
                cstext.Append("        var popupWindow = null;" & vbCrLf)
                cstext.Append("        document.getElementById('" & hiddenSenderUserID.ClientID & "').value = strOther;" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
                cstext.Append("     $get('chatframe').src= 'chat.aspx?Usr=' +  strSenderUserID+ '&Init=1';" & vbCrLf)
                cstext.Append("      var modalPopupBehavior = $find('programmaticModalPopupBehaviorChatReq');" & vbCrLf)
                cstext.Append("      modalPopupBehavior.show();" & vbCrLf)
                cstext.Append(" //movePanel();" & vbCrLf)
                cstext.Append("  }" & vbCrLf)
                cstext.Append("var id = null; " & vbCrLf)
                cstext.Append("function movePanel() { " & vbCrLf)
                cstext.Append("  var pnl = $get('PanelChatRequest'); " & vbCrLf)
                cstext.Append(" if (pnl != null) { " & vbCrLf)
                cstext.Append("  pnl.style.top = '200'; " & vbCrLf)
                cstext.Append("  pnl.style.left =  '200'; } " & vbCrLf)
                cstext.Append(" id = setTimeout('movePanel();', 100);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append(" function stopMoving() { " & vbCrLf)
                cstext.Append(" clearTimeout(id);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function CheckChatReqOnTimeout(strSenderUserID) {" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function OnOk() {" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
                cstext.Append("  // var w = window.open();" & vbCrLf)
                cstext.Append("  // w.opener = null;" & vbCrLf)
                cstext.Append("  // w.document.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append("  // window.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append(" //   popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function OnCancel() {" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    ret = ChatService.SendNak(strMyUserID, strSenderUserID);" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
                cstext.Append("//stopMoving();" & vbCrLf)
                cstext.Append("  }" & vbCrLf)

                cs.RegisterClientScriptBlock(cstype, csname, cstext.ToString, True)
            End If

            ' Dim strScript As String = "InitCheckChatReq('" & HttpUtility.UrlEncode(Page.User.Identity.Name) & "');"
            Dim strScript As String = "InitCheckChatReq('" & Session("myIP") & "');"
            csname = "InitCheckChatReq"
            cs = Page.ClientScript
            If (Not cs.IsStartupScriptRegistered(cstype, csname)) Then
                cs.RegisterStartupScript(cstype, csname, strScript, True)
            End If

        End If
      

        'rebindGridView(Session("CurrentQuery"), gvCirculars)
        'rebindGridView(Session("CurrentQuery1"), gvArticles)
        rebindCachedGridView(Session("CurrentQuery"), gvCirculars, "gvCirculars")
        rebindCachedGridView(Session("CurrentQuery1"), gvArticles, "gvArticles")

    End Sub
    Private Function GetRSSFeed1(ByVal link As String, ByVal proxy As String, ByVal gridViewControl As GridView) As String

        'Create a WebRequest
        Dim rssReq As WebRequest = WebRequest.Create(link)

        'Create a Proxy
        Dim px As New WebProxy(proxy, True) 'proxy = 191.254.186.111:5678

        'Assign the proxy to the WebRequest
        rssReq.Proxy = px

        'Set the timeout in Seconds for the WebRequest
        rssReq.Timeout = 5000
        Try
            'Get the WebResponse
            Dim resp As WebResponse = rssReq.GetResponse()

            'Read the Response in a XMLTextReader

            Dim xtr As New XmlTextReader(resp.GetResponseStream())

            'Create a new DataSet
            Dim ds As New DataSet()

            'Read the Response into the DataSet
            ds.ReadXml(xtr, "rss/channel/item")

            'Bind the Results to the Repeater
            gridViewControl.DataSource = ds
            gridViewControl.DataBind()
            Return "1"
        Catch ex As Exception

            Return ex.ToString
        End Try
    End Function
    Private Function GetRSSFeed(ByVal link As String, ByVal proxy As String, ByVal gridViewControl As GridView, ByVal cachename As String) As String

       'called from timer
        Dim myxml As XmlDataSource = New XmlDataSource

        lbError.Visible = False
        If IsNothing(Cache.Item(cachename)) Then
            ' lbError.Text = "if cache is null then fetch"
            myxml = New XmlDataSource  'myxml is null so reset it
            myxml.DataFile = link
            myxml.XPath = "rss/channel/item"

            Try
                Cache.Insert(cachename, myxml, Nothing, Now.AddMinutes(30), TimeSpan.Zero)
                'nameof ur cache, datasource, null , no of minutes or hours to survive, tiespan
                lblQuotes.Text = "Getting from  " + cachename
                gridViewControl.DataSource = myxml
                gridViewControl.DataBind()
                myxml.CacheDuration = 10 * 60
                myxml.Dispose()
                Return "1"
            Catch ex As Exception
                'gvLiveNews.Visible = False
                Return "Unable to get Portion of Live News Feed from internet. Service shall be restored shortly."
            End Try
        Else
            lblQuotes.Text = "Getting from cache " + cachename
            myxml = CType(Cache.Item(cachename), XmlDataSource)
            gridViewControl.DataSource = myxml
            gridViewControl.DataBind()
            Return "1"
        End If
    End Function


    'Private Sub loadLiveNews()
    '    'called from timer
    '    XmlDataSource1.DataFile = "http://rss.news.yahoo.com/rss/india" 'vinservice.getDataSource
    '    XmlDataSource2.DataFile = "http://news.google.com/news?cf=all&ned=hi_in&hl=hi&output=rss" 'vinservice.getDataSource
    '    '   Dim gvDatasource As List(Of XmlDataSource) = {XmlDataSource1, XmlDataSource2}

    '    ' gvLiveNews.DataSource = {XmlDataSource1, XmlDataSource2}

    '    gvLiveNews.DataSource = XmlDataSource1
    '    gvLiveNews2.DataSource = XmlDataSource2
    '    imgLoad2.Visible = False

    '    Try
    '        lbError.Visible = False
    '        gvLiveNews.DataBind()
    '        gvLiveNews2.DataBind()

    '    Catch ex As Exception
    '        'gvLiveNews.Visible = False
    '        lbError.Visible = True
    '        lbError.Text = "Unable to get Portion of Live News Feed from internet. Service shall be restored shortly."
    '    End Try
    'End Sub
    
    
    Protected Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        '   loadLiveNews()

            GetRSSFeed("http://rss.accuweather.com/rss/liveweather_rss.asp?metric=1&locCode=ASI|IN|IN033|bhatwari", "191.254.186.111:5678", gvTemp, "gvTemp")

            GetRSSFeed("http://www.bseindia.com/sensex/xml-data/sensexrss.xml", "191.254.186.111:5678", gvBSE, "gvBSE")

            GetRSSFeed("http://rss.news.yahoo.com/rss/india", "191.254.186.111:5678", gvLiveNews, "gvLiveNews")

            If GetRSSFeed("http://news.google.com/news?cf=all&ned=hi_in&hl=hi&output=rss", "191.254.253.60:8080", gvLiveNews2, "gvLiveNews2") <> "1" Then
                lbError.Text = "Unable to get Portion of Live News Feed from internet. Service shall be restored shortly."
            End If

            Timer2.Enabled = False
       
    End Sub
    
    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ChatService As New ChatService
        ChatService.trackOnlineVisitor(Session("myIP"))
        ' rebindGridView2("select * from onlineusers", gvUsers)
        Dim oQuery = " SELECT        o.ipaddress as ipaddress, o.lastlogon, ISNULL(i.name, o.ipaddress) AS name " & _
"FROM            onlineusers AS o LEFT OUTER JOIN " & _
                       "iplist AS i ON o.ipaddress = i.ipaddress " & _
"ORDER BY o.lastlogon DESC"
        ChatService.rebindGridView2(oQuery, gvUsers)
    End Sub
   
    Protected Sub gvCirculars_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCirculars.PageIndexChanging
        If gvCirculars.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvCirculars.DataSource = SortDataTable(gvCirculars.DataSource, True)
            gvCirculars.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvCirculars.DataBind()
        End If
    End Sub
    Protected Sub gvCirculars_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCirculars.SelectedIndexChanged
        ' Bind current data
        gvCirculars.DataSource = SortDataTable(gvCirculars.DataSource, True)
        gvCirculars.PageIndex = Session("CurrentPage")
        gvCirculars.DataBind()

        ' Clear session variables
        Session("CurrentPage") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery") = Nothing

    End Sub

    Protected Sub gvArticles_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvArticles.PageIndexChanging
        If gvArticles.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvArticles.DataSource = SortDataTable(gvArticles.DataSource, True)
            gvArticles.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvArticles.DataBind()
        End If
    End Sub
    Protected Sub gvArticles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvArticles.SelectedIndexChanged
        ' Bind current data
        gvArticles.DataSource = SortDataTable(gvArticles.DataSource, True)
        gvArticles.PageIndex = Session("CurrentPage")
        gvArticles.DataBind()

        ' Clear session variables
        Session("CurrentPage") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery1") = Nothing

    End Sub

    Private Function loadwishes() As String
        Dim wishscript As String = "" & _
       " <script type='text/javascript'>" & _
        "var mygallery=new fadeSlideShow({" & _
        "wrapperid: 'fadeshow1'," & _
     "dimensions: [155, 110]," & _
      "imagearray: [ " & _
       " ['images/bday.jpg', '', '', 'B-Day Wishes']," & _
       getwishbday() & _
        " ['images/anniversary.jpg', '', '', 'Marriage Anniversary.']," & _
        getwishanniversary() & _
  "]," & _
 "displaymode: {type:'auto', pause:2500, cycles:0, wraparound:false}," & _
 "persist: false, " & _
 "fadeduration: 500, " & _
 "descreveal: 'always'," & _
 "togglerid: ''" & _
    "}) </script>"
        '" ['database/pics/p009383.gif', '', '', 'Sr. Engineer']," & _
        '        " ['database/pics/p009633.gif', '', '', 'Engineer']," & _
        '          " ['database/pics/p085525.gif', '', '', 'A Engineer']" & _


        ' lblName.Text = wishscript
        'getwishbday() & _
        Return (wishscript)

    End Function

    Private Function getwishbday() As String
        'implement cache
        If IsNothing(Cache.Item("bday")) Then

            Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
                Dim sqlComm As SqlCommand
                Dim sqlReader As SqlDataReader
                Dim dt As New DataTable()

                Dim i As Integer
                Dim emparray As String = ""
                Try
                    'connection.Close()
                    connection.Open()
                    sqlComm = New SqlCommand("select eid, fname, lname,  dob, designation from empdetail WHERE (MONTH(dob) = MONTH(GETDATE())) ORDER BY DAY(dob) ", connection)  ' fname + ' ' + lname AS name
                    '         sqlComm = New SqlCommand(" SELECT        e.eid, e.fname , e.lname , e.designation, e.dob, " & _
                    '" x.adate" & _
                    '" FROM            empdetail AS e INNER JOIN " & _
                    '"               empdetailx AS x ON e.eid = x.eid " & _
                    '"  where (MONTH(e.dob) = MONTH(GETDATE()) or MONTH(x.adate) = MONTH(GETDATE())) " & _
                    '           "ORDER BY DAY(e.dob)") '
                    sqlReader = sqlComm.ExecuteReader()
                    dt.Load(sqlReader)
                    i = dt.Rows.Count
                    ''Strings.Format(Session("name"), "capetalize")
                    If i > 0 Then
                        'capetalize the name.
                        Dim picpath As String
                        Dim j As Integer = 0
                        While j < i
                            picpath = "database/pics/p" + Trim(dt.Rows(j).Item("eid")) + ".gif"
                            If FileIO.FileSystem.FileExists(Server.MapPath("~/database/pics/") + "p" + Trim(dt.Rows(j).Item("eid")) + ".gif") Then
                                picpath = "database/pics/p" + Trim(dt.Rows(j).Item("eid")) + ".gif"
                            Else
                                picpath = "database/pics/default.gif"
                            End If
                            emparray = emparray + " ['" + picpath + "', 'departments.aspx?showemp=" + Trim(dt.Rows(j).Item("eid")) + "', '', '" + Str(Day(dt.Rows(j).Item("dob"))) + " " + MonthName(Month(dt.Rows(j).Item("dob"))) + "-" + UCase(Left(dt.Rows(j).Item("fname"), 1)) + ". " + UCase(Left(dt.Rows(j).Item("lname"), 1)) + LCase(Mid(dt.Rows(j).Item("lname"), 2)) + "']"

                            j = j + 1     'disabled for marriage anniversary
                            ' If j < i Then
                            emparray = emparray + "," & _
                                ""
                            'End If

                        End While
                        sqlComm.Dispose()
                        connection.Close()
                        Cache.Insert("bday", emparray, Nothing, Now.AddDays(7), TimeSpan.Zero)  ' make 7 days cache in server
                        getwishbday = emparray
                    ElseIf i = 0 Then  'no bday found
                        sqlComm.Dispose()
                        connection.Close()
                        Cache.Insert("bday", " ['database/pics/default.gif', '', '', 'No Birthdays this month']", Nothing, Now.AddDays(7), TimeSpan.Zero)
                        getwishbday = " ['database/pics/default.gif', '', '', 'No Birthdays this month']"
                    Else
                        sqlComm.Dispose()
                        connection.Close()
                        getwishbday = "Database not open " + i  
                    End If
                    sqlReader.Close()
                Catch e As Exception
                    'lblDebug.text = e.Message
                    connection.Close()
                    getwishbday = "Database does not open " + e.Message
                End Try
                connection.Close()

            End Using
        Else
            getwishbday = CType(Cache.Item("bday"), String)
            'lblQuotes.Text = "bday from cache"
        End If
    End Function
    Private Function getwishanniversary() As String
        If IsNothing(Cache.Item("anne")) Then
            Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
                Dim sqlComm As SqlCommand
                Dim sqlReader As SqlDataReader
                Dim dt As New DataTable()
                Dim i As Integer
                Dim emparray As String = ""
                Try
                    'connection.Close()
                    connection.Open()
                    '  sqlComm = New SqlCommand("select eid, fname, lname,  dob, designation from empdetail WHERE (MONTH(dob) = MONTH(GETDATE())) ORDER BY DAY(dob) ", connection)  ' fname + ' ' + lname AS name
                    sqlComm = New SqlCommand("  SELECT        e.eid, e.fname, e.lname, e.designation, x.adate" & _
         " FROM            empdetail AS e INNER JOIN" & _
                                "  empdetailx AS x ON e.eid = x.eid" & _
                    " WHERE(Month(x.adate) = Month(GETDATE()))" & _
         " ORDER BY DAY(x.adate)", connection)

                    sqlReader = sqlComm.ExecuteReader()
                    dt.Load(sqlReader)
                    sqlComm.Dispose()
                    i = dt.Rows.Count
                    ''Strings.Format(Session("name"), "capetalize")
                    If i > 0 Then
                        'capetalize the name.
                        Dim picpath As String
                        Dim j As Integer = 0
                        While j < i
                            picpath = "database/pics/p" + Trim(dt.Rows(j).Item("eid")) + ".gif"
                            If FileIO.FileSystem.FileExists(Server.MapPath("~/database/pics/") + "p" + Trim(dt.Rows(j).Item("eid")) + ".gif") Then
                                picpath = "database/pics/p" + Trim(dt.Rows(j).Item("eid")) + ".gif"
                            Else
                                picpath = "database/pics/default.gif"
                            End If
                            emparray = emparray + " ['" + picpath + "', 'departments.aspx?showemp=" + Trim(dt.Rows(j).Item("eid")) + "', '', '" + Str(Day(dt.Rows(j).Item("adate"))) + " " + MonthName(Month(dt.Rows(j).Item("adate"))) + "-" + UCase(Left(dt.Rows(j).Item("fname"), 1)) + ". " + UCase(Left(dt.Rows(j).Item("lname"), 1)) + LCase(Mid(dt.Rows(j).Item("lname"), 2)) + "']"

                            j = j + 1
                            If j < i Then
                                emparray = emparray + "," & _
                                    ""
                            End If

                        End While

                        connection.Close()
                        Cache.Insert("anne", emparray, Nothing, Now.AddDays(7), TimeSpan.Zero)  ' make 7 days cache in server
                        getwishanniversary = emparray

                    ElseIf i = 0 Then  'no anneversary found
                        sqlComm.Dispose()
                        connection.Close()
                        Cache.Insert("anne", " ['database/pics/default.gif', '', '', 'No Anniversary this month']", Nothing, Now.AddDays(7), TimeSpan.Zero)
                        getwishanniversary = " ['database/pics/default.gif', '', '', 'No Anniversary this month']"
                    Else
                        sqlComm.Dispose()
                        connection.Close()
                        getwishanniversary = "Database not open " + i
                    End If
                    sqlReader.Close()
                Catch e As Exception
                    'lblDebug.text = e.Message
                    connection.Close()
                    getwishanniversary = "Database does not open " + e.Message
                End Try
                connection.Close()
            End Using
        Else
            getwishanniversary = CType(Cache.Item("anne"), String)
        End If
    End Function
    Private Function getQuotes() As String
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim i = CInt(Int(42 * Rnd()) + 1) ' Generate random value between 1 and
            Dim quote As String

            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("select * from quotes WHERE id =" + Str(i), connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                If dt.Rows.Count > 0 Then
                    quote = dt.Rows(0).Item("quote") + "- <i>" + dt.Rows(0).Item("qby") + "</i>"
                    connection.Close()
                    getQuotes = quote

                Else
                    connection.Close()
                    getQuotes = "Database not accese " + i
                End If
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                getQuotes = "Database not open " + Str(i) + e.Message
            End Try
            connection.Close()
        End Using
    End Function
    Private Function trackVisitor(ByVal ipaddress As String) As String

        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim count As String
            Try
                'connection.Close()
                connection.Open()
                sqlComm = New SqlCommand("select * from visitors WHERE (ipaddress = '" + ipaddress + "') ", connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                sqlReader.Close()
                If dt.Rows.Count = 1 Then    ' if ip exists
                    dt.Dispose()

                    connection.Close()
                    connection.Open()
                    sqlComm = New SqlCommand("UPDATE visitors set counter = counter + 1 WHERE (ipaddress = '" + ipaddress + "') ", connection)  ' fname + ' ' + lname AS name
                    sqlReader = sqlComm.ExecuteReader()
                    sqlReader.Close()
                    sqlComm.Dispose()
                    connection.Close()
                    dt.Reset()
                    dt.Dispose()

                    connection.Open()
                    sqlComm = New SqlCommand("select ipaddress, counter from visitors WHERE (ipaddress = '" + ipaddress + "') ", connection)
                    sqlReader = sqlComm.ExecuteReader()
                    dt.Load(sqlReader)
                    count = "<font color='#9218AB'>" + Str(dt.Rows(0).Item("counter")) + "</font>"
                    sqlComm.Dispose()
                    sqlReader.Close()
                    connection.Close()
                    dt.Reset()
                    dt.Dispose()


                    ' Dim dt1 As New DataTable()
                    connection.Open()
                    sqlComm = New SqlCommand("SELECT SUM(counter) AS counter FROM visitors", connection)
                    sqlReader = sqlComm.ExecuteReader()
                    dt.Load(sqlReader)
                    sqlReader.Close()
                    count = count + "<br/> Total Hits : <font color='#9218AB'>" + Str(240000 + Int(dt.Rows(0).Item("counter"))) + "</font>" '240000 is hits of last 4 years.
                    sqlComm.Dispose()
                    connection.Close()
                    dt.Reset()
                    dt.Dispose()
                    Return count
                Else    'insert ip
                    connection.Close()
                    connection.Open()
                    sqlComm = New SqlCommand("Insert Into visitors ( ipaddress, counter) " & _
           " VALUES  ( '" + ipaddress + "' , 1 ) ", connection)
                    sqlReader = sqlComm.ExecuteReader()
                    sqlComm.Dispose()
                    connection.Close()
                    sqlReader.Close()
                    Return "1"
                End If


            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return e.Message
            End Try
            connection.Close()
        End Using
    End Function

    Protected Sub gvUsers_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvUsers.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        ' Retrieve the row that contains the button clicked 
        ' by the user from the Rows collection.
        Dim row As GridViewRow = gvUsers.Rows(index)

        Response.Redirect("~/Chat.aspx?Usr=" + Server.HtmlDecode(row.Cells(1).Text) + "&amp;Init=1")


    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ModalPopupExtender1.Hide()
    End Sub
    Protected Sub btnok2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnok2.Click
        ModalPopupExtender2.Hide()
    End Sub

    Protected Sub upNet_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles upNet.Load
        lblNet.Text = "Sending Garbage Data.. Updating... <img src=images/loaderbar.gif /> <br />" & _
            "<b><font color=blue> Web Server : </font></b> <font color=green> Working Fine </font>" & _
           "<br /><b><font color=blue> NTPC Mail: </font></b>" + showPing("191.254.186.230") & _
           "<br /><b><font color=blue> SAP-ESS : </font></b>" + showPing("10.2.0.112") & _
           "<br /><b><font color=blue> SAP-R3 : </font></b>" + showPing("10.2.0.54") & _
           "<br /><b><font color=blue> BSNL Broadband Internet: </font></b><font color=red>Unable to get Status </font> If not working then you are requested to use common IT internet kiosk." & _
           "<br /><b><font color=blue> MPLS Link (Bhatwari): </font></b>" + showPing("172.29.176.229") & _
           "<br /><b><font color=blue> MPLS Link (Dehradun): </font></b>" + showPing("172.29.176.230") & _
           "<br /><b><font color=blue> MPLS Link (Hyderabad): </font></b>" + showPing("10.2.0.38") & _
           "<br /><b><font color=blue> MPLS Link (Noida): </font></b>" + showPing("10.0.0.48") & _
           "<br /><b><font color=blue> VSAT Noida: </font></b>" + showPing("191.254.125.133") & _
           "<br /><br /><center><font color=blue> The screen refreshes each 10 second. Please do have patience till services get restored. We are already working on it. </font></center>"
    End Sub
      


    Private Function showPing(ByVal ipaddress As String) As String
        Try
            Dim ping As Ping = New Ping
            Dim garbage As Byte()
            Dim enc As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding
            garbage = enc.GetBytes("vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                   "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                    "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                     "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                      "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                       "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                        "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                         "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                          "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                           "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown" & _
                                            "vinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdownvinodkotiyaworkinginntpclimited hasdesignedthismoduletogetthepingresponceofvariousserverandroutersandapplicationstogettherealtimedataandtosatisfythisbloodyuserswhofrequentlyusedtocallmewheneversomethinggetsdown")

            ' garbage is used to get responce time of more than 1 ms
            Dim pingreply As PingReply = ping.Send(ipaddress, 2048, garbage)

            If Int(pingreply.RoundtripTime.ToString) > 0 Then
                Return " <font color=green>Working Fine </font> with Responce Time of <b>" + pingreply.RoundtripTime.ToString + "</b> mili second for " + ipaddress
            Else
                Return "<font color=red>Currently Down </font>Due to network problem. Please Have Patience. Restoration work initiated. " + pingreply.RoundtripTime.ToString + " mili second for " + ipaddress
            End If

        Catch e As Exception
            Return e.Message
        End Try
    End Function
    Private Sub rebindCachedGridView(ByVal query As String, ByVal gridViewControl As GridView, ByVal cachename As String)
        'Binds Paging/Sorting GridView with data from the specified query
        ' Bind GridView to current query & always store ur query into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery
        ' Dim dt As DataTable = Nothing 'CType(Cache.Item(cachename), DataTable) '= New DataTable

        Dim dt As New DataTable
        'lbError.Visible = True

        '  dt = CType(Cache.Item(cachename), DataTable)

        If IsNothing(Cache.Item(cachename)) Then
            Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
                Dim sqlComm As SqlCommand
                Dim sqlReader As SqlDataReader

                Dim dataTableRowCount As Integer
                Try
                    'connection.Close()
                    connection.Open()
                    sqlComm = New SqlCommand(query, connection)
                    sqlReader = sqlComm.ExecuteReader()
                    dt.Load(sqlReader)
                    sqlComm.Dispose()
                    dataTableRowCount = dt.Rows.Count

                    If dataTableRowCount > 0 Then
                        '   Dim vincache As Cache
                        '  vincache.Insert("cache" + gridName, dt, vbNull, Now.AddMinutes(10), TimeSpan.Zero)
                        Cache.Insert(cachename, dt, Nothing, Now.AddMinutes(10), TimeSpan.Zero)
                        gridViewControl.DataSource = dt
                        gridViewControl.DataBind()
                        '   lbError.Text = "not from cache"
                    End If
                    sqlReader.Close()
                Catch e As Exception
                    lbError.Text = e.Message

                    connection.Close()
                End Try


                connection.Close()
            End Using
        Else
            '  lbError.Text = "Getting from cache"
            dt = CType(Cache.Item(cachename), DataTable)

            gridViewControl.DataSource = dt
            gridViewControl.DataBind()
        End If
    End Sub
End Class
