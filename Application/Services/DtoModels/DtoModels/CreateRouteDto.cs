namespace Application.Services.DtoModels.DtoModels
{
    public class CreateRouteDto
    {
        public string StartLocation { get; set; } 
        
        public string EndLocation { get; set; }
        
        public uint Distance { get; set; }

    }
}
