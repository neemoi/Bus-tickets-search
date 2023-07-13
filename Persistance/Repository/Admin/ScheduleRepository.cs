using Application.DtoModels.Models.Admin;
using Application.Services.Interfaces.IRepository.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    public class ScheduleRepository : ISсheduleRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public ScheduleRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<Sсhedule> CreateSсhedulesAsync(Sсhedule sсhedule)
        {
            var result = await _btsContext.Sсhedules.AddAsync(sсhedule);

            if (result != null)
            {
                await _btsContext.SaveChangesAsync();

                return sсhedule;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<Sсhedule> DeleteSсhedulesByIdAsync(uint idSchedule)
        {
            var result = await _btsContext.Sсhedules.FirstOrDefaultAsync(s => s.SсheduleId == idSchedule);

            if (result != null)
            {
                _btsContext.Sсhedules.Remove(result);

                await _btsContext.SaveChangesAsync();

                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<Sсhedule> EditSсhedulesAsync(uint idSchedule, ScheduleDto model)
        {
            var result = await _btsContext.Sсhedules.FirstOrDefaultAsync(s => s.SсheduleId == idSchedule);

            if (result != null)
            {
                _mapper.Map(model, result);

                _btsContext.Sсhedules.Update(result);

                await _btsContext.SaveChangesAsync();

                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<List<Sсhedule>> GetAllSсhedulesAsync()
        {
            var result = await _btsContext.Sсhedules.ToListAsync();

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<Sсhedule> GetByIdSсhedulesAsync(uint idSchedule)
        {
            var result = await _btsContext.Sсhedules.FirstOrDefaultAsync(s => s.SсheduleId == idSchedule);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }
    }
}