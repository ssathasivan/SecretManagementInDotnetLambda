using Amazon.SecretsManager.Extensions.Caching;

namespace Lambda.Secrets.AWSSDK.Infrastructure
{
    public class SecretsProvider : ISecretsProvider
    {

        //Set the cache item ttl to 15 mins
        private static SecretCacheConfiguration _cacheConfiguration = new SecretCacheConfiguration
        {
            CacheItemTTL = 900000
        };

        private SecretsManagerCache _cache = new SecretsManagerCache(_cacheConfiguration);


        public async Task<string> GetSecretAsync(string secretName)
        {
            return await _cache.GetSecretString(secretName);
        }
    }
}
