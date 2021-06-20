Imports Microsoft.VisualBasic
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class vinservice
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function getDataSource() As String
        '"http://rss.news.yahoo.com/rss/topstories"   'http://news.google.com/news?cf=all&ned=hi_in&hl=hi&output=rss
        Return "http://rss.news.yahoo.com/rss/iran"

    End Function

End Class
