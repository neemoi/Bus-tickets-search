using Application.DtoModels.Models.Admin;
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

        public async Task<Driver> CreateDriverAsync(Driver driver)
        {
            var result = await _btsContext.Drivers.AddAsync(driver);

            if (result != null)
            {
                await _btsContext.SaveChangesAsync();

                return driver;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<Driver> DeleteDriversByIdAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                _btsContext.Drivers.Remove(result);

                await _btsContext.SaveChangesAsync();

                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<Driver> EditDriversAsync(uint idDriver, DriverDto model)
        {
            var driver = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (driver != null)
            {
                _mapper.Map(model, driver);

                _btsContext.Drivers.Update(driver);

                await _btsContext.SaveChangesAsync();

                return driver;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<List<Driver>> GetAllDriversAsync()
        {
            var result = await _btsContext.Drivers.ToListAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<Driver> GetByIdDriversAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }
    }
}