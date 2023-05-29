using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend2.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options){

            try
            {
                var databaseCreator = this.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                    }
                }
            }
            catch (System.Exception)
            {   
                throw;
            }
        }

        public DbSet<NoRelational> NoRelational {get;set;}
    } 
}