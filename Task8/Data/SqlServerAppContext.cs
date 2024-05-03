using Microsoft.EntityFrameworkCore;

namespace Task8.Data;

public class SqlServerAppContext: BaseApplicationContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"data source=o-dubchak-pc2\SQLEXPRESS;initial catalog=foxminded;trusted_connection=true;TrustServerCertificate=True;");
    }
}