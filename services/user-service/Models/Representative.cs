// ── REPRESENTATIVE ────────────────────────────────────────────
using Shared;
using UserService.Models;

public class Representative
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid BusinessId { get; set; }
    public RepRole Role { get; set; } = RepRole.Attendant;
    public bool IsActive { get; set; } = true;
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public User? User { get; set; }
}