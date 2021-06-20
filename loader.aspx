<%@ Page Language="VB" AutoEventWireup="false" CodeFile="loader.aspx.vb" Inherits="_Default" %>

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
        #loader
        {
            width: 717px;
        }
    </style>
   <!-- MyCSSMenu Noscript Support [Keep in head for full validation!] -->
<noscript><style type="text/css">.qmmc {width:200px !important;height:200px !important;overflow:scroll;}.qmmc div {position:relative !important;visibility:visible !important;}.qmmc a {float:none !important;white-space:normal !important;}</style></noscript>
<link rel='stylesheet' type='text/css' href='quickmenu.css'/>
<script type='text/javascript' src='quickmenu.js'></script>
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
  <a href="departments.aspx">Departments</a>

		<div>
		
		
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
		<a href="uploader.aspx?mode=articles">Search Articles</a>
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
 <li><a href="loader.aspx?requestedpage=hindi">हिन्दी</a></li>
    <li><a href="uploader.aspx?mode=feedback">Feedback</a></li>
       
  </ul>
    <h2>&nbsp;<span style="font-weight:bold; color:#891E18;"><asp:Label ID="lblLoader" runat="server" Text="Label"></asp:Label> </span> 
        </h2>
    <div id="frame"> 
     <iframe id="frmLoader" background-color="transparent" allowTransparency="true" scrolling="auto" runat="server" visible= "false" > </iframe>
     </div>
   
  
</div>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="10000">

                </asp:Timer>
                </ContentTemplate>
    </asp:UpdatePanel>
 
    </form>
    </body>
</html>
