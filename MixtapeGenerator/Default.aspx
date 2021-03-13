﻿<%@ Page Title="Home Page" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MixtapeGenerator._Default" %>

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
    <asp:Label ID="Label2" runat="server" Text="Songs that match your search will appear below, <br>so you can make sure we're getting it right!"></asp:Label>
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem Value="0" Text=" Choice 1"></asp:ListItem> <%--Selected attribute--%>
        <asp:ListItem Value="1" Text=" Choice 2"></asp:ListItem>
        <asp:ListItem Value="2" Text=" Choice 3"></asp:ListItem>
        <asp:ListItem Value="3" Text=" Choice 4"></asp:ListItem>
        <asp:ListItem Value="4" Text=" Choice 5"></asp:ListItem>
    </asp:RadioButtonList>

    <asp:Button ID="Button2_Submit" runat="server" OnClick ="Button2_Submit_Click" Text="Confirm"/>
    
        <br />
        <br />

    <strong>
        <asp:Label ID="MixtapeTitle" runat="server" Text=""></asp:Label></strong><br /> 
    <asp:Label ID="MixtapeList" runat="server" Text=""></asp:Label>

</asp:Content>
