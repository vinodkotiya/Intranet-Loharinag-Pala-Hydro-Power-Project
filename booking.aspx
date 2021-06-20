<%@ Page Language="VB" AutoEventWireup="false" CodeFile="booking.aspx.vb" Inherits="_Default" %>

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
        .style2
        {
            color: #000000;
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
 <li><a href="departments.aspx">SearchEmployee</a></li>
    <li><a href="uploader.aspx?mode=feedback">Feedback</a></li>
       
  </ul>
  <div id="sidebar-a">
    <h2>&nbsp;</h2>
    <div class="menu">
    
    </div>
    <h3>>></h3>
      <p><asp:Image ID="imgUser" runat="server" class="border"  alt="Loading.." />
      
              
        <center> <asp:Label ID="lblName" runat="server" Text="Guest" Font-Bold="True" 
              ForeColor="#CC33FF"></asp:Label>
     <br />  <asp:Label ID="lblEid" runat="server" Font-Bold="True" ForeColor="#CC33FF"></asp:Label>
     <br />
         
          <asp:Label ID="lblDept" runat="server" Font-Bold="True" ForeColor="#CC33FF"></asp:Label></center> </p>
  </div>
  
  <div id="vincontent">
    <h2>&nbsp;<span style="font-weight:bold; color:#891E18;">Welfare Vehicle</span> 
        e-Booking</h2>
    <blockquote class="style1">Use This Feature to online book and cancel the seats in 
        welfare vehicle.
        <br />
        <span class="style2">Uttarkashi to Haridwar: (Tue,Thu,Sat)<br />
        Haridwar to Uttarkashi: (Wed,Fri,Sun)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Driver Cell No:</span></blockquote>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
                &nbsp;
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Journey Date"></asp:Label>
                &nbsp;<asp:TextBox ID="txtDate" runat="server" ValidationGroup="group1" 
                    CssClass="tbox"></asp:TextBox>
                <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDate">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDate" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </ContentTemplate>
     </asp:UpdatePanel>
   <br />
    <asp:Button ID="Button1" runat="server" Text="Show Seats" 
        CausesValidation="False" ValidationGroup="group1" BorderColor="#009933" 
          BorderWidth="2px" CssClass="button" />
  
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  
    <asp:Button ID="Button4" runat="server" Text="Print Journey Date" 
        CausesValidation="False" UseSubmitBehavior="False" ValidationGroup="group5" 
          BorderColor="#009933" BorderWidth="2px" CssClass="button" />
  
    <br />
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" Visible="False">
        <ContentTemplate>
            <asp:Label ID="lblDate" runat="server" Text="Date" Font-Bold="True"></asp:Label>
           <table border="1">
           <tr><td class="tdimage">
            <asp:Label ID="s1" runat="server" Text="seat1" Visible="False" CssClass="vinlabel1" 
                   ForeColor="Blue"></asp:Label>
            <asp:CheckBox ID="cs1" runat="server" Visible="False" 
                ValidationGroup="group2" CssClass="vinlabel2" ForeColor="Red" />
            </td>
            <td class="tdimage">
            <asp:Label ID="s4" runat="server" Text="seat4" Visible="False" CssClass="vinlabel1"></asp:Label>
            <asp:CheckBox ID="cs4" runat="server" CssClass="vinlabel2" ForeColor="Red" />
            </td> <td class="tdimage">
            <asp:Label ID="s7" runat="server" Text="seat7" Visible="False" CssClass="vinlabel1"></asp:Label>
            <asp:CheckBox ID="cs7" runat="server" ValidationGroup="group2" 
                Visible="False" CssClass="vinlabel2" ForeColor="Red" />
                </td><td class="tdimage" >
            <asp:Label ID="s10" runat="server" Text="seat10" Visible="False" CssClass="vinlabel1"></asp:Label>
            <asp:CheckBox ID="cs10" runat="server" CssClass="vinlabel2" ForeColor="Red" />
            </td>
            </tr> 
               <caption>
                   <br />
                   <tr><td class="tdimage">
                   <asp:Label ID="s2" runat="server" Text="seat2" Visible="False" CssClass="vinlabel1"></asp:Label>
                   <asp:CheckBox ID="cs2" runat="server" ValidationGroup="group2" 
                       Visible="False" CssClass="vinlabel2" ForeColor="Red" />
                       </td>
                       <td class="tdimage">
                   <asp:Label ID="s5" runat="server" Text="seat5" Visible="False" CssClass="vinlabel1"></asp:Label>
                   <asp:CheckBox ID="cs5" runat="server" CssClass="vinlabel2" ForeColor="Red" />
                   </td><td class="tdimage">
                   <asp:Label ID="s8" runat="server" Text="seat8" Visible="False" CssClass="vinlabel1"></asp:Label>
                   <asp:CheckBox ID="cs8" runat="server" ValidationGroup="group2" 
                       Visible="False" CssClass="vinlabel2" ForeColor="Red" />
                       </td><td class="tdimage">
                   <asp:Label ID="s11" runat="server" Text="seat11" Visible="False" CssClass="vinlabel1"></asp:Label>
                   <asp:CheckBox ID="cs11" runat="server" CssClass="vinlabel2" ForeColor="Red" />
                   </td>
                   </tr> <tr><td bgcolor="#669999">!</td><td bgcolor="#669999">!</td>
                       <td bgcolor="#669999">!</td><td bgcolor="#669999">!</td></tr>
                   <caption>
                       <br />
                       <tr>
                           <td class="tdimage">
                               <asp:Label ID="s3" runat="server" Text="seat3" Visible="False" 
                                   CssClass="vinlabel1"></asp:Label>
                               <asp:CheckBox ID="cs3" runat="server" ValidationGroup="group2" 
                                   Visible="False" CssClass="vinlabel2" ForeColor="Red" />
                           </td>
                           <td class="tdimage">
                               <asp:Label ID="s6" runat="server" Text="seat6" Visible="False" 
                                   CssClass="vinlabel1"></asp:Label>
                               <asp:CheckBox ID="cs6" runat="server" CssClass="vinlabel2" ForeColor="Red" />
                           </td>
                           <td class="tdimage">
                               <asp:Label ID="s9" runat="server" Text="seat9" Visible="False" 
                                   CssClass="vinlabel1"></asp:Label>
                               <asp:CheckBox ID="cs9" runat="server" ValidationGroup="group2" 
                                   Visible="False" CssClass="vinlabel2" ForeColor="Red" />
                           </td>
                           <td class="tdimage">
                               <asp:Label ID="s12" runat="server" Text="seat12" Visible="False" 
                                   CssClass="vinlabel1"></asp:Label>
                               <asp:CheckBox ID="cs12" runat="server" CssClass="vinlabel2" ForeColor="Red" />
                           </td>
                       </tr>
                   </caption>
               </caption>
            </table>
            <h4>Declaration: </h4><asp:RadioButtonList ID="rbDeclare" runat="server" AutoPostBack="True">
                <asp:ListItem Value="1">On Tour With Approval</asp:ListItem>
                <asp:ListItem Selected="True" Value="2">On Leave</asp:ListItem>
                <asp:ListItem Value="3">Booking For Guest/ Family Member</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            
        </ContentTemplate>
    </asp:UpdatePanel>
            <asp:Button ID="Button2" runat="server" Text="Book Above Seats" Visible="False" 
                CausesValidation="False" ValidationGroup="group2" 
          BorderColor="#009933" BorderWidth="2px" CssClass="button" />
    <br />
    <h3>Your Booking
    History</h3><asp:GridView 
        ID="gvHistorygrid" runat="server" PageSize="5" 
               AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px" Width="404px" BorderColor="#009933">
        <Columns>
            <asp:BoundField DataField="book_date" HeaderText="Journey Date" >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:CommandField HeaderText="Cancel Booking" ShowSelectButton="True" 
                SelectText="Click to Cancel"  >
            <HeaderStyle HorizontalAlign="Left" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <br />
 <h4>  <asp:Label ID="lblCdate" runat="server"></asp:Label> </h4>
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="False">
        <ContentTemplate>
           
           
            <table style="width:62%; table-layout: auto;" border="2px" cellpadding="1px">
                <tr>
                    <td>
                        <asp:Label ID="c1" runat="server" Text="seat1" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc1" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Label ID="c4" runat="server" Text="seat4" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc4" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Label ID="c7" runat="server" Text="seat7" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc7" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                        <td>
                            <asp:Label ID="c10" runat="server" Text="seat10" Visible="False" 
                                CssClass="vinlabel1"></asp:Label>
                            <asp:CheckBox ID="cc10" runat="server" ValidationGroup="group3" 
                                Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="c2" runat="server" Text="seat2" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc2" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Label ID="c5" runat="server" Text="seat5" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc5" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Label ID="c8" runat="server" Text="seat8" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc8" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                        <td>
                            <asp:Label ID="c11" runat="server" Text="seat11" Visible="False" 
                                CssClass="vinlabel1"></asp:Label>
                            <asp:CheckBox ID="cc11" runat="server" ValidationGroup="group3" 
                                Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="c3" runat="server" Text="seat3" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc3" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Label ID="c6" runat="server" Text="seat6" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc6" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                    <td>
                        <asp:Label ID="c9" runat="server" Text="seat9" Visible="False" 
                            CssClass="vinlabel1"></asp:Label>
                        <asp:CheckBox ID="cc9" runat="server" ValidationGroup="group3" 
                            Visible="False" />
                    </td>
                        <td>
                            <asp:Label ID="c12" runat="server" Text="seat12" Visible="False" 
                                CssClass="vinlabel1"></asp:Label>
                            <asp:CheckBox ID="cc12" runat="server" ValidationGroup="group3" 
                                Visible="False" />
                    </td>
                </tr>
                
            </table>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
            <asp:Button ID="Button3" runat="server" Text="Cancel Above Seats" CausesValidation="False" 
                ValidationGroup="group3" BorderColor="#009933" BorderWidth="2px" 
                CssClass="button" />
        </p>
 </div>
</div>
    </form>
    </body>
</html>
