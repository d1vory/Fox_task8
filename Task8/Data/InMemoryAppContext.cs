using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Task8.Data;

public class InMemoryAppContext: BaseApplicationContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
    }
}