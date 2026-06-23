// ── PAYMENT ───────────────────────────────────────────────────
using Shared;

namespace BookingService.Models;

public class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? BookingId { get; set; }
    public Guid PayerId { get; set; }
    public Guid BusinessId { get; set; }

    public decimal Amount { get; set; }
    public string Currency { get; set; } = "GHS";
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    // ── Provider ─────────────────────────────────────────────
    public string? ProviderRef { get; set; }    // MoMo/Paystack transaction ref
    public string? ProviderName { get; set; }   // mtn_momo | paystack | vodafone_cash
    public string? ProviderRespJson { get; set; } // Raw JSON from provider

    // ── Timestamps ───────────────────────────────────────────
    public DateTime InitiatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PaidAt { get; set; }
    public DateTime? FailedAt { get; set; }
    public DateTime? RefundedAt { get; set; }
    public DateTime? WebhookReceivedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // ── Navigation ───────────────────────────────────────────
    public Booking? Booking { get; set; }
}
