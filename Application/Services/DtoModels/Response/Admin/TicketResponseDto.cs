namespace Application.Services.DtoModels.Response.Admin
{
    public class TicketResponseDto
    {
        public uint TicketId { get; set; }

        public uint Price { get; set; }

        public int FkRouteT { get; set; }

        public string? UserId { get; set; }
    }
}
