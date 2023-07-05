using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    public class TransportRepository : ITransportRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public TransportRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<Transport> CreateTransportsAsync(Transport transport)
        {
            var result = await _btsContext.Transports.AddAsync(transport);

            if (result != null && transport != null)
            {
                await _btsContext.SaveChangesAsync();

                return transport;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<Transport> DeleteTransportsByIdAsync(uint idTransport)
        {
            var result = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (result != null)
            {
                _btsContext.Transports.Remove(result);

                await _btsContext.SaveChangesAsync();

                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<Transport> EditTransportsAsync(uint idTransport, TransportDto model)
        {
            var transport = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (transport != null)
            {
                _mapper.Map(model, transport);

                _btsContext.Transports.Update(transport);

                await _btsContext.SaveChangesAsync();

                return transport;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<List<Transport>> GetAllTransportsAsync()
        {
            var result = await _btsContext.Transports.ToListAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<Transport> GetByIdTransportsAsync(uint idTransport)
        {
            var result = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }
    }
}