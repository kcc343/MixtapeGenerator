
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Net.Http;
using SpotifyAPI.Web;
using Amazon;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;
using Table = Amazon.DynamoDBv2.DocumentModel.Table;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace MixtapeGenerator
{
    public partial class _Default : Page
    {
        SpotifyClient spotify;


        protected void Page_Load(object sender, EventArgs e) {
            

        }

        // Function for 'search' button after click 
        // Uses Spotify Search API to find the root song 
        protected async void Button1_Submit_Click(object sender, EventArgs e)
        {
            // Get input from user via TextBox
            string song = Convert.ToString(TextBox1.Text);
            // Get input from user via TextBox
            string artist = Convert.ToString(TextBox2.Text);

            string searchSong = "";

            if (song.Length > 0 && artist.Length > 0)
            {
                searchSong = song + " " + artist;
            } // 

            else //no song input or no artist input
            {
                // display an error message
            }

            Label1.Text = "Searching for " + song;

            //spotify credentials

          string CLIENTID = System.Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
          string CLIENTSECRET = System.Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_SECRET");

            //amazon credentials and info
            string ACCOUNTID = System.Environment.GetEnvironmentVariable("AMAZON_ACCOUNTID");
            string ACCOUNTKEY = System.Environment.GetEnvironmentVariable("AMAZON_ACCOUNTKEY");
            string tableName = "Program5";

            //connect to spotify
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(CLIENTID, CLIENTSECRET);
            var response = await new OAuthClient(config).RequestToken(request);
            spotify = new SpotifyClient(config.WithToken(response.AccessToken));
            // [placeholder] catch Spotify connection errors

            //connect to amazon
            var credentials = new BasicAWSCredentials(ACCOUNTID, ACCOUNTKEY);
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USWest2);
            //connect to amazon
            // [placeholder] catch Amazon connection errors

            //perform search. CAN REPLACE WITH USER INPUTTED REQUEST HERE
            var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, searchSong));

            //Get tracks from search result
            var trackResults = spotify.PaginateAll(search.Tracks, (s) => s.Tracks);

            //dictionary to put song attributes into for database
            Dictionary<string, AttributeValue> attributes = new Dictionary<string, AttributeValue>();

            string temp = "";
            //print list of first 5 items that appear in search result
            for (int i = 0; i < 5; i++)
            {
                if (trackResults.Result[i] != null)
                {
                    //at this point we want user to input a number
                    //Console.Write("Option " + i + ": \"" + trackList[i].Name + "\" by \"" + trackList[i].Artists[0].Name + "\"");
                    //Console.WriteLine(" From the album \"" + trackList[i].Album.Name + "\"");
                    temp = i + ": \"" + trackResults.Result[i].Name + "\" by \"" + trackResults.Result[i].Artists[0].Name 
                        + "\"" + " From the album \"" + trackResults.Result[i].Album.Name + "\"";

                    //store track information into dynamodb
                    attributes["track number"] = new AttributeValue { S = i.ToString() };
                    attributes["track id"] = new AttributeValue { S = trackResults.Result[i].Id };
                    attributes["artist id"] = new AttributeValue { S = trackResults.Result[i].Artists[0].Id };
                    attributes["artist"] = new AttributeValue { S = trackResults.Result[i].Artists[0].Name };

                    PutItemRequest trackInfo = new PutItemRequest
                    {
                        TableName = tableName,
                        Item = attributes
                    };
                    await client.PutItemAsync(trackInfo);
                }
            }


            string track0 = trackResults.Result[0].Name + "\" by \"" + trackResults.Result[0].Artists[0].Name + "\"" + " From the album \"" + trackResults.Result[0].Album.Name;
            string track1 = trackResults.Result[1].Name + "\" by \"" + trackResults.Result[1].Artists[0].Name + "\"" + " From the album \"" + trackResults.Result[1].Album.Name;
            string track2 = trackResults.Result[2].Name + "\" by \"" + trackResults.Result[2].Artists[0].Name + "\"" + " From the album \"" + trackResults.Result[2].Album.Name;
            string track3 = trackResults.Result[3].Name + "\" by \"" + trackResults.Result[3].Artists[0].Name + "\"" + " From the album \"" + trackResults.Result[3].Album.Name;
            string track4 = trackResults.Result[4].Name + "\" by \"" + trackResults.Result[4].Artists[0].Name + "\"" + " From the album \"" + trackResults.Result[4].Album.Name;

            RadioButtonList1.Items[0].Text = track0;
            RadioButtonList1.Items[1].Text = track1;
            RadioButtonList1.Items[2].Text = track2;
            RadioButtonList1.Items[3].Text = track3;
            RadioButtonList1.Items[4].Text = track4;
        }

 

        // After user confirms options, generate 20 recommended songs
        protected async void Button2_Submit_Click(object sender, EventArgs e)
        {
            // Generate picture 
            string song = Convert.ToString(TextBox1.Text);
            string cover = await GenerateImage(song);
            Image1.ImageUrl = cover;
            
            //SPOTIFY CREDENTIALS
          string CLIENTID = System.Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
          string CLIENTSECRET = System.Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_SECRET");
            //connect to spotify
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(CLIENTID, CLIENTSECRET);
            var response = await new OAuthClient(config).RequestToken(request);
            spotify = new SpotifyClient(config.WithToken(response.AccessToken));

            // returns [0, 1, 2, 3, 4] based on selected value
            string selected = RadioButtonList1.SelectedValue;

            MixtapeList.Text = selected;
            //var trackResults; 
            ////this should be seperate method
            //// Matches the choice from the list 
            //// choice = input from default.aspx
            string trackID = await RetrieveTrackAsync(selected, "track id"); 
            string artistID = await RetrieveTrackAsync(selected, "artist id");
            string artist = await RetrieveTrackAsync(selected, "artist");

            //get the genres of the artist by searching for the exact artist name based on choice from user
            List<string> artistGenres = new List<string>();
            var search = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Artist, artist));
            var artistResults = spotify.PaginateAll(search.Artists, (s) => s.Artists);

            //go through every artist until we find a matching artist ID.
            //This may be problematic if we run into a weird case where we get the ID but when searching by name the artist doesnt show up
            //I set i to 50 because I wasn't sure how to iterate through the whole ilist, 80% sure we will have a 99% chance we find the artist

            for (int i = 0; i < artistResults.Result.Count; i++)
            {
                if (artistResults.Result[i] == null)
                {
                    //if we ran out of results to look for?
                    break;
                }
                //to ensure we have the right artis
                if (artistResults.Result[i].Id == artistID)
                {
                    artistGenres = artistResults.Result[i].Genres;
                    break;
                }
            }
           // information for generating the reccomendations
                        RecommendationsRequest recFinder = new RecommendationsRequest();
                        recFinder.SeedTracks.Add(trackID);
                        recFinder.SeedGenres.Add(artistGenres[0]);
                        recFinder.SeedArtists.Add(artistID);

                        //WE CAN CHANGE AMOUNT OF SONGS WE WANT TO GENERATE HERE
                        recFinder.Limit = 20;

                        //performt he recommendation search
                        var recList = spotify.Browse.GetRecommendations(recFinder);

                        Console.WriteLine("\nReccomendations found: ");

                        string recommendations = "";
                        for (int i = 0; i < recList.Result.Tracks.Count; i++)
                        {
                            string tmp = ("Song " + (i + 1) + ": \"" + recList.Result.Tracks[i].Name + "\" by " + recList.Result.Tracks[i].Artists[0].Name + "<br>");
                            recommendations += tmp;
                            //maybe print the URL for a track here idk how to find it I'm happy with what is done so far.
                        }

                        MixtapeList.Text = "Reccomendations found: " + recommendations;
        }

        protected async System.Threading.Tasks.Task<string> RetrieveTrackAsync(string trackNum, string IdType)
        {
            //amazon credentials and info
            string ACCOUNTID = System.Environment.GetEnvironmentVariable("AMAZON_ACCOUNTID");
            string ACCOUNTKEY = System.Environment.GetEnvironmentVariable("AMAZON_ACCOUNTKEY");
            string tableName = "Program5";
            //connect to amazon
            var credentials = new BasicAWSCredentials(ACCOUNTID, ACCOUNTKEY);
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USWest2);

            //load and create query filter
            Table table = Table.LoadTable(client, tableName);
            QueryFilter filter = new QueryFilter("track number", QueryOperator.Equal, trackNum);

            //perform query
            Search search = table.Query(filter);
            var matches = await search.GetNextSetAsync();
            var song = matches[0];
            if (IdType == "track id")
            {
                return song[IdType].AsPrimitive().Value.ToString();
            }

            if (IdType == "artist id")
            {
                return song[IdType].AsPrimitive().Value.ToString();
            }

            if (IdType == "artist")
            {
                return song[IdType].AsPrimitive().Value.ToString();
            }

            return "";
        }
    }
    
           protected async System.Threading.Tasks.Task GenerateImage(string song)
        {
            string imageURL;

            HttpClient client = new HttpClient();
            string APIKey = System.Environment.GetEnvironmentVariable("UNSPLASH_APIKEY");
            string URL = "https://api.unsplash.com/photos/random/?client_id=" + APIKey + "&query=" + song + "&count=1";
            HttpResponseMessage response = await client.GetAsync(URL);

            if (response.IsSuccessStatusCode) // 2xx or 3xx code 
            {
                // Retrieve the json data from response 
                string result = await response.Content.ReadAsStringAsync();

                // Deserialize json data: 
                Class1.Rootobject root = JsonConvert.DeserializeObject<Class1.Rootobject>(result);
                imageURL = root.results[0].urls.small;
            }

            else
            {
                imageURL = "https://images.unsplash.com/photo-1608934923079-ef4aee854cd8?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=2100&q=80";
            }

            Image1.ImageUrl = imageURL;

        }
		

    public class UnsplashAPI
    {
        public class Rootobject
        {
            public int total { get; set; }
            public int total_pages { get; set; }
            public Result[] results { get; set; }
        }

        public class Result
        {
            public string id { get; set; }
            public DateTime created_at { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string color { get; set; }
            public int likes { get; set; }
            public bool liked_by_user { get; set; }
            public string description { get; set; }
            public User user { get; set; }
            public object[] current_user_collections { get; set; }
            public Urls urls { get; set; }
            public Links1 links { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string instagram_username { get; set; }
            public string twitter_username { get; set; }
            public string portfolio_url { get; set; }
            public Profile_Image profile_image { get; set; }
            public Links links { get; set; }
        }

        public class Profile_Image
        {
            public string small { get; set; }
            public string medium { get; set; }
            public string large { get; set; }
        }

        public class Links
        {
            public string self { get; set; }
            public string html { get; set; }
            public string photos { get; set; }
            public string likes { get; set; }
        }

        public class Urls
        {
            public string raw { get; set; }
            public string full { get; set; }
            public string regular { get; set; }
            public string small { get; set; }
            public string thumb { get; set; }
        }

        public class Links1
        {
            public string self { get; set; }
            public string html { get; set; }
            public string download { get; set; }
        }

    }
}
