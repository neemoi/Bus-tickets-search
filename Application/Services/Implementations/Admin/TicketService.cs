using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using AutoMapper;
using WebApi.Models;

namespace Application.Services.Implementations.Admin
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TicketResponseDto> CreateTicketAsync(TicketDto model)
        {
            var ticket = _mapper.Map<Ticket>(model);

            var result = await _unitOfWork.TicketRepository.CreateTicketAsync(ticket);

            return _mapper.Map<TicketResponseDto>(result);
        }

        public async Task<TicketResponseDto> DeleteTicketByIdAsync(uint idTicket)
        {
            var result = await _unitOfWork.TicketRepository.DeleteTicketByIdAsync(idTicket);

            return _mapper.Map<TicketResponseDto>(result);
        }

        public async Task<TicketResponseDto> EditTicketAsync(uint idTicket, TicketDto model)
        {
            var result = await _unitOfWork.TicketRepository.EditTicketAsync(idTicket, model);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TicketResponseDto>(result);
        }

        public async Task<List<TicketResponseDto>> GetAllTicketsAsync()
        {
            var result = await _unitOfWork.TicketRepository.GetAllTicketsAsync();

            var mappedTickets = new List<TicketResponseDto>();

            foreach (var ticket in result)
            {
                var mappedTicket = _mapper.Map<TicketResponseDto>(ticket);

                mappedTickets.Add(mappedTicket);
            }

            return mappedTickets;
        }

        public async Task<TicketResponseDto> GetByIdTicketAsync(uint idTicket)
        {
            var result = await _unitOfWork.TicketRepository.GetByIdTicketAsync(idTicket);

            return _mapper.Map<TicketResponseDto>(result);
        }
    }
}
