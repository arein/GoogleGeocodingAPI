using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoogleGeocodingClient.Api
{
    [DataContract(Name = "geometry")]
    internal class Geometry
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        [DataMember(Name = "location_type")]
        public string LocationType { get; set; }
    }
}
