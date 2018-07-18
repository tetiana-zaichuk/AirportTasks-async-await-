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
    public class PilotService : IService<Pilot>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ValidationForeignIdAsync(Pilot ob) => await Task.FromResult(true);

        public async Task<Pilot> IsExistAsync(int id)
        {
            var ob = await _unitOfWork.Set<DataAccessLayer.Models.Pilot>().GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Pilot, Pilot>(ob.FirstOrDefault());
        }

        public DataAccessLayer.Models.Pilot ConvertToModel(Pilot pilot)
            => _mapper.Map<Pilot, DataAccessLayer.Models.Pilot>(pilot);

        public async Task<List<Pilot>> GetAllAsync()
            => _mapper.Map<List<DataAccessLayer.Models.Pilot>, List<Pilot>>(await _unitOfWork.Set<DataAccessLayer.Models.Pilot>().GetAsync());

        public async Task<Pilot> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Pilot pilot)
        {
            await _unitOfWork.Set<DataAccessLayer.Models.Pilot>().CreateAsync(ConvertToModel(pilot));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pilot pilot)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Pilot>().Update(ConvertToModel(pilot));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Pilot>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.Set<DataAccessLayer.Models.Pilot>().Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
