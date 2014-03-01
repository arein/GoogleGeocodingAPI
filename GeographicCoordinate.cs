using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleGeocodingClient
{
	/// <summary>
	/// Type that holds an address's geographic coordinates as determined by the Google Maps
	/// Geocoding API.
	/// </summary>
	//[Serializable]
	public class GeographicCoordinate
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public double Altitude { get; set; }

		public override string ToString()
		{
			return string.Format(
				"{0}, {1}, {2}",
				Latitude,
				Longitude,
				Altitude
				);
		}
	}
}
