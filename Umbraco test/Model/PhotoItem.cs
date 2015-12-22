using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Globalization;
using System.Diagnostics;

namespace Umbraco_test.Model
{

    public class PhotoItem
    {
        [JsonProperty(PropertyName = "author_id")]
        public string AuthorId { get; set; }
        
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        
        [JsonProperty(PropertyName = "media")]
        public Media media { get; set; }

        [JsonProperty(PropertyName = "date_taken")]
        public DateTime DateTaken { get; set; }

        [JsonProperty(PropertyName = "unique_token")]
        public string UniqueToken { 
            get { return Guid.NewGuid().ToString(); } 
        }
    }

}