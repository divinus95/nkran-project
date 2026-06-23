// ── BUSINESS MEDIA ────────────────────────────────────────────
using Shared;

namespace BusinessService.Models;

public class BusinessMedia
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid BusinessId { get; set; }
    public MediaType Type { get; set; } = MediaType.Image;
    public string Url { get; set; } = string.Empty;
    public string? PublicId { get; set; }    // Cloudinary public_id
    public string? Caption { get; set; }
    public bool IsPrimary { get; set; } = false;
    public int SortOrder { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public Businesses? Business { get; set; }
}
