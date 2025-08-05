using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Configuration;

public class Program
{

    public static async Task Main(string[] args)
    {
        string blobServiceEndpoint = AppConfiguration.BlobServiceEndpoint;
        string storageAccountName = AppConfiguration.StorageAccountName;
        string storageAccountKey = AppConfiguration.StorageAccountKey;

        StorageSharedKeyCredential accountCredentials = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);
        BlobServiceClient serviceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), accountCredentials);

        AccountInfo info = await serviceClient.GetAccountInfoAsync();

        await Console.Out.WriteLineAsync($"Azure Storage Account service connected");

        await Console.Out.WriteLineAsync($"Account name: {storageAccountName}");

        await Console.Out.WriteLineAsync($"Account type: {info?.AccountKind}");

        await Console.Out.WriteLineAsync($"Account SKU: {info?.SkuName}");

    }

}