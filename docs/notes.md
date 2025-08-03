# Dotnet command for the project

## .NET SDK Version Management

### Check installed .NET versions
```sh
$ dotnet --list-sdks
$ dotnet --version
```

### Create global.json to pin SDK version (like .nvmrc for Node.js)
```sh
$ dotnet new globaljson --sdk-version 8.0.0
```

### The global.json file content:
```json
{
  "sdk": {
    "version": "8.0.0",
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

## How to build the console app

```sh
$ dotnet build
```