using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace ReelJett.Domain.Helpers
{
    public static class BlobHandler
    {
        public static async Task<string> UploadToBlobStorage(byte[] file)
        {
            try
            {
                ConfigurationBuilder configurationBuilder = new();
                var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();
                var constr = builder.GetConnectionString("blobstorage");
                var blobServiceClient = new BlobServiceClient(constr);

                var blobContainerClient = blobServiceClient.GetBlobContainerClient("reeljettimages");

                await blobContainerClient.CreateIfNotExistsAsync();

                var blobClient = blobContainerClient.GetBlobClient(Guid.NewGuid().ToString());

                using (var stream = new MemoryStream(file))
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                }

                var imageUrl = blobClient.Uri.ToString();
                return imageUrl;
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return "";
            }
            
        }

        public static async Task DeleteBlob(string blobUrl)
        {

            ConfigurationBuilder configurationBuilder = new();
            var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();
            var constr = builder.GetConnectionString("blobstorage");
            var blobServiceClient = new BlobServiceClient(constr);

            var blobContainerClient = blobServiceClient.GetBlobContainerClient("reeljettimages");
            var uri = new Uri(blobUrl);
            string blobName = uri.Segments[^1];
            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient(blobName);

            await blobClient.DeleteIfExistsAsync();
        }
    }
}
