using Lambda.Secrets.Extension.Infrastructure;

using Microsoft.AspNetCore.Mvc;

namespace Lambda.Secrets.Extension.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SecretsController : ControllerBase
{
    private readonly ILogger<SecretsController> _logger;
    private readonly ISecretsProvider _secretsProvider;

    private const string SECRET_NAME_KEY = "DbSecretName";

    public SecretsController(ILogger<SecretsController> logger, ISecretsProvider secretsProvider)
    {
        _logger = logger;
        _secretsProvider = secretsProvider;
    }



    [HttpGet()]
    public async Task<IActionResult> CanFetchSecrets()
    {
        var secretName = Environment.GetEnvironmentVariable(SECRET_NAME_KEY);
        _logger.LogInformation($"The secret name : {secretName} ");
        string secret = await _secretsProvider.GetSecretAsync(secretName);
        if (string.IsNullOrWhiteSpace(secret))
        {
            return Ok("Failed to fetch secret");
        }
        return Ok("Successfully fetched Secrets");
    }



}