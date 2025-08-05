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

        await EnumerateContainersAsync(serviceClient);

        string existingContainerName = "raster-graphics";

        await EnumerateBlobsAsync(serviceClient, existingContainerName);

        string newContainerName = "vectors-graphics";

        BlobContainerClient containerClient = await GetContainerAsync(serviceClient, newContainerName);
    }

    private static async Task EnumerateContainersAsync(BlobServiceClient client)
    {
        await foreach (BlobContainerItem container in client.GetBlobContainersAsync())
        {
            await Console.Out.WriteLineAsync($"Container: {container.Name}");
        }
    }

    private static async Task EnumerateBlobsAsync(BlobServiceClient client, string containerName)
    {
        BlobContainerClient container = client.GetBlobContainerClient(containerName);
        await Console.Out.WriteLineAsync($"Searching in: {container.Name}");
        await foreach (BlobItem blob in container.GetBlobsAsync())
        {
            await Console.Out.WriteLineAsync($"Blob: {blob.Name}");
        }
    }

    private static async Task<BlobContainerClient> GetContainerAsync(BlobServiceClient client, string containerName)
    {
        BlobContainerClient container = client.GetBlobContainerClient(containerName);

        await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

        await Console.Out.WriteLineAsync($"New container called: {containerName}");

        return container;
    }


}