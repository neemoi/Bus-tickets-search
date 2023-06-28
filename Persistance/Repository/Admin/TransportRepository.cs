using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using Application.Services.Interfaces.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    //[Authorize(Roles = "Admin")]
    public class TransportRepository : ITransportRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public TransportRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }
        
        public async Task<TransportResponseDto> CreateTransportAsync(TransportDto model)
        {
            var transport = _mapper.Map<Transport>(model);

            var result = await _btsContext.Transports.AddAsync(transport);

            if (result != null && transport != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<TransportResponseDto>(transport);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<TransportResponseDto> DeleteTransportByIdAsync(uint idTransport)
        {
            var result = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (result != null)
            {
                _btsContext.Transports.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<TransportResponseDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<TransportResponseDto> EditTransportAsync(uint idTransport, TransportDto model)
        {
            var transport = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (transport != null)
            {
                _mapper.Map(model, transport);

                _btsContext.Transports.Update(transport);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<TransportResponseDto>(transport);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<List<TransportResponseDto>> GetAllTransportAsync()
        {
            var result = await _btsContext.Transports.ToListAsync();

            if (result != null)
            {
                var mappedTransports = new List<TransportResponseDto>();

                foreach (var transport in result)
                {
                    var mappedTransport = _mapper.Map<TransportResponseDto>(transport);

                    mappedTransports.Add(mappedTransport);
                }

                return mappedTransports;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<TransportResponseDto> GetByIdTransportAsync(uint idTransport)
        {
            var result = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (result != null)
            {
                return _mapper.Map<TransportResponseDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }
    }
}