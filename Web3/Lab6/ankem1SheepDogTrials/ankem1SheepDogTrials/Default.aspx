<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ankem1SheepDogTrials.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 250px">
    <form id="form1" runat="server">
    <div>
    
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnShowDogs" runat="server" OnClick="btnShowDogs_Click" Text="Show all Dogs" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnShowFarmers" runat="server" OnClick="btnShowFarmers_Click" Text="Show all Farmers" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDogsAndFarmers" runat="server" OnClick="btnDogsAndFarmers_Click" Text="Show Dogs and Farmers" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDogResults" runat="server" OnClick="btnDogResults_Click" Text="Show Dog Results" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPopulate" runat="server" OnClick="btnPopulate_Click" Text="Populate Database" />
        <br />
        <br />
    
    </div>
        <div style="margin-left: 40px">
            <asp:GridView ID="gvDisplay" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
