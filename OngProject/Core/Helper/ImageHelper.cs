using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class ImageHelper : IImageHelper
    {
        private readonly IAmazonS3 _amazonService;
        private readonly IConfiguration _configuration;
        private BasicAWSCredentials _credentials;

        public ImageHelper(/*IAmazonS3 amazonService,*/ IConfiguration configuration)
        {
            _configuration = configuration;
            _credentials = new BasicAWSCredentials(_configuration["AWS:AccessKey"], _configuration["AWS:SecretKey"]);
            _amazonService = new AmazonS3Client(_credentials, RegionEndpoint.SAEast1);

            //var chain = new CredentialProfileStoreChain("App_data\\credentials.ini");
            //AWSCredentials awsCredentials;
            //if (chain.TryGetAWSCredentials("default", out awsCredentials))
            //{
            //    _amazonService = new AmazonS3Client(awsCredentials.GetCredentials().AccessKey, awsCredentials.GetCredentials().SecretKey, RegionEndpoint.SAEast1);
            //}
        }

        public async Task<string> UploadFile(IFormFile file)
        {

            var request = new PutObjectRequest
            {
                BucketName = _configuration["AWS:BucketName"],
                Key = file.FileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType
            };

            var result = await _amazonService.PutObjectAsync(request);

            var url = $"https://{_configuration["AWS:BucketName"]}.s3.sa-east-1.amazonaws.com/{file.FileName}";

            return url;
        }
    }
}
