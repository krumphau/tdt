using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace TDTapi.Utils
{
    public class S3Util
    {
        string accessKey = "x";
        string secretKey = "z";
        string bucketName = "tdt-document-files";
        string downloadFolder = @".\downloads";
        AmazonS3Config config = new AmazonS3Config();
        AmazonS3Client s3Client;
        public S3Util() 
        {
            config.RegionEndpoint = RegionEndpoint.EUWest2;

            s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    );
        }

        public void UploadFile(Stream fileStream, String name)
        {
            TransferUtility transfer = new TransferUtility(s3Client);

            transfer.Upload(fileStream, bucketName, name);
        }

        public async Task<string> DownloadFile(string fileName)
        {
            var file = await s3Client.GetObjectAsync(bucketName, fileName);
            string filePath = Path.Combine(downloadFolder, fileName);
            await file.WriteResponseStreamToFileAsync(filePath, false, default(CancellationToken));
            return filePath;
        }

        public void DeleteFile(string name)
        {
            s3Client.DeleteObjectAsync(bucketName, name);
        }

        public async Task<List<string>> ListBucketContents()
        {

            ListObjectsV2Request request = new ListObjectsV2Request();
            request.BucketName = bucketName;

            ListObjectsV2Response resp = await s3Client.ListObjectsV2Async(request);

            List<string> fileNames = new List<string>();
            foreach(var s3Object in resp.S3Objects)
            {
                fileNames.Add(s3Object.Key);

            }

            return fileNames;
        }
    }
}
