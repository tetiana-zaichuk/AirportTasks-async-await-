using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftService : IService<Aircraft>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AircraftService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ValidationForeignIdAsync(Aircraft ob)
        {
            var list = await _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().GetAsync();
            return list.FirstOrDefault(o => o.Id == ob.AircraftType.Id) != null;
        }

        public async Task<Aircraft> IsExistAsync(int id)
        {
            var ob = await _unitOfWork.AircraftRepository.GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Aircraft, Aircraft>(ob.FirstOrDefault());
        }

        public DataAccessLayer.Models.Aircraft ConvertToModel(Aircraft aircraft)
            => _mapper.Map<Aircraft, DataAccessLayer.Models.Aircraft>(aircraft);

        public async Task<List<Aircraft>> GetAllAsync()
            => _mapper.Map<List<DataAccessLayer.Models.Aircraft>, List<Aircraft>>(await _unitOfWork.AircraftRepository.GetAsync());

        public async Task<Aircraft> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Aircraft aircraft)
        {
            await _unitOfWork.AircraftRepository.CreateAsync(ConvertToModel(aircraft));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aircraft aircraft)
        {
            _unitOfWork.AircraftRepository.Update(ConvertToModel(aircraft));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.AircraftRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.AircraftRepository.Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
