using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Common
{
    public static class HelperMethods
    {
        public static void UploadToBlob(byte[] file, string fileName, string storageConnection, string ContainerName)
        {

            string blobContainerName = ContainerName;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnection);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(blobContainerName);

            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(fileName);
            blob.UploadFromByteArrayAsync(file, 0, file.Length);

        }
    }
}
