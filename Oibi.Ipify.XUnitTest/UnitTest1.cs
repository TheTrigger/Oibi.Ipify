using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Oibi.Ipify.XUnitTest
{
	public class UnitTest1
	{
		[Fact]
		public async Task TestRaw()
		{
			var result = await Ipify.GetPublicRawIPAsync();
			Assert.NotEmpty(result);
		}

		[Fact]
		public async Task TestIPAddress()
		{
			var ipAddress = await Ipify.GetPublicIPAddressAsync();
			Assert.True(ipAddress.AddressFamily == AddressFamily.InterNetwork || ipAddress.AddressFamily == AddressFamily.InterNetworkV6);
		}

		[Fact]
		public async Task TestCancellationToken()
		{
			var cancellationTokenSource = new CancellationTokenSource();
			var task = Ipify.GetPublicRawIPAsync(cancellationTokenSource.Token);
			cancellationTokenSource.Cancel();

			await Assert.ThrowsAsync<TaskCanceledException>(() => task);
		}

		[Fact]
		public void TestParseIPv6()
		{
			const string ip = "2b00:1180:100b:81d::100e";
			var ipv6 = IPAddress.Parse(ip);

			Assert.Equal(ip, ipv6.ToString());
			Assert.Equal(AddressFamily.InterNetworkV6, ipv6.AddressFamily);
		}
	}
}