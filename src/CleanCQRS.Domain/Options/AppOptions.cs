namespace CleanCQRS.Domain.Options;

public class AppOptions
{
    public const string App = "App";
    public string AppName { get; set; }
    public string AppVersion { get; set; }
    public string AppDescription { get; set; }
    public string AppAuthor { get; set; }
    public string AppAuthorUrl { get; set; }
    public string AppAuthorEmail { get; set; }
    public string AppAuthorPhone { get; set; }
    public string AppLicense { get; set; }
    public string AppLicenseUrl { get; set; }
    public string AppTermsOfServiceUrl { get; set; }
    public string AppPrivacyPolicyUrl { get; set; }
}