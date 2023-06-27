﻿namespace Application.Services.DtoModels.DtoModels.Route
{
    public class EditRoutesDto
    {
        public string StartLocation { get; set; } = null!;

        public string EndLocation { get; set; } = null!;

        public uint Distance { get; set; }

        public uint FkDriver { get; set; } 

        public uint FkTransport { get; set; } 

        public uint FkShedule { get; set; } 
    }
}
