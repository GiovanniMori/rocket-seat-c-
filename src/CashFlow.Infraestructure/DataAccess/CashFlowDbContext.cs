using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infraestructure;

public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "server=localhost;port=3306;database=cashflow;user=cashflow;password=12345";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
