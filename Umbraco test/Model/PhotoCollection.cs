using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Umbraco_test.Model
{
    
    public class PhotoCollection
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<PhotoItem> Items { get; set; }

        public static List<PhotoItem> SortPhotoItemsDescending(List<PhotoItem> photoItems) {
            photoItems.Sort((x, y) => x.DateTaken.CompareTo(y.DateTaken));
            photoItems.Reverse();
            return photoItems;
        }
    }

}