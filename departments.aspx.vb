Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("myIP") = Request.UserHostAddress   ' for LAN/WAN   or
        'Session("myIP") = Request.UserHostAddress + Request.Browser.Browser  'for single PC
        If Not Page.IsPostBack Then
            'this will be executed only first time any event happen on web page
            ' Clear user paging/sort
            Session("CurrentPage") = 0
            Session("SortExpression") = Nothing
            GridViewSortDirection = "ASC"
            ' Set current query
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
            " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo , x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
            " FROM            empdetail AS e INNER JOIN " & _
            "               empdetailx AS x ON e.eid = x.eid " & _
                       "ORDER BY e.grade DESC"  '"  WHERE        (e.eid = '009383') " & _

        End If
        'this will be executed every time any event happen on web page
        ''page parameter inputs.. "requestedpage"

        'kisi page me session expire ho gaya hai.. login kara ke wapas bhejne ke liye
        Session("requestedpage") = Request.Params("requestedpage")

        If Request.Params("signout") = 1 Then
            clearsession()
            Response.Redirect("login.aspx")
        End If
        lblName.Text = "Guest: " + Request.UserHostAddress

       

        Dim frame1 As HtmlControl = CType(Me.FindControl("iframe1"), HtmlControl)
        Dim frame2 As HtmlControl = CType(Me.FindControl("iframe2"), HtmlControl)

        If Not String.IsNullOrEmpty(Request.Params("dept")) Then
            lblDepLink.Visible = True
            frame1.Visible = True
            frame2.Visible = True
            lblActivity.Visible = True
        Else
            lblDepLink.Visible = False
        End If

        If UCase(Request.Params("dept")) = "IT" Then
            lblDepLink.Text = "Important Links from IT Dept"
            frame1.Attributes("src") = "dept/it/link.html"
            frame2.Attributes("src") = "dept/it/it.html"

            'Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='IT' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
            " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
            " FROM            empdetail AS e INNER JOIN " & _
            "               empdetailx AS x ON e.eid = x.eid " & _
            "  WHERE        (dept='IT')" & _
                       "ORDER BY e.grade DESC"  '
        ElseIf UCase(Request.Params("dept")) = "HR" Then
            lblDepLink.Text = "Important Links from HR Dept"
            'Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='HR' or dept='PUB. RELN.' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
            " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
            " FROM            empdetail AS e INNER JOIN " & _
            "               empdetailx AS x ON e.eid = x.eid " & _
            "  WHERE        (dept='HR' or dept='PUB. RELN.')" & _
                       "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/hr/link.html"
            frame2.Attributes("src") = "dept/hr/hr.html"
        ElseIf UCase(Request.Params("dept")) = "R&R" Then
            lblDepLink.Text = "Important Links from R & R Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='R & R' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
           " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
           " FROM            empdetail AS e INNER JOIN " & _
           "               empdetailx AS x ON e.eid = x.eid " & _
           "  WHERE        (dept='R & R')" & _
                      "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/rnr/link.html"
            frame2.Attributes("src") = "dept/rnr/rnr.html"
        ElseIf UCase(Request.Params("dept")) = "FQA" Then
            lblDepLink.Text = "Important Links from FQA Dept"
            'Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='FQA' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
           " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
           " FROM            empdetail AS e INNER JOIN " & _
           "               empdetailx AS x ON e.eid = x.eid " & _
           "  WHERE        (dept='FQA')" & _
                      "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/fqa/link.html"
            frame2.Attributes("src") = "dept/fqa/fqa.html"
        ElseIf UCase(Request.Params("dept")) = "FINANCE" Then
            lblDepLink.Text = "Important Links from FINANCE Dept"
            'Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='FINANCE' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
           " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
           " FROM            empdetail AS e INNER JOIN " & _
           "               empdetailx AS x ON e.eid = x.eid " & _
           "  WHERE        (dept='FINANCE')" & _
                      "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/fna/link.html"
            frame2.Attributes("src") = "dept/fna/fna.html"
        ElseIf UCase(Request.Params("dept")) = "C&M" Then
            lblDepLink.Text = "Important Links from C&M Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='C&M' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
          " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
          " FROM            empdetail AS e INNER JOIN " & _
          "               empdetailx AS x ON e.eid = x.eid " & _
          "  WHERE        (dept='C&M')" & _
                     "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/cnm/link.html"
            frame2.Attributes("src") = "dept/cnm/cnm.html"
        ElseIf UCase(Request.Params("dept")) = "CIVIL" Then
            lblDepLink.Text = "Important Links from CIVIL CONST Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='CIVIL CONST' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
          " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
          " FROM            empdetail AS e INNER JOIN " & _
          "               empdetailx AS x ON e.eid = x.eid " & _
          "  WHERE        (dept='CIVIL CONST')" & _
                     "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/ccd/link.html"
            frame2.Attributes("src") = "dept/ccd/ccd.html"
        ElseIf UCase(Request.Params("dept")) = "CIVILT" Then
            lblDepLink.Text = "Important Links from CIVIL CONST- TOWNSHIP Dept"
            '  Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='CIVIL CONST- TOWNSHIP' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
         " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
         " FROM            empdetail AS e INNER JOIN " & _
         "               empdetailx AS x ON e.eid = x.eid " & _
         "  WHERE        (dept='CIVIL CONST- TOWNSHIP')" & _
                    "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/ccd/link.html"
            frame2.Attributes("src") = "dept/ccd/ccd.html"
        ElseIf UCase(Request.Params("dept")) = "EED" Then
            lblDepLink.Text = "Important Links from ELECT ERECT Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='ELECT ERECT' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
        " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
        " FROM            empdetail AS e INNER JOIN " & _
        "               empdetailx AS x ON e.eid = x.eid " & _
        "  WHERE        (dept='ELECT ERECT')" & _
                   "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/eed/link.html"
            frame2.Attributes("src") = "dept/eed/eed.html"
        ElseIf UCase(Request.Params("dept")) = "MED" Then
            lblDepLink.Text = "Important Links from MECH ERECT Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='MECH ERECT' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
        " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
        " FROM            empdetail AS e INNER JOIN " & _
        "               empdetailx AS x ON e.eid = x.eid " & _
        "  WHERE        (dept='MECH ERECT')" & _
                   "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/eed/link.html"
            frame2.Attributes("src") = "dept/eed/eed.html"
        ElseIf UCase(Request.Params("dept")) = "P&S" Then
            lblDepLink.Text = "Important Links from P & S Dept"
            'Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='P & S' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
       " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
       " FROM            empdetail AS e INNER JOIN " & _
       "               empdetailx AS x ON e.eid = x.eid " & _
       "  WHERE        (dept='P & S')" & _
                  "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/pns/link.html"
            frame2.Attributes("src") = "dept/pns/pns.html"
        ElseIf UCase(Request.Params("dept")) = "FES" Then
            lblDepLink.Text = "Important Links from FES Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='FLD. ENGG.' or dept= 'HYDRO- GEO' or dept = 'ENVT. MGT.' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
       " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
       " FROM            empdetail AS e INNER JOIN " & _
       "               empdetailx AS x ON e.eid = x.eid " & _
       "  WHERE        (dept='FLD. ENGG.' or dept= 'HYDRO- GEO' or dept = 'ENVT. MGT.' )" & _
                  "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/fes/link.html"
            frame2.Attributes("src") = "dept/fes/fes.html"
        ElseIf UCase(Request.Params("dept")) = "SAFETY" Then
            lblDepLink.Text = "Important Links from SAFETY Dept"
            'Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='SAFETY' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
      " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
      " FROM            empdetail AS e INNER JOIN " & _
      "               empdetailx AS x ON e.eid = x.eid " & _
      "  WHERE        (dept='SAFETY' )" & _
                 "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/safety/link.html"
            frame2.Attributes("src") = "dept/safety/safety.html"
        ElseIf UCase(Request.Params("dept")) = "MEDICAL" Then
            lblDepLink.Text = "Important Links from MEDICAL Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='MEDICAL' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
      " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
      " FROM            empdetail AS e INNER JOIN " & _
      "               empdetailx AS x ON e.eid = x.eid " & _
      "  WHERE        (dept='MEDICAL' )" & _
                 "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/medical/link.html"
            frame2.Attributes("src") = "dept/medical/medical.html"
        ElseIf UCase(Request.Params("dept")) = "VIGILANCE" Then
            lblDepLink.Text = "Important Links from VIGILANCE Dept"
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='VIGILANCE' ORDER BY grade DESC"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
      " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
      " FROM            empdetail AS e INNER JOIN " & _
      "               empdetailx AS x ON e.eid = x.eid " & _
      "  WHERE        (dept='VIGILANCE' )" & _
                 "ORDER BY e.grade DESC"  '
            frame1.Attributes("src") = "dept/vigilance/link.html"
            frame2.Attributes("src") = "dept/vigilance/vigilance.html"
        ElseIf UCase(Request.Params("dept")) = "HOP" Then
            lblDepLink.Text = "Important Links from HOP SECT"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
     " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
     " FROM            empdetail AS e INNER JOIN " & _
     "               empdetailx AS x ON e.eid = x.eid " & _
     "  WHERE        ( dept='HOP SECT' or dept= 'HEAD OF PROJECT' )" & _
                "ORDER BY e.grade DESC"  '
            'Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where dept='HOP SECT' or dept= 'HEAD OF PROJECT' ORDER BY grade DESC"
            frame1.Attributes("src") = "dept/vigilance/link.html"
            frame2.Attributes("src") = "dept/vigilance/vigilance.html"
        Else
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
           " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo , x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
           " FROM            empdetail AS e INNER JOIN " & _
           "               empdetailx AS x ON e.eid = x.eid " & _
                      "ORDER BY e.grade DESC"  '"  WHERE        (e.eid = '009383') " & _
        End If

        If Not String.IsNullOrEmpty(Request.Params("showemp")) Then
            ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where eid='" + Trim(Request.Params("showemp")) + "'"
            Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
            " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
            " FROM            empdetail AS e INNER JOIN " & _
            "               empdetailx AS x ON e.eid = x.eid " & _
            "  WHERE        (e.eid = '" + Trim(Request.Params("showemp")) + "')" & _
                       "ORDER BY e.grade DESC"  '
        End If

        rebindListview(Session("currentQuery"), lvMylist)

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
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ChatService As New ChatService
        ChatService.trackOnlineVisitor(Session("myIP"))

    End Sub





    Protected Sub lvMylist_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMylist.SelectedIndexChanged

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim search As String = Trim(txtSearch.Text)
        ' Session("CurrentQuery") = "SELECT eid, fname + ' ' +  lname as name, 'database/pics/p' + rtrim(eid) + '.gif' as pic, grade , dept, designation, convert(varchar, dob, 104) as dob, convert(varchar, projjoindate, 104) as projjoindate, prevproj, native, marital, bgroup,panno,reportingto,cell from empdetail where fname like '%" + search + "%' or lname like '%" + search + "%' ORDER BY grade DESC"
        Session("CurrentQuery") = " SELECT        e.eid, e.fname + ' ' + e.lname AS name, 'database/pics/p' + RTRIM(e.eid) + '.gif' AS pic, e.grade, e.dept, e.designation, CONVERT(varchar, e.dob, 104) AS dob, " & _
   " CONVERT(varchar, e.projjoindate, 104) AS projjoindate, e.prevproj, e.native, e.marital, e.bgroup, e.panno, e.reportingto, e.cell, '01374-' + x.phoneo as phoneo, x.email, x.cug, CONVERT(varchar, x.adate, 104) AS adate,x.epabx " & _
   " FROM            empdetail AS e INNER JOIN " & _
   "               empdetailx AS x ON e.eid = x.eid " & _
   "  where fname like '%" + search + "%' or lname like '%" + search + "%' " & _
   " or e.eid like '%" + search + "%' " & _
   " or email like '%" + search + "%' " & _
   " or grade like '%" + search + "%' " & _
   " or bgroup like '%" + search + "%' " & _
   " or designation like '%" + search + "%' " & _
   " or dept like '%" + search + "%' " & _
              "ORDER BY e.grade DESC"  '
        rebindListview(Session("currentQuery"), lvMylist)
        '   lblMessage.Text = Session("CurrentQuery")
    End Sub
End Class
