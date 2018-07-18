using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class FlightService : IService<Flight>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool ValidationForeignId(Flight ob)
        {
            foreach (var t in ob.Tickets)
            {
                if (_unitOfWork.Set<DataAccessLayer.Models.Ticket>().Get(t.Id).FirstOrDefault() == null) return false;
            }
            return true;
        }

        public Flight IsExist(int id) => _mapper.Map<DataAccessLayer.Models.Flight, Flight>(_unitOfWork.FlightRepository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Flight ConvertToModel(Flight flight) => _mapper.Map<Flight, DataAccessLayer.Models.Flight>(flight);
        
        public List<Flight> GetAll() => _mapper.Map<List<DataAccessLayer.Models.Flight>, List<Flight>>(_unitOfWork.FlightRepository.Get());

        public Flight GetDetails(int id) => IsExist(id);

        public void Add(Flight flight)
        {
            _unitOfWork.FlightRepository.Create(ConvertToModel(flight));
            _unitOfWork.SaveChages();
        }

        public void Update(Flight flight)
        {
            _unitOfWork.FlightRepository.Update(ConvertToModel(flight));
            _unitOfWork.SaveChages();
        }

        public void Remove(int id)
        {
            _unitOfWork.FlightRepository.Delete(id);
            _unitOfWork.SaveChages();
        }

        public void RemoveAll()
        {
            _unitOfWork.FlightRepository.Delete();
            _unitOfWork.SaveChages();
        }
    }
}
