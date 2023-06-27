using Application.Services.DtoModels.DtoModels.Driver;
using Application.Services.DtoModels.Response.AdminDriverControllerDto;
using Application.Services.Interfaces.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    //[Authorize(Roles = "Admin")]
    public class DriverRepository : IRepositoryDriver
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public DriverRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<AdminCreateDriverDto> CreateDriverAsync(CreateDriverDto model)
        {
            var driver = new Driver
            {
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _btsContext.Drivers.AddAsync(driver);

            if (result != null && driver != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminCreateDriverDto>(driver);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Driver not found");
            }
        }

        public async Task<AdminDeleteDriverById> DeleteDriverByIdAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                _btsContext.Drivers.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminDeleteDriverById>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Driver not found");
            }
        }

        public async Task<AdminEditDriverDto> EditDriverAsync(uint idDriver, EditDriverDto model)
        {
            var driver = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (driver != null)
            {
                driver.Name = model.Name ?? driver.Name;
                driver.Surname = model.Surname ?? driver.Surname;

                _btsContext.Drivers.Update(driver);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminEditDriverDto>(driver);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<List<AdminGetAllDriverDto>> GetAllDriverAsync()
        {
            var result = await _btsContext.Drivers.ToListAsync();

            if (result != null)
            {
                var mappedDrivers = new List<AdminGetAllDriverDto>();

                foreach (var driver in result)
                {
                    var mappedDriver = _mapper.Map<AdminGetAllDriverDto>(driver);

                    mappedDrivers.Add(mappedDriver);
                }

                return mappedDrivers;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<AdminGetByIdDriverDto> GetByIdDriverAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                return _mapper.Map<AdminGetByIdDriverDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }
    }
}
