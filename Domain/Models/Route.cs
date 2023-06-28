namespace WebApi.Models;

public partial class Route
{
    public int RouteId { get; set; }

    public uint FkDriver { get; set; }

    public uint FkTransport { get; set; }

    public string StartLocation { get; set; } = null!;

    public string EndLocation { get; set; } = null!;

    public uint Distance { get; set; }

    public uint FkShedule { get; set; }

    public virtual Driver FkDriverNavigation { get; set; } = null!;

    public virtual Sсhedule FkSheduleNavigation { get; set; } = null!;

    public virtual Transport FkTransportNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
