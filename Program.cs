using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Configuration;

public class Program
{
    private string blobServiceEndpoint = AppConfiguration.BlobServiceEndpoint;
    private string storageAccountName = AppConfiguration.StorageAccountName;
    private string storageAccountKey = AppConfiguration.StorageAccountKey;

    public static async Task Main(string[] args)
    {
        
    }

}