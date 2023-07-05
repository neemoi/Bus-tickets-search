namespace Application.DtoModels.Response.Admin
{
    public class ScheduleResponseDto
    {
        public uint SсheduleId { get; set; }

        public string? DepartureTime { get; set; }

        public string? ArrivalTime { get; set; }

        public string? Date { get; set; }
    }
}