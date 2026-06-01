using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TraderDashboard.Domain.Entities;
using TraderDashboard.Infrastructure.Data.Configurations;

namespace TraderDashboard.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Trade> Trades => Set<Trade>();
    public DbSet<Strategy> Strategies => Set<Strategy>();
    public DbSet<UploadLog> UploadLogs => Set<UploadLog>();
    public DbSet<BehaviourAlert> BehaviourAlerts => Set<BehaviourAlert>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TradeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}