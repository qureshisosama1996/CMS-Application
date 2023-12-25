
using CMStool.data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



public class CMSDbContext : DbContext
    {
  

    // Retrieve connection string
    public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for your entity classes here
        public DbSet<AI_Data> AIData_table { get; set; }

       


    }


