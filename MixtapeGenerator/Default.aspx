<%@ Page Title="Home Page" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MixtapeGenerator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
<h2>Mixtape Generator</h2>
<p class="lead"><strong>This app generates a mixtape of 20 songs based on a track of your choice.</strong><br /><br /></p>

<%--@* Default section: Search bar for initial input*@--%>
    <p>
        Enter a song name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter an artist name:
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Width="166px"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"  Width="166px"></asp:TextBox>
    
    <br />    
        <asp:Button ID="Button1_Submit" runat="server" OnClick="Button1_Submit_Click" Text="Search" />
    <br />
        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
    </p>
    <br /> 

<%--@* Section to display after user confirms the song from the list of results:
    Shows the generated playlist with a default image *@--%>
    <asp:Label ID="Label2" runat="server" Text="[Display list of options]"></asp:Label>
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem Value="0" Text="Choice0"></asp:ListItem> <%--Selected attribute--%>
        <asp:ListItem Value="1" Text="Choice1"></asp:ListItem>
        <asp:ListItem Value="2" Text="Choice2"></asp:ListItem>
        <asp:ListItem Value="3" Text="Choice3"></asp:ListItem>
        <asp:ListItem Value="4" Text="Choice4"></asp:ListItem>
    </asp:RadioButtonList>

<%--    <asp:RequiredFieldValidator ID="RequiredChoice" ErrorMessage="Please select a song.<br />"
    ControlToValidate="RadioButtonList1" runat="server" ForeColor="Red" Display="Dynamic" />--%>
    <asp:Button ID="Button2_Submit" runat="server" OnClick ="Button2_Submit_Click" Text="Confirm"/>

    <asp:Table ID="Table1" runat="server"></asp:Table>

        <br /> 

<%--    <img src="https://images.unsplash.com/photo-1608934923079-ef4aee854cd8?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=2100&q=80"
         class="img-thumbnail" alt="...">--%>

    <strong>
        <asp:Label ID="MixtapeTitle" runat="server" Text="[Mixtape title]"></asp:Label></strong><br /> 
    <asp:Label ID="MixtapeList" runat="server" Text="[Display list of songs"></asp:Label>

</asp:Content>
