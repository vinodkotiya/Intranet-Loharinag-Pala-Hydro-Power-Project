<%@ Page Language="VB" AutoEventWireup="false" CodeFile="query.aspx.vb" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:vinConn %>" 
            SelectCommand="SELECT * FROM [visitors] ORDER BY [ipaddress]">
        </asp:SqlDataSource>
        <asp:TextBox ID="txtQuery" runat="server" Height="23px" Width="480px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Fire" />
        <br />
        <span class="style1">Example Set:</span><br class="style1" />
        <span class="style1">Request.Params(&quot;admin&quot;)</span><br class="style1" />
        <span class="style1">update articles set topic = N&#39;कुछ हिन्दी मे... &#39; where 
        cdate=&#39;5/22/2010&#39;</span><br class="style1" />
        <span class="style1">update emplogin set pwd = &#39;ntpc123&#39; where eid = &#39;009383&#39;</span><br 
            class="style1" />
        <span class="style1">delete from circulars where cdate = &#39;5/22/2010&#39;</span><br 
            class="style1" />
        <span class="style1">insert into emplogin (eid, pwd) values (&#39;009383&#39; &#39;vin&#39;)</span><br 
            class="style1" />
        <span class="style1">insert into iplist (name,ipaddress) values (&#39;Vinod K&#39; , 
        &#39;191.254.186.6&#39;)<br />
        Database Design</span><br />
        <asp:Image ID="Image1" runat="server" ImageUrl="images/dbdesign.jpg" />
          <asp:Image ID="Image2" runat="server" ImageUrl="images/dbdesign2.jpg" />
              <asp:Image ID="Image3" runat="server" ImageUrl="images/dbdesign3.jpg" />
        <br />
    
    </div>
    </form>
</body>
</html>
