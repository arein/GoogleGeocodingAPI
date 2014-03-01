using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GoogleGeocodingClient.Api
{
    [DataContract (Name = "location")]
    internal class Location
    {
        [DataMember (Name = "lat")]
        public string Latitude { get; set; }

        [DataMember(Name = "lng")]
        public string Longitude { get; set; }
    }
}
