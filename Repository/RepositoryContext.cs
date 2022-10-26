using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JournalConfiguration());
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
    }
    public DbSet<Journal>? Journals { get; set; }
    public DbSet<Article>? Articles { get; set; }
}