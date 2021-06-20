<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Experiment.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="com.flajaxian.FileUploader" namespace="com.flajaxian" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource2">
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="cnoLabel" runat="server" Text='<%# Eval("cno") %>' />
                </td>
                <td>
                    <asp:Label ID="subLabel" runat="server" Text='<%# Eval("sub") %>' />
                </td>
                <td>
                    <asp:Label ID="deptLabel" runat="server" Text='<%# Eval("dept") %>' />
                </td>
                <td>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                </td>
                <td>
                    <asp:Label ID="cdateLabel" runat="server" Text='<%# Eval("cdate") %>' />
                </td>
                <td>
                    <asp:Label ID="cdatetextLabel" runat="server" Text='<%# Eval("cdatetext") %>' />
                </td>
                <td>
                    <asp:Label ID="filenameLabel" runat="server" Text='<%# Eval("filename") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="cnoLabel" runat="server" Text='<%# Eval("cno") %>' />
                </td>
                <td>
                    <asp:Label ID="subLabel" runat="server" Text='<%# Eval("sub") %>' />
                </td>
                <td>
                    <asp:Label ID="deptLabel" runat="server" Text='<%# Eval("dept") %>' />
                </td>
                <td>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                </td>
                <td>
                    <asp:Label ID="cdateLabel" runat="server" Text='<%# Eval("cdate") %>' />
                </td>
                <td>
                    <asp:Label ID="cdatetextLabel" runat="server" Text='<%# Eval("cdatetext") %>' />
                </td>
                <td>
                    <asp:Label ID="filenameLabel" runat="server" Text='<%# Eval("filename") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table 
                
                style="" runat="server">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="cnoTextBox" runat="server" Text='<%# Bind("cno") %>' />
                </td>
                <td>
                    <asp:TextBox ID="subTextBox" runat="server" Text='<%# Bind("sub") %>' />
                </td>
                <td>
                    <asp:TextBox ID="deptTextBox" runat="server" Text='<%# Bind("dept") %>' />
                </td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="cdateTextBox" runat="server" Text='<%# Bind("cdate") %>' />
                </td>
                <td>
                    <asp:TextBox ID="cdatetextTextBox" runat="server" 
                        Text='<%# Bind("cdatetext") %>' />
                </td>
                <td>
                    <asp:TextBox ID="filenameTextBox" runat="server" 
                        Text='<%# Bind("filename") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">
                                    cno</th>
                                <th runat="server">
                                    sub</th>
                                <th runat="server">
                                    dept</th>
                                <th runat="server">
                                    name</th>
                                <th runat="server">
                                    cdate</th>
                                <th runat="server">
                                    cdatetext</th>
                                <th runat="server">
                                    filename</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                        Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="cnoTextBox" runat="server" Text='<%# Bind("cno") %>' />
                </td>
                <td>
                    <asp:TextBox ID="subTextBox" runat="server" Text='<%# Bind("sub") %>' />
                </td>
                <td>
                    <asp:TextBox ID="deptTextBox" runat="server" Text='<%# Bind("dept") %>' />
                </td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="cdateTextBox" runat="server" Text='<%# Bind("cdate") %>' />
                </td>
                <td>
                    <asp:TextBox ID="cdatetextTextBox" runat="server" 
                        Text='<%# Bind("cdatetext") %>' />
                </td>
                <td>
                    <asp:TextBox ID="filenameTextBox" runat="server" 
                        Text='<%# Bind("filename") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="cnoLabel" runat="server" Text='<%# Eval("cno") %>' />
                </td>
                <td>
                    <asp:Label ID="subLabel" runat="server" Text='<%# Eval("sub") %>' />
                </td>
                <td>
                    <asp:Label ID="deptLabel" runat="server" Text='<%# Eval("dept") %>' />
                </td>
                <td>
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                </td>
                <td>
                    <asp:Label ID="cdateLabel" runat="server" Text='<%# Eval("cdate") %>' />
                </td>
                <td>
                    <asp:Label ID="cdatetextLabel" runat="server" Text='<%# Eval("cdatetext") %>' />
                </td>
                <td>
                    <asp:Label ID="filenameLabel" runat="server" Text='<%# Eval("filename") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:Label ID="Label3" runat="server" ForeColor="#006600" Text="Label"></asp:Label>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:vinConn %>" 
        SelectCommand="SELECT * FROM [test]">
    </asp:SqlDataSource>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="cno" HeaderText="cno" SortExpression="cno" />
                    <asp:BoundField DataField="sub" HeaderText="sub" SortExpression="sub" />
                    <asp:BoundField DataField="dept" HeaderText="dept" SortExpression="dept" />
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="cdate" HeaderText="cdate" SortExpression="cdate" />
                    <asp:BoundField DataField="cdatetext" HeaderText="cdatetext" 
                        SortExpression="cdatetext" />
                    <asp:BoundField DataField="filename" HeaderText="filename" 
                        SortExpression="filename" />
                </Columns>
                
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource2">
        <EditItemTemplate>
            cno:
            <asp:TextBox ID="cnoTextBox" runat="server" Text='<%# Bind("cno") %>' />
            <br />
            sub:
            <asp:TextBox ID="subTextBox" runat="server" Text='<%# Bind("sub") %>' />
            <br />
            dept:
            <asp:TextBox ID="deptTextBox" runat="server" Text='<%# Bind("dept") %>' />
            <br />
            name:
            <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
            <br />
            cdate:
            <asp:TextBox ID="cdateTextBox" runat="server" Text='<%# Bind("cdate") %>' />
            <br />
            cdatetext:
            <asp:TextBox ID="cdatetextTextBox" runat="server" 
                Text='<%# Bind("cdatetext") %>' />
            <br />
            filename:
            <asp:TextBox ID="filenameTextBox" runat="server" 
                Text='<%# Bind("filename") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            cno:
            <asp:TextBox ID="cnoTextBox" runat="server" Text='<%# Bind("cno") %>' />
            <br />
            sub:
            <asp:TextBox ID="subTextBox" runat="server" Text='<%# Bind("sub") %>' />
            <br />
            dept:
            <asp:TextBox ID="deptTextBox" runat="server" Text='<%# Bind("dept") %>' />
            <br />
            name:
            <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
            <br />
            cdate:
            <asp:TextBox ID="cdateTextBox" runat="server" Text='<%# Bind("cdate") %>' />
            <br />
            cdatetext:
            <asp:TextBox ID="cdatetextTextBox" runat="server" 
                Text='<%# Bind("cdatetext") %>' />
            <br />
            filename:
            <asp:TextBox ID="filenameTextBox" runat="server" 
                Text='<%# Bind("filename") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            cno:
            <asp:Label ID="cnoLabel" runat="server" Text='<%# Bind("cno") %>' />
            <br />
            sub:
            <asp:Label ID="subLabel" runat="server" Text='<%# Bind("sub") %>' />
            <br />
            dept:
            <asp:Label ID="deptLabel" runat="server" Text='<%# Bind("dept") %>' />
            <br />
            name:
            <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("name") %>' />
            <br />
            cdate:
            <asp:Label ID="cdateLabel" runat="server" Text='<%# Bind("cdate") %>' />
            <br />
            cdatetext:
            <asp:Label ID="cdatetextLabel" runat="server" Text='<%# Bind("cdatetext") %>' />
            <br />
            filename:
            <asp:Label ID="filenameLabel" runat="server" Text='<%# Bind("filename") %>' />
            <br />
        </ItemTemplate>
    </asp:FormView>
    <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" 
        DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
        ForeColor="#990000" StaticSubMenuIndent="10px">
        <StaticSelectedStyle BackColor="#FFCC66" />
        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
        <DynamicMenuStyle BackColor="#FFFBD6" />
        <DynamicItemTemplate>
            <%# Eval("Text") %>
        </DynamicItemTemplate>
        <DynamicSelectedStyle BackColor="#FFCC66" />
        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        <StaticHoverStyle BackColor="#990000" ForeColor="White" />
        <Items>
            <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
            <asp:MenuItem Enabled="False" Text="New Item" Value="New Item"></asp:MenuItem>
            <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
            <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
            <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
            <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
            <asp:MenuItem Text="New Item" Value="New Item"></asp:MenuItem>
        </Items>
    </asp:Menu>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <asp:AsyncFileUpload ID="AsyncFileUpload1"  runat="server" UploaderStyle= "Modern" ThrobberID="img1" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload Async" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:vinConn %>" 
        SelectCommand="SELECT * FROM [circulars]"></asp:SqlDataSource>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>


<asp:PostBackTrigger ControlID="Button2" />
</Triggers>
        <ContentTemplate>
            <asp:FileUpload ID="FileUpload1" runat="server" style="height: 22px" />
            <asp:Button ID="Button2" runat="server" Text="Upload" onclick="Button2_Click" />
            <br />
            <br />
            <asp:AsyncFileUpload ID="AsyncFileUpload2" runat="server" />
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TextBox2">
            </asp:CalendarExtender>
            <asp:Button ID="Button3" runat="server" Text="Submit" />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Image ID="imgProgress" runat="server" />
     
    
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="TextBox3_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="TextBox3">
            </asp:CalendarExtender>
            <asp:Button ID="Button4" runat="server" Text="Button" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvTest" runat="server" 
    AutoGenerateColumns="False"  AllowPaging="True" 
                AllowSorting="True" DataKeyNames="filename">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="filename" HeaderText="filename" ReadOnly="True" 
                        SortExpression="filename" />
                </Columns>
            </asp:GridView>
           
            <asp:GridView ID="gvData" runat="server" AllowPaging="True" AllowSorting="True" 
                 PageSize="2"  >
            </asp:GridView>
           
        </ContentTemplate>
    </asp:UpdatePanel>
     
    
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblDebug" runat="server" Text="Label"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
     
    
    <asp:DataList ID="DataList1" runat="server" DataKeyField="filename" 
        DataSourceID="SqlDataSource1">
        <ItemTemplate>
            name:
            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
            <br />
            filename:
            <asp:Label ID="filenameLabel" runat="server" Text='<%# Eval("filename") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
     
    
    </form>
</body>
</html>
