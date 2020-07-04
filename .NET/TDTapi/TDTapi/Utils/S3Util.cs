using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        string accessKey = "";
        string secretKey = "";
        string bucketName = "tdt-document-files";
        string downloadFolder = @".\downloads";
        
        public void UploadFile(Stream fileStream, String name)
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            AmazonS3Config config = new AmazonS3Config();
            config.RegionEndpoint = RegionEndpoint.EUWest2;
            using (AmazonS3Client s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    ))
            {
                using (TransferUtility transfer = new TransferUtility(s3Client))
                {
                    transfer.Upload(fileStream, bucketName, name);
                }
            }
        }

        public async Task<string> DownloadFile(string fileName)
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            AmazonS3Config config = new AmazonS3Config();
            config.RegionEndpoint = RegionEndpoint.EUWest2;
            using (AmazonS3Client s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    ))
            {
                var file = await s3Client.GetObjectAsync(bucketName, fileName);
                string filePath = Path.Combine(downloadFolder, fileName);
                await file.WriteResponseStreamToFileAsync(filePath, false, default(CancellationToken));
                return filePath;
            }
        }

        public string GetTempURLForFile(string fileName)
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            AmazonS3Config config = new AmazonS3Config();
            config.RegionEndpoint = RegionEndpoint.EUWest2;
            using (AmazonS3Client s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    ))
            {
                GetPreSignedUrlRequest request1 =
                new GetPreSignedUrlRequest()
                {
                    BucketName = bucketName,
                    Key = fileName,
                    Expires = DateTime.Now.AddMinutes(5)
                };

                return s3Client.GetPreSignedURL(request1);
            }
        }

        public void DeleteFile(string name)
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            AmazonS3Config config = new AmazonS3Config();
            config.RegionEndpoint = RegionEndpoint.EUWest2;
            using (AmazonS3Client s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    ))
            {
                s3Client.DeleteObjectAsync(bucketName, name);
            }
        }

        public async Task<List<string>> ListBucketContents()
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            AmazonS3Config config = new AmazonS3Config();
            config.RegionEndpoint = RegionEndpoint.EUWest2;
            using (AmazonS3Client s3Client = new AmazonS3Client(
                    accessKey,
                    secretKey,
                    config
                    ))
            {
                ListObjectsV2Request request = new ListObjectsV2Request();
                request.BucketName = bucketName;

                ListObjectsV2Response resp = await s3Client.ListObjectsV2Async(request);
                List<string> fileNames = new List<string>();
                foreach (var s3Object in resp.S3Objects)
                {
                    fileNames.Add(s3Object.Key);

                }

                while (resp.IsTruncated)
                {
                    request.ContinuationToken = resp.NextContinuationToken;
                    resp = await s3Client.ListObjectsV2Async(request);
                    foreach (var s3Object in resp.S3Objects)
                    {
                        fileNames.Add(s3Object.Key);

                    }
                }

                return fileNames;
            }
        }
    }
}
