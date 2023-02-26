using System.Runtime.Serialization;

namespace CleanCQRS.Domain.Options;

[DataContract]
public class AuthOptions
{
    public const string Auth = "Auth";
    public string Realm { get; set; }
    public Uri AuthServerUrl { get; set; }

    public string Resource { get; set; }
    public string SwaggerClientId { get; set; }
    public string SwaggerClientSecret { get; set; }
}