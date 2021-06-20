
Partial Class livenews
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim vinservice As New vinservice
        'XmlDataSource1.DataFile = vinservice.getDataSource
        'gvLiveNews.DataSource = XmlDataSource1

        'Try
        '    lbError.Visible = False
        '    gvLiveNews.DataBind()
        'Catch ex As Exception
        '    gvLiveNews.Visible = False
        '    lbError.Visible = True
        '    lbError.Text = "Unable to get Live News Feed from internet. Service shall be restored shortly. Sorry for inconvenience."
        'End Try


    End Sub
    Protected Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        loadLiveNews("http://news.google.com/news?cf=all&ned=hi_in&hl=hi&output=rss", gvln1)
        loadLiveNews("http://rss.news.yahoo.com/rss/india", gvln2)
        'lbError.Text = "in timer"
        Timer2.Enabled = False

    End Sub
    Private Sub loadLiveNews(ByVal url As String, ByVal gvLiveNews As GridView)
        XmlDataSource1.DataFile = url '"" 'vinservice.getDataSource
        gvLiveNews.DataSource = XmlDataSource1
        imgLoad2.Visible = False
        Try
            lbError.Visible = False
            gvLiveNews.DataBind()
        Catch ex As Exception
            gvLiveNews.Visible = False
            lbError.Visible = True
            lbError.Text = "Unable to get Live News Feed from internet. Service shall be restored shortly. Sorry for inconvenience."
        End Try
    End Sub
End Class
