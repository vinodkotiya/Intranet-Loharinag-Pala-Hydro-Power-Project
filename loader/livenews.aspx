<%@ Page Language="VB" AutoEventWireup="false" CodeFile="livenews.aspx.vb" Inherits="livenews" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
   <div>
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
          
 </asp:ToolkitScriptManager>
        <br />
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
            XPath="rss/channel/item" ></asp:XmlDataSource>
   
    </div>
    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"  >
    <ContentTemplate>
         <asp:Label ID="lbError" runat="server" Text="Getting News Feed.. Please Wait for few seconds..." > <asp:Image  ID="imgLoad2" runat="server" ImageUrl="../images/loaderclock.gif"  /> </asp:Label>
      
         <asp:GridView ID="gvln1" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" ForeColor="#333333"
            GridLines="None" Style="position: static" 
             EmptyDataText="No Users Online" Font-Size="9px" Width="698px" BorderColor="#3399FF" 
                      BorderStyle="Dotted" BorderWidth="1px" AllowPaging="true" 
             ShowHeader="False"  >
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerSettings Visible="False" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>

          <asp:TemplateField  ShowHeader="False">
         
          <ItemTemplate>
                 <%#XPath("title")%><br />
                <%#XPath("pubDate")%><br />
                <%#XPath("author")%><br />
                <%#XPath("description")%> 
             </ItemTemplate>
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
            </Columns>
               
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:GridView ID="gvln2" runat="server" AutoGenerateColumns="False" 
            CellPadding="2" ForeColor="#333333"
            GridLines="None" Style="position: static" 
             EmptyDataText="No Users Online" Font-Size="9px" Width="695px" BorderColor="#3399FF" 
                      BorderStyle="Dotted" BorderWidth="1px" AllowPaging="true" 
             ShowHeader="False"  >
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerSettings Visible="False" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>

          <asp:TemplateField  ShowHeader="False">
         
          <ItemTemplate>
                 <%#XPath("title")%><br />
                <%#XPath("pubDate")%><br />
                <%#XPath("author")%><br />
                <%#XPath("description")%> 
             </ItemTemplate>
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>  
            </Columns>
               
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        <asp:Timer ID="Timer2" runat="server" Interval="3000">
        </asp:Timer>
        </ContentTemplate>
        
        </asp:UpdatePanel>

       
    </form>
</body>
</html>
