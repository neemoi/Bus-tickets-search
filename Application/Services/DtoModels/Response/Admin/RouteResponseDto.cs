﻿namespace Application.Services.DtoModels.Response.Admin
{
    public class RouteResponseDto
    {
        public uint RouteId { get; set; }

        public string? StartLocation { get; set; }

        public string? EndLocation { get; set; }

        public uint? Distance { get; set; }

        public uint? FkDriver { get; set; }

        public uint? FkTransport { get; set; }

        public uint? FkShedule { get; set; }
    }
}