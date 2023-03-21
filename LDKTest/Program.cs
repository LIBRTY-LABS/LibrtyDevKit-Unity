using LibrtyDevKit;

LibrtyDevKit.LibrtyDevKit LDK = new LibrtyDevKit.LibrtyDevKit("LibrtyDubaiHack");
// Token APIs
var response = await LDK.getTokenBalance("0xc2132d05d31c914a87c6611c10748aeb04b58e8f", "0x6fe489d80a48caf7472cd45f4258b9ffb5208e3c", LDKNetworkType.polygon);
Console.WriteLine($"Data: {response.data}");
Console.WriteLine($"status: {response.status}");
Console.WriteLine($"message: {response.message}");