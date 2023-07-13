using Application.Services.Interfaces.IRepository.Admin;

namespace Application.Services.Interfaces.IServices
{
    public interface IUnitOfWork
    {
        IDriverRepository DriverRepository { get; }

        IRouteRepository RouteRepository { get; }

        ISсheduleRepository SсheduleRepository { get; }

        ITicketRepository TicketRepository { get; }

        ITransportRepository TransportRepository { get; }

        Task SaveChangesAsync();
    }
}
