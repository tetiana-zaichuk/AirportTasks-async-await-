using System.Collections.Generic;
using System.Linq;
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

        public bool ValidationForeignId(AircraftType ob) => true;

        public AircraftType IsExist(int id)
            => _mapper.Map<DataAccessLayer.Models.AircraftType, AircraftType>(_unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Get(id).FirstOrDefault());

        public DataAccessLayer.Models.AircraftType ConvertToModel(AircraftType aircraftType)
            => _mapper.Map<AircraftType, DataAccessLayer.Models.AircraftType>(aircraftType);

        public List<AircraftType> GetAll()
            => _mapper.Map<List<DataAccessLayer.Models.AircraftType>, List<AircraftType>>(_unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Get());

        public AircraftType GetDetails(int id) => IsExist(id);

        public void Add(AircraftType aircraftType)
        {
            _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Create(ConvertToModel(aircraftType));
            _unitOfWork.SaveChages();
        }

        public void Update(AircraftType aircraftType)
        {
            _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Update(ConvertToModel(aircraftType));
            _unitOfWork.SaveChages();
        }

        public void Remove(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Delete(id);
            _unitOfWork.SaveChages();
        }

        public void RemoveAll()
        {
            _unitOfWork.Set<DataAccessLayer.Models.AircraftType>().Delete();
            _unitOfWork.SaveChages();
        }
    }
}
