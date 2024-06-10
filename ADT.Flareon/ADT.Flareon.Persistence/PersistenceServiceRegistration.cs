using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ADT.Flareon.Application.Intefaces.Persistence;
using ADT.Flareon.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.Flareon.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //AWS Config
            services.AddAWSService<IAmazonDynamoDB>();
            AWSOptions awsOptions = configuration.GetAWSOptions();
            awsOptions.Credentials = new BasicAWSCredentials("", "") ;

            services.AddDefaultAWSOptions(awsOptions);
            services.AddScoped<IDynamoDBContext, DynamoDBContext>();

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IOrderLastInsertedIdTableRepository, OrderLastInsertedIdTableRepository>();

            return services;
        }
    }
}
