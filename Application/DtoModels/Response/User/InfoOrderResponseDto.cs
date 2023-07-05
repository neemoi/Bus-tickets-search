namespace Application.DtoModels.Response.User
{
    public class InfoOrderResponseDto
    {
        public uint TicketId { get; set; }

        public string? Surname { get; set; }

        public decimal Price { get; set; }

        public string? StartLocation { get; set; }

        public string? EndLocation { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public string Model { get; set; } = null!;

        public string Number { get; set; } = null!;

        public string Color { get; set; } = null!;

        //Оставляем имя водителя? 
        //public string? Name { get; set; } = null!;
    }
}