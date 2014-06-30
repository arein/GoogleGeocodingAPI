using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Globalization;
using GoogleGeocodingClient.Transport;
using GoogleGeocodingClient.Api;

namespace GoogleGeocodingClient
{
	/// <summary>
	/// Wrapper for returning results from Google's Geocoding API.
	/// </summary>
	public static class GoogleGeocodingClient
	{
		/// <summary>
		/// Obtain the geographic coordinates of the specified address.  May return multiple sets
		/// of coordinates.
		/// </summary>
		/// <param name="address"></param>
		/// <returns></returns>
		public async static Task<List<GeographicCoordinate>> Geocode(string address)
        {
			return await Geocode(address, false);
		}

		/// <summary>
		/// Obtain the geographic coordinates of the specified address.  May return multiple sets
		/// of coordinates.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="sensor">Use of the Google Maps API now requires that you indicate whether your application is using a sensor (such as a GPS locator) to determine the user's location.  Applications that determine the user's location via a sensor must true.</param>
		/// <returns></returns>
		public async static Task<List<GeographicCoordinate>> Geocode(string address, bool sensor)
		{
			var requestParams = new Dictionary<string, string>
			{
				{"address", address},
				//{"key", ApiKey},
				{"sensor", sensor.ToString().ToLowerInvariant()},
				{"output", "json"},
				{"oe", "utf8"}
			};

            var response = await GeocodingRequest.Execute(requestParams);
			return ReadResult(response);
		}


		#region Helpers

		private static List<GeographicCoordinate> ReadResult(GeocodingResponse response)
		{
			List<GeographicCoordinate> coords = new List<GeographicCoordinate>();
            if (response.Results == null || response.Results.Length == 0)
			{
				return coords;
			}

            foreach (GeocodingResult result in response.Results)
			{
				coords.Add(new GeographicCoordinate
				{
                    Latitude = double.Parse(result.Geometry.Location.Latitude, CultureInfo.InvariantCulture),
                    Longitude = double.Parse(result.Geometry.Location.Longitude, CultureInfo.InvariantCulture)
				});
			}

			return coords;
		}

		#endregion
	}
}
