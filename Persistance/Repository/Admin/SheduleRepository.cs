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
            var shedule = new Shedule
            {
                ArrivalTime = model.ArrivalTime,
                DepartureTime = model.DepartureTime,
                Date= model.Date
            };

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

        public Task<AdminDeleteSheduleByIdDto> DeleteSheduleByIdAsync(uint idShedule)
        {
            throw new NotImplementedException();
        }

        public Task<AdminEditSheduleDto> EditSheduleAsync(uint idShedule, EditSheduleDto model)
        {
            throw new NotImplementedException();
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

        public Task<AdminGetByIdSheduleDto> GetByIdSheduleAsync(uint idShedule)
        {
            throw new NotImplementedException();
        }
    }
}
