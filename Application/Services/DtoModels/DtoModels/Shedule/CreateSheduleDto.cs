namespace Application.Services.DtoModels.DtoModels.Shedule
{
    public class CreateSheduleDto
    {
        public TimeOnly DepartureTime { get; set; }

        public TimeOnly ArrivalTime { get; set; }
        
        public DateOnly Date { get; set; }
    }
}
