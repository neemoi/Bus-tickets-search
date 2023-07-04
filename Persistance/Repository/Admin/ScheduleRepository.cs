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
    public class ScheduleRepository : ISсheduleRepository
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public ScheduleRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<ScheduleResponseDto> CreateSсhedulesAsync(ScheduleDto model)
        {
            var schedule = _mapper.Map<Sсhedule>(model);

            var result = await _btsContext.Sсhedules.AddAsync(schedule);

            if (result != null && schedule != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<ScheduleResponseDto>(schedule);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<ScheduleResponseDto> DeleteSсhedulesByIdAsync(uint idSchedule)
        {
            var result = await _btsContext.Sсhedules.FirstOrDefaultAsync(s => s.SсheduleId == idSchedule);

            if (result != null)
            {
                _btsContext.Sсhedules.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<ScheduleResponseDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<ScheduleResponseDto> EditSсhedulesAsync(uint idSchedule, ScheduleDto model)
        {
            var result = await _btsContext.Sсhedules.FirstOrDefaultAsync(s => s.SсheduleId == idSchedule);

            if (result != null)
            {
                _mapper.Map(model, result);

                _btsContext.Sсhedules.Update(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<ScheduleResponseDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<List<ScheduleResponseDto>> GetAllSсhedulesAsync()
        {
            var result = await _btsContext.Sсhedules.ToListAsync();

            if (result != null)
            {
                var mappedShedules = new List<ScheduleResponseDto>();

                foreach (var shedule in result)
                {
                    var mappedShedule = _mapper.Map<ScheduleResponseDto>(shedule);

                    mappedShedules.Add(mappedShedule);
                }

                return mappedShedules;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }

        public async Task<ScheduleResponseDto> GetByIdSсhedulesAsync(uint idSchedule)
        {
            var result = await _btsContext.Sсhedules.FirstOrDefaultAsync(s => s.SсheduleId == idSchedule);

            if (result != null)
            {
                return _mapper.Map<ScheduleResponseDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Schedule not found");
            }
        }
    }
}