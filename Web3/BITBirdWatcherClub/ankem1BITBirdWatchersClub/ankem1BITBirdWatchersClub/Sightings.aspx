<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sightings.aspx.cs" Inherits="ankem1BITBirdWatchersClub.Sightings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="padding: 10px">
    <form id="form1" runat="server">
    <div id="divLogo" runat="server" style="width: 38%; height: 100%; float: left">
            <asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/birdWithReed.png" Width="444px" />
    </div>

    <div id="divNavigation" runat="server" style="width: 62%; float: right; text-align: center; margin-top: 20px; padding-top: 10px; padding-bottom: 10px; height: 25px; background-color: #DEEFFA;">
        <asp:HyperLink ID="hplHome" runat="server" ForeColor="Black">Home</asp:HyperLink> 
        &nbsp;|
        <asp:HyperLink ID="hplMembers" runat="server" ForeColor="Black">Members</asp:HyperLink>
        &nbsp;|
        <asp:HyperLink ID="hplSightings" runat="server" ForeColor="Black">Sightings</asp:HyperLink>
        &nbsp;|
        <asp:HyperLink ID="hplNewSighting" runat="server" ForeColor="Black">New Sighting</asp:HyperLink>
    </div>
    <div id="content" runat="server" style="width: 62%; float: right; text-align: left; height: 184px;">
        
        &nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnViewBirds" runat="server" OnClick="btnViewBirds_Click" Text="View Birds" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBirdsMember" runat="server" OnClick="btnBirdsMember_Click" Text="View Birds by Sighting Member" />
        <br />
        &nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblInfo" runat="server" Text="Listed below are all birds that have been sighted by our club."></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvDisplay" runat="server">
        </asp:GridView>
        
        <br />
        
    </div>
    </form>
    </body>
</html>
