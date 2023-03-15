using System;
using System.Net.Http;


public enum LDKNetworkType : int
{
    ethereum  = 1,
    goerli = 5,
    simulation = 3,
    polygon = 137,
    mumbai = 80001,
    ronin = 2020
}

public class LibrtyDevKit 
{
    string baseUrl = "http://ec2-3-110-219-61.ap-south-1.compute.amazonaws.com:3000";
    string apiKey ;
    HttpClient client = new HttpClient();

    public LibrtyDevKit(string devApiKey){
        apiKey = devApiKey;
    }
    private async void executeGetRequest(HttpRequestMessage request){
        request.Headers.Add("x-api-key", apiKey);
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }

    public void getTokenBalance(string tokenAddress, string walletAddress, LDKNetworkType network) {
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "/api/token/"+tokenAddress+"/balance?walletAddress="+ walletAddress +"&network=" + (int)network);
        executeGetRequest(request);
    }

    public void getTokenTransaction(string tokenAddress, string walletAddress, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/transactions?walletAddress=" + walletAddress + "&network=" + (int)network);
        executeGetRequest(request);
    }

    public void getTokenPrice(string tokenAddress, LDKNetworkType network) {
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/price?network=" + (int)network);
        executeGetRequest(request);
    }

    public void getTokenInfo(string tokenAddress, LDKNetworkType network) {
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/info?network=" + (int)network);
        executeGetRequest(request);
    }

    public void getNativeTokenBalance(string walletAddress, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/native/balance?walletAddress="+walletAddress+"&network=" + (int)network);
        executeGetRequest(request);
    }
    public void getTokenAllowance(string tokenAddress, string walletAddress, string spenderWalletAddress, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/allowance?&network=" + (int)network+"&walletAddress="+walletAddress+"&spender="+spenderWalletAddress);
        executeGetRequest(request);
    }

    public void getTokensInWallet(string walletAddress, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get,  baseUrl+"/api/token/portfolio?network=" + (int)network + "&walletAddress="+walletAddress);
        executeGetRequest(request);
    }

    public void getNFTInfo(string nftAddress, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/nft/"+nftAddress+"/45/info?network=" + (int)network);
        executeGetRequest(request);
    }
    public void getCollectionInfo(string nftAddress, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/nft/"+nftAddress+"/info?network=1");
        executeGetRequest(request);
    }
    public void getTransactionDetails(string transactionId, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/account/transaction/"+transactionId+"?network="+(int)network);
        executeGetRequest(request);
    }
    public async void getGasFee(string walletAddress, LDKNetworkType network){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/account/total-fees?network="+(int)network+"&walletAddress="+walletAddress);
        executeGetRequest(request);
    }
}
