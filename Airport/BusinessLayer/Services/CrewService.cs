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
    public class CrewService : IService<Crew>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ValidationForeignIdAsync(Crew ob)
        {
            //if (ob.Stewardesses == null) return false;
            foreach (var st in ob.Stewardesses)
            {
                var listSt = await _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().GetAsync(st.Id);
                if (listSt.FirstOrDefault() == null) return false;
            }
            var listP = await _unitOfWork.Set<DataAccessLayer.Models.Pilot>().GetAsync();
            return listP.FirstOrDefault(o => o.Id == ob.Pilot.Id) != null;
        }

        public async Task<Crew> IsExistAsync(int id)
        {
            var listCrew = await _unitOfWork.CrewRepository.GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Crew, Crew>(listCrew.FirstOrDefault());
        }

        public DataAccessLayer.Models.Crew ConvertToModel(Crew crew) => _mapper.Map<Crew, DataAccessLayer.Models.Crew>(crew);

        public async Task<List<Crew>> GetAllAsync() => _mapper.Map<List<DataAccessLayer.Models.Crew>, List<Crew>>(await _unitOfWork.CrewRepository.GetAsync());

        public async Task<Crew> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Crew crew)
        {
            await _unitOfWork.CrewRepository.CreateAsync(ConvertToModel(crew));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Crew crew)
        {
            _unitOfWork.CrewRepository.Update(ConvertToModel(crew));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.CrewRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.CrewRepository.Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
