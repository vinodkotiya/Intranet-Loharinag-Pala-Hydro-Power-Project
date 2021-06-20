Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn
Partial Class test
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If InStr(Session("admin"), "vin1") > 0 Then
            If (InStr(txtQuery.Text, "update") > 0 Or InStr(txtQuery.Text, "delete") > 0 Or InStr(txtQuery.Text, "insert") > 0) Then
                txtQuery.Text = insertRecord(txtQuery.Text)
            Else
                txtQuery.Text = " query invalid " & Session("admin") + Str(InStr(txtQuery.Text, "delete"))
            End If
       
        else If InStr(Session("admin"), "vin2") > 0 Then
            If (InStr(txtQuery.Text, "update") > 0 Or InStr(txtQuery.Text, "delete") > 0 Or InStr(txtQuery.Text, "insert") > 0) Then
                txtQuery.Text = executeQuerydb2(txtQuery.Text)
            Else
                txtQuery.Text = " query invalid " & Session("admin") + Str(InStr(txtQuery.Text, "delete"))
            End If
        ElseIf InStr(Session("admin"), "vin3") > 0 Then
            If (InStr(txtQuery.Text, "update") > 0 Or InStr(txtQuery.Text, "delete") > 0 Or InStr(txtQuery.Text, "insert") > 0) Then
                txtQuery.Text = executeQuerydb3(txtQuery.Text)
            Else
                txtQuery.Text = " query invalid " & Session("admin") + Str(InStr(txtQuery.Text, "delete"))
            End If
        Else
            txtQuery.Text = "provide admin parameter first for db1 or second for db2 " + Str(InStr(Session("admin"), "vin2"))
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("admin") = Request.Params("admin")
    End Sub
End Class
