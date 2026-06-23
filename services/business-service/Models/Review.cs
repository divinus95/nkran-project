// ── REVIEW ────────────────────────────────────────────────────
using Shared;
namespace BusinessService.Models;

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? BookingId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BusinessId { get; set; }

    public short Rating { get; set; }      // 1–5
    public string? Comment { get; set; }
    public List<string> Images { get; set; } = new();

    // Moderation
    public bool IsVisible { get; set; } = true;
    public bool Flagged { get; set; } = false;
    public string? FlagReason { get; set; }

    // Owner reply
    public string? ReplyText { get; set; }
    public DateTime? RepliedAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Businesses? Business { get; set; }
}
