// Nkran.Shared/Enums/NkranEnums.cs
// Shared across booking-service, business-service, user-service
//namespace Nkran.Shared.Enums;
namespace Shared;

public enum UserRole
{
    Customer,
    Owner,
    Representative,
    Admin
}

public enum UserStatus
{
    Pending,
    Active,
    Inactive,
    Suspended
}

public enum ServiceCategory
{
    Laundry,
    Barbering,
    Salon,
    Restaurant,
    FastFood,
    Pub,
    Bar,
    Church,
    Mosque,
    CarRental,
    Pharmacy,
    Clinic,
    Hospital,
    Hotel,
    Guesthouse,
    Grocery,
    Supermarket,
    Gym,
    Market,
    Mechanic,
    Photography,
    EventPlanning,
    Catering,
    Bakery,
    Printing,
    Tailoring,
    Cleaning,
    Plumbing,
    Electrician,
    Other
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    InProgress,
    Completed,
    Cancelled,
    NoShow
}

public enum PaymentMethod
{
    MomoMtn,
    MomoAirteltigo,
    MomoVodafone,
    BankTransfer,
    Card,
    Cash
}

public enum PaymentStatus
{
    Pending,
    Processing,
    Success,
    Failed,
    Refunded,
    Cancelled
}

public enum NotificationType
{
    BookingCreated,
    BookingConfirmed,
    BookingCompleted,
    BookingCancelled,
    PaymentSuccess,
    PaymentFailed,
    NewReview,
    Promotion,
    System,
    Chat
}

public enum RepRole
{
    Delivery,
    Attendant,
    Cashier,
    Barber,
    Chef,
    Driver,
    Cleaner,
    Receptionist,
    Other
}

public enum MediaType
{
    Image,
    Video
}