<%@ Page Language="VB" AutoEventWireup="false" CodeFile="sms.aspx.vb" Inherits="sms" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> LPHPP Intranet</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<link href="style.css" rel="stylesheet" type="text/css" />
   <!-- MyCSSMenu Noscript Support [Keep in head for full validation!] -->
<noscript><style type="text/css">.qmmc {width:200px !important;height:200px !important;overflow:scroll;}.qmmc div {position:relative !important;visibility:visible !important;}.qmmc a {float:none !important;white-space:normal !important;}</style></noscript>
<link rel='stylesheet' type='text/css' href='quickmenu.css'/>

<script type='text/javascript' src='quickmenu.js'></script>
    <style type="text/css">
        .style9
        {
            width: 120px;
            height: 26px;
        }
        .style10
        {
            height: 44px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
           <Services>    <asp:ServiceReference Path="vinsmsservice.asmx" /> 
           </Services>
 </asp:ToolkitScriptManager>
     <script type="text/javascript">
         var xPos1, yPos1;
         var xPos2, yPos2;
         var prm = Sys.WebForms.PageRequestManager.getInstance();
         prm.add_beginRequest(BeginRequestHandler);
         prm.add_endRequest(EndRequestHandler);
         function BeginRequestHandler(sender, args) {
             xPos1 = $get('Panel1').scrollLeft;
             yPos1 = $get('Panel1').scrollTop;
             xPos2 = $get('Panel2').scrollLeft;
             yPos2 = $get('Panel2').scrollTop;
         }

         function EndRequestHandler(sender, args) {
             $get('Panel1').scrollLeft = xPos1;
             $get('Panel1').scrollTop = yPos1;
             $get('Panel2').scrollLeft = xPos2;
             $get('Panel2').scrollTop = yPos2;

         }
  </script>
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
  <li><a href="loader.aspx?requestedpage=hindi">&#2361;&#2367;&#2344;&#2381;&#2342;&#2368;</a></li>
    <li><a href="uploader.aspx?mode=feedback">Feedback</a></li>
       
  </ul>
  <div id="sidebar-a">
     
    <h3>>></h3>
    
    
      <p><asp:Image ID="imgUser" runat="server" class="border"  alt="Loading.." />
      
              
        <center> <asp:Label ID="lblName" runat="server" Text="Guest" Font-Bold="True" 
              ForeColor="#CC33FF"></asp:Label>
     <br />  <asp:Label ID="lblEid" runat="server" Font-Bold="True" ForeColor="#CC33FF"></asp:Label>
     <br />
         
          <asp:Label ID="lblDept" runat="server" Font-Bold="True" ForeColor="#CC33FF"></asp:Label></center> </p>
  </div>


 <div id="vincontent">
 <h2>&nbsp;<span style="font-weight:bold; color:#891E18;">Group Messaging</span> 
       System</h2> <blockquote class="style1">Use This Feature to send group SMS within LPHPP. You must have a master password to send ths SMS immediately. If you dont have any then use "review" as master password and your SMS shall be sent later after review.</blockquote>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
        <table> <tr ><td width="300px"> <fieldset><legend>Send SMS</legend> <table> <tr> 
            <td class="style9">
        
                    &nbsp;<asp:Label ID="lblCell" runat="server" Text="Cell No:" 
                        style="font-weight: 700"></asp:Label>
        </td> <td >       
            <asp:TextBox ID="txtCell" runat="server" BorderColor="#009900" 
                BorderStyle="Solid" BorderWidth="2px" CssClass="tbox" Width="123px">+919411103810</asp:TextBox>
            <br /></td> </tr>
            <tr> <td class="style10" >
                <strong>Master Password:</strong> </td> <td class="style10" >    
            <asp:TextBox ID="txtMasterPassword" runat="server" Width="171px" 
                BorderColor="#009900" BorderStyle="Solid" BorderWidth="2px" CssClass="tbox" 
                TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblPwd" runat="server" ForeColor="Red" 
                        Text="Default Password is &quot;review&quot;"></asp:Label>
            <br /> </td> </tr>
            <tr> <td >
                <strong>Select Group: </strong> </td> <td>  
                    <asp:RadioButtonList ID="rblGroup" runat="server" 
                RepeatDirection="Horizontal" Height="26px" Width="280px" RepeatColumns="2">
                <asp:ListItem Value="1">All Employees</asp:ListItem>
                <asp:ListItem Value="2">All HoD's</asp:ListItem>
                <asp:ListItem Value="3">IT Report</asp:ListItem>
                        <asp:ListItem Value="9">Test Group</asp:ListItem>
            </asp:RadioButtonList>
            &nbsp;<br /> </td>  </tr>
            </table>
        
      
            <asp:TextBox ID="txtSMS" runat="server" Height="72px" Width="300px" 
                BorderColor="#009900" BorderStyle="Solid" BorderWidth="2px" CssClass="tbox" 
                TextMode="MultiLine"></asp:TextBox> 
            <asp:Button ID="btnSend" runat="server" Text="Send SMS" BorderColor="#009900" 
                BorderWidth="2px" CssClass="button" />
            
           
            <asp:Label ID="lblLogin" runat="server"></asp:Label>
            
           
            </fieldset>
            </td>
           
            <td >   <asp:Label ID="lblExe" runat="server" Text="Execution" 
                    style="font-weight: 700"></asp:Label> 
                <br />
                <asp:Label ID="lblSent" runat="server" ForeColor="#009900"></asp:Label>
                <br />
                <asp:Panel ID="Panel1" 
                    runat="server" Height="199px" 
                    ScrollBars="Vertical" Width="206px">
                <asp:Label ID="lblCellno" runat="server"></asp:Label>
                </asp:Panel>
            </td>
            <td >
                <asp:Panel ID="Panel2" runat="server" Height="217px" ScrollBars="Vertical" 
                    Width="150px">
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </asp:Panel></td>
            </tr>
            </table>
            <fieldset  Width="600px"  ><legend>SMS Log</legend>
          <asp:GridView ID="gvSMSlog" runat="server" Height="109px" PageSize="10" 
              Width="600px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                             <asp:BoundField DataField="smsid"  ShowHeader="False" 
                                 HeaderText="smsID" >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            <asp:HyperLinkField DataTextField="requestby" HeaderText="Sent By" 
                                Text="requestby" DataNavigateUrlFields="requestby" Target="_blank" 
                                DataNavigateUrlFormatString="departments.aspx?showemp={0}">
                              <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle ForeColor="#FF0066" Font-Size="8pt" />
                            </asp:HyperLinkField>
                        <asp:BoundField DataField="message"  ShowHeader="False" HeaderText="Messgae" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle  Font-Size="8pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="requesttime1"  ShowHeader="False" HeaderText="Time" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="10%" Font-Size="8pt" />
                            </asp:BoundField>
                              <asp:BoundField DataField="groupid"  ShowHeader="False" HeaderText="Group" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="4%" Font-Size="8pt" />
                            </asp:BoundField>
                             <asp:BoundField DataField="status"  ShowHeader="False" HeaderText="Status" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="8%" Font-Size="8pt" />
                            </asp:BoundField>
                             <asp:BoundField DataField="successratio"  ShowHeader="False" HeaderText="Sent" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="5%" Font-Size="8pt" />
                            </asp:BoundField>

                      </Columns>
                     </asp:GridView>
        </fieldset>
            <asp:Timer ID="Timer1" runat="server">
            </asp:Timer>
            
        
        </ContentTemplate>
        </asp:UpdatePanel>
    
    </div>
    </div>
    </form>
</body>
</html>
