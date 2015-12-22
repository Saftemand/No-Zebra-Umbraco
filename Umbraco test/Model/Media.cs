using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco_test.Model
{
    public class Media
    {
        [JsonProperty(PropertyName = "m")]
        public string MiniSrc { get; set; }

        private string fullSrc;
        [JsonProperty(PropertyName = "f")]
        public string FullSrc {
            get {
                return ReplaceLastOccurrence(MiniSrc, "_m", "");
            }
        }

        private string ReplaceLastOccurrence(string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);

            if (place == -1)
                return source;

            string result = source.Remove(place, find.Length).Insert(place, replace);
            return result;
        }

    }
}