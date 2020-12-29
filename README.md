# Ipify

Unofficial library (.NET Standard 1.3) for ipify [api64.ipify.org](https://api64.ipify.org).

Obtains public IPv4 or IPv6 address thought an HTTPS async call.

## Usage

### Return ip address as string

```csharp
using Oibi.Ipify;
var result = await Ipify.GetPublicRawIPAsync();
```

### Return ip address as [IPAddress](https://docs.microsoft.com/it-it/dotnet/api/system.net.ipaddress)

```csharp
using Oibi.Ipify;
var ipAddress = await Ipify.GetPublicIPAddressAsync();
```
