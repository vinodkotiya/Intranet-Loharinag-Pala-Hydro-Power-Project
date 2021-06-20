<%@ Page Language="VB" AutoEventWireup="false" CodeFile="uploader_old1.aspx.vb" Inherits="_Default" %>

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
    <h2>&nbsp;<span style="font-weight:bold; color:#891E18;">Uploader</span> 
        Module</h2>
    <blockquote class="style1">Use This Feature to Add the Circulars, Articles, News, 
        Events, Reports, Zigyasa Presentation's, Your Data etc.. which will be 
        available to everyone through intranet. Use PDF Writer to convert your document 
        in pdf format.</blockquote>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate >
        <asp:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="6" Height="497px" 
          Width="622px"  
          AutoPostBack="true" >
          <asp:TabPanel runat="server" HeaderText="Circulars" ID="TabPanel1"     >
               <ContentTemplate >
               <fieldset ><legend>Enter Details...</legend> 
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="8pt" 
                  ForeColor="#6666FF" Text="Circular No."  Height="16px" 
                  Width="82px"></asp:Label>
              <asp:TextBox ID="txtCno" Height="16px" runat="server"  MaxLength="50" 
                   CssClass= "tbox" Font-Names="Arial" ForeColor="#0066FF" 
                  Wrap="False" ValidationGroup="tab1"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                  ControlToValidate="txtCno" ErrorMessage="Enter Circular No." 
                 ValidationGroup="tab1"></asp:RequiredFieldValidator>
         
             
                   <br />
         
             
              <br />
           
              <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="8pt"  
                  ForeColor="#6666FF" Text="Subject : "  Width="75px" Height="20px"></asp:Label>
&nbsp;
              <asp:TextBox ID="txtSub" runat="server" Height="16px" MaxLength="60" 
                   CssClass= "tbox" Font-Names="Arial" ForeColor="#0066FF" 
                  Wrap="False" Width="264px" ValidationGroup="tab1"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtSub" ErrorMessage="Enter the Subject" 
                 ValidationGroup="tab1" ></asp:RequiredFieldValidator>
              <br />
              <br />
              <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="8pt" 
                  ForeColor="#6666FF" Text="Date : " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtDate" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="16px" ValidationGroup="tab1"></asp:TextBox>
              <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                  Enabled="True" TargetControlID="txtDate">
              </asp:CalendarExtender>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="txtDate" ErrorMessage="Enter Date" 
                 ValidationGroup="tab1"></asp:RequiredFieldValidator>
              <br />
              &nbsp;<asp:AsyncFileUpload ID="afuFile" runat="server" UploaderStyle="Modern" 
                  CompleteBackColor="#0099CC" Font-Names="Arial" 
                  ForeColor="#0066FF" UploadingBackColor="#99FF99" Visible="False" 
                       FailedValidation="False"   />
              &nbsp;<asp:Label ID="lblMsg" runat="server" Font-Bold="True" 
                  ForeColor="Red"></asp:Label>
              <br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="False" 
                  class="button" BorderColor="#009900" BorderWidth="2px" 
                 ValidationGroup="tab1"/>
              
              <br />
              <asp:Label ID="lblBy" runat="server" 
                  Text="Please authorize yourself by Signing in. click here to " 
                  Font-Bold="True" ForeColor="#0033CC" Font-Size="8pt"></asp:Label>
              <asp:HyperLink ID="lbSignin" runat="server" 
                  NavigateUrl="login.aspx?requestedpage=uploader.aspx?mode=circulars" 
                 Target="_self">Sign In</asp:HyperLink>
               </fieldset> 

               <fieldset><legend>Search...</legend>
                    <asp:Label ID="Label8" runat="server" Text="Search in circulars subject : " Font-Size="8pt"></asp:Label>
          <asp:TextBox ID="txtSearch" runat="server" class="tbox" Height="16px" ValidationGroup="tab11"></asp:TextBox>
          <asp:Button ID="btnSearch" runat="server" CausesValidation="False" 
              Text="Search"  class= "button" Height="24px" Width="165px" 
              BorderColor="#009900" BorderWidth="2px" ValidationGroup="tab11" />
          <asp:GridView ID="gvCirculars" runat="server" Height="109px" PageSize="5" 
              Width="611px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                             <asp:BoundField DataField="cno"  ShowHeader="False" 
                                 HeaderText="C. No." >  
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            <asp:HyperLinkField DataTextField="sub" HeaderText="Subject" 
                                Text="filename" DataNavigateUrlFields="filename" Target="_blank" 
                                DataNavigateUrlFormatString="database/circulars/{0}">
                              <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle ForeColor="#FF0066" Width="30%" Font-Size="8pt" />
                            </asp:HyperLinkField>
                        <asp:BoundField DataField="cdate1"  ShowHeader="False" HeaderText="Date" >
                            <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                             <asp:HyperLinkField DataNavigateUrlFields="eid" 
                                 DataNavigateUrlFormatString="departments.aspx?showemp={0}" DataTextField="name" 
                                 HeaderText="Uploaded By" Text="name">
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:HyperLinkField>
                             
                      </Columns>
                     </asp:GridView>
                   </fieldset>
                </ContentTemplate >
           </asp:TabPanel>
           <asp:TabPanel runat="server" HeaderText="Articles" ID="TabPanel2"     >
                <ContentTemplate >
                 <fieldset ><legend>Enter Details...</legend> 
               <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#6666FF" Height="20px" Text="Topic: " Width="75px"></asp:Label>
                          <asp:TextBox ID="txtSub0" runat="server" CssClass="tbox" Font-Names="Arial" 
                              ForeColor="#0066FF" Height="16px" MaxLength="60" Width="264px" 
                              Wrap="False" ValidationGroup="tab2"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                              ControlToValidate="txtSub0" ErrorMessage="Enter the Topic" 
                              ValidationGroup="tab2"></asp:RequiredFieldValidator>
                          <br />
                           <br />
                  &nbsp;<asp:AsyncFileUpload ID="afuFile0" runat="server" CompleteBackColor="#0099CC" 
                      Font-Names="Arial" ForeColor="#0066FF" UploaderStyle="Modern" 
                      UploadingBackColor="#99FF99" FailedValidation="False" Visible="False" /><br />
                          <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                           <br />
                          <br /><asp:Button ID="btnsubmit0" runat="server" Text="Submit" 
                              ValidationGroup="tab2" BorderColor="#669900" BorderWidth="2px" 
                              CssClass="button" Enabled="False" />
                          <asp:Label ID="lblBy0" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#0033CC" 
                              Text="Please authorize yourself. click here to "></asp:Label>
                          <asp:HyperLink ID="lbSignin0" runat="server" 
                              NavigateUrl="login.aspx?requestedpage=uploader.aspx?mode=articles" 
                              Target="_self">Sign In</asp:HyperLink>
                </fieldset> 
                <fieldset><legend>Search</legend>
                <asp:Label ID="Label9" runat="server" Font-Size="8pt" 
                              Text="Search in Articles topic : "></asp:Label>
                          <asp:TextBox ID="txtSearch0" runat="server" class="tbox" Height="16px" 
                              ValidationGroup="tab2"></asp:TextBox>
                          <asp:Button ID="btnSearch0" runat="server" BorderColor="#009900" 
                              BorderWidth="2px" CausesValidation="False" class="button" Height="24px" 
                              Text="Search" Width="165px" ValidationGroup="tab2" />
                          <br />
                          <asp:GridView ID="gvCirculars0" runat="server" AllowPaging="True" 
                              AutoGenerateColumns="False" BorderWidth="2px" EmptyDataText="No records found" 
                              GridLines="None" Height="109px" PageSize="5" Width="599px">
                              <Columns>
                                  <asp:HyperLinkField DataNavigateUrlFields="filename" 
                                      DataNavigateUrlFormatString="database/circulars/{0}" DataTextField="topic" 
                                      HeaderText="Topic" Target="_blank" Text="filename" >
                                  <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                                  <ItemStyle ForeColor="#FF0066" Width="50%" Font-Size="8pt" />
                                  </asp:HyperLinkField>
                                  <asp:BoundField DataField="cdate1"  HeaderText="Date" ShowHeader="False">
                                 <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                                  <ItemStyle Width="20%" Font-Size="8pt" />
                                  </asp:BoundField>
                                  <asp:HyperLinkField DataNavigateUrlFields="eid" 
                                      DataNavigateUrlFormatString="departments.aspx?showemp={0}" DataTextField="name" 
                                      HeaderText="Uploaded By:">
                                  <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                                  </asp:HyperLinkField>
                              </Columns>
                          </asp:GridView>
                
                </fieldset>
                </ContentTemplate >
           </asp:TabPanel>
           <asp:TabPanel runat="server" HeaderText="File_sharing" ID="TabPanel3"     >
                <ContentTemplate >
                 <fieldset ><legend>Enter Details...</legend> 
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#6666FF" Height="29px" 
                              Text="Please choose your file to upload on server. A link will be generated, which can be shared to download your files on other PC's. Max file size is limited to 40 MB. Files will be deleted automatically within 15 days from date of upload." 
                              Width="625px"></asp:Label>
                    
                          <br />
                          <br /><asp:AsyncFileUpload ID="afufile1" runat="server" CompleteBackColor="#0099CC" 
                      Font-Names="Arial" ForeColor="#0066FF" UploaderStyle="Modern" 
                      UploadingBackColor="#99FF99" FailedValidation="False" Visible="False" /><br />
                          <br />
                          <asp:Label ID="lblshare" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#0033CC" Text="Link shall be generated here."></asp:Label>
                          <br />
                          <asp:TextBox ID="txtLink" runat="server" Height="21px" ReadOnly="True" 
                              Visible="False" Width="563px" ValidationGroup="tab3"></asp:TextBox>
                          <br />
                          <asp:Button ID="btnSubmit1" runat="server" BorderColor="#009900" 
                              BorderWidth="2px" CssClass="button" Text="Submit" ValidationGroup="tab3" 
                              Enabled="False" />
                          <asp:Label ID="lblBy1" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#0033CC" Text="Please authorize yourself. click here to "></asp:Label>
                          <asp:HyperLink ID="lbSignin1" runat="server" 
                              NavigateUrl="login.aspx?requestedpage=uploader.aspx?mode=ftp" 
                              Target="_self">Sign In</asp:HyperLink>


                </fieldset> 
                </ContentTemplate >
           </asp:TabPanel>
           <asp:TabPanel runat="server" HeaderText="Feedback" ID="TabPanel4"     >
                <ContentTemplate >
                 <fieldset ><legend>Your Feedback Plz...</legend> 
               <asp:TextBox ID="txtSub1" runat="server" Font-Names="Arial" 
                              ForeColor="#0066FF" Height="120px" MaxLength="400" ValidationGroup="tab4" 
                              Width="392px" Wrap="False" TextMode="MultiLine" CssClass="tbox">Name:</asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                              ControlToValidate="txtSub1" 
                              ErrorMessage="You have forgot to enter the feedback." ValidationGroup="tab4"></asp:RequiredFieldValidator>
                          <br />
                          <br />
                          <asp:Button ID="btnsubmit2" runat="server" BorderColor="#009900" 
                              BorderWidth="2px" CssClass="button" Text="Submit" ValidationGroup="tab4" />
                          <br />
                          <asp:Label ID="lblBy2" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#0033CC" Text="Give Feedback as Guest or "></asp:Label>
                          <asp:HyperLink ID="lbSignin2" runat="server" 
                              NavigateUrl="login.aspx?requestedpage=uploader.aspx?mode=feedback" 
                              Target="_self">Sign In</asp:HyperLink>
              <br />
                </fieldset> 
                <fieldset ><legend>Feedback History...</legend> 
                
                <asp:GridView ID="gvCirculars1" runat="server" AllowPaging="True" 
                              AutoGenerateColumns="False" BorderWidth="2px" EmptyDataText="No records found" 
                              GridLines="None" Height="109px" Width="609px">
                              <Columns>
                                  <asp:BoundField DataField="feedback" HeaderText="Feedback">
                                  <ItemStyle Width="60%" BackColor="#CCFF66" BorderColor="#009900" 
                                      BorderWidth="2px" ForeColor="Blue" />
                                       <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="fdate1" DataFormatString="{0:D}" HeaderText="Date" 
                                      ShowHeader="False">
                                  <ItemStyle BorderColor="#009900" BorderWidth="2px" Font-Size="8pt" />
                                   <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="fby" HeaderText="By:" 
                                      ShowHeader="False">
                                  <ItemStyle Font-Size="8pt" Width="20%" BorderColor="#009900" 
                                      BorderWidth="2px" />
                                       <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                                  </asp:BoundField>
                              </Columns>
                          </asp:GridView>
                </fieldset>
                </ContentTemplate >
           </asp:TabPanel>
           <asp:TabPanel runat="server" HeaderText="Reports" ID="TabPanel5"     >
                <ContentTemplate >
                 <fieldset ><legend>Enter Details...</legend> 
              <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#6666FF" Height="18px" Text="Enter Report Date: " 
                         Width="166px"></asp:Label> <asp:TextBox ID="txtDate0" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="16px" ValidationGroup="tab5"></asp:TextBox>
              <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                  Enabled="True" TargetControlID="txtDate0">
              </asp:CalendarExtender>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtDate0" ErrorMessage="Enter Date" 
                 ValidationGroup="tab5"></asp:RequiredFieldValidator>
                     <br />
                     <br />
                     <asp:AsyncFileUpload ID="afufile4" runat="server" UploaderStyle="Modern" 
                  CompleteBackColor="#0099CC" Font-Names="Arial" 
                  ForeColor="#0066FF" UploadingBackColor="#99FF99" Visible="False" 
                       FailedValidation="False"  />
                         
              <br />
             
              &nbsp;<asp:Label ID="lblMsg4" runat="server" Font-Bold="True" 
                  ForeColor="Red"></asp:Label>
              <br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnSubmit4" runat="server" Text="Submit" Enabled="False" 
                  class="button" BorderColor="#009900" BorderWidth="2px" 
                 ValidationGroup="tab5"/>
              
        
                     <br />
              
        
              <asp:Label ID="lblBy4" runat="server" 
                  Text="Please authorize yourself by Signing in. click here to " 
                  Font-Bold="True" ForeColor="#0033CC" Font-Size="8pt"></asp:Label>
              <asp:HyperLink ID="lbsignin4" runat="server" 
                  NavigateUrl="login.aspx?requestedpage=uploader.aspx?mode=reports" 
                 Target="_self">Sign In</asp:HyperLink>
              <br />


                </fieldset> 

                <fieldset><legend>Search...</legend>
                    <asp:Label ID="Label5" runat="server" Text="Search By Dept : " Font-Size="8pt"></asp:Label>
          <asp:TextBox ID="txtSearch4" runat="server" class="tbox" Height="16px" ValidationGroup="tab11"></asp:TextBox>
          <asp:Button ID="btnSearch4" runat="server" CausesValidation="False" 
              Text="Search"  class= "button" Height="24px" Width="165px" 
              BorderColor="#009900" BorderWidth="2px" ValidationGroup="tab11" />
          <asp:GridView ID="gvCirculars4" runat="server" Height="109px" PageSize="5" 
              Width="608px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                            <asp:HyperLinkField DataTextField="filename" HeaderText="Report" 
                                Text="filename" DataNavigateUrlFields="filename" Target="_blank" 
                                DataNavigateUrlFormatString="database/reports/{0}">
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                            <ItemStyle ForeColor="#FF0066" Width="50%" Font-Size="8pt" />
                            </asp:HyperLinkField>
                        <asp:BoundField DataField="cdate1"  ShowHeader="False" HeaderText="Date" >
                             <HeaderStyle HorizontalAlign="Left" BackColor="#009900" ForeColor="White" />
                            <ItemStyle Width="20%" Font-Size="8pt" />
                            </asp:BoundField>
                             <asp:BoundField DataField="dept" HeaderText="Dept" >
                              <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                                </asp:BoundField>
                             <asp:HyperLinkField DataNavigateUrlFields="eid" 
                                 DataNavigateUrlFormatString="departments.aspx?showemp={0}" DataTextField="eid" 
                                 HeaderText="Uploaded By" Text="eid">
                              <HeaderStyle HorizontalAlign="Left" BackColor="#009933" ForeColor="White" />
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:HyperLinkField>
                             
                      </Columns>
                     </asp:GridView>
                   </fieldset>
                </ContentTemplate >
           </asp:TabPanel>
           <asp:TabPanel runat="server" HeaderText="Zigyaasa" ID="TabPanel6"     >
                <ContentTemplate >
                 <fieldset ><legend>Knowledge Sharing...</legend> 
               <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="8pt" 
                  ForeColor="#6666FF" 
                         Text="This has been merged with Articles.  Please upload all Zigyaasa Presentation , in article section."  Height="16px" 
                  Width="601px"></asp:Label>
             
              <br />


                </fieldset> 
                </ContentTemplate >
           </asp:TabPanel>
           <asp:TabPanel runat="server" HeaderText="Profile Pic" ID="TabPanel7"     >
                <ContentTemplate >
                 <fieldset ><legend>Upload your new profile picture...</legend> 
               <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="8pt" 
                  ForeColor="#6666FF" 
                         Text="Here users can upload there profile picture. It will automatically get resized."  Height="16px" 
                  Width="601px"></asp:Label>


                </fieldset> 
                </ContentTemplate >
           </asp:TabPanel>
         </asp:TabContainer>
        </ContentTemplate >
     </asp:UpdatePanel>
   
 </div>
</div>
    </form>
    </body>
</html>
