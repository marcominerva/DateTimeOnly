using DateTimeOnly.DataAccessLayer.Converters;
using Microsoft.EntityFrameworkCore;

namespace DateTimeOnly.DataAccessLayer;

public class DataContext : DbContext
{
    private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DateTimeDB";

    public DbSet<Entities.Invoice> Invoices { get; set; }

    public DbSet<Entities.Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        _ = configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter, DateOnlyComparer>().HaveColumnType("date");
        _ = configurationBuilder.Properties<TimeOnly>().HaveConversion<TimeOnlyConverter, TimeOnlyComparer>().HaveColumnType("time(7)");

        base.ConfigureConventions(configurationBuilder);
    }
}
