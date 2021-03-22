using Azure.Storage.Blobs;
using System.Threading.Tasks;

namespace BlazorAO.App.Services
{
    public class AzureTester
    {
        public async Task<bool> TestConnectionAsync(string connectionString, string containerName)
        {
            try
            {
                var client = new BlobContainerClient(connectionString, containerName);
                await client.CreateIfNotExistsAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
