namespace Application.Services.DtoModels.Response.AdminRoutesControllerDto
{
    public class DeleteRouteDto
    {
        public uint RouteId { get; set; }    

        public string StartLocation { get; set; } = null!;

        public string EndLocation { get; set; } = null!;

        public uint Distance { get; set; }
    }
}
