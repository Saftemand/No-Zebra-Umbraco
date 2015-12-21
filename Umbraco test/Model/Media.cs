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
        public string src { get; set; }
    }
}