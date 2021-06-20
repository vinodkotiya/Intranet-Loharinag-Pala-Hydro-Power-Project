<%@ Page Language="VB" AutoEventWireup="false" CodeFile="departments.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> LPHPP Intranet</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<link href="style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
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
    <li><a href="uploader.aspx?mode=feedback">Feedback</a></li>
       
  </ul>
  <div id="sidebar-a">
    <h2>&nbsp;</h2>
    <div class="menu">
    
    </div>
    <h3>>></h3>
      <p>&nbsp;<img class="border" src="images/gallery.gif" alt="Loading.." /></p>
    <p> <asp:Label ID="lblName" runat="server" Text="Guest" Font-Bold="True" 
              ForeColor="#CC33FF"></asp:Label>
      </p>
  </div>
  
  <div id="vincontent">
    <h2>&nbsp;<span style="font-weight:bold; color:#891E18;">Department</span> 
        InFormation</h2>
    <blockquote class="style1">Get the employees information and various departmental 
        data.</blockquote>
      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
          <ContentTemplate>
          <fieldset> <legend>
              <asp:Label ID="lblDepLink" runat="server" Text="Department Link" 
                  Font-Bold="True" ForeColor="#0066FF"></asp:Label> </legend> 
              <IFRAME id="iframe1" scrolling="auto" runat="server" visible= "false">
              </IFRAME></fieldset>
              <fieldset> <legend> Search ..  </legend> 
              <asp:Label ID="Label16" runat="server" Font-Size="8pt" 
                  Text="Enter Some Keywords to search(eg name, grade, dept)"></asp:Label>
              <asp:TextBox ID="txtSearch" runat="server" class="tbox" Height="16px" 
                  ValidationGroup="tab1"></asp:TextBox>
              <asp:Button ID="btnSearch" runat="server" BorderColor="#009900" 
                  BorderWidth="2px" class="button" Height="24px" Text="Search" 
                  ValidationGroup="tab1" Width="165px" /> </fieldset>
          </ContentTemplate>

      </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
         

          
         <asp:ListView runat="server" ID="lvMylist"   >
  <LayoutTemplate>
   <fieldset> <legend>  <asp:Label ID="lblDepLink" runat="server" Text="Department Link" 
                  Font-Bold="True" ForeColor="#0066FF"> Employee  </asp:Label></legend>
    <table cellpadding="2" runat="server" id="tblEmployees" 
        style="width:100%">
       <tr runat="server" id="itemPlaceholder">
      </tr>
    </table> 
     <asp:DataPager runat="server" ID="DataPager" PageSize="3"  >
      <Fields>
        <asp:NumericPagerField
          ButtonCount="5"
          PreviousPageText="<--"
          NextPageText="-->"    />
      </Fields>
    </asp:DataPager> <br />
   </fieldset>
  </LayoutTemplate>
             
  <ItemTemplate>
   <tr id="Tr1" runat="server" width=100%>
       <td valign="top" colspan="2" align="center" 
           class="EmployeeName" width="20%" >
        <%-- Data-bound content. --%>
        <img class="bordermini"  src='<%#Eval("pic") %>'  onerror="this.src = 'database/pics/default.gif';" />
        </td>
        <td width="30%">
       
  <asp:Label ID="name" runat="server" 
          Text='<%#Eval("name") %>'  CssClass="vinlabel" />  <asp:Label ID="eid" runat="server" 
          Text='<%#Eval("eid") %>' cssclass="vinlabel2"/> <br /> <asp:Label ID="lbDesg" runat="server" 
          Text='<%#Eval("designation") %>' Font-Bold cssclass="vinlabel2" />
          <asp:Label ID="Label2" runat="server" 
          Text='<%#Eval("dept") %>' cssclass="vinlabel2" /> <br />
          <asp:Label ID="Label1" runat="server" cssclass="vinlabel2" Text="Reporting To: "> </asp:Label><a href= 'departments.aspx?showemp=<%# Eval("reportingto")%>'> '<%# Eval("reportingto")%>' </a> <br />
              <asp:Label ID="Label13" runat="server" cssclass="vinlabel2" Text="Cell: "> </asp:Label> <asp:Label ID="Label14" runat="server" 
          Text='<%#Eval("cell") %>' Font-Bold />
          </td>
          <td width="30%">
          <asp:Label ID="Label3" runat="server" cssclass="vinlabel2" Text="Date of Birth: " Font-Bold> </asp:Label> <asp:Label ID="Label4" runat="server" 
         cssclass="vinlabel2" Text='<%#Eval("dob") %>' /><br />
             <asp:Label ID="Label5" runat="server" cssclass="vinlabel2" Text="Blood Group: " Font-Bold> </asp:Label> <asp:Label ID="Label6" runat="server" 
         cssclass="vinlabel2" Text='<%#Eval("bgroup") %>' /><br />
             <asp:Label ID="Label7" runat="server"  cssclass="vinlabel2" Text="Marital Status: " Font-Bold> </asp:Label> <asp:Label ID="Label8" runat="server" 
         cssclass="vinlabel2" Text='<%#Eval("marital") %>' /><br />
             <asp:Label ID="Label9" runat="server" cssclass="vinlabel2" Text="From: " Font-Bold> </asp:Label> <asp:Label ID="Label10" runat="server" 
          cssclass="vinlabel2" Text='<%#Eval("native") %>' /><br />
          <asp:Label ID="Label11" runat="server" cssclass="vinlabel2" Text="Prev Project: " Font-Bold> </asp:Label> <asp:Label ID="Label12" runat="server" 
         cssclass="vinlabel2"  Text='<%#Eval("prevproj") %>' /><br />
          </td>
          <td width="30%">
          <asp:Label ID="Label17" runat="server" cssclass="vinlabel2" Text="phone(o): " Font-Bold> </asp:Label> <asp:Label ID="Label18" runat="server" 
         cssclass="vinlabel2" Text='<%#Eval("phoneo") %>' /><br />
             <asp:Label ID="Label19" runat="server" cssclass="vinlabel2" Text="EPABX: " Font-Bold> </asp:Label> <asp:Label ID="Label20" runat="server" 
          cssclass="vinlabel2" Text='<%#Eval("epabx") %>' /><br />
             <asp:Label ID="Label21" runat="server" cssclass="vinlabel2" Text="Anniversary: " Font-Bold> </asp:Label> <asp:Label ID="Label22" runat="server" 
          cssclass="vinlabel2" Text='<%#Eval("adate") %>' /><br />
             <asp:Label ID="Label23" runat="server" cssclass="vinlabel2" Text="CUG: " Font-Bold> </asp:Label> <asp:Label ID="Label24" runat="server" 
          cssclass="vinlabel2" Text='<%#Eval("cug") %>' /><br />
          <asp:Label ID="Label25" runat="server" cssclass="vinlabel2" Text="Email: " Font-Bold> </asp:Label> <asp:Label ID="Label26" runat="server" 
          cssclass="vinlabel2" Text='<%#Eval("email") %>' /><br />
          </td>
   </tr>
   
       
        
  </ItemTemplate>
</asp:ListView>
  
        
          <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
          <br />
           <fieldset> <legend>
              <asp:Label ID="lblActivity" runat="server" Text="Activity" 
                  Font-Bold="True" ForeColor="#0066FF" Visible="False"></asp:Label> </legend> 
              <IFRAME id="IFRAME2" scrolling="auto" runat="server" visible= "false">
              </IFRAME></fieldset>
      </ContentTemplate>
     </asp:UpdatePanel>
   
       
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
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="10000">

                </asp:Timer>
                </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    </body>
</html>

