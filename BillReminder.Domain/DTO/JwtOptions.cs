
namespace BillReminder.Domain.DTO;

public class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; init; }
    public string ApiKeyName { get; set; }
    public string ApiKey { get; set; }
}
