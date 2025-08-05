# Dotnet command for the project

## .NET SDK Version Management

### Check installed .NET versions
```sh
$ dotnet --list-sdks
$ dotnet --version
```

### Create global.json to pin SDK version (like .nvmrc for Node.js)
```sh
$ dotnet new globaljson --sdk-version 8.0.411
```

### The global.json file content:
```json
{
  "sdk": {
    "version": "8.0.411",
    "rollForward": "latestPatch"
  }
}
```

## How to create the project

```sh
$ dotnet new console --framework net8.0 --name BlobManager --output .
```


## How to install Azure.Storage.Blobs package

```sh
$ dotnet add package Azure.Storage.Blobs --version 12.18.0
```

## How to install DotNetEnv package for .env file support

```sh
$ dotnet add package DotNetEnv
```

## Environment Configuration

1. Copy `.env.example` to `.env`:
```sh
$ cp .env.example .env
```

2. Edit `.env` file and add your actual Azure Storage credentials:
```txt
BLOB_SERVICE_ENDPOINT=https://yourstorageaccount.blob.core.windows.net/
STORAGE_ACCOUNT_NAME=yourstorageaccount
STORAGE_ACCOUNT_KEY=your_actual_storage_account_key
```

3. Use the Configuration class in your code:
```csharp
// Using static Configuration class
var connectionString = Configuration.Configuration.ConnectionString;
var storageAccountName = Configuration.Configuration.StorageAccountName;

// Or using instance-based AppConfiguration class
var config = new AppConfiguration();
var blobServiceClient = new BlobServiceClient(config.ConnectionString);
```

**Note**: The `.env` file is gitignored and should never be committed to version control.

## How to build the console app

```sh
$ dotnet build
```

## How to run the console application

```sh
$ dotnet run
```