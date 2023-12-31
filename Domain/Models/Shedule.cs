﻿namespace WebApi.Models;

public partial class Shedule
{
    public uint SheduleId { get; set; }

    public TimeOnly DepartureTime { get; set; }

    public TimeOnly ArrivalTime { get; set; }

    public DateOnly Date { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
