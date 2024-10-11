using Entites.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace E_Learning.ContextFactory
{
	public class RepositoryContextFactory : IDesignTimeDbContextFactory<ElearingDbcontext>
	{
		public ElearingDbcontext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();
			var builder = new DbContextOptionsBuilder<ElearingDbcontext>()
			.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
			b => b.MigrationsAssembly("E-Learning"));
			return new ElearingDbcontext(builder.Options);

		}
	}
}
