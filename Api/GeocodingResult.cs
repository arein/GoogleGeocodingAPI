using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GoogleGeocodingClient.Api
{
    [DataContract]
	internal class GeocodingResult
	{
        [DataMember(Name = "address_components")]
        public AddressComponent[] AddressComponents { get; set; }

        [DataMember(Name = "formatted_address")]
        public string FormattedAddress { get; set; }

        [DataMember(Name = "partial_match")]
        public string PartialMatch { get; set; }

        [DataMember(Name = "types")]
        public string[] Types { get; set; }

        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }
	}
}
