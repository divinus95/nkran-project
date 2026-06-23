// Nkran.Shared/DTOs/AllDTOs.cs
// Request/Response DTOs shared across services
namespace Shared;
//namespace Nkran.Shared.DTOs;

// ═══════════════════════════════════════════════════════════════
// AUTH DTOs
// ═══════════════════════════════════════════════════════════════

public record RegisterDto(
    string FullName,
    string Phone,
    string? Email,
    string Password,
    UserRole Role = UserRole.Customer
);

public record LoginDto(
    string Phone,
    string Password
);

public record VerifyOtpDto(
    string Phone,
    string Code,
    string Purpose  // phone_verify | login | password_reset
);

public record AuthResponseDto(
    string AccessToken,
    string RefreshToken,
    DateTime ExpiresAt,
    UserProfileDto User
);

public record RefreshTokenDto(string Token);


// ═══════════════════════════════════════════════════════════════
// USER DTOs
// ═══════════════════════════════════════════════════════════════

public record UserProfileDto(
    Guid Id,
    string FullName,
    string Phone,
    string? Email,
    UserRole Role,
    UserStatus Status,
    string? AvatarUrl,
    bool PhoneVerified,
    bool EmailVerified,
    string? MomoNumber,
    string? MomoProvider,
    DateTime CreatedAt
);

public record UpdateProfileDto(
    string? FullName,
    string? Email,
    string? AvatarUrl,
    DateOnly? DateOfBirth,
    string? Gender,
    string? PreferredLang,
    string? MomoNumber,
    string? MomoProvider,
    string? PushToken
);

public record UpdateLocationDto(
    decimal Lat,
    decimal Lng
);


// ═══════════════════════════════════════════════════════════════
// BUSINESS DTOs
// ═══════════════════════════════════════════════════════════════

public record CreateBusinessDto(
    string Name,
    string Description,
    ServiceCategory Category,
    List<string> Tags,
    string Address,
    string? DigitalAddress,
    string City,
    decimal Lat,
    decimal Lng,
    string? Phone,
    string? Whatsapp,
    string? Email,
    string? Website,
    Dictionary<string, DayHoursDto>? OpeningHours
);

public record DayHoursDto(
    string Open,
    string Close,
    bool Closed
);

public record UpdateBusinessDto(
    string? Name,
    string? Description,
    List<string>? Tags,
    string? Address,
    string? DigitalAddress,
    decimal? Lat,
    decimal? Lng,
    string? Phone,
    string? Whatsapp,
    string? Email,
    string? Website,
    Dictionary<string, DayHoursDto>? OpeningHours,
    bool? IsActive
);

public record BusinessSummaryDto(
    Guid Id,
    string Name,
    string Slug,
    ServiceCategory Category,
    string Address,
    string City,
    decimal Lat,
    decimal Lng,
    string? Phone,
    string? LogoUrl,
    string? CoverUrl,
    decimal AvgRating,
    int TotalReviews,
    int TotalBookings,
    bool IsVerified,
    List<string> Tags,
    double? DistanceMeters = null   // Populated in proximity queries
);

public record BusinessDetailDto(
    Guid Id,
    string Name,
    string Slug,
    string? Description,
    ServiceCategory Category,
    string Address,
    string? DigitalAddress,
    string City,
    decimal Lat,
    decimal Lng,
    string? Phone,
    string? Whatsapp,
    string? Email,
    string? Website,
    Dictionary<string, string>? SocialLinks,
    string? LogoUrl,
    string? CoverUrl,
    Dictionary<string, DayHoursDto>? OpeningHours,
    bool IsVerified,
    bool IsActive,
    decimal AvgRating,
    int TotalReviews,
    int TotalBookings,
    List<string> Tags,
    List<ServiceDto> Services,
    List<BusinessMediaDto> Media,
    DateTime CreatedAt
);


// ─── SERVICE DTOs ─────────────────────────────────────────────

public record CreateServiceDto(
    string Name,
    string? Description,
    decimal Price,
    string Currency = "GHS",
    int? DurationMins = null,
    string? ImageUrl = null
);

public record ServiceDto(
    Guid Id,
    Guid BusinessId,
    string Name,
    string? Description,
    decimal Price,
    string Currency,
    int? DurationMins,
    string? ImageUrl,
    bool IsAvailable,
    int SortOrder
);


// ─── MEDIA DTOs ───────────────────────────────────────────────

public record BusinessMediaDto(
    Guid Id,
    string Url,
    string? Caption,
    bool IsPrimary,
    int SortOrder
);


// ─── REVIEW DTOs ──────────────────────────────────────────────

public record CreateReviewDto(
    Guid BookingId,
    short Rating,
    string? Comment,
    List<string>? Images
);

public record ReviewDto(
    Guid Id,
    Guid CustomerId,
    string CustomerName,
    string? CustomerAvatar,
    short Rating,
    string? Comment,
    List<string> Images,
    string? ReplyText,
    DateTime? RepliedAt,
    DateTime CreatedAt
);


// ─── REPRESENTATIVE DTOs ──────────────────────────────────────

public record AddRepresentativeDto(
    Guid UserId,
    RepRole Role
);

public record RepresentativeDto(
    Guid Id,
    Guid UserId,
    string FullName,
    string Phone,
    string? AvatarUrl,
    RepRole Role,
    bool IsActive,
    DateTime JoinedAt
);


// ─── PROMOTION DTOs ───────────────────────────────────────────

public record CreatePromotionDto(
    string Title,
    string? Description,
    string? Code,
    decimal? DiscountPct,
    decimal? DiscountAmt,
    decimal? MinOrderAmt,
    decimal? MaxDiscount,
    DateTime? StartsAt,
    DateTime? EndsAt,
    int? MaxUses
);

public record ValidatePromoDto(string Code, decimal OrderAmount);
public record PromoResultDto(bool IsValid, decimal DiscountAmt, string? Message);


// ─── FILTER / QUERY DTOs ──────────────────────────────────────

public record BusinessFilterDto(
    ServiceCategory? Category = null,
    decimal? Lat = null,
    decimal? Lng = null,
    int RadiusKm = 5,
    string? Query = null,          // Text search
    string? Tag = null,
    string SortBy = "distance",    // distance | rating | bookings
    int Page = 1,
    int PageSize = 20
);


// ═══════════════════════════════════════════════════════════════
// BOOKING DTOs
// ═══════════════════════════════════════════════════════════════

public record CreateBookingDto(
    Guid BusinessId,
    Guid? ServiceId,
    DateTime? ScheduledAt,
    int Quantity = 1,
    bool IsDelivery = false,
    string? DeliveryAddr = null,
    decimal? DeliveryLat = null,
    decimal? DeliveryLng = null,
    string? Notes = null,
    string? PromoCode = null
);

public record BookingSummaryDto(
    Guid Id,
    string Reference,
    BookingStatus Status,
    Guid BusinessId,
    string BusinessName,
    string? ServiceName,
    decimal TotalAmount,
    string Currency,
    DateTime? ScheduledAt,
    DateTime CreatedAt
);

public record BookingDetailDto(
    Guid Id,
    string Reference,
    BookingStatus Status,
    Guid CustomerId,
    string CustomerName,
    string CustomerPhone,
    Guid BusinessId,
    string BusinessName,
    string BusinessCategory,
    string BusinessPhone,
    Guid? ServiceId,
    string? ServiceName,
    decimal? ServicePrice,
    Guid? RepId,
    string? RepName,
    decimal TotalAmount,
    string Currency,
    decimal DiscountAmt,
    decimal DeliveryFee,
    bool IsDelivery,
    string? DeliveryAddr,
    DateTime? ScheduledAt,
    DateTime? ConfirmedAt,
    DateTime? CompletedAt,
    string? Notes,
    string? PaymentStatus,
    DateTime CreatedAt
);

public record UpdateBookingStatusDto(
    BookingStatus Status,
    string? Reason = null
);


// ═══════════════════════════════════════════════════════════════
// PAYMENT DTOs
// ═══════════════════════════════════════════════════════════════

public record InitiatePaymentDto(
    Guid BookingId,
    PaymentMethod Method,
    string? MomoPhone = null     // If different from account phone
);

public record PaymentResponseDto(
    Guid PaymentId,
    string? ProviderRef,
    PaymentStatus Status,
    string? Message,
    string? RedirectUrl    // For card payments
);

public record MomoWebhookDto(
    string ReferenceId,
    string Status,       // SUCCESSFUL | FAILED
    string? Reason,
    string ExternalId,   // booking_id
    decimal Amount,
    string Currency,
    string Payer         // Phone number
);


// ═══════════════════════════════════════════════════════════════
// COMMON
// ═══════════════════════════════════════════════════════════════

public record PagedResultDto<T>(
    List<T> Data,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages
);

public record ApiResponseDto<T>(
    bool Success,
    string? Message,
    T? Data,
    List<string>? Errors = null
);