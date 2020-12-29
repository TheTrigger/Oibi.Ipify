using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Oibi.Ipify
{
	/// <summary>
	/// Static utility class exposing methods to facilitate resolving a client's public IP address on the Internet by querying the service api64.ipify.org
	/// </summary>
	public static class Ipify
	{
		private static readonly HttpClient _httpClient = new HttpClient();
		private const string _ipv64endPoint = "https://api64.ipify.org";

		/// <summary>
		/// Resolves the public IP address as raw string
		/// </summary>
		/// <returns>A string containing the IP address</returns>
		/// <exception cref="System.Net.Http.HttpRequestException"/>
		public static async Task<string> GetPublicRawIPAsync(CancellationToken cancellationToken = default)
		{
			var response = await _httpClient.GetAsync(requestUri: _ipv64endPoint, cancellationToken: cancellationToken);
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}

		/// <summary>
		/// Resolves the public IPv4/6 address
		/// </summary>
		/// <exception cref="System.Net.Http.HttpRequestException"/>
		/// <exception cref="System.FormatException"/>
		public static async Task<IPAddress> GetPublicIPAddressAsync(CancellationToken cancellationToken = default)
		{
			var ip = await GetPublicRawIPAsync(cancellationToken);
			return IPAddress.Parse(ip); // exception to user
		}
	}
}