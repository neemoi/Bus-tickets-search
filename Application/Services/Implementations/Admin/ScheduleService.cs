using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using WebApi.Models;

namespace Application.Services.Implementations.Admin
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ScheduleResponseDto> CreateSсhedulesAsync(ScheduleDto model)
        {
            var sсhedule = _mapper.Map<Sсhedule>(model);

            var result = await _unitOfWork.SсheduleRepository.CreateSсhedulesAsync(sсhedule);

            return _mapper.Map<ScheduleResponseDto>(result);
        }

        public async Task<ScheduleResponseDto> DeleteSсhedulesByIdAsync(uint idSсhedule)
        {
            var result = await _unitOfWork.SсheduleRepository.DeleteSсhedulesByIdAsync(idSсhedule);

            return _mapper.Map<ScheduleResponseDto>(result);
        }

        public async Task<ScheduleResponseDto> EditSсhedulesAsync(uint idSсhedule, ScheduleDto model)
        {
            var result = await _unitOfWork.SсheduleRepository.EditSсhedulesAsync(idSсhedule, model);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ScheduleResponseDto>(result);
        }

        public async Task<List<ScheduleResponseDto>> GetAllSсhedulesAsync()
        {
            var result = await _unitOfWork.SсheduleRepository.GetAllSсhedulesAsync();

            var mappedShedules = new List<ScheduleResponseDto>();

            foreach (var shedule in result)
            {
                var mappedShedule = _mapper.Map<ScheduleResponseDto>(shedule);

                mappedShedules.Add(mappedShedule);
            }

            return mappedShedules;
        }

        public async Task<ScheduleResponseDto> GetByIdSсhedulesAsync(uint idSсhedule)
        {
            var result = await _unitOfWork.SсheduleRepository.GetByIdSсhedulesAsync(idSсhedule);

            return _mapper.Map<ScheduleResponseDto>(result);
        }
    }
}
