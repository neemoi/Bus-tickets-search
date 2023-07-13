using Application.DtoModels.Models.Admin;
using Application.DtoModels.Response.Admin;
using Application.Services.Interfaces.IServices;
using Application.Services.Interfaces.IServices.Admin;
using AutoMapper;
using WebApi.Models;

namespace Application.Services.Implementations.Admin
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DriverResponseDto> CreateDriverAsync(DriverDto model)
        {
            var driver = _mapper.Map<Driver>(model);

            var result = await _unitOfWork.DriverRepository.CreateDriverAsync(driver);

            return _mapper.Map<DriverResponseDto>(result);
        }

        public async Task<DriverResponseDto> DeleteDriversByIdAsync(uint idDriver)
        {
            var result = await _unitOfWork.DriverRepository.DeleteDriversByIdAsync(idDriver);

            return _mapper.Map<DriverResponseDto>(result);
        }

        public async Task<DriverResponseDto> EditDriversAsync(uint idDriver, DriverDto model)
        {
            var result = await _unitOfWork.DriverRepository.EditDriversAsync(idDriver, model);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DriverResponseDto>(result);
        }

        public async Task<List<DriverResponseDto>> GetAllDriversAsync()
        {
            var result = await _unitOfWork.DriverRepository.GetAllDriversAsync();

            var mappedDrivers = new List<DriverResponseDto>();

            foreach (var driver in result)
            {
                var mappedDriver = _mapper.Map<DriverResponseDto>(driver);

                mappedDrivers.Add(mappedDriver);
            }

            return mappedDrivers;
        }

        public async Task<DriverResponseDto> GetByIdDriversAsync(uint idDriver)
        {
            var result = await _unitOfWork.DriverRepository.GetByIdDriversAsync(idDriver);

            return _mapper.Map<DriverResponseDto>(result);
        }
    }
}
