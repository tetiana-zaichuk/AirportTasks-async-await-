using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class DepartureService : IService<Departure>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool ValidationForeignId(Departure ob)
        {
            return _unitOfWork.AircraftRepository.Get()
                        .FirstOrDefault(o => o.Id == ob.Aircraft.Id) != null &&
                    _unitOfWork.CrewRepository.Get().FirstOrDefault(o => o.Id == ob.Crew.Id) !=
                    null &&
                    _unitOfWork.FlightRepository.Get().FirstOrDefault(o => o.Id == ob.Flight.Id) !=
                    null;
        }

        public Departure IsExist(int id)
            => _mapper.Map<DataAccessLayer.Models.Departure, Departure>(_unitOfWork.DepartureRepository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Departure ConvertToModel(Departure departure)
            => _mapper.Map<Departure, DataAccessLayer.Models.Departure>(departure);

        public List<Departure> GetAll()
            => _mapper.Map<List<DataAccessLayer.Models.Departure>, List<Departure>>(_unitOfWork.DepartureRepository.Get());

        public Departure GetDetails(int id) => IsExist(id);

        public void Add(Departure departure)
        {
            _unitOfWork.DepartureRepository.Create(ConvertToModel(departure));
            _unitOfWork.SaveChages();
        }

        public void Update(Departure departure)
        {
            _unitOfWork.DepartureRepository.Update(ConvertToModel(departure));
            _unitOfWork.SaveChages();
        }

        public void Remove(int id)
        {
            _unitOfWork.DepartureRepository.Delete(id);
            _unitOfWork.SaveChages();
        }

        public void RemoveAll()
        {
            _unitOfWork.DepartureRepository.Delete();
            _unitOfWork.SaveChages();
        }
    }
}
