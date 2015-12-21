using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Umbraco.Web.Mvc;
using Umbraco_test.Model;

namespace Umbraco_test.Controller
{

    public class FeedSurfaceController : SurfaceController
    {
        private string flickrApiAddress = "https://api.flickr.com/services/feeds/photos_public.gne?format=json";

        [HttpPost]
        [OutputCache(Duration = 30, VaryByParam = "tags;sortByDate", Location = OutputCacheLocation.Client)]
        public JsonResult HandleFormPost(string tags, string sortByDate, string firstOrLast) {
            string result = ConsumeFlickrApi(tags);

            result = PickJson(result);

            PhotoCollection photoCollection = ConvertJsonToPhotoCollection(result);
            
            if(sortByDate.ToLower().Equals("true")){
                photoCollection.Items = PhotoCollection.SortPhotoItemsDescending(photoCollection.Items);
            }

            if (firstOrLast.ToLower().Equals("first"))
            {
                if (photoCollection.Items.Count > 10)
                {
                    photoCollection.Items.RemoveRange(9, photoCollection.Items.Count - 10);
                }
            } 
            
            result = ConvertPhotoCollectionToJson(photoCollection);
            Debug.WriteLine("Result: " + result);

            return Json(result);
        }

        private string ConsumeFlickrApi(string tags) {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(flickrApiAddress + "&tags=" + tags).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        private string PickJson(string result){
            if (!String.IsNullOrEmpty(result))
            {
                result = result.Substring(15, (result.Length - 16));
            }

            return result;
        }

        private PhotoCollection ConvertJsonToPhotoCollection(string json) {
            PhotoCollection result = JsonConvert.DeserializeObject<PhotoCollection>(json);
            return result;
        }

        private string ConvertPhotoCollectionToJson(PhotoCollection photoCollection)
        {
            string result = JsonConvert.SerializeObject(photoCollection);
            return result;
        }

    }

}