using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DtoModels.Response.AdminRoutesControllerDto
{
    public class AdminCreatNewRouteDto
    {
        public string? Id { get; set; } 

        public string? StartLocation { get; set; }

        public string? EndLocation { get; set; } 

        public uint? Distance { get; set; }
    }
}
