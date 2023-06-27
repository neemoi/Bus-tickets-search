namespace Application.Services.DtoModels.Response.AdminTransportControllerDto
{
    public class AdminGetByIdTransportDto
    {
        public uint TransportId { get; set; }

        public string? Model { get; set; }

        public string? Number { get; set; }

        public string? Color { get; set; }
    }
}
