Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn
Imports System.Net
Imports System.Net.NetworkInformation
Partial Class test
    Inherits System.Web.UI.Page

    
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPing.Text = showPing(Request.Params("ipaddress"))
    End Sub
    Private Function showPing(ByVal ipaddress As String) As String
        Try
            Dim ping As Ping = New Ping
            Dim pingreply As PingReply = ping.Send(ipaddress)
            Return "roundtrip time: " + pingreply.RoundtripTime.ToString
        Catch e As Exception
            Return e.Message
        End Try

    End Function
End Class
