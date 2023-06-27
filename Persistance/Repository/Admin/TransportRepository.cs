using Application.Services.DtoModels.DtoModels.Transport;
using Application.Services.DtoModels.Response.AdminTransportControllerDto;
using Application.Services.Interfaces.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    //[Authorize(Roles = "Admin")]
    public class TransportRepository : IRepositoryTransport
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public TransportRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }
        //не пашет
        public async Task<AdminCreateTransportDto> CreateTransportAsync(CreateTransportDto model)
        {
            var transport = new Transport
            {
                Color = model.Color,
                Model = model.Model,
                Number = model.Number
            };

            var result = await _btsContext.Transports.AddAsync(transport);

            if (result != null && transport != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminCreateTransportDto>(transport);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Transport not found");
            }
        }
        
        public async Task<AdminDeleteTransportByIdDto> DeleteTransportByIdAsync(uint idTransport)
        {
            var result = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (result != null)
            {
                _btsContext.Transports.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminDeleteTransportByIdDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Transport not found");
            }
        }
        //не пашет
        public async Task<AdminEditTransportDto> EditTransportAsync(uint idTransport, EditTransportDto model)
        {
            var transport = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (transport != null)
            {
                transport.Number = model.Number ?? transport.Number;
                transport.Model = model.Model ?? transport.Model;
                transport.Color = model.Color ?? transport.Color;

                _btsContext.Transports.Update(transport);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminEditTransportDto>(transport);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<List<AdminGetAllTransportDto>> GetAllTransportAsync()
        {
            var result = await _btsContext.Transports.ToListAsync();

            if (result != null)
            {
                var mappedTransports = new List<AdminGetAllTransportDto>();

                foreach (var transport in result)
                {
                    var mappedTransport = _mapper.Map<AdminGetAllTransportDto>(transport);

                    mappedTransports.Add(mappedTransport);
                }

                return mappedTransports;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Transport not found");
            }
        }

        public async Task<AdminGetByIdTransportDto> GetByIdTransportAsync(uint idTransport)
        {
            var result = await _btsContext.Transports.FirstOrDefaultAsync(p => p.TransportId == idTransport);

            if (result != null)
            {
                return _mapper.Map<AdminGetByIdTransportDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }
    }
}
