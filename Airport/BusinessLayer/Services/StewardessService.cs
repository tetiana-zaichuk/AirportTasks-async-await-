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
    public class StewardessService : IService<Stewardess>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ValidationForeignIdAsync(Stewardess ob) => await Task.FromResult(true);

        public async Task<Stewardess> IsExistAsync(int id)
        {
            var ob = await _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Stewardess, Stewardess>(ob.FirstOrDefault());
        }

        public DataAccessLayer.Models.Stewardess ConvertToModel(Stewardess stewardess)
            => _mapper.Map<Stewardess, DataAccessLayer.Models.Stewardess>(stewardess);

        public async Task<List<Stewardess>> GetAllAsync()
            => _mapper.Map<List<DataAccessLayer.Models.Stewardess>, List<Stewardess>>(await _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().GetAsync());

        public async Task<Stewardess> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Stewardess stewardess)
        {
            await _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().CreateAsync(ConvertToModel(stewardess));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stewardess stewardess)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Update(ConvertToModel(stewardess));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
