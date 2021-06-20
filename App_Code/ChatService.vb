' ASPDOTNETAJAXIM - Copyright 2010 Vinod Kotiya
' http://vinodkotiya.blogspot.com

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data


<WebService(Namespace:="http://www.vinodkotiya.com/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class ChatService
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Sub rebindGridView2(ByVal query As String, ByVal gridViewControl As GridView)
        'Binds Paging/Sorting GridView with data from the specified query
        ' Bind GridView to current query & always store ur query into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery

        Using connection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)

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
    <WebMethod()> _
    Public Function trackOnlineVisitor(ByVal ipaddress As String) As String

        Using connection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()

            Try

                connection.Open()

                sqlComm = New SqlCommand("select * from onlineusers WHERE (ipaddress = '" + ipaddress + "') ", connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlReader.Close()
                If dt.Rows.Count = 1 Then    ' if ip exists
                    dt.Dispose()
                    sqlComm.Dispose()
                    'connection.Close()
                    'connection.Open()
                    sqlComm = New SqlCommand("UPDATE onlineusers set lastlogon = '" + Now.TimeOfDay().ToString + "' WHERE (ipaddress = '" + ipaddress + "') ", connection)  ' fname + ' ' + lname AS name
                    sqlReader = sqlComm.ExecuteReader()
                    sqlComm.Dispose()
                    sqlReader.Close()
                    'connection.Close()

                    ' now delete idle users having more then 5 minutes or having -ve value of yesterdays

                    'connection.Open()
                    sqlComm = New SqlCommand("DELETE FROM onlineusers WHERE (DATEDIFF(mi, lastlogon, CONVERT(VARCHAR(8), GETDATE(), 108)) > 1  or  DATEDIFF(mi, lastlogon, CONVERT(VARCHAR(8), GETDATE(), 108)) < 0)", connection)  ' delete who are ideal more than 1 min
                    'SELECT        DATEDIFF(mi, lastlogon, CONVERT(VARCHAR(8), GETDATE(), 108)) AS Expr1 FROM            onlineusers
                    sqlReader = sqlComm.ExecuteReader()
                    sqlComm.Dispose()
                    sqlReader.Close()
                    connection.Close()
                    Return "updated"

                Else    'insert ip
                    'connection.Close()
                    'connection.Open()
                    sqlComm = New SqlCommand("Insert Into onlineusers ( ipaddress, lastlogon) " & _
           " VALUES  ( '" + ipaddress + "' , '" + Now.TimeOfDay().ToString + "' ) ", connection)
                    sqlReader = sqlComm.ExecuteReader()
                    sqlComm.Dispose()
                    connection.Close()
                    sqlReader.Close()
                    Return "new insertion"
                End If


            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return e.Message
            End Try
            connection.Close()
        End Using

    End Function
    <WebMethod()> _
    Public Function GetMessages(ByVal strFromUserID As String, ByVal strToUserID As String) As String
        Dim blnSucess As Boolean = False
        Dim strMessage As String
        Dim dDateSent As Date

        strMessage = ""

        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            conn.Open()

            Dim cmd As SqlCommand

            'Dim MemUser As MembershipUser
            Dim strFromUserGUID As String
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strFromUserID))
            'strFromUserGUID = MemUser.ProviderUserKey.ToString
            Dim strToUserGUID As String
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strToUserID))
            'strToUserGUID = MemUser.ProviderUserKey.ToString

            strFromUserGUID = strFromUserID
            strToUserGUID = strToUserID

            cmd = New SqlCommand("SELECT TOP(1) Message, DateSent FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID) ORDER BY DateSent DESC", conn)
            cmd.Parameters.AddWithValue("@SenderUserID", strToUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strFromUserGUID)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                dDateSent = reader("DateSent")
                'If dDateSent > DateAdd(DateInterval.Minute, -5, DateTime.Now) Then
                strMessage = reader("Message")
                blnSucess = True
                'End If
            End While
            reader.Close()
            cmd.Dispose()

            If blnSucess Then
                cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
                cmd.Parameters.AddWithValue("@SenderUserID", strToUserGUID)
                cmd.Parameters.AddWithValue("@RecipientUserID", strFromUserGUID)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
            conn.Close()

        End Using
        Return strMessage
    End Function
    <WebMethod()> _
    Public Function SendMessage(ByVal strSenderUserID As String, ByVal strRecipientUserID As String, ByVal strMessage As String) As String
        Dim blnSucess As Boolean = False
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)

            conn.Open()

            Dim cmd As SqlCommand

            'Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            'strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            'strSenderUserGUID = MemUser.ProviderUserKey.ToString

            strRecipientUserGUID = strRecipientUserID
            strSenderUserGUID = strSenderUserID

            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO IMChats(RecipientUserID, SenderUserID, Message, DateSent) VALUES (@RecipientUserID, @SenderUserID, @Message, @DateSent)"
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@Message", strMessage)
            cmd.Parameters.AddWithValue("@DateSent", DateTime.Now)

            cmd.ExecuteNonQuery()
            blnSucess = True
            cmd.Dispose()
            conn.Close()
        End Using
        Return blnSucess
    End Function

    'ENQ = chr(5)                            # Request to send
    'EOT = chr(4)                            # Ready to receive
    'ACK = chr(6)                            # Correct reception
    'NAK = chr(21)                           # Incorrect reception
    '////////////////////////////////
    '// Sender init chat
    '////////////////////////////////
    '// Sender ENQ     Wait 4 ACK
    '// Recip  ACK ENQ Wait 4 ACK ACK
    '// Sender ACK ACK Wait 4 EOT
    '// Recip  EOT
    '////////////////////////////////
    '// Recip wait 4 chat
    '////////////////////////////////
    '// Recip  ACK ENQ Wait 4 ACK
    '// Sender ACK ACK Wait 4 EOT
    '// Recip  EOT

    <WebMethod()> _
    Public Function CheckChatReq(ByVal strMyUserID As String) As String
        Dim strSenderUserID, strMessage As String
        Dim dDateSent As Date
        strSenderUserID = ""
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            conn.Open()

            Dim cmd As SqlCommand

            Dim strMyUserGUID As String = ""
            Dim strSenderUserGUID As String = ""
            'Dim MemUser As MembershipUser = Membership.GetUser(HttpUtility.UrlDecode(strMyUserID))
            'strMyUserGUID = MemUser.ProviderUserKey.ToString
            strMyUserGUID = strMyUserID


            cmd = New SqlCommand("SELECT TOP(1) SenderUserID, Message, DateSent FROM [IMChats] WHERE ([RecipientUserID] = @RecipientUserID) ORDER BY DateSent DESC", conn)
            cmd.Parameters.AddWithValue("@RecipientUserID", strMyUserGUID)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                dDateSent = reader("DateSent")
                'If dDateSent > DateAdd(DateInterval.Minute, -5, DateTime.Now) Then
                strMessage = reader("Message")
                ' ENQ
                If strMessage = "~::::=[(HANDSHAKE)]=::::~[ENQ]" Then
                    strSenderUserGUID = reader("SenderUserID").ToString
                    'strSenderUserID = Membership.GetUser(New Guid(strSenderUserGUID)).UserName
                    strSenderUserID = strSenderUserGUID
                    'End If
                End If
            End While
            reader.Close()
            cmd.Dispose()

            If Not String.IsNullOrEmpty(strSenderUserGUID) Then
                cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
                cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
                cmd.Parameters.AddWithValue("@RecipientUserID", strMyUserGUID)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
            conn.Close()

        End Using
        Return strSenderUserID
    End Function
    
    <WebMethod()> _
    Public Function SendChatReq(ByVal strSenderUserID As String, ByVal strRecipientUserID As String) As Boolean
        Dim blnSucess As Boolean = False
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)

            conn.Open()

            Dim cmd As SqlCommand

            ' Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String
            ' MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            ' strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String
            ' MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            ' strSenderUserGUID = MemUser.ProviderUserKey.ToString
            strRecipientUserGUID = strRecipientUserID
            strSenderUserGUID = strSenderUserID

            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @RecipientUserID AND [RecipientUserID] = @SenderUserID)"
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO IMChats(RecipientUserID, SenderUserID, Message, DateSent) VALUES (@RecipientUserID, @SenderUserID, @Message, @DateSent)"
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            ' ENQ
            cmd.Parameters.AddWithValue("@Message", "~::::=[(HANDSHAKE)]=::::~[ENQ]")
            cmd.Parameters.AddWithValue("@DateSent", DateTime.Now)

            cmd.ExecuteNonQuery()
            blnSucess = True
            cmd.Dispose()
            conn.Close()
        End Using
        Return blnSucess
    End Function
    <WebMethod()> _
    Public Function ChatCleanUpAll(ByVal strMyUserID As String) As String
        Dim blnSucess As Boolean = False
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            conn.Open()

            Dim cmd As SqlCommand

            Dim strMyUserGUID As String
            ' Dim MemUser As MembershipUser = Membership.GetUser(HttpUtility.UrlDecode(strMyUserID))
            ' strMyUserGUID = MemUser.ProviderUserKey.ToString
            strMyUserGUID = strMyUserID

            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([RecipientUserID] = @RecipientUserID)"
            cmd.Parameters.AddWithValue("@RecipientUserID", strMyUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            blnSucess = True
        End Using
        Return blnSucess
    End Function
    <WebMethod()> _
    Public Function CleanUp(ByVal strMyUserID As String, ByVal strSenderUserID As String, ByVal blnSendEOT As Boolean) As Boolean
        Dim blnSucess As Boolean = False
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            conn.Open()

            Dim cmd As SqlCommand

            Dim strMyUserGUID As String
            '    Dim MemUser As MembershipUser = Membership.GetUser(HttpUtility.UrlDecode(strMyUserID))
            ' strMyUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String
            '  MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            '   strSenderUserGUID = MemUser.ProviderUserKey.ToString
            strMyUserGUID = strMyUserID
            strSenderUserGUID = strSenderUserID

            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
            cmd.Parameters.AddWithValue("@RecipientUserID", strMyUserGUID)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            If blnSendEOT Then
                cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO IMChats(RecipientUserID, SenderUserID, Message, DateSent) VALUES (@RecipientUserID, @SenderUserID, @Message, @DateSent)"
                cmd.Parameters.AddWithValue("@RecipientUserID", strSenderUserGUID)
                cmd.Parameters.AddWithValue("@SenderUserID", strMyUserGUID)
                ' EOT
                cmd.Parameters.AddWithValue("@Message", "~::::=[(HANDSHAKE)]=::::~[EOT]")
                cmd.Parameters.AddWithValue("@DateSent", DateTime.Now)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
            conn.Close()
            blnSucess = True

        End Using
        Return blnSucess

    End Function
    <WebMethod()> _
    Public Function SendNak(ByVal strSenderUserID As String, ByVal strRecipientUserID As String) As Boolean
        Dim blnSucess As Boolean = False
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)

            conn.Open()

            Dim cmd As SqlCommand

            '  Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String = strRecipientUserID
            '  MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            ' strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String = strSenderUserID
            ' MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            ' strSenderUserGUID = MemUser.ProviderUserKey.ToString

            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO IMChats(RecipientUserID, SenderUserID, Message, DateSent) VALUES (@RecipientUserID, @SenderUserID, @Message, @DateSent)"
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            ' NAK
            cmd.Parameters.AddWithValue("@Message", "~::::=[(HANDSHAKE)]=::::~[NAK]")
            cmd.Parameters.AddWithValue("@DateSent", DateTime.Now)

            cmd.ExecuteNonQuery()
            blnSucess = True
            cmd.Dispose()
            conn.Close()
        End Using
        Return blnSucess
    End Function
    <WebMethod()> _
    Public Function SendAck(ByVal strSenderUserID As String, ByVal strRecipientUserID As String) As Boolean
        Dim blnSucess As Boolean = False
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)

            conn.Open()

            Dim cmd As SqlCommand

            ' Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String = strRecipientUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            'strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String = strSenderUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            'strSenderUserGUID = MemUser.ProviderUserKey.ToString

            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO IMChats(RecipientUserID, SenderUserID, Message, DateSent) VALUES (@RecipientUserID, @SenderUserID, @Message, @DateSent)"
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            ' ACK
            cmd.Parameters.AddWithValue("@Message", "~::::=[(HANDSHAKE)]=::::~[ACK]")
            cmd.Parameters.AddWithValue("@DateSent", DateTime.Now)

            cmd.ExecuteNonQuery()
            blnSucess = True
            cmd.Dispose()
            conn.Close()
        End Using
        Return blnSucess
    End Function
    <WebMethod()> _
    Public Function GetAck(ByVal strRecipientUserID As String, ByVal strSenderUserID As String) As Boolean
        Dim blnSucess As Boolean = False
        Dim strMessage As String
        Dim dDateSent As Date

        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            conn.Open()

            Dim cmd As SqlCommand

            '  Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String = strRecipientUserID
            ' MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            'strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String = strSenderUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            'strSenderUserGUID = MemUser.ProviderUserKey.ToString

            cmd = New SqlCommand("SELECT TOP(1) Message, DateSent FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID) ORDER BY DateSent DESC", conn)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                dDateSent = reader("DateSent")
                'If dDateSent > DateAdd(DateInterval.Minute, -5, DateTime.Now) Then
                strMessage = reader("Message")
                ' ACK
                If strMessage = "~::::=[(HANDSHAKE)]=::::~[ACK]" Then
                    blnSucess = True
                    'End If
                End If
            End While
            reader.Close()
            cmd.Dispose()

            If blnSucess Then
                cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
                cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
                cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
            conn.Close()

        End Using
        Return blnSucess
    End Function
    <WebMethod()> _
    Public Function GetNak(ByVal strRecipientUserID As String, ByVal strSenderUserID As String) As Boolean
        Dim blnSucess As Boolean = False
        Dim strMessage As String
        Dim dDateSent As Date

        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            conn.Open()

            Dim cmd As SqlCommand

            '  Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String = strRecipientUserID
            ' MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            ' strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String = strSenderUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            'strSenderUserGUID = MemUser.ProviderUserKey.ToString

            cmd = New SqlCommand("SELECT TOP(1) Message, DateSent FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID) ORDER BY DateSent DESC", conn)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                dDateSent = reader("DateSent")
                'If dDateSent > DateAdd(DateInterval.Minute, -5, DateTime.Now) Then
                strMessage = reader("Message")
                ' NAK
                If strMessage = "~::::=[(HANDSHAKE)]=::::~[NAK]" Then
                    blnSucess = True
                    'End If
                End If
            End While
            reader.Close()
            cmd.Dispose()

            If blnSucess Then
                cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
                cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
                cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
            conn.Close()

        End Using
        Return blnSucess
    End Function
    <WebMethod()> _
    Public Function SendEot(ByVal strSenderUserID As String, ByVal strRecipientUserID As String) As Boolean
        Dim blnSucess As Boolean = False
        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)

            conn.Open()

            Dim cmd As SqlCommand

            ' Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String = strRecipientUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            'strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String = strSenderUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            'strSenderUserGUID = MemUser.ProviderUserKey.ToString

            cmd = conn.CreateCommand()
            cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @RecipientUserID AND [RecipientUserID] = @SenderUserID)"
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = conn.CreateCommand()
            cmd.CommandText = "INSERT INTO IMChats(RecipientUserID, SenderUserID, Message, DateSent) VALUES (@RecipientUserID, @SenderUserID, @Message, @DateSent)"
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            ' EOT
            cmd.Parameters.AddWithValue("@Message", "~::::=[(HANDSHAKE)]=::::~[EOT]")
            cmd.Parameters.AddWithValue("@DateSent", DateTime.Now)

            cmd.ExecuteNonQuery()
            blnSucess = True
            cmd.Dispose()
            conn.Close()
        End Using
        Return blnSucess
    End Function
    <WebMethod()> _
    Public Function GetEot(ByVal strRecipientUserID As String, ByVal strSenderUserID As String) As Boolean
        Dim blnSucess As Boolean = False
        Dim strMessage As String
        Dim dDateSent As Date

        Using conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
            conn.Open()

            Dim cmd As SqlCommand

            ' Dim MemUser As MembershipUser
            Dim strRecipientUserGUID As String = strRecipientUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strRecipientUserID))
            'strRecipientUserGUID = MemUser.ProviderUserKey.ToString
            Dim strSenderUserGUID As String = strSenderUserID
            'MemUser = Membership.GetUser(HttpUtility.UrlDecode(strSenderUserID))
            'strSenderUserGUID = MemUser.ProviderUserKey.ToString

            cmd = New SqlCommand("SELECT TOP(1) Message, DateSent FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID) ORDER BY DateSent DESC", conn)
            cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
            cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read()
                dDateSent = reader("DateSent")
                'If dDateSent > DateAdd(DateInterval.Minute, -5, DateTime.Now) Then
                strMessage = reader("Message")
                ' EOT
                If strMessage = "~::::=[(HANDSHAKE)]=::::~[EOT]" Then
                    blnSucess = True
                    'End If
                End If
            End While
            reader.Close()
            cmd.Dispose()

            If blnSucess Then
                cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM [IMChats] WHERE ([SenderUserID] = @SenderUserID AND [RecipientUserID] = @RecipientUserID)"
                cmd.Parameters.AddWithValue("@SenderUserID", strSenderUserGUID)
                cmd.Parameters.AddWithValue("@RecipientUserID", strRecipientUserGUID)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
            conn.Close()

        End Using
        Return blnSucess
    End Function

End Class
