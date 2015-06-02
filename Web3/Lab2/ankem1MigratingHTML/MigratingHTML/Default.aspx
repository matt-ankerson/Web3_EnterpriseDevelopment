<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MigratingHTML.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> BIT Music Survey </title>
</head>
<body>
    <form id="formSurvey" runat="server">
    <div>
        <h1>Take Our Music Survey!</h1>
        <br />
        <p>Name:</p>
        <input type="text" runat="server" id="txtName"/>
        <br />
        <p>Email:</p>
        <input type="text" runat="server" id="txtEmail"/>
        <br />
        <p>Which musical genres do you enjoy?</p>
        <br />
           <select multiple="true" runat="server" id="slctGenre" aria-multiselectable="True">
             <option>Rock</option>
             <option>Jazz</option>
             <option>Folk</option>
             <option>World</option>
             <option>Country</option>
		     <option>Techno</option>
		     <option>Hip Hop</option>
		     <option>Blues</option>
		     <option>Classical</option>
           </select>
         
        <br />
        <p>Would you like to join the BIT Glee Club?</p>
        <input runat="server" id="rbGleeClubYes" type="radio" name="gleeClub" value="Yes"/>Yes
        <br />
        <input runat="server" id="rbGleeClubNo" type="radio" name="gleeClub" value="No"/>No
        <br />
        <br />
        <input  runat="server" onserverclick="btnSubmit_Click" id="btnSubmit" type="submit" value="Send Data"/>
    </div>
    <br />
        <br />
    <div id="divReport" runat="server">

    </div>
    </form>
</body>
</html>
