using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
/// <summary>
/// tell tools how to create db-context by implement the IDesignTimeDbContextFactory<TContext>
/// if a class implementing this interface is found in either the same project as the derived DbContext or in
/// the application's startup project, the tools bypass the other ways of creating the Dbcontext and use the
/// design-time factory instead.
/// </summary>
namespace Data.EF
{
    //declaring db-context at desing-time
    public  class ProjectDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            //start get info-config from json file, auto reload if file is changed
            ConfigurationBuilder l_configuration = new ConfigurationBuilder();
            l_configuration.SetBasePath(Directory.GetCurrentDirectory());
            l_configuration.AddJsonFile(path: "./appsettings.json", optional: false, reloadOnChange: true);
            var l_configurer = l_configuration.Build();
            //end

            var l_optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            l_optionsBuilder.UseSqlServer(connectionString: l_configurer["ConnectionStrings:db1"]);

            //return ProjectDbContext within configured DbContext
            return new ProjectDbContext(l_optionsBuilder.Options);
        }
    }
}
