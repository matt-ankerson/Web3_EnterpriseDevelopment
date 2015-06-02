<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ankem1WebControls.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 38px">
    <form id="form1" runat="server">
    <div style="height: 98px">
    
        <asp:Label ID="lblFont" runat="server" Text="Select your Font: "></asp:Label>
        <asp:DropDownList ID="ddlFonts" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblText" runat="server" Text="Enter your text"></asp:Label>
&nbsp;<asp:TextBox ID="txtEnterText" runat="server" Width="293px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnDisplay" runat="server" OnClick="btnDisplay_Click" Text="Display" />
        <div runat="server" id="divImageText">
        </div>
    </div>
    </form>
</body>
</html>
