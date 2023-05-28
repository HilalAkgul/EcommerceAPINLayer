using System;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddDalModules(this IServiceCollection services
			)
		{
			services.AddDbContextPool<AppDbContext>(opt => opt.UseSqlServer(
                "Server=tcp:127.0.0.1;Database=TestDb;UID=sa;PWD=MyPass@word;TrustServerCertificate=True"

                )); ;
			services.AddScoped(typeof(AppRepository<>));
			return services;
		}
	}
}

