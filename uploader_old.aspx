<%@ Page Language="VB" AutoEventWireup="false" CodeFile="uploader_old.aspx.vb" Inherits="_Default" %>

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
<script type='text/javascript' src='hindikb.js'></script>
<script type='text/javascript' src='quickmenu.js'></script>
<script type="text/javascript">
    function ActiveTabChanged(sender, e) {
        __doPostBack('TabContainer1_ActiveTabChanged', ''); 
    }
    function articlesubmitclick(sender, e) {
        __doPostBack('btnSubmit0_Click', '');
    }
    
</script>
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
       
        <a href="javascript:void(0)">Search</a>

		<div>
		<a href="javascript:void(0)">Search Employee</a>
		<a href="uploader.aspx?mode=circulars">Search Circulars</a>
		<a href="uploader.aspx?mode=articles">Search Articles</a>

		
		</div> 
<span class="qmclear">&nbsp;</span></div>

<!-- Create Menu Settings: (Menu ID, Is Vertical, Show Timer, Hide Timer, On Click ('all' or 'lev2'), Right to Left, Horizontal Subs, Flush Left, Flush Top) -->
<script type="text/javascript">    qm_create(0, false, 0, 50, false, false, false, false, false);</script>
  <ul id="navlist">
    <li id="active"><a id="current" href="default.aspx">HOME</a></li>
    <li><a href="http://191.254.186.111/erp.aspx">ERP</a></li>
    <li><a href="http://191.254.186.111/mail.aspx">Mail</a></li>
   <li><a href="uploader.aspx?mode=circulars">Circulars</a></li>
    <li><a href="uploader.aspx?mode=articles">Articles</a></li>
    <li><a href="uploader.aspx?mode=ftp">File Sharing</a></li>
    <li><a href="departments.aspx">SearchEmployee</a></li>
    <li><a href="http://191.254.186.111/feedback.aspx">Feedback</a></li>
    <li><a href="http://191.254.186.111/">Links</a></li>
    <li><a href="http://191.254.186.111/">AboutUs</a></li>
  </ul>
  <div id="sidebar-a">
    
    
    <h3><a href="http://191.254.186.111/fotogal.aspx">>></a></h3>
    <script language="javascript">
        CreateCustomHindiTextArea("id 1", "यहां हिन्दी मे लिखें और Copy-Paste करें", 15, 5, false);
</script>
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
    <h2>&nbsp;<span style="font-weight:bold; color:#891E18;">UPLOADER</span> Module</h2>
    <blockquote class="style1">Use This Feature to Add the Circulars, Articles, News, 
        Events, Your Data. which will be 
        available to everyone through intranet. Use PDF Writer to convert your document 
        in pdf format. </blockquote>
        
<asp:TabContainer 
          ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="497px" 
          Width="755px" OnClientActiveTabChanged="ActiveTabChanged" 
          AutoPostBack="true"  >
          <asp:TabPanel runat="server" HeaderText="Circulars" ID="TabPanel1"     >

              <ContentTemplate >
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                      <ContentTemplate>
                       
         <fieldset ><legend>Enter Details...</legend>
              <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="8pt" 
                  ForeColor="#6666FF" Text="Circular No."  Height="16px" 
                  Width="82px"></asp:Label>
              <asp:TextBox ID="txtCno" Height="16px" runat="server"  MaxLength="50" 
                   CssClass= "tbox" Font-Names="Arial" ForeColor="#0066FF" 
                  Wrap="False" ValidationGroup="tab1"></asp:TextBox> 
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtCno" ErrorMessage="Enter Circular No." 
                 ValidationGroup="tab1"></asp:RequiredFieldValidator>
              <br />
              <br />
              <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="8pt"  
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
              <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="8pt" 
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
                  ForeColor="#0066FF" UploadingBackColor="#99FF99" Visible="False"   />
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
                            <br />
         
                          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                              <ContentTemplate>
                                  <fieldset><legend>Search...</legend>
                    <asp:Label ID="Label5" runat="server" Text="Search in circulars subject : " Font-Size="8pt"></asp:Label>
          <asp:TextBox ID="txtSearch" runat="server" class="tbox" Height="16px" ValidationGroup="tab1"></asp:TextBox>
          <asp:Button ID="btnSearch" runat="server" CausesValidation="False" 
              Text="Search"  class= "button" Height="24px" Width="165px" 
              BorderColor="#009900" BorderWidth="2px" ValidationGroup="tab1" />
          <asp:GridView ID="gvCirculars" runat="server" Height="109px" PageSize="5" 
              Width="754px" AllowPaging="True" 
                 AutoGenerateColumns="False" 
                        EmptyDataText="No records found" GridLines="None" 
              BorderWidth="2px">
                        <Columns>
                             <asp:BoundField DataField="cno"  ShowHeader="False" ItemStyle-Font-Size ="8pt" 
                                 HeaderText="C. No." >  
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle Font-Size="8pt" />
                             </asp:BoundField>
                            <asp:HyperLinkField DataTextField="sub" HeaderText="Subject" 
                                Text="filename" DataNavigateUrlFields="filename" Target="_blank" 
                                DataNavigateUrlFormatString="database/circulars/{0}"  
                                 ItemStyle-Font-Size ="8pt">
                             <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle ForeColor="#FF0066" Width="30%" />
                            </asp:HyperLinkField>
                        <asp:BoundField DataField="cdate1"  ShowHeader="False" 
                                 ItemStyle-Font-Size ="8pt" HeaderText="Date" >
                             <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                            </asp:BoundField>
                             <asp:HyperLinkField DataNavigateUrlFields="eid" 
                                 DataNavigateUrlFormatString="departments.aspx?showemp={0}" DataTextField="name" 
                                 HeaderText="Uploaded By" Text="name">
                             <HeaderStyle HorizontalAlign="Left" />
                             <ItemStyle HorizontalAlign="Left" />
                             </asp:HyperLinkField>
                             
                    </Columns>
          </asp:GridView>
     </fieldset>
                              </ContentTemplate>
                          </asp:UpdatePanel>
                      </ContentTemplate>
                  </asp:UpdatePanel>
              </ContentTemplate>
           
          </asp:TabPanel>
          <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Articles">
              <HeaderTemplate>
                  Articles
              </HeaderTemplate>

              <ContentTemplate>
                  <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                      <ContentTemplate> <fieldset><legend> Enter Details </legend>
                          <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="8pt" 
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
                   </fieldset>    </ContentTemplate>
                  </asp:UpdatePanel>
                  <br /> 
                 

                  <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                      <ContentTemplate>
                          <asp:Label ID="Label8" runat="server" Font-Size="8pt" 
                              Text="Search in Articles topic : "></asp:Label>
                          <asp:TextBox ID="txtSearch0" runat="server" class="tbox" Height="16px" 
                              ValidationGroup="tab2"></asp:TextBox>
                          <asp:Button ID="btnSearch0" runat="server" BorderColor="#009900" 
                              BorderWidth="2px" CausesValidation="False" class="button" Height="24px" 
                              Text="Search" Width="165px" ValidationGroup="tab2" />
                          <br />
                          <asp:GridView ID="gvCirculars0" runat="server" AllowPaging="True" 
                              AutoGenerateColumns="False" BorderWidth="2px" EmptyDataText="No records found" 
                              GridLines="None" Height="109px" PageSize="5" Width="754px">
                              <Columns>
                                  <asp:HyperLinkField DataNavigateUrlFields="filename" 
                                      DataNavigateUrlFormatString="database/articles/{0}" DataTextField="topic" 
                                      HeaderText="Topic" ItemStyle-Font-Size="8pt" Target="_blank" Text="filename" >
                                  <HeaderStyle HorizontalAlign="Left" />
                                  <ItemStyle ForeColor="#FF0066" Width="50%" />
                                  </asp:HyperLinkField>
                                  <asp:BoundField DataField="cdate1"  HeaderText="Date" 
                                      ItemStyle-Font-Size="8pt" ShowHeader="False">
                                  <HeaderStyle HorizontalAlign="Left" />
                                  <ItemStyle Width="20%" />
                                  </asp:BoundField>
                                  <asp:HyperLinkField DataNavigateUrlFields="eid" 
                                      DataNavigateUrlFormatString="departments.aspx?showemp={0}" DataTextField="name" 
                                      HeaderText="Uploaded By:">
                                  <HeaderStyle HorizontalAlign="Left" />
                                  </asp:HyperLinkField>
                              </Columns>
                          </asp:GridView>
                      </ContentTemplate>
                  </asp:UpdatePanel>

              </ContentTemplate>

          </asp:TabPanel>
          <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="File Sharing">
              <ContentTemplate>
              <fieldset> <legend>Enter Details</legend>
                  <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                      <ContentTemplate>
                          <br />
                          <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#6666FF" Height="29px" 
                              Text="Please choose your file to upload on server. A link will be generated, which can be shared to download your files on other PC's. Max file size is limited to 40 MB. Files will be deleted automatically within 15 days from date of upload." 
                              Width="625px"></asp:Label>
                     </fieldset> 
                          <br />
                          <br /><asp:AsyncFileUpload ID="afufile1" runat="server" CompleteBackColor="#0099CC" 
                      Font-Names="Arial" ForeColor="#0066FF" UploaderStyle="Modern" 
                      UploadingBackColor="#99FF99" FailedValidation="False" Visible="False" /><br />
                          <br />
                          <asp:Label ID="lblshare" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#0033CC" Text="Link shall be generated here."></asp:Label>
                          <br />
                          <asp:TextBox ID="txtLink" runat="server" Height="21px" ReadOnly="True" 
                              Visible="False" Width="563px"></asp:TextBox>
                          <br />
                          <asp:Button ID="btnSubmit1" runat="server" BorderColor="#009900" 
                              BorderWidth="2px" CssClass="button" Text="Submit" ValidationGroup="tab3" 
                              Enabled="False" />
                          <asp:Label ID="lblBy1" runat="server" Font-Bold="True" Font-Size="8pt" 
                              ForeColor="#0033CC" Text="Please authorize yourself. click here to "></asp:Label>
                          <asp:HyperLink ID="lbSignin1" runat="server" 
                              NavigateUrl="login.aspx?requestedpage=uploader.aspx?mode=ftp" 
                              Target="_self">Sign In</asp:HyperLink>
                      </ContentTemplate>
                  </asp:UpdatePanel>&nbsp;
              </ContentTemplate>
          </asp:TabPanel>
          <asp:TabPanel ID="tabpanel4" runat="server" HeaderText ="News"> <ContentTemplate>
          
             <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                      <ContentTemplate>
                          <br /> <fieldset><legend>Please give Feedback:</legend> 
                          <asp:TextBox ID="txtSub1" runat="server" Font-Names="Arial" 
                              ForeColor="#0066FF" Height="50px" MaxLength="60" ValidationGroup="tab4" 
                              Width="392px" Wrap="False" TextMode="MultiLine"></asp:TextBox>
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
                              NavigateUrl="login.aspx?requestedpage=uploader.aspx?mode=circulars" 
                              Target="_self">Sign In</asp:HyperLink>
                      </fieldset></ContentTemplate>
                  </asp:UpdatePanel> &nbsp;
                  <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                      <ContentTemplate>
                          <asp:GridView ID="gvCirculars1" runat="server" AllowPaging="True" 
                              AutoGenerateColumns="False" BorderWidth="2px" EmptyDataText="No records found" 
                              GridLines="None" Height="109px" PageSize="5" Width="754px">
                              <Columns>
                                  <asp:BoundField DataField="feedback" HeaderText="Feedback">
                                  <ItemStyle Width="60%" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="fdate" DataFormatString="{0:D}" HeaderText="Date" 
                                      ItemStyle-Font-Size="8pt" ShowHeader="False"></asp:BoundField>
                                  <asp:BoundField DataField="fby" HeaderText="By:" ItemStyle-Font-Size="8pt" 
                                      ShowHeader="False">
                                  <ItemStyle Font-Size="8pt" Width="20%" />
                                  <ItemStyle Font-Size="8pt" />
                                  </asp:BoundField>
                              </Columns>
                          </asp:GridView>
                      </ContentTemplate>
                  </asp:UpdatePanel>
          
          </ContentTemplate></asp:TabPanel>
           
      </asp:TabContainer>
      </div>
  <div id="footer"> </div>

    </div>
    <asp:Label ID="lbldebug" runat="server"></asp:Label>
    </form>
    </body>
</html>
