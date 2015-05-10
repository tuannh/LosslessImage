<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LosslessImage.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtPath" Width="500px" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnRun" runat="server" Text="Run" OnClick="btnRun_Click" />
            <a href="/SingleFile.aspx">SingleFile.aspx</a>

        </div>
        Error: <asp:Label ID="lblError" runat="server"></asp:Label>

        <br />
        Success: <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    </form>
</body>
</html>
