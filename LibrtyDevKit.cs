using System;
using System.Net.Http;

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

    public void getTokenBalance(string tokenAddress, string walletAddress, int networkType) {
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + "/api/token/"+tokenAddress+"/balance?walletAddress="+ walletAddress +"&network=" + networkType);
        executeGetRequest(request);
    }

    public void getTokenTransaction(string tokenAddress, string walletAddress, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/transactions?walletAddress=" + walletAddress + "&network=" + networkType);
        executeGetRequest(request);
    }

    public void getTokenPrice(string tokenAddress, int networkType) {
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/price?network=" + networkType);
        executeGetRequest(request);
    }

    public void getTokenInfo(string tokenAddress, int networkType) {
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/info?network=" + networkType);
        executeGetRequest(request);
    }

    public void getNativeTokenBalance(string walletAddress, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/native/balance?walletAddress="+walletAddress+"&network=" + networkType);
        executeGetRequest(request);
    }
    public void getTokenAllowance(string tokenAddress, string walletAddress, string spenderWalletAddress, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/token/"+tokenAddress+"/allowance?&network=" + networkType+"&walletAddress="+walletAddress+"&spender="+spenderWalletAddress);
        executeGetRequest(request);
    }

    public void getTokensInWallet(string walletAddress, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get,  baseUrl+"/api/token/portfolio?network=" + networkType + "&walletAddress="+walletAddress);
        executeGetRequest(request);
    }

    public void getNFTInfo(string nftAddress, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/nft/"+nftAddress+"/45/info?network=" + networkType);
        executeGetRequest(request);
    }
    public void getCollectionInfo(string nftAddress, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/nft/"+nftAddress+"/info?network=1");
        executeGetRequest(request);
    }
    public void getTransactionDetails(string transactionId, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/account/transaction/"+transactionId+"?network=137");
        executeGetRequest(request);
    }
    public void getGasFee(string walletAddress, int networkType){
        var request = new HttpRequestMessage(HttpMethod.Get, baseUrl+"/api/account/total-fees?network="+networkType+"&walletAddress="+walletAddress);
        executeGetRequest(request);
    }
}