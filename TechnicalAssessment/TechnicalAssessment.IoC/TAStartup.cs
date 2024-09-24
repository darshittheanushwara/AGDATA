using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using TechnicalAssessment.Application.User;
using TechnicalAssessment.Core.Interfaces;
using TechnicalAssessment.Domain.Commands.User;
using TechnicalAssessment.Domain.Commands.User.Validators;
using TechnicalAssessment.Domain.Interfaces.Repositories;
using TechnicalAssessment.Infrastructure.Data.Configurations;
using TechnicalAssessment.Infrastructure.Data.Context;
using TechnicalAssessment.Infrastructure.Data.Repositories;

namespace TechnicalAssessment.IoC
{
    public static class TAStartup
    {
        public static void Register(this IServiceCollection services)
        {
            //data
            services.AddScoped<IUserRepository, UserRepository>();

            //validators
            services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
            services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();

            //commandHandlers
            services.AddScoped<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();

            //queries
            services.AddScoped<IUserQueries, UserQueries>();
        }


        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = new DatabaseSettings();
            configuration.GetSection("DatabaseSettings").Bind(databaseSettings);
            services.AddSingleton<IDatabaseSettings>(databaseSettings);

            // Register Database Initializer
            services.AddSingleton<DbContext>();

            // Register Document Store
            services.AddSingleton<IDocumentStore>(sp =>
            {
                // Get the Database Initializer
                var initializer = sp.GetRequiredService<DbContext>();

                // Return the Document Store from the Database Initializer
                return initializer.DocumentStore;
            });
        }
    }
}
