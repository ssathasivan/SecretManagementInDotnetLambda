namespace Lambda.Secrets.AWSSDK.Infrastructure
{
    public interface ISecretsProvider
    {
        Task<string> GetSecretAsync(string secretName);
    }
}
