namespace Application.Services.DtoModels.Response.AdminSheduleControllerDto
{
    public class AdminEditSheduleDto
    {
        public uint SheduleId { get; set; }

        public string? DepartureTime { get; set; }

        public string? ArrivalTime { get; set; }

        public string? Date { get; set; }
    }
}
