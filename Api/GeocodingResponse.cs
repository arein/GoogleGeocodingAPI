using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoogleGeocodingClient.Api
{
    [DataContract]
    internal class GeocodingResponse
    {
        [DataMember(Name = "results")]
        public GeocodingResult[] Results { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
