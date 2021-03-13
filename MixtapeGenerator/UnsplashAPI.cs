using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixtapeGenerator
{
    public class UnsplashAPI
    {

        public class Rootobject
        {
            public string id { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public string width { get; set; }
            public string height { get; set; }
            public string color { get; set; }
            public string blur_hash { get; set; }
            public string downloads { get; set; }
            public string likes { get; set; }
            public string liked_by_user { get; set; }
            public string description { get; set; }
            public Exif exif { get; set; }
            public Location location { get; set; }
            public Urls urls { get; set; }
            public Links links { get; set; }
            public User user { get; set; }
        }

        public class Exif
        {
            public string make { get; set; }
            public string model { get; set; }
            public string exposure_time { get; set; }
            public string aperture { get; set; }
            public string focal_length { get; set; }
            public string iso { get; set; }
        }

        public class Location
        {
            public string name { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public Position position { get; set; }
        }

        public class Position
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class Urls
        {
            public string raw { get; set; }
            public string full { get; set; }
            public string regular { get; set; }
            public string small { get; set; }
            public string thumb { get; set; }
        }

        public class Links
        {
            public string self { get; set; }
            public string html { get; set; }
            public string download { get; set; }
            public string download_location { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public DateTime updated_at { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public string portfolio_url { get; set; }
            public string bio { get; set; }
            public string location { get; set; }
            public string total_likes { get; set; }
            public string total_photos { get; set; }
            public string total_collections { get; set; }
            public string instagram_username { get; set; }
            public string twitter_username { get; set; }
            public Links1 links { get; set; }
        }

        public class Links1
        {
            public string self { get; set; }
            public string html { get; set; }
            public string photos { get; set; }
            public string likes { get; set; }
            public string portfolio { get; set; }
        }

    }
}