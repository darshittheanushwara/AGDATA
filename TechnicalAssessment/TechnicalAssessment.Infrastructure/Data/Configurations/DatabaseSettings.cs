namespace TechnicalAssessment.Infrastructure.Data.Configurations
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string Database { get; set; }
        public string[] Url { get; set; }
        public string CertificatePath { get; set; }
        public string CertificatePassword { get; set; }
    }
}
