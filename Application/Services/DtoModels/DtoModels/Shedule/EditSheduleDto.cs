namespace Application.Services.DtoModels.DtoModels.Shedule
{
    public class EditSheduleDto
    {
        public TimeOnly DepartureTime { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public DateOnly Date { get; set; }
    }
}
