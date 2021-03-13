<%@ Page Title="Home Page" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MixtapeGenerator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
<h2>Mixtape Generator</h2>
<p class="lead"><strong>This app generates a mixtape of 20 songs based on a track of your choice.</strong><br /><br /></p>

<%--@* Default section: Search bar for initial input*@--%>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Text="Enter a song name" ></asp:TextBox>
          
    &nbsp;&nbsp;&nbsp;
          
    <asp:TextBox ID="TextBox2" runat="server" Text="Enter an artist name" Width="166px"></asp:TextBox>
        <br />    
        <asp:Button ID="Button1_Submit" runat="server" OnClick="Button1_Submit_Click" Text="Search" />
    <br />
        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
    </p>
    <strong>
    <br /> 

<%--@* Section to display after user confirms the song from the list of results:
    Shows the generated playlist with a default image *@--%>
<%--    <img src="https://images.unsplash.com/photo-1608934923079-ef4aee854cd8?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=2100&q=80"
         class="img-thumbnail" alt="...">--%>


        <asp:Label ID="RecLabel" runat="server" Text="[Mixtape title]"></asp:Label></strong><br /> 
            1. 
            <asp:Label ID="Option1" runat="server" Text="[Track 1]"></asp:Label><br /> 
        2. 
        <asp:Label ID="Option2" runat="server" Text="[Track 2]"></asp:Label><br /> 
        3. 
        <asp:Label ID="Option3" runat="server" Text="[Track 3]"></asp:Label><br /> 
        4. 
        <asp:Label ID="Option4" runat="server" Text="[Track 4]"></asp:Label><br /> 
        5. 
        <asp:Label ID="Option5" runat="server" Text="[Track 5]"></asp:Label><br /> 


</asp:Content>
