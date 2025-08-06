using DotNetEnv;

namespace Configuration
{
    public static class AppConfiguration
    {
        static AppConfiguration()
        {
            // Load .env file when the class is first accessed
            Env.Load();
        }

        public static string BlobServiceEndpoint => 
            Environment.GetEnvironmentVariable("BLOB_SERVICE_ENDPOINT") 
            ?? throw new InvalidOperationException("BLOB_SERVICE_ENDPOINT environment variable is not set");

        public static string StorageAccountName => 
            Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_NAME") 
            ?? throw new InvalidOperationException("STORAGE_ACCOUNT_NAME environment variable is not set");

        public static string StorageAccountKey => 
            Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_KEY") 
            ?? throw new InvalidOperationException("STORAGE_ACCOUNT_KEY environment variable is not set");


        // Optional: Validate that all required configuration is present
        public static void ValidateConfiguration()
        {
            try
            {
                _ = BlobServiceEndpoint;
                _ = StorageAccountName;
                _ = StorageAccountKey;
                Console.WriteLine("✓ Configuration validation passed");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ Configuration validation failed: {ex.Message}");
                throw;
            }
        }
    }
}