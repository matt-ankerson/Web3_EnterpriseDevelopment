<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSighting.aspx.cs" Inherits="ankem1BITBirdWatchersClub.NewSighting" %>

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
    <div id="content" runat="server" style="width: 62%; float: right; text-align: left; height: 478px;">
        
        &nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblInfo" runat="server" Text="Use this page to report a bird sighting." Font-Bold="True"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblChooseMember" runat="server" Text="Club Member: "></asp:Label>
        <asp:DropDownList ID="ddlMember" runat="server">
        </asp:DropDownList>
        <br />
        
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblChooseInputMethod" runat="server" Text="Choose an existing bird or input a new bird."></asp:Label>
        &nbsp;<br />
&nbsp;<asp:Panel ID="Panel1" runat="server">
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbExisting" runat="server" OnCheckedChanged="rbExisting_CheckedChanged" Text="Existing Bird" AutoPostBack="True" Checked="True" GroupName="InputType" />
            &nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbNew" runat="server" OnCheckedChanged="rbNew_CheckedChanged" Text="New Bird" AutoPostBack="True" GroupName="InputType" />
        </asp:Panel>
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlBird" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<div id="divNewBird" runat="server" style="position: relative;">
            <asp:Label ID="lblMaori" runat="server" Text="Maori Name: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtMaori" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="&lt;-- These fields are required."></asp:Label>
            <br />
    
            <asp:Label ID="lblEnglish" runat="server" Text="English Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEnglish" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblScientific" runat="server" Text="Scientific Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtScientific" runat="server"></asp:TextBox>
        </div>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
        
        <br />
        
    </div>
    </form>
    </body>
</html>
