namespace Application.Services.DtoModels.Response
{
    public class AdminSheduleDto
    {
        public uint SheduleId { get; set; }

        public string? DepartureTime { get; set; }

        public string? ArrivalTime { get; set; }

        public string? Date { get; set; }
    }
}
