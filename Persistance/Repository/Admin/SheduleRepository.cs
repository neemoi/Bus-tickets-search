using Application.Services.DtoModels.DtoModels.Shedule;
using Application.Services.DtoModels.Response.AdminDriverControllerDto;
using Application.Services.DtoModels.Response.AdminSheduleControllerDto;
using Application.Services.Interfaces.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository.Admin
{
    //[Authorize(Roles = "Admin")]
    public class SheduleRepository : IRepositoryShedule
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public SheduleRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<AdminCreateSheduleDto> CreateSheduleAsync(CreateSheduleDto model)
        {
            Shedule shedule = new();

            if (!string.IsNullOrEmpty(model.ArrivalTime))
            {
                shedule.ArrivalTime = TimeOnly.Parse(model.ArrivalTime);
            }

            if (!string.IsNullOrEmpty(model.DepartureTime))
            {
                shedule.DepartureTime = TimeOnly.Parse(model.DepartureTime);
            }

            if (!string.IsNullOrEmpty(model.Date))
            {
                shedule.Date = DateOnly.Parse(model.Date);
            }

            var result = await _btsContext.Shedules.AddAsync(shedule);

            if (result != null && shedule != null)
            {
                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminCreateSheduleDto>(shedule);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Shedule not found");
            }
        }

        public async Task<AdminDeleteSheduleByIdDto> DeleteSheduleByIdAsync(uint idShedule)
        {
            var result = await _btsContext.Shedules.FirstOrDefaultAsync(s => s.SheduleId == idShedule);

            if (result != null) 
            {
                _btsContext.Shedules.Remove(result);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminDeleteSheduleByIdDto>(result);
            }
            throw new NotImplementedException();
        }

        public async Task<AdminEditSheduleDto> EditSheduleAsync(uint idShedule, EditSheduleDto model)
        {
            var result = await _btsContext.Shedules.FirstOrDefaultAsync(s => s.SheduleId == idShedule);

            if (result != null)
            {
                var newShedule = result;

                if (!string.IsNullOrEmpty(model.ArrivalTime))
                {
                    newShedule.ArrivalTime = TimeOnly.Parse(model.ArrivalTime);
                }

                if (!string.IsNullOrEmpty(model.DepartureTime))
                {
                    newShedule.DepartureTime = TimeOnly.Parse(model.DepartureTime);
                }

                if (!string.IsNullOrEmpty(model.Date))
                {
                    newShedule.Date = DateOnly.Parse(model.Date);
                }

                _btsContext.Shedules.Update(newShedule);

                await _btsContext.SaveChangesAsync();

                return _mapper.Map<AdminEditSheduleDto>(newShedule);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Shedule not found");
            }
        }

        public async Task<List<AdminGetAllSheduleDto>> GetAllSheduleAsync()
        {
            var result = await _btsContext.Shedules.ToListAsync();

            if (result != null)
            {
                var mappedShedules = new List<AdminGetAllSheduleDto>();

                foreach (var shedule in result)
                {
                    var mappedShedule = _mapper.Map<AdminGetAllSheduleDto>(shedule);

                    mappedShedules.Add(mappedShedule);
                }

                return mappedShedules;
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Shedule not found");
            }
        }

        public async Task<AdminGetByIdSheduleDto> GetByIdSheduleAsync(uint idShedule)
        {
            var result = await _btsContext.Shedules.FirstOrDefaultAsync(s => s.SheduleId == idShedule);

            if (result != null)
            {
                return _mapper.Map<AdminGetByIdSheduleDto>(result);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Shedule not found");
            }
        }
    }
}
