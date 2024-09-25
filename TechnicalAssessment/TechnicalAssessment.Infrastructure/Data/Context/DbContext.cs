using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using System.Security.Cryptography.X509Certificates;
using TechnicalAssessment.Core.Entity;
using TechnicalAssessment.Infrastructure.Data.Configurations;

namespace TechnicalAssessment.Infrastructure.Data.Context
{
    public class DbContext
    {
        private readonly IDatabaseSettings _databaseSettings;
        public IDocumentStore DocumentStore { get; private set; }

        public DbContext(IDatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            InitializeDocumentStore();
            CreateDatabaseIfNotExists();
        }

        // Initializes the DocumentStore with the provided database settings
        private void InitializeDocumentStore()
        {
            var clientCertificate = new X509Certificate2(_databaseSettings.CertificatePath, _databaseSettings.CertificatePassword);

            DocumentStore = new DocumentStore
            {
                Urls = _databaseSettings.Url,
                Database = _databaseSettings.Database,
                Certificate = clientCertificate
            };
            DocumentStore.Initialize();

            DocumentStore.OnBeforeStore += (sender, args) =>
            {
                if (args.Entity is IEntity auditable)
                {
                    var now = DateTime.UtcNow;
                    auditable.Created = now;

                    if (!string.IsNullOrEmpty(args.DocumentId))
                    {
                        auditable.Updated = now;
                    }
                }
            };
        }

        private void CreateDatabaseIfNotExists()
        {
            try
            {
                // Check if the database exists
                var dbRecord = DocumentStore.Maintenance.Server.Send(new GetDatabaseRecordOperation(_databaseSettings.Database));
                if (dbRecord == null)
                {
                    // Create the database if it doesn't exist
                    var createDatabaseOperation = new CreateDatabaseOperation(new DatabaseRecord(_databaseSettings.Database));
                    DocumentStore.Maintenance.Server.Send(createDatabaseOperation);

                    Console.WriteLine($"Database '{_databaseSettings.Database}' created successfully.");
                }
                else
                {
                    Console.WriteLine($"Database '{_databaseSettings.Database}' already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the database: {ex.Message}");
            }
        }

        // Returns the initialized DocumentStore
        public IDocumentStore GetStore() => DocumentStore;
    }
}
