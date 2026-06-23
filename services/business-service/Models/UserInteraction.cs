using Shared;
namespace BusinessService.Models;
// ── USER INTERACTION (for AI feed) ────────────────────────────
public class UserInteraction
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? UserId { get; set; }
    public string? SessionId { get; set; }
    public Guid BusinessId { get; set; }
    public string Action { get; set; } = string.Empty;  // view|click|save|share|call
    public string? Source { get; set; }                 // search|recommendation|category|map
    public int? DurationSecs { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}