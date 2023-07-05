namespace Application.DtoModels.Models.Admin
{
    public class RouteDto
    {
        public string? StartLocation { get; set; }

        public string? EndLocation { get; set; }

        public uint Distance { get; set; }

        public uint DriverId { get; set; }

        public uint TransportId { get; set; }

        public uint SheduleId { get; set; }
    }
}