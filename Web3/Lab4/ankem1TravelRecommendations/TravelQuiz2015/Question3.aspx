<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question3.aspx.cs" Inherits="TravelQuiz2015.Question3" %>

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
    <h2>What do you like to do most when on holiday?</h2>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>Shop</asp:ListItem>
        <asp:ListItem>Visit historical sites</asp:ListItem>
        <asp:ListItem>Enjoy the solitude</asp:ListItem>
        <asp:ListItem>Hiking, fishing, hunting, kayaking</asp:ListItem>
        <asp:ListItem>Go to museums, plays and concerts</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <br />
    <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" 
        Text="Next Question" />
    <br />
    </form>

</div>
</body>
</html>