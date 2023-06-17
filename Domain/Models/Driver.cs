using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Driver
{
    public uint DriverId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();
}
