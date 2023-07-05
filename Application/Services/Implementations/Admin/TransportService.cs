using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using AutoMapper;
using WebApi.Models;

namespace Application.Services.Implementations.Admin
{
    public class TransportService : ITransportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TransportResponseDto> CreateTransportsAsync(TransportDto model)
        {
            var transport = _mapper.Map<Transport>(model);

            var result = await _unitOfWork.TransportRepository.CreateTransportsAsync(transport);

            return _mapper.Map<TransportResponseDto>(result);
        }

        public async Task<TransportResponseDto> DeleteTransportsByIdAsync(uint idTransport)
        {
            var result = await _unitOfWork.TransportRepository.DeleteTransportsByIdAsync(idTransport);

            return _mapper.Map<TransportResponseDto>(result);
        }

        public async Task<TransportResponseDto> EditTransportsAsync(uint idTransport, TransportDto model)
        {
            var result = await _unitOfWork.TransportRepository.EditTransportsAsync(idTransport, model);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TransportResponseDto>(result);
        }

        public async Task<List<TransportResponseDto>> GetAllTransportsAsync()
        {
            var result = await _unitOfWork.TransportRepository.GetAllTransportsAsync();

            var mappedTransports = new List<TransportResponseDto>();

            foreach (var transport in result)
            {
                var mappedTransport = _mapper.Map<TransportResponseDto>(transport);

                mappedTransports.Add(mappedTransport);
            }

            return mappedTransports;
        }

        public async Task<TransportResponseDto> GetByIdTransportsAsync(uint idTransport)
        {
            var result = await _unitOfWork.TransportRepository.GetByIdTransportsAsync(idTransport);

            return _mapper.Map<TransportResponseDto>(result);
        }
    }
}
