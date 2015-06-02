<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ankem1BirdWatchersDbSetup.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnResetDatabase" runat="server" OnClick="btnResetDatabase_Click" Text="Reset Database" />
        <br />
        <br />
        <asp:Label ID="lblResetDb" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
