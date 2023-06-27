namespace Application.Services.DtoModels.Response.AdminSheduleControllerDto
{
    public class AdminGetAllSheduleDto
    {
        public uint SheduleId { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public DateOnly Date { get; set; }
    }
}
