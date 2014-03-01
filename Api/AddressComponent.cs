using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoogleGeocodingClient.Api
{
    [DataContract(Name = "address_component")]
    internal class AddressComponent
    {
        [DataMember(Name = "long_name")]
        string LongName { get; set; }

        [DataMember(Name = "short_name")]
        string ShortName { get; set; }

        [DataMember(Name = "types")]
        string[] Types { get; set; }
    }
}
