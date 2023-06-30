namespace WebApi.Models;

public partial class Ticket
{
    public uint TicketId { get; set; }

    public uint Price { get; set; }

    public int FkRouteT { get; set; }

    public string? UserId { get; set; }

    public virtual Route FkRouteTNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
