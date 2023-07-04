namespace Application.Services.DtoModels.Response.Admin
{
    public class RouteResponseDto
    {
        public uint RouteId { get; set; }

        public string? StartLocation { get; set; }

        public string? EndLocation { get; set; }

        public uint? Distance { get; set; }

        public uint? DriverId { get; set; }

        public uint? TransportId { get; set; }

        public uint? SheduleId { get; set; }
    }
}