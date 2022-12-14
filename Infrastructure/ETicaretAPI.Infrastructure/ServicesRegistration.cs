using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Infrastructure
{
    public static class ServicesRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileService, FileService>();
        }
    }
}
