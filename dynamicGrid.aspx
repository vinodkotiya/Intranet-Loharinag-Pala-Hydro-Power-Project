<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dynamicGrid.aspx.vb" Inherits="dynamicGrid" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvMygrid" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" 
                        EmptyDataText="No records found">
                        <Columns>
                        <asp:ButtonField ButtonType="Link" Text="Select" CommandName="SELECT" />
                        <asp:BoundField DataField="cno" HeaderText="cno" SortExpression="cno" />
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                        <asp:BoundField DataField="sub" HeaderText="sub" SortExpression="sub" />
                        <asp:BoundField DataField="filename" HeaderText="filename" SortExpression="filename" />
                        <asp:BoundField DataField="dept" HeaderText="dept" SortExpression="dept" />
                        <asp:BoundField DataField="cdate" HeaderText="cdate" SortExpression="cdate" />
                            <asp:HyperLinkField DataTextField="filename" HeaderText="Open" 
                                Text="filename" />
                    </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="lblDebug" runat="server" Text="Label"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    </asp:UpdatePanel>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    
    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" style="height: 26px" 
        Text="Button" />
        <br />
    <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
