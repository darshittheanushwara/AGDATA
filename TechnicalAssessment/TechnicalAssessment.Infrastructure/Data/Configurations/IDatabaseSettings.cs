namespace TechnicalAssessment.Infrastructure.Data.Configurations
{
    public interface IDatabaseSettings
    {
        string Database { get; set; }
        string[] Url { get; set; }
        string CertificatePath { get; set; }
        string CertificatePassword { get; set; }
    }
}
