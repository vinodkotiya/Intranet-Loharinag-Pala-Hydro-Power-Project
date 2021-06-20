<%@ Page Language="VB" AutoEventWireup="false" CodeFile="print.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
        #form1
        {
            width: 629px;
        }
    </style>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <asp:Label ID="Label2" runat="server" Text="Welfare Vehicle Booking - LPHPP" 
        Font-Bold="True" Font-Size="Large" ForeColor="#3333CC"></asp:Label>
   
    <br />
           <br />
           <asp:Label ID="lblDate" runat="server" Text="Date" 
        style="text-align: center" Font-Bold="True" ForeColor="#660033"></asp:Label>
   
    <br />
   
    <br />
   
   <table border ="1" 
        style="height: 177px; width: 594px;
        "#99FF99" bgcolor="#CCCCFF">
       <tr>
   <td class="style1" width=30% bgcolor="#00CC00">
       <asp:Label ID="Label3" runat="server" Text="Seat No." ForeColor="Blue" 
           Font-Bold="True" Font-Size="Medium"></asp:Label>
       </td><td class="style1" width=70% bgcolor="#00CC00">
           <asp:Label ID="Label5" runat="server" Text="Person" ForeColor="Blue" 
                   Font-Bold="True" Font-Size="Medium"></asp:Label>
       </td>
   </tr>
   
   <tr>
   <td class="style1" width=30%>
       <asp:Label ID="Label1" runat="server" Text="Seat1" CssClass="vinlabel"></asp:Label>
       </td><td class="style1" width=70%>
           <asp:Label ID="lblSeat1" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td class="style1" bgcolor="#FFFFCC">
       <asp:Label ID="Label4" runat="server" Text="Seat2" CssClass="vinlabel"></asp:Label>
       </td><td class="style1" bgcolor="#FFFFCC">
           <asp:Label ID="lblSeat2" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td>
       <asp:Label ID="Label7" runat="server" Text="Seat3" CssClass="vinlabel"></asp:Label>
       </td><td>
           <asp:Label ID="lblSeat3" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td bgcolor="#FFFFCC">
       <asp:Label ID="Label10" runat="server" Text="Seat4" CssClass="vinlabel"></asp:Label>
       </td><td bgcolor="#FFFFCC">
           <asp:Label ID="lblSeat4" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td>
       <asp:Label ID="Label13" runat="server" Text="Seat5" CssClass="vinlabel"></asp:Label>
       </td><td>
           <asp:Label ID="lblSeat5" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td bgcolor="#FFFFCC">
       <asp:Label ID="Label16" runat="server" Text="Seat6" CssClass="vinlabel"></asp:Label>
       </td><td bgcolor="#FFFFCC">
           <asp:Label ID="lblSeat6" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td class="style1">
       <asp:Label ID="Label19" runat="server" Text="Seat7" CssClass="vinlabel"></asp:Label>
       </td><td class="style1">
           <asp:Label ID="lblSeat7" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td bgcolor="#FFFFCC">
       <asp:Label ID="Label22" runat="server" Text="Seat8" CssClass="vinlabel"></asp:Label>
       </td><td bgcolor="#FFFFCC">
           <asp:Label ID="lblSeat8" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td>
       <asp:Label ID="Label25" runat="server" Text="Seat9" CssClass="vinlabel"></asp:Label>
       </td><td>
           <asp:Label ID="lblSeat9" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td bgcolor="#FFFFCC">
       <asp:Label ID="Label28" runat="server" Text="Seat10" CssClass="vinlabel"></asp:Label>
       </td><td bgcolor="#FFFFCC">
           <asp:Label ID="lblSeat10" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td>
       <asp:Label ID="Label31" runat="server" Text="Seat11" CssClass="vinlabel"></asp:Label>
       </td><td>
           <asp:Label ID="lblSeat11" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   <tr>
   <td bgcolor="#FFFFCC">
       <asp:Label ID="Label34" runat="server" Text="Seat12" CssClass="vinlabel"></asp:Label>
       </td><td bgcolor="#FFFFCC">
           <asp:Label ID="lblSeat12" runat="server" Text="Seat Available"></asp:Label>
       </td>
   </tr>
   </table>
    <br />
    <asp:Label ID="Label35" runat="server" Font-Bold="True" 
        Text="Note: This is only for record to be given to Driver.  Employees are requested to not take prints. Save Paper .. Save Energy.. Save the Planet.."></asp:Label>
    <br />
    <br />
    Seat status for month in 
    given journey date. #1 Tour, #2 Leave #3 Family/guest<asp:GridView ID="gvWelfare" 
        runat="server" Font-Names="Arial" Font-Size="10px" ForeColor="#333399">
    </asp:GridView>
    </form>
</body>
</html>
