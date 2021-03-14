<%@ Page Title="Home Page" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MixtapeGenerator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<br /> 
<p class="lead"><strong>This app generates a mixtape of 20 songs based on a song of your choice.</strong><br /></p>

<%--@* Default section: Search bar for initial input*@--%>
    <div class="container-fluid" style="background-color:#DBE4EE">
        <div class="row">
            <div class="col-sm-4" >
                <p><strong>Enter a song name:</strong></p>
                <asp:TextBox ID="TextBox1" runat="server" Width="166px"></asp:TextBox>
                <br /> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Song cannot be blank" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator> 
                
            </div>

            <div class="col-sm-4">
                <p"><strong>Enter an artist name:</strong></p>
                <asp:TextBox ID="TextBox2" runat="server"  Width="166px"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Artist cannot be blank" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator> 
                
            </div>
        </div>

                <br />
                <asp:Button ID="Button1_Submit" runat="server" OnClick="Button1_Submit_Click" Text="Search" />
                <br />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
    </div>
        <br />
<%--@* Section to display after user confirms the song from the list of results:
    Shows the generated playlist with a default image *@--%>
    <div class="container-fluid" style="background-color:#DBE4EE">
        <asp:Label ID="Label2" runat="server" Text="Songs that match your search will appear below for you to confirm."></asp:Label>
        <br />

        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="0" Text=" Choice 1"></asp:ListItem> <%--Selected attribute--%>
            <asp:ListItem Value="1" Text=" Choice 2"></asp:ListItem>
            <asp:ListItem Value="2" Text=" Choice 3"></asp:ListItem>
            <asp:ListItem Value="3" Text=" Choice 4"></asp:ListItem>
            <asp:ListItem Value="4" Text=" Choice 5"></asp:ListItem>
        </asp:RadioButtonList>

        <asp:Button ID="Button2_Submit" runat="server" OnClick ="Button2_Submit_Click" Text="Confirm"/>

        <br /><br />
        </div>

        <br />
    <strong><asp:Label ID="MixtapeTitle" runat="server" Text=""></asp:Label></strong>
    <br /><br />

    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-6 col-sm-8" style="background-color:#1F2833;">
                <br /><br /><br /><br /><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Image ID="Image1" runat="server" Width="400px"/>
                <br /><br /><br /><br /><br />
            </div>
            <div class="col-sm-6 col-sm-8" style="background-color:#c5c7c7;">
                
                <br />
                <asp:Label ID="MixtapeList" runat="server" Text=""></asp:Label>
                <br />
            </div>
      </div>
    </div>


</asp:Content>
