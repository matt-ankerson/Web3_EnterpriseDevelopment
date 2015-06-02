<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TravelQuizHome.aspx.cs" Inherits="TravelQuiz2015.TravelQuizHome" %>

<!DOCTYPE html />

<html>
<head>
    <title>IN712 Web3 2015 Travel Quiz</title>
    <link href="Styles/TravelQuiz.css" rel="stylesheet" />
</head>
<body>
<div id="container" class="page">


    <h2>Welcome to the IN712 Travel Quiz. Answer these questions to find your perfect 
    travel destination....</h2>

    <form runat="server">
    <br />
    <br />
    <br />
    <asp:Button ID="btnStartQuiz" runat="server" Text="Start Quiz" OnClick="btnStartQuiz_Click"/>
    </form>

</div>
</body>
</html>

