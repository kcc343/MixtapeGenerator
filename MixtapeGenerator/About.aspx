<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MixtapeGenerator.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
        <div class="container-fluid" style="background-color:#1F2833">
            <h3 style="color:white">About the Project</h3>
            <p class="h5" style="color:lightgrey">This project was developed in the context of CSS436 - Cloud Computing 
                <br />
                by Kelly Chhor, Victor Chong Ly, and Stephanie Moua.
            </p>
            
            <p class="h5" style="color:lightgrey">
                Our project “Mixtape Generator” provides a web application that users can use to generate a
                “mixtape” of 20 recommended songs baed on one song of their choice. The application is 
                written using ASP.NET Web Forms in C# and is hosted on Azure. 
                <br /><br />
                To use the application, the user must input a song name and artist name, either full or partial, 
                that are used to retrieve data from the Spotify API. The user must confirm the song choice from 
                a list of top 5 results pulled from the Spotify database. 
                Upon confirmation, the application uses the recommendation features of the Spotify API 
                to generate a list of related songs. The song input is also used to generate an image that serves 
                as the cover for the mixtape via the Unsplash API. Both the image and the list of songs are 
                displayed on the site for the user. 
            </p>
    </div>

</asp:Content>
