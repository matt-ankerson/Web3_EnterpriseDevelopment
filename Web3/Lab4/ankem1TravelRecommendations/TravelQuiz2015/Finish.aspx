<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finish.aspx.cs" Inherits="TravelQuiz2015.Finish" %>

<!DOCTYPE html>

<html>
<head>
    <title>IN712 Web3 2015 Travel Quiz</title>
    <link href="Styles/TravelQuiz.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="divContainer" class="page" runat="server">
        <h2>You should go to....</h2>

        <asp:Image ID="imgTravelDestination" runat="server" />

        <br />

        <asp:Label ID="lblDestination" runat="server"></asp:Label>

        <div id="testSessionDiv" runat="server">

        </div>

    </div>
    </form>
</body>
</html>
