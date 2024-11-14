namespace Lambda.Secrets.Extension.Infrastructure
{
    public interface ISecretsProvider
    {
        Task<string> GetSecretAsync(string secretName);
    }
}
