using Application.Services.DtoModels.Models.Admin;
using Application.Services.DtoModels.Response.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    public class DriverRepository : IDriverRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public DriverRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<DriverResponseDto> CreateDriverAsync(DriverDto model)
        {
            var driver = _mapper.Map<Driver>(model);

            var result = await _btsContext.Drivers.AddAsync(driver);

            if (result != null && driver != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<DriverResponseDto>(driver);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<DriverResponseDto> DeleteDriverByIdAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                _btsContext.Drivers.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<DriverResponseDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<DriverResponseDto> EditDriverAsync(uint idDriver, DriverDto model)
        {
            var driver = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (driver != null)
            {
                _mapper.Map(model, driver);

                _btsContext.Drivers.Update(driver);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<DriverResponseDto>(driver);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<List<DriverResponseDto>> GetAllDriverAsync()
        {
            var result = await _btsContext.Drivers.ToListAsync();

            if (result != null)
            {
                var mappedDrivers = new List<DriverResponseDto>();

                foreach (var driver in result)
                {
                    var mappedDriver = _mapper.Map<DriverResponseDto>(driver);

                    mappedDrivers.Add(mappedDriver);
                }

                return mappedDrivers;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<DriverResponseDto> GetByIdDriverAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                return _mapper.Map<DriverResponseDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }
    }
}