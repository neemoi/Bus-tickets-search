using Microsoft.AspNetCore.Identity;

namespace WebApi.Models;

public partial class User : IdentityUser
{
    public string? Surname { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}
