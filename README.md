# nkran-project
# supase_default  db_supa_nkran

postgresql://postgres:db_supa_nkran@db.uclumsrrafutckqewvqe.supabase.co:5432/postgres

# Installs the EF Core command-line tool globally if you don't have it
dotnet tool install --global dotnet-ef

# Creates a migration file based on your C# models
dotnet ef migrations add InitialSupabaseSetup

# Executes the migration and builds the tables inside your Supabase database
dotnet ef database update


using Microsoft.EntityFrameworkCore;
using UserService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add PostgreSQL service registration
var connectionString = builder.Configuration.GetConnectionString("SupabaseConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // This property automatically maps your User class to a "Users" table in Supabase
    public DbSet<User> Users { get; set; } 
}
