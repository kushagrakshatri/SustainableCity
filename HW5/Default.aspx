<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ OutputCache Duration="20" VaryByParam="*" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Sustainable City Predictor<br />
            <br />
            This application is used to predict a sustainable city score for a particular city. The sustainable city score is calculated based on the UV Index and Wind Speed of a city<br />
            <br />
            A higher value of UV Index indicates that the city is suitable for using solar energy<br />
            <br />
            A higher value of Wind Speed indicates that the city is suitable for using wind energy
            <br />
            <br />
            Enter the city name
            <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 29px" Width="160px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 37px" Text="Submit" Width="104px" />
            <br />
            <br />
            Sustainable City Score:&nbsp; <div id="result" runat="server">
            </div>
        </div>
    </form>
</body>
</html>
