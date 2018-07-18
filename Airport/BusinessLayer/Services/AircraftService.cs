using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
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

        public bool ValidationForeignId(Aircraft ob)
            => _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Get().FirstOrDefault(o=>o.Id==ob.AircraftType.Id)!=null;

        public Aircraft IsExist(int id)
            => _mapper.Map<DataAccessLayer.Models.Aircraft, Aircraft>(_unitOfWork.AircraftRepository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Aircraft ConvertToModel(Aircraft aircraft)
            => _mapper.Map<Aircraft, DataAccessLayer.Models.Aircraft>(aircraft);

        public List<Aircraft> GetAll()
            => _mapper.Map<List<DataAccessLayer.Models.Aircraft>, List<Aircraft>>(_unitOfWork.AircraftRepository.Get());

        public Aircraft GetDetails(int id) => IsExist(id);

        public void Add(Aircraft aircraft)
        {
            _unitOfWork.AircraftRepository.Create(ConvertToModel(aircraft));
            _unitOfWork.SaveChages();
        }

        public void Update(Aircraft aircraft)
        {
            _unitOfWork.AircraftRepository.Update(ConvertToModel(aircraft));
            _unitOfWork.SaveChages();
        }

        public void Remove(int id)
        {
            _unitOfWork.AircraftRepository.Delete(id);
            _unitOfWork.SaveChages();
        }

        public void RemoveAll()
        {
            _unitOfWork.AircraftRepository.Delete();
            _unitOfWork.SaveChages();
        }
    }
}
