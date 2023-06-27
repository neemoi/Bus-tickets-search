﻿using Application.Services.DtoModels.DtoModels;
using Application.Services.DtoModels.Response;
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

        public async Task<AdminDriverDto> CreateDriverAsync(DriverDto model)
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

                return _mapper.Map<AdminDriverDto>(driver);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Driver not found");
            }
        }

        public async Task<AdminDriverDto> DeleteDriverByIdAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                _btsContext.Drivers.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminDriverDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Driver not found");
            }
        }

        public async Task<AdminDriverDto> EditDriverAsync(uint idDriver, DriverDto model)
        {
            var driver = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (driver != null)
            {
                driver.Name = model.Name ?? driver.Name;
                driver.Surname = model.Surname ?? driver.Surname;

                _btsContext.Drivers.Update(driver);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminDriverDto>(driver);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<List<AdminDriverDto>> GetAllDriverAsync()
        {
            var result = await _btsContext.Drivers.ToListAsync();

            if (result != null)
            {
                var mappedDrivers = new List<AdminDriverDto>();

                foreach (var driver in result)
                {
                    var mappedDriver = _mapper.Map<AdminDriverDto>(driver);

                    mappedDrivers.Add(mappedDriver);
                }

                return mappedDrivers;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }

        public async Task<AdminDriverDto> GetByIdDriverAsync(uint idDriver)
        {
            var result = await _btsContext.Drivers.FirstOrDefaultAsync(p => p.DriverId == idDriver);

            if (result != null)
            {
                return _mapper.Map<AdminDriverDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Driver not found");
            }
        }
    }
}
