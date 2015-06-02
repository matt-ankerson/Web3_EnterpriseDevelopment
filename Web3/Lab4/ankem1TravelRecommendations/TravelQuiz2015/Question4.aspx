<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question4.aspx.cs" Inherits="TravelQuiz2015.Question4" %>

<!DOCTYPE html>

<html>
<head>
    <title>IN712 Web3 2015 Travel Quiz</title>
    <link href="Styles/TravelQuiz.css" rel="stylesheet" />
</head>

<body>
<div id="container" class="page">
    <form id="Form1" runat="server">


    <div id="divQuestionContainer" runat="server"></div>
    <h2>How do you like to travel?</h2>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>With my friends</asp:ListItem>
        <asp:ListItem>With my partner</asp:ListItem>
        <asp:ListItem>With my family</asp:ListItem>
        <asp:ListItem>Solo</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" 
        Text="Where Should I Go?" />
    <br />
    </form>

</div>
</body>
</html>
