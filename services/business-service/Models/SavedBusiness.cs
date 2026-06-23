using Shared;
namespace BusinessService.Models;
// ── SAVED BUSINESS ────────────────────────────────────────────
public class SavedBusiness
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid BusinessId { get; set; }
    public DateTime SavedAt { get; set; } = DateTime.UtcNow;
}