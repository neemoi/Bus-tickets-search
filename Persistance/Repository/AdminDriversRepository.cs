using Application.Services.DtoModels.DtoModels.Driver;
using Application.Services.DtoModels.Response.AdminDriverControllerDto;
using Application.Services.Interfaces.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using WebApi.Models;
using WebApi.RequestError;

namespace Persistance.Repository
{
    public class AdminDriversRepository : IRepositoryDriver
    {
        private readonly BtsContext _btsContext;
        private readonly IMapper _mapper;

        public AdminDriversRepository(BtsContext btsContext, IMapper mapper)
        {
            _btsContext = btsContext;
            _mapper = mapper;
        }

        public async Task<AdminCreateNewDriverDto> CreatNewDriverAsync(CreateNewDriverDto model)
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

                return _mapper.Map<AdminCreateNewDriverDto>(driver);
            }
            else
            {
                throw new ApiRequestErrorException(StatusCodes.Status400BadRequest, "Result = 0 or Driver note found");
            }

        }

        public Task<AdminDeleteDriverDto> DeleteDriverAsync(DeleteDriverDto model)
        {
            throw new NotImplementedException();
        }

        public Task<AdminEditDriverDto> EditDriverAsync(EditDriverDto model)
        {
            throw new NotImplementedException();
        }

        public Task<AdminGetAllDriverDto> GetAllDriverAsync(GetAllDriverDto model)
        {
            throw new NotImplementedException();
        }

        public Task<AdminGetByIdDriverDto> GetByIdDriverAsync(GetByIdDriverDto model)
        {
            throw new NotImplementedException();
        }
    }
}
