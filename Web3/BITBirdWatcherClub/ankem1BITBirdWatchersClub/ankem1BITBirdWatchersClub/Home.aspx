<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ankem1BITBirdWatchersClub.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="padding: 10px">
    <form id="form1" runat="server">

    <div id="divLogo" runat="server" style="width: 38%; float: left; height: 1000px;">
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
    <div id="content" runat="server" style="width: 62%; text-align: left; float: right;">
        <h3 style="padding-left: 5px; height: 27px;">&nbsp;</h3>
        <h3 style="padding-left: 5px; height: 27px;">Our Club</h3>
        <p>&nbsp;</p>
        <p>The BIT Bird Watchers Club was established a long time ago. The club is the single most prestigious registered bird watching<br />
            organistation that we know of. Members of this club particularly enjoy spotting bird life in Dunedin and the surrounding districts because otherwise it&#39;s just too far to drive. Members of this club spend most of their time watching sea gulls, ducks and the occasional blackbird. </p>
        <p>If you see any bird other than a sea gull, this is regarded as a rare occurence and should be reported immediately. We are particularly interested in sightings of the following birds: Emperor Penguin, Pheasant, Chicken, Rooster, Dodo and Flamingo.</p>
        <p>To maximise your chances of sighting a bird it is recommended that you leave the house. In the past members have recorded success when looking out of a window, though results may not be as favourable.</p>
        <p>Use this website to view our members, view bird sighting records, or add a new bird sighting record.</p>
        <p>&nbsp;</p>
    </div>
    </form>
</body>
</html>
