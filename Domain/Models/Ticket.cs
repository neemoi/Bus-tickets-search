using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Ticket
{
    public uint TicketId { get; set; }

    public uint FkUser { get; set; }

    public uint Price { get; set; }

    public int Seat { get; set; }

    public int FkRouteT { get; set; }

    public virtual Route FkRouteTNavigation { get; set; } = null!;

    public virtual User FkUserNavigation { get; set; } = null!;
}
