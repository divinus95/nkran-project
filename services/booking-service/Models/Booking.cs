// booking-service/Models/Booking.cs

using Shared;

namespace BookingService.Models;

public class Booking
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Reference { get; set; } = string.Empty;  // Auto-generated: NKR-20241201-0001

    // ── Parties ──────────────────────────────────────────────
    public Guid CustomerId { get; set; }
    public Guid BusinessId { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? RepId { get; set; }               // Assigned representative

    // ── Status ───────────────────────────────────────────────
    public BookingStatus Status { get; set; } = BookingStatus.Pending;

    // ── Scheduling ───────────────────────────────────────────
    public DateTime? ScheduledAt { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public string? CancelReason { get; set; }
    public Guid? CancelledBy { get; set; }

    // ── Financials ───────────────────────────────────────────
    public decimal? UnitPrice { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal? Subtotal { get; set; }
    public decimal DiscountAmt { get; set; } = 0m;
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; } = "GHS";

    // ── Delivery ─────────────────────────────────────────────
    public bool IsDelivery { get; set; } = false;
    public string? DeliveryAddr { get; set; }
    public decimal? DeliveryLat { get; set; }
    public decimal? DeliveryLng { get; set; }
    public decimal DeliveryFee { get; set; } = 0m;

    // ── Extras ───────────────────────────────────────────────
    public string? Notes { get; set; }
    public Guid? PromotionId { get; set; }

    // ── Timestamps ───────────────────────────────────────────
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // ── Navigation ───────────────────────────────────────────
    public Payment? Payment { get; set; }
}


// ── AUDIT LOG ─────────────────────────────────────────────────
