namespace Application.Services.DtoModels.DtoModels.Route
{
    public class CreateRouteDto
    {
        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public uint Distance { get; set; }

        public uint FkDriver { get; set; }

        public uint FkTransport { get; set; }

        public uint FkShedule { get; set; }
    }
}