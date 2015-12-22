using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco_test.utils
{
    class CustomDateTimeConverter : IsoDateTimeConverter{
        public CustomDateTimeConverter(){
            base.DateTimeFormat = "yyyy-MM-dd hh:mm:ss";
        }
    }
}