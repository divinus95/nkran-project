
using Shared;
namespace UserService.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // ── Identity ─────────────────────────────────────────────
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string Phone { get; set; } = string.Empty;        // Primary identifier
    public string PasswordHash { get; set; } = string.Empty;

    // ── Role & Status ────────────────────────────────────────
    public UserRole Role { get; set; } = UserRole.Customer;
    public UserStatus Status { get; set; } = UserStatus.Pending;

    // ── Profile ──────────────────────────────────────────────
    public string? AvatarUrl { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string PreferredLang { get; set; } = "en";

    // ── Location ─────────────────────────────────────────────
    public decimal? LastLat { get; set; }
    public decimal? LastLng { get; set; }
    public DateTime? LastSeenAt { get; set; }

    // ── MoMo ─────────────────────────────────────────────────
    public string? MomoNumber { get; set; }
    public string? MomoProvider { get; set; }  // mtn | airteltigo | vodafone

    // ── Push Notifications ───────────────────────────────────
    public string? PushToken { get; set; }     // FCM token

    // ── Verification ─────────────────────────────────────────
    public bool EmailVerified { get; set; } = false;
    public bool PhoneVerified { get; set; } = false;

    // ── Auth tokens ──────────────────────────────────────────
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExp { get; set; }

    // ── Timestamps ───────────────────────────────────────────
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // ── Navigation ───────────────────────────────────────────
    public ICollection<Representative> Representations { get; set; } = new List<Representative>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
