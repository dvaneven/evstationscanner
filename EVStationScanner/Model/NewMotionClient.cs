using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EVStationScanner.Model
{
	public class NewMotionClient
	{
        private readonly Uri _locationBaseUri;

        public NewMotionClient(Uri locationBaseUri)
        {
            if (locationBaseUri == null)
				throw new ArgumentNullException(nameof(locationBaseUri));

			_locationBaseUri = locationBaseUri;
        }

		public async Task<EvseInfo> GetEvseInfo(string locationId)
		{
			var client = new HttpClient();
			var requestUri = new Uri(_locationBaseUri, locationId);
			var request = await client.GetAsync(requestUri);
			request.EnsureSuccessStatusCode();
			return await request.Content.ReadAsAsync<EvseInfo>();
		}
	}
}