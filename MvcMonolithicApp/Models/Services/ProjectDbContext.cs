using Microsoft.EntityFrameworkCore;
using MvcMonolithicApp.Models.DomainModels.PersonAggregate;
using MvcMonolithicApp.Models.DomainModels.ProductAggregate;

namespace MvcMonolithicApp.Models.Services;

public class ProjectDbContext : DbContext
{
    #region [ - Default Constructor() - ]

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
        
    }

    #endregion
    
    #region [ - DbSets - ]

    public DbSet<Person> Person { get; set; }
    public DbSet<Product> Product { get; set; }

    #endregion
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 2);
    }
}