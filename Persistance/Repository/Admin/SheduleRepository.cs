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
    public class ScheduleRepository : IRepositoryShedule
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public ScheduleRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<AdminSheduleDto> CreateSheduleAsync(ScheduleDto model)
        {
            var shedule = _mapper.Map<Shedule>(model);

            var result = await _btsContext.Shedules.AddAsync(shedule);

            if (result != null && shedule != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminSheduleDto>(shedule);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Shedule not found");
            }
        }

        public async Task<AdminSheduleDto> DeleteSheduleByIdAsync(uint idShedule)
        {
            var result = await _btsContext.Shedules.FirstOrDefaultAsync(s => s.SheduleId == idShedule);

            if (result != null)
            {
                _btsContext.Shedules.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminSheduleDto>(result);
            }
            throw new NotImplementedException();
        }

        public async Task<AdminSheduleDto> EditSheduleAsync(uint idShedule, ScheduleDto model)
        {
            var result = await _btsContext.Shedules.FirstOrDefaultAsync(s => s.SheduleId == idShedule);

            if (result != null)
            {
                _mapper.Map(model, result);

                _btsContext.Shedules.Update(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminSheduleDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Shedule not found");
            }
        }

        public async Task<List<AdminSheduleDto>> GetAllSheduleAsync()
        {
            var result = await _btsContext.Shedules.ToListAsync();

            if (result != null)
            {
                var mappedShedules = new List<AdminSheduleDto>();

                foreach (var shedule in result)
                {
                    var mappedShedule = _mapper.Map<AdminSheduleDto>(shedule);

                    mappedShedules.Add(mappedShedule);
                }

                return mappedShedules;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Shedule not found");
            }
        }

        public async Task<AdminSheduleDto> GetByIdSheduleAsync(uint idShedule)
        {
            var result = await _btsContext.Shedules.FirstOrDefaultAsync(s => s.SheduleId == idShedule);

            if (result != null)
            {
                return _mapper.Map<AdminSheduleDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Shedule not found");
            }
        }
    }
}
