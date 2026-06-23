using Microsoft.EntityFrameworkCore;
using BusinessService.Models;

namespace BusinessService.Data;

public class BusinessDbContext : DbContext
{
    public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
    {
    }
    public DbSet<Businesses> Businesses { get; set; }
    public DbSet<BusinessMedia> BusinessMedias { get; set; }
    public DbSet<BusinessPromotion> BusinessPromotions { get; set; }
    public DbSet<BusinessServices> BusinessServices { get; set; }
    public DbSet<DayHours> DayHours { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<SavedBusiness> SavedBusinesses { get; set; }
    public DbSet<UserInteraction> UserInteractions { get; set; }
}
