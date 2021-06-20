<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:vinConn2 %>" 
            SelectCommand="SELECT * FROM [IMChats]"></asp:SqlDataSource>
        SELECT t.ipaddress, t.counter, i.name FROM temp AS t LEFT OUTER JOIN iplist AS i 
        ON t.ipaddress = i.ipaddress WHERE (i.name &lt;&gt; &#39;&#39;)<br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="SenderUserID" HeaderText="SenderUserID" 
                    SortExpression="SenderUserID" />
                <asp:BoundField DataField="RecipientUserID" HeaderText="RecipientUserID" 
                    SortExpression="RecipientUserID" />
                <asp:BoundField DataField="Message" HeaderText="Message" 
                    SortExpression="Message" />
                <asp:BoundField DataField="DateSent" HeaderText="DateSent" 
                    SortExpression="DateSent" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ipaddress" HeaderText="ipaddress" 
                    SortExpression="ipaddress" />
                <asp:BoundField DataField="counter" HeaderText="counter" 
                    SortExpression="counter" />
            </Columns>
        </asp:GridView>
    
        <asp:TextBox ID="txtPing" runat="server" Width="621px"></asp:TextBox>
        <br />
    
    </div>
    </form>
</body>
</html>
