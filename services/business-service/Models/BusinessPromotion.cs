// ── PROMOTION ─────────────────────────────────────────────────
using Shared;
namespace BusinessService.Models;

public class BusinessPromotion
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BusinessId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Code { get; set; }               // e.g. NKRAN20
    public decimal? DiscountPct { get; set; }       // e.g. 20.00 = 20%
    public decimal? DiscountAmt { get; set; }       // Fixed GHS off
    public decimal? MinOrderAmt { get; set; }
    public decimal? MaxDiscount { get; set; }

    public DateTime? StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public int? MaxUses { get; set; }
    public int UsedCount { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Businesses? Business { get; set; }
}
