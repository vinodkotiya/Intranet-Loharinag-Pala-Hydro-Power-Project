<%@ Page Language="VB" AutoEventWireup="false" CodeFile="circulars.aspx.vb" Inherits="_Default" %>

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

	<a href="javascript:void(0)">Departments</a>

		<div>
		<a href="">AGM(I/C) Sect.</a>
		<a href="javascript:void(0)">Civil Const</a>

			<div>
			<a href="javascript:void(0)">Barrage</a>
			<a href="javascript:void(0)">HRT</a>
			<a href="javascript:void(0)">Powerhouse</a>
			<a href="javascript:void(0)">Township</a>
			</div>

		<a href="javascript:void(0)">Contracts & Material</a>

			

		<a href="javascript:void(0)">Equipment Erection</a>
        <div>
			<a href="javascript:void(0)">Electrical</a>
			<a href="javascript:void(0)">Mechanical</a>
			<a href="javascript:void(0)">IT</a>
			
			</div>
            <a href="javascript:void(0)">Field Engg Services</a>

			<div>
			<a href="javascript:void(0)">FES</a>
			<a href="javascript:void(0)">EMG</a>
			<a href="javascript:void(0)">FQA</a>
			<a href="javascript:void(0)">Safety</a>
			</div>
		<a href="javascript:void(0)">Finance & Accounts</a>
		<a href="javascript:void(0)">Human Resource</a>
        <div>
			<a href="javascript:void(0)">HR</a>
			<a href="javascript:void(0)">Law</a>
			<a href="javascript:void(0)">PR</a>
            <a href="javascript:void(0)">Hindi</a>
            </div>
        <a href="javascript:void(0)">Information Technology</a>
		<a href="javascript:void(0)">Planning & System</a>
        <div>
			<a href="javascript:void(0)">Daily Report</a>
			<a href="javascript:void(0)">Buiseness Plan</a>
			<a href="javascript:void(0)">Budget</a>
            <div>
			<a href="javascript:void(0)">Planning</a>
			<a href="javascript:void(0)">Review</a>
			<a href="javascript:void(0)">Utilization</a>
			
			</div>
			<a href="javascript:void(0)">Visits</a>
			</div>
        <a href="javascript:void(0)">R&R</a>
         <a href="javascript:void(0)">Vigilance</a>
		
		</div>

	<a href="javascript:void(0)">Imp Links</a>

		<div>
		<a href="http://191.254.186.111/dept/hr/dop2005.pdf">DoP 2005</a>
		<a href="javascript:void(0)">HR Formats</a>
		<a href="javascript:void(0)">F&A Formats</a>
		<a href="http://10.0.5.2:8001/webntpc/hr_homepage_files/corp_hr_circulars.jsp">HR Circulars(CC)</a>
		<a href="http://191.254.198.107/gdams/realview_new2.asp">GDAMS</a>
		<a href="http://191.254.1.211:81/doctracker">DOC Tracker</a>
        <a href="javascript:void(0)">Zigyaasa</a>
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
        <a href="http://www.gmail.com">Gmail</a>
        <a href="http://www.mail.yahoo.com">Yahoo!</a>
        <a href="http://www.rediffmail.com">Rediff</a>
       
		        </div>
		</div>

	<a href="javascript:void(0)">Project</a>

		<div>
		<a href="javascript:void(0)">Project Detail</a>
		<a href="javascript:void(0)">Layout</a>
		<a href="javascript:void(0)">Ongoing Activity</a>
		<a href="javascript:void(0)">Progress</a>
		
		</div> 

<span class="qmclear">&nbsp;</span></div>

<!-- Create Menu Settings: (Menu ID, Is Vertical, Show Timer, Hide Timer, On Click ('all' or 'lev2'), Right to Left, Horizontal Subs, Flush Left, Flush Top) -->
<script type="text/javascript">    qm_create(0, false, 0, 50, false, false, false, false, false);</script>
  <ul id="navlist">
    <li id="active"><a id="current" href="default.aspx">HOME</a></li>
    <li><a href="http://191.254.186.111/erp.aspx">ERP</a></li>
    <li><a href="http://191.254.186.111/mail.aspx">Mail</a></li>
    <li><a href="circulars.aspx">Circulars</a></li>
    <li><a href="http://191.254.186.111/articles.aspx">Articles</a></li>
    <li><a href="http://191.254.186.111/">e-Services</a></li>
    <li><a href="http://191.254.186.111/searchemp.aspx">SearchEmployee</a></li>
    <li><a href="http://191.254.186.111/feedback.aspx">Feedback</a></li>
    <li><a href="http://191.254.186.111/">Links</a></li>
    <li><a href="http://191.254.186.111/">AboutUs</a></li>
  </ul>
  <div id="sidebar-a">
    
    
    <h3><a href="http://191.254.186.111/fotogal.aspx">>></a></h3>
      <p>&nbsp;<asp:Image ID="imgUser" runat="server" class="border"  alt="Loading.." />
      
              
        <center> <asp:Label ID="lblName" runat="server" Text="Guest" Font-Bold="True" 
              ForeColor="#CC33FF"></asp:Label>
     <br />  <asp:Label ID="lblEid" runat="server" Font-Bold="True" ForeColor="#CC33FF"></asp:Label>
     <br />
         
          <asp:Label ID="lblDept" runat="server" Font-Bold="True" ForeColor="#CC33FF"></asp:Label></center> 
      </p>
      <br />
     
      <p>
          &nbsp;</p>
      <p>&nbsp;</p>
  </div>
  
  <div id="vincontent">
    <h2>&nbsp;<span style="font-weight:bold; color:#891E18;">CiRCulars</span> Module</h2>
    <blockquote class="style1">Use This Feature to Add the Circulars, which will be 
        available to everyone through intranet. Use PDF Writer to convert your document 
        in pdf format. </blockquote>
      <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers = "true">
          <ContentTemplate>
         <fieldset ><legend>Enter data</legend>
              <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="Circular No."  Height="16px" 
                  Width="82px"></asp:Label>
              <asp:TextBox ID="txtCno" Height="16px" runat="server"  MaxLength="50" 
                   CssClass= "tbox" Font-Names="Arial" ForeColor="#0066FF" 
                  Wrap="False"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtCno" ErrorMessage="Enter Circular No."></asp:RequiredFieldValidator>
              <br />
              <br />
              <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="Subject : "  Width="75px" Height="20px"></asp:Label>
&nbsp;
              <asp:TextBox ID="txtSub" runat="server" Height="16px" MaxLength="60" 
                   CssClass= "tbox" Font-Names="Arial" ForeColor="#0066FF" 
                  Wrap="False" Width="264px"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="txtSub" ErrorMessage="Enter the Subject" ></asp:RequiredFieldValidator>
              <br />
              <br />
              <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                  ForeColor="#6666FF" Text="Date : " ></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              <asp:TextBox ID="txtDate" runat="server" CssClass= "tbox" Font-Names="Arial" 
                  ForeColor="#0066FF" Wrap="False" Height="16px"></asp:TextBox>
              <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                  Enabled="True" TargetControlID="txtDate">
              </asp:CalendarExtender>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="txtDate" ErrorMessage="Enter Date"></asp:RequiredFieldValidator>
              <br />
              &nbsp;<asp:AsyncFileUpload ID="afuFile" runat="server" UploaderStyle="Modern" 
                  CompleteBackColor="#0099CC" Font-Names="Arial" 
                  ForeColor="#0066FF" UploadingBackColor="#99FF99"  />
              &nbsp;<asp:Label ID="lblMsg" runat="server" Font-Bold="True" 
                  ForeColor="Red"></asp:Label>
              <br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnSubmit" runat="server" Text="Submit" Enabled="False" 
                  class="button" BorderColor="#009900" BorderWidth="2px"/>
              <br />
              <asp:Label ID="lblBy" runat="server" 
                  Text="Please authorize yourself by logging in. click here to " 
                  Font-Bold="True" ForeColor="#0033CC"></asp:Label>
              <asp:HyperLink ID="lbSignin" runat="server" 
                  NavigateUrl="login.aspx?requestedpage=circulars.aspx" Target="_self">Sign In</asp:HyperLink>
                </fieldset> 
          </ContentTemplate>
      </asp:UpdatePanel>
&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>
          <br />
          <asp:Label ID="Label5" runat="server" Text="Search in circulars subject : "></asp:Label>
          <asp:TextBox ID="txtSearch" runat="server" class="tbox" Height="16px"></asp:TextBox>
          <asp:Button ID="btnSearch" runat="server" CausesValidation="False" 
              Text="Search"  class= "button" Height="24px" Width="165px" 
              BorderColor="#009900" BorderWidth="2px" />
          <asp:GridView ID="gvCirculars" runat="server" Height="109px" PageSize="5" 
              Width="754px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                             <asp:BoundField DataField="cno"  ShowHeader="False" >  </asp:BoundField>
                            <asp:HyperLinkField DataTextField="sub" HeaderText="Circulars" 
                                Text="filename" DataNavigateUrlFields="filename" Target="_blank" 
                                DataNavigateUrlFormatString="database/circulars/{0}" >
                            <ItemStyle ForeColor="#FF0066" Width="30%" />
                            </asp:HyperLinkField>
                        <asp:BoundField DataField="cdate" DataFormatString="{0:D}" ShowHeader="False" >
                            <ItemStyle Width="20%" />
                            </asp:BoundField>
                             <asp:BoundField DataField="name"  ShowHeader="False" >  </asp:BoundField>
                             
                    </Columns>
          </asp:GridView>
          <br />
      </ContentTemplate>
      </asp:UpdatePanel>
  <div id="footer"> <a href="http://191.254.186.111/">Homepageesign by  href="">Creative Commons Attribution 3.0 License</a></div>
</div>
    </div>
    <asp:Label ID="lbldebug" runat="server"></asp:Label>
    </form>
    </body>
</html>
