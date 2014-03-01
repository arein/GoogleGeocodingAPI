using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using GoogleGeocodingClient.Api;

namespace GoogleGeocodingClient.Transport
{
	internal class GeocodingRequest
	{
		#region Class Properties

		/// <summary>
		/// The base API URL, up to and including the query string question mark.  The parameters 
		/// will be appended as query string parameters.
		/// </summary>
		private static string ApiUrl
		{
			get
			{
                string apiUrl = "https://maps.googleapis.com/maps/api/geocode/json?";

				return apiUrl;
			}
		}

		#endregion


		/// <summary>
		/// Calls the geocoding API with the given request parameters.
		/// </summary>
		/// <param name="requestParams"></param>
		/// <returns></returns>
        internal async static Task<GeocodingResponse> Execute(IDictionary<string, string> requestParams)
		{
			string requestUrl = GetRequestUrl(requestParams);

            var httpClient = new HttpClient();
            var url = new Uri(requestUrl);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            httpRequestMessage.Headers.Add("User-Agent", "WinRT");
            var resp = await httpClient.SendAsync(httpRequestMessage);

            using (StreamReader respReader = new StreamReader(await resp.Content.ReadAsStreamAsync()))
            {
                string jsonResponse = respReader.ReadToEnd();
                return JsonConvert.DeserializeObject<GeocodingResponse>(jsonResponse);
            }
		}

		/// <summary>
		/// Constructs the request URL using the provided dictionary of request parameters.
		/// </summary>
		/// <param name="requestParams"></param>
		/// <returns></returns>
		private static string GetRequestUrl(IDictionary<string, string> requestParams)
		{
			StringBuilder qsParams = new StringBuilder();

			foreach (string key in requestParams.Keys)
			{
				if (qsParams.Length > 0)
				{
					qsParams.Append("&");
				}

                qsParams.AppendFormat("{0}={1}", System.Net.WebUtility.UrlEncode(key), System.Net.WebUtility.UrlEncode(requestParams[key]));
			}

			return string.Format("{0}{1}", ApiUrl, qsParams.ToString());
		}
	}
}
