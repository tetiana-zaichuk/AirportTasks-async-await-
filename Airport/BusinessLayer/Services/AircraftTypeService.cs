using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftTypeService : IService<AircraftType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AircraftTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ValidationForeignIdAsync(AircraftType ob) =>await Task.FromResult(true);

        public async Task<AircraftType> IsExistAsync(int id)
        {
            var ob = await _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.AircraftType, AircraftType>(ob.FirstOrDefault());
        }
        public DataAccessLayer.Models.AircraftType ConvertToModel(AircraftType aircraftType)
            => _mapper.Map<AircraftType, DataAccessLayer.Models.AircraftType>(aircraftType);

        public async Task<List<AircraftType>> GetAllAsync()
            => _mapper.Map<List<DataAccessLayer.Models.AircraftType>, List<AircraftType>>(await _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().GetAsync());

        public async Task<AircraftType> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(AircraftType aircraftType)
        {
            await _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().CreateAsync(ConvertToModel(aircraftType));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(AircraftType aircraftType)
        {
            _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Update(ConvertToModel(aircraftType));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
