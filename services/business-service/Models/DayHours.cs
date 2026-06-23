// ── DAY HOURS ─────────────────────────────────────────────────
using Shared;
namespace BusinessService.Models;

public class DayHours
{
    public string Open { get; set; } = "09:00";
    public string Close { get; set; } = "18:00";
    public bool Closed { get; set; } = false;
}