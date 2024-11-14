using System.Web;

using Amazon.SecretsManager.Model;


namespace Lambda.Secrets.Extension.Infrastructure
{
    public class SecretsProvider : ISecretsProvider
    {
        private readonly HttpClient _httpClient;

        private readonly string GetSecretsEndpoint = "/secretsmanager/get?secretId=";

        public SecretsProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            var httpRequest = new HttpRequestMessage(
                HttpMethod.Get,
                new Uri($"{GetSecretsEndpoint}{HttpUtility.UrlEncode(secretName)}", UriKind.Relative));

            //Pass X-Aws-Parameters-Secrets-Token as a header. This is a required header that uses the AWS_SESSION_TOKEN value,
            //which is present in the Lambda execution environment by default. 
            httpRequest.Headers.Add("X-Aws-Parameters-Secrets-Token",
                Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN")
            );
            var response = await _httpClient
                .SendAsync(httpRequest)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var responseAsJson = await response.Content.ReadFromJsonAsync<GetSecretValueResponse>();
            return responseAsJson!.SecretString;
        }
    }
}
