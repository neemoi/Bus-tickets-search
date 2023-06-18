using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class User : IdentityUser
{
    public string? Surname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}
