<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleFile.aspx.cs" Inherits="LosslessImage.SingleFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtPath" Width="500px" runat="server"></asp:TextBox>
        <asp:Button ID="btnRun" runat="server" Text="Run" OnClick="btnRun_Click" />
    </div>
    </form>
</body>
</html>
