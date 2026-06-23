
using Shared;
namespace BusinessService.Models;

public class Businesses
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OwnerId { get; set; }

    // ── Identity ─────────────────────────────────────────────
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;        // URL-safe unique name
    public string? Description { get; set; }
    public ServiceCategory Category { get; set; }
    public List<string> Tags { get; set; } = new();

    // ── Location ─────────────────────────────────────────────
    public string Address { get; set; } = string.Empty;
    public string? DigitalAddress { get; set; }              // Ghana Post GPS
    public string City { get; set; } = "Accra";
    public string Region { get; set; } = "Greater Accra";
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
    // PostGIS geometry handled separately via raw SQL / Dapper

    // ── Contact ──────────────────────────────────────────────
    public string? Phone { get; set; }
    public string? Whatsapp { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public Dictionary<string, string>? SocialLinks { get; set; }

    // ── Media ────────────────────────────────────────────────
    public string? LogoUrl { get; set; }
    public string? CoverUrl { get; set; }

    // ── Hours ────────────────────────────────────────────────
    // Stored as JSON: { "mon": { "open": "08:00", "close": "18:00", "closed": false } }
    public Dictionary<string, DayHours>? OpeningHours { get; set; }

    // ── Status ───────────────────────────────────────────────
    public bool IsVerified { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; } = false;
    public DateTime? VerifiedAt { get; set; }

    // ── Stats (denormalised) ─────────────────────────────────
    public decimal AvgRating { get; set; } = 0m;
    public int TotalReviews { get; set; } = 0;
    public int TotalBookings { get; set; } = 0;

    // ── Payments ─────────────────────────────────────────────
    public string? MomoMerchant { get; set; }
    public string? MomoProvider { get; set; }
    public string? PaystackRef { get; set; }

    // ── Timestamps ───────────────────────────────────────────
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // ── Navigation ───────────────────────────────────────────
    public ICollection<BusinessMedia> Media { get; set; } = new List<BusinessMedia>();
    public ICollection<BusinessServices> Services { get; set; } = new List<BusinessServices>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<BusinessPromotion> Promotions { get; set; } = new List<BusinessPromotion>();
}
