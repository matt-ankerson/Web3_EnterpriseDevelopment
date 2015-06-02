<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IntroToWebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #frmMain {
            height: 250px;
        }
    </style>
</head>
<body>
    <form id="frmMain" runat="server">
            <h1>This is plain HTML</h1>
            <br />
            HTML TextBox:&nbsp;&nbsp; <input type="text" style="width: 140px; margin-left: 50px" width="140" /><br />
            HTML Control TextBox:&nbsp; <input type="text" runat="server" id="txtControl" style="width: 140px; margin-left: 3px" width="140" />
            <br />
            ASP.NET Control TextBox:&nbsp;
            <asp:TextBox ID="txtASPControl" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;<input type="submit" value="Empty Submit" style="width: 153px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ASP Button" />
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
