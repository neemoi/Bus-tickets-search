using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Transport
{
    public uint TransportId { get; set; }

    public string Model { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
