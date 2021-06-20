<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> LPHPP Intranet</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<link href="style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            text-align: justify;
        }
    </style>
   <!-- MyCSSMenu Noscript Support [Keep in head for full validation!] -->
<noscript><style type="text/css">.qmmc {width:200px !important;height:200px !important;overflow:scroll;}.qmmc div {position:relative !important;visibility:visible !important;}.qmmc a {float:none !important;white-space:normal !important;}</style></noscript>
<link rel='stylesheet' type='text/css' href='quickmenu.css'/>
<script type='text/javascript' src='quickmenu.js'></script>   <!-- shows menu -->
<script type="text/javascript" src="jquery.min.js"></script>   <!-- shows slideshow -->
<script type="text/javascript" src="fadeslideshow.js"></script>   <!-- shows slideshow -->
<script type="text/javascript">
var mygallery2=new fadeSlideShow({
	wrapperid: "fadeshow2", //ID of blank DIV on page to house Slideshow
	dimensions: [400, 200], //width/height of gallery in pixels. Should reflect dimensions of largest image
	imagearray: [
		["images/lphpp/1_resize.jpg", "images/lphpp/1.jpg", "_new", "Diversion Channel."],
["images/lphpp/2_resize.jpg", "images/lphpp/2.jpg", "_new", "Tail Race Tunnel."],
["images/lphpp/3_resize.jpg", "images/lphpp/3.jpg", "_new", "Bhagirathi.. Diverted."],
["images/lphpp/4_resize.jpg", "images/lphpp/4.jpg", "_new", "Gunaga Adit Approach Road"],
["images/lphpp/5_resize.jpg", "images/lphpp/5.jpg", "_new", "Adit to Bottom of Surge Shaft"],
["images/lphpp/6_resize.jpg", "images/lphpp/6.jpg", "_new", "Inlet of Diversion Channel."],
["images/lphpp/7_resize.jpg", "images/lphpp/7.jpg", "_new", "Tail Race Tunnel."],
["images/lphpp/8_resize.jpg", "images/lphpp/8.jpg", "_new", "Outlet of Diversion Channel.."],
["images/lphpp/9_resize.jpg", "images/lphpp/9.jpg", "_new", "Barrage Concrete"],
["images/lphpp/10_resize.jpg", "images/lphpp/10.jpg", "_new", "Bhagirathi.. Diverted."],
["images/lphpp/11_resize.jpg", "images/lphpp/11.jpg", "_new", "TRT Manifold"],
["images/lphpp/12_resize.jpg", "images/lphpp/12.jpg", "_new", "Diversion Channel."],
["images/lphpp/13_resize.jpg", "images/lphpp/13.jpg", "_new", " Desilting Chamber."],
["images/lphpp/14_resize.jpg", "images/lphpp/14.jpg", "_new", "Inlet of Diversion Channel."],
["images/lphpp/15_resize.jpg", "images/lphpp/15.jpg", "_new", "DC Intake Tunnel."],
["images/lphpp/16_resize.jpg", "images/lphpp/16.jpg", "_new", "Bridge Over Diversion Channel."],
["images/lphpp/17_resize.jpg", "images/lphpp/17.jpg", "_new", "Head Race Tunnel."],
["images/lphpp/18_resize.jpg", "images/lphpp/18.jpg", "_new", "Environment Protection Work."],
["images/lphpp/19_resize.jpg", "images/lphpp/19.jpg", "_new", "Bailey Bridge at barrage"],
["images/lphpp/20_resize.jpg", "images/lphpp/20.jpg", "_new", "Adit to Bottom of Surge Shaft"],
["images/lphpp/21_resize.jpg", "images/lphpp/21.jpg", "_new", "Fabrication Yard"],
["images/lphpp/22_resize.jpg", "images/lphpp/22.jpg", "_new", "Main Access Tunnel."],
["images/lphpp/23_resize.jpg", "images/lphpp/23.jpg", "_new", "Inlet of Diversion Channel."],
["images/lphpp/24_resize.jpg", "images/lphpp/24.jpg", "_new", "Adit to Top of Transformer Cavern"],
["images/lphpp/25_resize.jpg", "images/lphpp/25.jpg", "_new", "Gunaga Adit Approach Road."],
["images/lphpp/26_resize.jpg", "images/lphpp/26.jpg", "_new", "Surge Shaft Top"],
["images/lphpp/27_resize.jpg", "images/lphpp/27.jpg", "_new", "Adit to Bottom of Surge Shaft."],
["images/lphpp/28_resize.jpg", "images/lphpp/28.jpg", "_new", "Switch Yard"],
["images/lphpp/29_resize.jpg", "images/lphpp/29.jpg", "_new", "Mech w/s."]
		 //<--no trailing comma after very last image element!
	],
	displaymode: {type:'auto', pause:2000, cycles:0, wraparound:false},
	persist: false, //remember last viewed slide and recall within same session?
	fadeduration: 500, //transition duration (milliseconds)
	descreveal: "always",  // it can be "ondemand"
	togglerid: "fadeshow2toggler"
})


</script>

<!-- <script type='text/javascript' src='bottomovermsg.js'></script> -->  <!-- shows some message on home page -->
<script type="text/javascript" runat="server">
    Function getProject(ByVal ipaddress As String) As String
        Dim oct3 As String = Strings.Left(ipaddress, Strings.InStrRev(ipaddress, ".") - 1)
        Select Case oct3
            Case "191.254.186", "127.0.0"
                oct3 = ""
            Case "191.254.20"
                oct3 = " - ANTA"
            Case "191.254.16"
                oct3 = " - AURAIYA"
            Case "191.254.178"
                oct3 = " - BADARPUR"
            Case "191.254.100"
                oct3 = " - BARH"
            Case "10.1.249"
                oct3 = " - BONGAIGAON"
            Case "10.0.9"
                oct3 = " - CC"
            Case "191.254.157"
                oct3 = " - DADRI"
            Case "190.190.25"
                oct3 = " - EOC"
            Case "191.254.171"
                oct3 = " - ERHQ I"
            Case "10.1.240"
                oct3 = " - ERHQ II"
            Case "191.254.2"
                oct3 = " - FARAKKA"
            Case "191.254.172"
                oct3 = " - FARIDABAD"
            Case "10.1.210"
                oct3 = " - HRHQ"
            Case "191.254.12"
                oct3 = " - JHANAUR"
            Case "10.0.152"
                oct3 = " - KAHALGAON"
            Case "191.254.10"
                oct3 = " - KAWAS"
            Case "191.254.164"
                oct3 = " - KAYAMKULAM"
            Case "191.254.184"
                oct3 = " - KOLDAM"
            Case "191.254.3"
                oct3 = " - KORBA"
            Case "10.0.216"
                oct3 = " - MAUDA"
            Case "191.254.191"
                oct3 = " - NCRRHQ"
            Case "191.254.173"
                oct3 = " - NRHQ"
            Case "191.254.4"
                oct3 = " - RAMAGUNDAM"
            Case "191.254.6"
                oct3 = " - RIHAND"
            Case "191.254.169"
                oct3 = " - SIMHADRI"
            Case "191.254.5"
                oct3 = " - SINGRAULI"
            Case "191.254.183"
                oct3 = " - SIPAT"
            Case "191.254.168"
                oct3 = " - SRHQ"
            Case "191.254.176"
                oct3 = " - TALCHER P"
            Case "10.0.120"
                oct3 = " - TALCHER S"
            Case "191.254.174"
                oct3 = " - TANDA"
            Case "191.254.187"
                oct3 = " - TAPOVAN"
            Case "191.254.11"
                oct3 = " - UNCHAHAR"
            Case "191.254.15"
                oct3 = " - VINDHYACHAL"
 	    Case "10.0.61"
                oct3 = " - SSTPS"
            Case "191.254.175"
                oct3 = " - WRHQ"
            Case "191.254.181"
                oct3 = " - PMI"
            Case "10.0.21"
                oct3 = " - EOC"
            Case "10.0.200"
                oct3 = " - Sipat"
            Case "10.0.30"
                oct3 = " - ntpc"
            Case "10.0.34"
                oct3 = " - ntpc"
            Case "10.0.36"
                oct3 = " - ntpc"
            Case "10.0.39"
                oct3 = " - ntpc"
            Case "10.0.48"
                oct3 = " - ntpc"
            Case "10.0.50"
                oct3 = " - ntpc"
            Case "10.0.52"
                oct3 = " - ntpc"
            Case "10.0.53"
                oct3 = " - ntpc"
            Case "10.0.57"
                oct3 = " - ntpc"
            Case "10.0.58"
                oct3 = " - ntpc"
            Case "10.0.60"
                oct3 = " - ntpc"
            Case "10.0.65"
                oct3 = " - ntpc"
            Case "10.0.73"
                oct3 = " - ntpc"
            Case "10.0.74"
                oct3 = " - ntpc"
            Case "10.0.75"
                oct3 = " - ntpc"
            Case "10.0.76"
                oct3 = " - ntpc"
            Case "10.0.80"
                oct3 = " - ntpc"
            Case "10.0.81"
                oct3 = " - ntpc"
            Case "10.0.82"
                oct3 = " - ntpc"
            Case "10.0.83"
                oct3 = " - ntpc"
            Case "10.0.84"
                oct3 = " - ntpc"
            Case "10.0.87"
                oct3 = " - ntpc"
            Case "10.0.89"
                oct3 = " - ntpc"
            Case "10.0.153"
                oct3 = " - ntpc"
            Case "10.0.155"
                oct3 = " - ntpc"
            Case "10.0.160"
                oct3 = " - ntpc"
            Case "10.0.176"
                oct3 = " - ntpc"
            Case "10.0.177"
                oct3 = " - ntpc"
            Case "10.0.178"
                oct3 = " - ntpc"
            Case "10.0.23"
                oct3 = " - ntpc"
            Case "10.0.212"
                oct3 = " - ntpc"
            Case "10.0.90"
                oct3 = " - ntpc"
            Case "10.0.91"
                oct3 = " - ntpc"
            Case "10.0.92"
                oct3 = " - ntpc"
            Case "10.0.95"
                oct3 = " - ntpc"
            Case "10.0.97"
                oct3 = " - ntpc"
            Case "10.0.98"
                oct3 = " - ntpc"
            Case "10.1.161"
                oct3 = " - ntpc"
            Case "10.1.168"
                oct3 = " - ntpc"
            Case "10.1.184"
                oct3 = " - ntpc"
            Case "10.1.205"
                oct3 = " - ntpc"
            Case "10.1.209"
                oct3 = " - ntpc"
            Case "10.0.121"
                oct3 = " - ntpc"
            Case "10.0.123"
                oct3 = " - ntpc"
            Case "10.0.124"
                oct3 = " - ntpc"
            Case "10.0.125"
                oct3 = " - ntpc"
            Case "10.0.126"
                oct3 = " - ntpc"
            Case "10.0.127"
                oct3 = " - ntpc"
            Case "10.1.228"
                oct3 = " - ntpc"
            Case "10.1.230"
                oct3 = " - ntpc"
            Case "10.1.231"
                oct3 = " - ntpc"
            Case "10.0.111"
                oct3 = " - ntpc"
            Case "10.1.242"
                oct3 = " - ntpc"
            Case "10.1.247"
                oct3 = " - ntpc"
            Case "10.1.250"
                oct3 = " - ntpc"
            Case "10.1.251"
                oct3 = " - ntpc"
            Case "10.1.252"
                oct3 = " - ntpc"
            Case "10.6.6"
                oct3 = " - ntpc"
            Case "191.254.1"
                oct3 = " - ntpc"
            Case "191.254.152"
                oct3 = " - ntpc"
            Case "191.254.156"
                oct3 = " - ntpc"
            Case "191.254.159"
                oct3 = " - ntpc"
            Case "191.254.161"
                oct3 = " - ntpc"
            Case "191.254.181"
                oct3 = " - ntpc"
            Case "191.254.185"
                oct3 = " - ntpc"
            Case "191.254.202"
                oct3 = " - ntpc"
            Case "191.254.206"
                oct3 = " - ntpc"
            Case "191.254.207"
                oct3 = " - ntpc"
            Case "191.254.211"
                oct3 = " - ntpc"
            Case "191.254.24"
                oct3 = " - ntpc"
            Case "191.254.249"
                oct3 = " - ntpc"
            Case "191.254.28"
                oct3 = " - ntpc"
            Case "191.254.33"
                oct3 = " - ntpc"
            Case "191.254.7"
                oct3 = " - ntpc"
            Case "202.54.61"
                oct3 = " - ntpc"
            Case Else
                oct3 = "- ntpc"
        End Select
        Return oct3.ToLower()
    End Function
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            <Services>
                    <asp:ServiceReference Path="ChatService.asmx" />
                </Services>
 </asp:ToolkitScriptManager>
    
    </div>
    <div id="container">
  <div id="banner">
      <asp:Label ID="lblHeader" runat="server" Font-Bold="True" 
          Font-Names="Microsoft Sans Serif" Font-Size="Large" ForeColor="White" 
          Text="Loharinag- Pala Hydro Power Project, NTPC Limited."></asp:Label>
  </div>
  
  <div id="qm0" class="qmmc">

	<a href="javascript:void(0)">Departments</a>

		<div>
		<a href="departments.aspx?dept=HOP">AGM(I/C) Sect.</a>
		<a href="javascript:void(0)">Civil Const</a>

			<div>
			<a href="departments.aspx?dept=CIVIL">Barrage</a>
			<a href="departments.aspx?dept=CIVIL">HRT</a>
			<a href="departments.aspx?dept=CIVIL">Powerhouse</a>
			<a href="departments.aspx?dept=CIVILT">Township</a>
			</div>

		<a href="departments.aspx?dept=C%26M">Contracts & Material</a>

			

		<a href="javascript:void(0)">Equipment Erection</a>
        <div>
			<a href="departments.aspx?dept=EED">Electrical</a>
			<a href="departments.aspx?dept=MED">Mechanical</a>
			<a href="departments.aspx?dept=IT">IT</a>
			
			</div>
            <a href="javascript:void(0)">Field Engg Services</a>

			<div>
			<a href="departments.aspx?dept=FES">FES</a>
			<a href="departments.aspx?dept=FES">EMG</a>
			<a href="departments.aspx?dept=FQA">FQA</a>
			<a href="departments.aspx?dept=SAFETY">Safety</a>
			</div>
		<a href="departments.aspx?dept=FINANCE">Finance & Accounts</a>
		<a href="javascript:void(0)">Human Resource</a>
        <div>
			<a href="departments.aspx?dept=HR">HR</a>
			<a href="departments.aspx?dept=HR">Law</a>
			<a href="departments.aspx?dept=HR">PR</a>
            <a href="departments.aspx?dept=HR">Hindi</a>
            </div>
        <a href="departments.aspx?dept=IT">Information Technology</a>
         <a href="departments.aspx?dept=MEDICAL">Medical</a>
		<a href="javascript:void(0)">Planning & System</a>
        <div>
			<a href="departments.aspx?dept=P%26S">Daily Report</a>
			<a href="departments.aspx?dept=P%26S">Buiseness Plan</a>
			<a href="javascript:void(0)">Budget</a>
            <div>
			<a href="departments.aspx?dept=P%26S">Planning</a>
			<a href="departments.aspx?dept=P%26S">Review</a>
			<a href="departments.aspx?dept=P%26S">Utilization</a>
			
			</div>
			<a href="departments.aspx?dept=P%26S">Visits</a>
			</div>
        <a href="departments.aspx?dept=R%26R">R&R</a>
         <a href="departments.aspx?dept=VIGILANCE">Vigilance</a>
		
		</div>

      <a href="javascript:void(0)">Mail</a>
             <div>
                <a href="http://191.254.186.230/WebRedir.nsf">NTPC Mail</a>
                 <a href="departments.aspx">Search e-Mail id</a>
                 <a href="http://10.0.8.220/names.nsf?ChangePassword">Change NTPC Mail Password</a>
                 <a href="http://191.254.1.220/names.nsf">Change Profile</a>

            </div>

	<a href="javascript:void(0)">Imp Links</a>

		<div>
<a href="dept/hr/pv.htm">Power Vision Magazine</a>
		<a href="dept/hr/dop2005.pdf">DoP 2005</a>
		<a href="departments.aspx?dept=HR">HR Formats</a>
		<a href="departments.aspx?dept=FINANCE">F&A Formats</a>
		<a href="http://10.0.5.2:8001/webntpc/hr_homepage_files/corp_hr_circulars.jsp">HR Circulars(CC)</a>
		<a href="http://191.254.198.107/gdams/realview_new2.asp">GDAMS</a>
		<a href="http://191.254.1.211:81/doctracker">DOC Tracker</a>
                 <a href="http://191.254.1.211:81/ipon/">IPON</a>
         <a href="http://10.1.210.55/IPON/IdeaLogin.aspx">HIPON</a>
         <a href="http://10.0.5.2:8001/webntpc/hr_homepage_files/transfer_list.htm">Transfer List</a>
         <a href="departments.aspx?dept=HR">Law & Acts</a>
         <a href="dept/eed/elecact/elecact.html">Electricity Act</a>
         <a href="departments.aspx?dept=IT">Software Downloads</a>
 <a href="http://10.0.37.183/vig1/html/index.html">HR Recruitment</a>

		</div>

	<a href="javascript:void(0)">Useful Links</a>

		<div>
        <a href="HTTP://www.ntpc.co.in">NTPC Limited</a>
		<a href="http://www.google.co.in">Google</a>
		<a href="http://www.onlinesbi.com">Online SBI</a>
		<a href="http://www.icicibank.com">ICICI Bank</a>
        <a href="http://www.bsnl.co.in">BSNL</a>
		<a href="http://www.erail.in">Rail Enquiry</a>
		<a href="javascript:void(0)">Train/Flight</a>
        <div>
        <a href="http://www.irctc.co.in">IRCTC</a>
        <a href="http://www.makemytrip.com">MakemyTrip</a>
        <a href="http://www.cleartrip.com">Clear Trip</a>
        <a href="http://www.yatra.com">Yatra</a>
		        </div>
		<a href="javascript:void(0)">Mail</a>
         <div>
         <a href="http://191.254.186.230/WebRedir.nsf">NTPC Mail</a>
        <a href="http://www.gmail.com">Gmail</a>
        <a href="http://www.mail.yahoo.com">Yahoo!</a>
        <a href="http://www.rediffmail.com">Rediff</a>
       
		        </div>
		</div>

	<a href="javascript:void(0)">Project</a>

		<div>
		<a href="loader.aspx?requestedpage=layout">Project Layout</a>
		<a href="dept/fes/dcsindex.html">Drawing Library</a>
		<a href="loader.aspx?requestedpage=activity">Ongoing Activity</a>
        <a href="loader.aspx?requestedpage=milestone">Milestones</a>
		<a href="dept/fes/caindex.html">Contract Agreements</a>
        <a href="loader.aspx?requestedpage=award">Award Details</a>
        <a href="loader.aspx?requestedpage=fotogal">Foto Gallery</a>
		
		</div> 
        <a href="javascript:void(0)">Search</a>

		<div>
		<a href="departments.aspx">Search Employee</a>
		<a href="uploader.aspx?mode=circulars">Search Circulars</a>
		<a href="uploader.aspx?mode=articles">Search Articles</a><a href="uploader.aspx?mode=reports">Search Reports</a>
        </div> 
          <a href="javascript:void(0)">e-Services</a>
        <div>
		<a href="sms.aspx?mode=group&portname=COM4">Group Messaging System</a>
        <a href="booking.aspx">Welfare Vehicle Booking</a>
		<a href="http://191.254.186.1:3431/">Online Complaints</a>
		<a href="uploader.aspx?mode=articles">Add Circulars,News,Events</a>
        <a href="uploader.aspx?mode=articles">Add Articles</a>
            <a href="uploader.aspx?mode=ftp">File Sharing</a>
        <a href="uploader.aspx?mode=reports">Online Report</a>
        <a href="uploader.aspx?mode=zigyaasa">Zigyaasa</a>
        </div> 

<span class="qmclear">&nbsp;</span></div>

<!-- Create Menu Settings: (Menu ID, Is Vertical, Show Timer, Hide Timer, On Click ('all' or 'lev2'), Right to Left, Horizontal Subs, Flush Left, Flush Top) -->
<script type="text/javascript">    qm_create(0, false, 0, 50, false, false, false, false, false);</script>
  <ul id="navlist">
    <li id="active"><a id="current" href="default.aspx">HOME</a></li>
    <li><a href="loader.aspx?requestedpage=erp">ERP</a></li>
    <li><a href="uploader.aspx?mode=circulars">Circulars</a></li>
    <li><a href="uploader.aspx?mode=articles">Articles</a></li>
     <li><a href="http://191.254.186.1:3431/">IT-Support</a></li>
   <li>  <a href="booking.aspx">e-Booking</a></li>
    <li>  <a href="sms.aspx?mode=group&portname=COM4">SMS</a></li>
 <li><a href="departments.aspx">SearchEmployee</a></li>
 <li><a href="loader.aspx?requestedpage=hindi">&#2361;&#2367;&#2344;&#2381;&#2342;&#2368;</a></li>
    <li><a href="uploader.aspx?mode=feedback">Feedback</a></li>
       
  </ul>
  <div id="sidebar-a">
    <h2>ViEW</h2>
    <div class="menu">
      <ul>
        <li> <asp:HyperLink ID="net" runat="server">Net Status<img src="images/new.gif" width="22px" height ="12px" /></asp:HyperLink> </li>
        <li><a href="departments.aspx?dept=P%26S">Daily Report</a></li>
        <li><a href="loader.aspx?requestedpage=erp">ERP</a></li>
        <li><a href="uploader.aspx?mode=reports">LPHPP Report <img src="images/left_arrow_animated.gif" width="10px" height ="6px" /></a></li>
        <li><a href="loader.aspx?requestedpage=projects">NTPC Projects</a></li>
        <li><a href="dept/fes/caindex.html">Contract Agreements</a></li>
        <li><a href="dept/fes/dcsindex.html">Drawings</a></li>
        <li><a href="login.aspx">Login</a></li>
      </ul>
    </div>
    <h3>Wishes</h3>
     <div id="fadeshow1" runat="server"></div><p>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
              <div style="width: 139px; height: 197px;  overflow-x: hidden; overflow-y: auto;  white-space:nowrap;" >
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" ForeColor="#333333"
            GridLines="None" Style="position: static" 
             EmptyDataText="No Users Online" Font-Size="9px" Width="137px" BorderColor="#3399FF" 
                      BorderStyle="Dotted" BorderWidth="1px"  >
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>

          <asp:TemplateField  ShowHeader="False">
          <ItemTemplate>
          <asp:Image ID="Image1" ImageUrl='<%# "images/greendot.gif" %>' runat="server" width="8px" height="8px" />
          </ItemTemplate>
              <HeaderStyle HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Left" Width="8px" />
          </asp:TemplateField>

          <asp:TemplateField HeaderText="Real Time Chat"  >
          <ItemTemplate>
                <a href="javascript:vinModal('<%# Eval("ipaddress") %>');" ><%# Eval("name")%> <font color="maroon"><i> <%# getProject(Eval("ipaddress"))%></i> </font>  </a>
             </ItemTemplate>
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
            </Columns>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                No users are online now.
            </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            </div>
        <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="10000">

                </asp:Timer>

             </ContentTemplate>
        </asp:UpdatePanel> </p>

  </div>
  <div id="sidebar-b">
      
    
    <h3>Live News </h3>
    
        
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional"  >
    <ContentTemplate>
         
         <asp:GridView ID="gvLiveNews" runat="server" AutoGenerateColumns="False"  CellPadding="2" ForeColor="#333333"
            GridLines="None" Style="position: static"  EmptyDataText="No News to show" Font-Size="10px" Width="137px" BorderColor="#3399FF" 
                      BorderStyle="Dotted" BorderWidth="1px" AllowPaging="True"   PageSize="4" ShowHeader="False"  >
               <PagerSettings Visible="False" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
               <asp:TemplateField  ShowHeader="False">
               <ItemTemplate>
                <a href="loader.aspx?requestedpage=livenews" ><font color="black"  > <%# XPath("title")%> </font> </a>
               </ItemTemplate>
               <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
            </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>

         <asp:GridView ID="gvLiveNews2" runat="server" AutoGenerateColumns="False"  CellPadding="2" ForeColor="#333333"
            GridLines="None" Style="position: static"  EmptyDataText="No News to show" Font-Size="10px" Width="137px" BorderColor="#3399FF" 
                      BorderStyle="Dotted" BorderWidth="1px" AllowPaging="True"   PageSize="4" ShowHeader="False"   >
               <PagerSettings Visible="False" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
               <asp:TemplateField  ShowHeader="False">
               <ItemTemplate>
                <a href="loader.aspx?requestedpage=livenews" ><font color="black"  > <%#XPath("title")%> </font> </a>
               </ItemTemplate>
               <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
            </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>

        
           <asp:Label ID="lbError" runat="server" Text="Getting News Feed.. Please Wait..." > <asp:Image  ID="imgLoad2" runat="server" ImageUrl="images/loaderbar.gif"  />  </asp:Label>
        <asp:Timer ID="Timer2" runat="server" Interval="100">
        </asp:Timer>
        </ContentTemplate>
       
        </asp:UpdatePanel>
      
      <fieldset ><legend ><font color="#b29b35" face = "arial" Font-Size="9pt" ><b>Statistics...</b></font></legend>   <asp:Label ID="lblName" runat="server" Text="Guest" Font-Bold="False" 
              ForeColor="Blue" Font-Size="XX-Small"></asp:Label>
    <br />
     <font color="blue" face = "arial" Font-Size="8pt"> Visitors online:</font> <font color="#9218AB"> <%= Application("OnlineUsers")%>  </font>  
     
     </fieldset> 
      
      
      

      
 <h3>Thoughts</h3>
 <p><asp:Label ID="lblQuotes" runat="server" ForeColor="#0066FF"></asp:Label>  </p>
    
  </div>
  <div id="content">
    <h2>&nbsp;<span style="font-weight:bold; color:#891E18;">Loharinag-pala</span> 
        Intranet</h2>
    <blockquote class="style1">In Loharinag Pala Hydro Power Project with a capacity of 600 MW (150 MW 
        x 4). The main package has been awarded. The present executives' strength 
        is 100+. The project is located on river Bhagirathi(Tributory of Ganga) in 
        Uttarkashi district of Uttaranchal state.</blockquote>
     <table ><tr><td ><a href="loader.aspx?requestedpage=tourism">How To Reach ! Tourism</a> </td>
     <td>   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
         
     <asp:GridView ID="gvTemp" runat="server" AutoGenerateColumns="False"  CellPadding="2" ForeColor="#333333"
            GridLines="None" Style="position: static"  EmptyDataText="No News to show" Font-Size="9px"  AllowPaging="True"   PageSize="1" ShowHeader="False"   >
               <PagerSettings Visible="False" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
               <asp:TemplateField  ShowHeader="False">
               <ItemTemplate>
               <font color="blue" > ! <img src="images/weather.gif" width="30px" height="18px" alt="Weather" /> Temperature: <%#XPath("title")%> </font> </a>
               </ItemTemplate>
               <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
           
            </Columns>
                            
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel></td>
        <td><asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
         
     <asp:GridView ID="gvBSE" runat="server" AutoGenerateColumns="False"  CellPadding="2" ForeColor="#333333"
            GridLines="None" Style="position: static"  EmptyDataText="No Updates" Font-Size="9px"   AllowPaging="True"   PageSize="1" ShowHeader="False"   >
               <PagerSettings Visible="False" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#CCCC00" />
            <Columns>
               <asp:TemplateField  ShowHeader="False">
               <ItemTemplate>
               <font color="#669900" > !  <%#XPath("title")%> </font> </a>
               </ItemTemplate>
               <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
           
            </Columns>
            
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
</tr></table>
    
    <center> 
        <div id="fadeshow2"></div>

        <div id="fadeshow2toggler" style="width:250px; text-align:center; margin-top:10px">
        <a href="#" class="prev"><img src="images/302rn5v.png" style="border-width:0" alt="back"/></a>  <span class="status" style="margin:0 50px; font-weight:bold"></span> <a href="#" class="next"><img src="images/lzkux.png" style="border-width:0" /></a>
         </div>

        <asp:HyperLink ID="HyperLink3" runat="server" 
            NavigateUrl="loader.aspx?requestedpage=fotogal">View Gallery</asp:HyperLink></center> 
      
   
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
   
         <table align="center"><tr><td> <asp:GridView ID="gvCirculars" runat="server" 
                 Height="109px" PageSize="5" 
              Width="339px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="Horizontal" 
              BorderWidth="2px" BorderColor="#006600">
                        <Columns>
                            <asp:HyperLinkField DataTextField="sub" HeaderText="Circulars / News / Events" 
                                Text= "filename" DataNavigateUrlFields="filename" Target="_blank" 
                                DataNavigateUrlFormatString="database/circulars/{0}" >
                            <HeaderStyle BackColor="#009900" ForeColor="White" />
                            <ItemStyle ForeColor="#FF0066" Width="70%" />
                            </asp:HyperLinkField>
                        <asp:BoundField DataField="cdate1" ShowHeader="False" >
                            <HeaderStyle BackColor="#009900" ForeColor="White" />
                            <ItemStyle Width="30%" />
                            </asp:BoundField>
                    </Columns>
               <AlternatingRowStyle BackColor="White"  />
          </asp:GridView></td><td>
                 <asp:GridView ID="gvArticles" runat="server" 
                     AllowPaging="True" Height="109px" PageSize="5"
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="Horizontal" 
              BorderWidth="2px" BorderColor="#006600" >
                 <Columns>
                     <asp:HyperLinkField HeaderText="Articles" DataNavigateUrlFields="filename" 
                         DataNavigateUrlFormatString="database/articles/{0}" DataTextField="topic" 
                         Text="topic" >
                     <HeaderStyle BackColor="Blue" ForeColor="Yellow" />
                     <ItemStyle Width="90%" />
                     </asp:HyperLinkField>
                 </Columns>
                  <AlternatingRowStyle BackColor="White"  />
              </asp:GridView></td></tr> 
              <tr><td>
          <asp:HyperLink ID="HyperLink1" runat="server" 
              NavigateUrl="uploader.aspx?mode=circulars">Add Circular++ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search&gt;&gt;  </asp:HyperLink>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </td><td> <asp:HyperLink ID="HyperLink2" runat="server" 
              NavigateUrl="uploader.aspx?mode=articles">Add Articles++</asp:HyperLink>
             </td></tr> </table>
      </ContentTemplate>
      </asp:UpdatePanel>
  
     
  </div>
  <div> <center>
      <OBJECT codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" 
          height="33" width="600" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" 
          style="text-align: center">
							<PARAM NAME="_cx" VALUE="19579">
							<PARAM NAME="_cy" VALUE="873">
							<PARAM NAME="FlashVars" VALUE="">
							<PARAM NAME="Movie" VALUE="images/vision.swf">
							<PARAM NAME="Src" VALUE="images/vision.swf">
							<PARAM NAME="WMode" VALUE="Transparent">
							<PARAM NAME="Play" VALUE="-1">
							<PARAM NAME="Loop" VALUE="-1">
							<PARAM NAME="Quality" VALUE="High">
							<PARAM NAME="SAlign" VALUE="">
							<PARAM NAME="Menu" VALUE="0">
							<PARAM NAME="Base" VALUE="">
							<PARAM NAME="AllowScriptAccess" VALUE="">
							<PARAM NAME="Scale" VALUE="NoScale">
							<PARAM NAME="DeviceFont" VALUE="0">
							<PARAM NAME="EmbedMovie" VALUE="0">
							<PARAM NAME="BGColor" VALUE="">
							<PARAM NAME="SWRemote" VALUE="">
							<PARAM NAME="MovieData" VALUE="">
							<PARAM NAME="SeamlessTabbing" VALUE="1">
							<PARAM NAME="Profile" VALUE="0">
							<PARAM NAME="ProfileAddress" VALUE="">
							<PARAM NAME="ProfilePort" VALUE="0">
							<PARAM NAME="AllowNetworking" VALUE="all">
							<PARAM NAME="AllowFullScreen" VALUE="false">
							<EMBED src="images/vision.swf" menu="false" quality="high" wmode="transparent" scale="noscale" WIDTH="600" HEIGHT="33" TYPE="application/x-shockwave-flash" PLUGINSPAGE="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash">
							</EMBED>
						</OBJECT>
  </center></div>
  <div id="footer"> <a href="http://191.254.186.111/default.aspx" class="vinlink">Old Version </a>  |  <a href="departments.aspx?dept=IT" class="vinlink">contact</a> | &copy; 2010 
       Design by <a href="departments.aspx?dept=IT" class="vinlink">IT LPHPP</a> | Licensed under a <a rel="license" target="_blank" href="default.aspx" class="vinlink" >Creative Commons Attribution 3.0 License</a>
        | Set As <a class="vinlink" style="CURSOR: hand; font-decoration: underline" onclick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://191.254.186.1');" href="\"> Homepage </A>
       </div>
       
</div>
    <asp:UpdatePanel ID="popupPanel" runat="server" CssClass="modalpopup"  style="display:none">
   <ContentTemplate>
              <center class="insidemodalpopup">     Information <br />
   <IFRAME id="iframe4" src="info.htm" scrolling="auto" runat="server" visible= "true" >
              </IFRAME> <br />
             <asp:Button ID="btnOK" runat="server" Text="Close" cssclass="button" BorderWidth="2px" BorderColor="Green"/></center>  
   
   </ContentTemplate>
     </asp:UpdatePanel>
      <asp:HyperLink ID="test" runat="server"></asp:HyperLink>
       <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="test" PopupControlID="popupPanel" BackgroundCssClass="modalBackground" dropshadow="true" OkControlID="btnok"  ></asp:ModalPopupExtender>
  


    <asp:UpdatePanel ID="upNet" runat="server" CssClass="modalpopup"  style="display:none">
   <ContentTemplate>
   <div class="insidemodalpopup">
              <center>    <h3> Network Real Time Status: LPHPP </h3> <br /> </center>  
                  <asp:Label ID="lblNet" runat="server" Text="Loading Network Status"></asp:Label>
                <br />
           <center>    <asp:Button ID="btnok2" runat="server" Text="Close" cssclass="button" BorderWidth="2px" BorderColor="Green"/></center>  
   </div>
   </ContentTemplate>
     </asp:UpdatePanel>
      
       <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="net" PopupControlID="upNet" BackgroundCssClass="modalBackground" dropshadow="true" OkControlID="btnok2"  ></asp:ModalPopupExtender>
      


      <div id="chatsection" >
        <asp:Panel ID="PanelChatRequest" runat="server" Style="display: none" CssClass="modalheader" scrolling="no" BorderWidth="2px" BorderStyle="Outset" BorderColor="Black">
             <center class="modalcontent">    <div id="ChatRequest">
                </div>
                 <asp:Label ID="Label1" runat="server" Text="Real Time Chat !!" ForeColor="White"></asp:Label>
                <asp:ImageButton ID="CancelButton" runat="server" ImageAlign="Right"  CssClass="closemodal"/>
                <p style="text-align: center;">
                       <iframe id="chatframe"  width="188" height="200" scrolling="no"></iframe>
                </p>
                </center>
            </asp:Panel>
            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
            <asp:TextBox ID="hiddenSenderUserID" runat="server" style="display:none"></asp:TextBox>
            <asp:TextBox ID="hiddenMyUserID" runat="server" style="display:none"></asp:TextBox>
            <asp:TextBox ID="hiddenAppPath" runat="server" style="display:none"></asp:TextBox>
            <asp:ModalPopupExtender runat="server" ID="programmaticModalPopup"
                BehaviorID="programmaticModalPopupBehaviorChatReq"
                TargetControlID="hiddenTargetControlForModalPopup"
                PopupControlID="PanelChatRequest" 
                             RepositionMode="RepositionOnWindowResizeAndScroll"
                CancelControlID="CancelButton" 
                OnCancelScript="OnCancel()"
                PopupDragHandleControlID = "PanelChatRequest"   >
            </asp:ModalPopupExtender>
</div>
    </form>
    </body>
</html>
