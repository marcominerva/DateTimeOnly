using Microsoft.EntityFrameworkCore;

namespace DateTimeOnly.DataAccessLayer;

public class DataContext : DbContext
{
    private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Chinook";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
}
