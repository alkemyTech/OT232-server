using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Microsoft.Extensions.Configuration;

namespace OngProject.Core.Helper
{
    public class ImageHelper
    {
        private readonly IAmazonS3 _amazonService;
        private readonly IConfiguration _configuration;
        public ImageHelper(IAmazonS3 amazonService, IConfiguration configuration)
        {
            _amazonService = amazonService;
            _configuration = configuration;
            var chain = new CredentialProfileStoreChain("App_data\\credentials.ini");
            AWSCredentials awsCredentials;
            if (chain.TryGetAWSCredentials("default", out awsCredentials))
            {
                _amazonService = new AmazonS3Client(awsCredentials.GetCredentials().AccessKey, awsCredentials.GetCredentials().SecretKey, RegionEndpoint.USEast1);
            }
        }
    }
}
