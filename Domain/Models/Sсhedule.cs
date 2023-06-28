namespace WebApi.Models;

public partial class Sсhedule
{
    public uint SсheduleId { get; set; }

    public TimeOnly DepartureTime { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public DateOnly Date { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
