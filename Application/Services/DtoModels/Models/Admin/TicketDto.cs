﻿namespace Application.Services.DtoModels.Models.Admin
{
    public class TicketDto
    {
        public uint Price { get; set; }

        public int FkRouteT { get; set; }

        public string? UserId { get; set; }

    }
}