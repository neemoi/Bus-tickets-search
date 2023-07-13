using Application.Services.Interfaces.IRepository.Admin;
using Application.Services.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace Persistance.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDriverRepository DriverRepository { get; }

        public IRouteRepository RouteRepository { get; }

        public ISсheduleRepository SсheduleRepository { get; }

        public ITicketRepository TicketRepository { get; }

        public ITransportRepository TransportRepository { get; }

        private readonly BtsContext _btsContext;

        public UnitOfWork(IDriverRepository driverRepository, IRouteRepository routeRepository, ISсheduleRepository sсheduleRepository, ITicketRepository ticketRepository, ITransportRepository transportRepository, BtsContext btsContext)
        {
            DriverRepository = driverRepository;
            RouteRepository = routeRepository;
            SсheduleRepository = sсheduleRepository;
            TicketRepository = ticketRepository;
            TransportRepository = transportRepository;
            _btsContext = btsContext;
        }

        async Task IUnitOfWork.SaveChangesAsync()
        {
            await _btsContext.SaveChangesAsync();
        }
    }
}
