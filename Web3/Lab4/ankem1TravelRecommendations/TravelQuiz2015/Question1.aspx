<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question1.aspx.cs" Inherits="TravelQuiz2015.Question1" %>

<!DOCTYPE html />

<html>
<head>
    <title>IN712 Web3 2015 Travel Quiz</title>
    <link href="Styles/TravelQuiz.css" rel="stylesheet" />
</head>
<body>
<div id="container" class="page">
    <form id="Form1" runat="server">


    <div id="divQuestionContainer" runat="server"></div>
    <h2>When choosing a vacation destination, the most important thing is...</h2>
    <br />
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>A place full of history</asp:ListItem>
        <asp:ListItem>A place with a wild club scene</asp:ListItem>
        <asp:ListItem>A place with adventure and outdoor activities</asp:ListItem>
        <asp:ListItem>A romantic spot</asp:ListItem>
        <asp:ListItem>A relaxing place</asp:ListItem>
        <asp:ListItem>A solitary place where I can be alone with my own thoughts</asp:ListItem>
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