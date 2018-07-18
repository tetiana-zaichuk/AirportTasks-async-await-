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
    public class DepartureService : IService<Departure>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ValidationForeignIdAsync(Departure ob)
        {
            var listPlane = await _unitOfWork.AircraftRepository.GetAsync();
            var listCrew = await _unitOfWork.CrewRepository.GetAsync();
            var listFlight = await _unitOfWork.FlightRepository.GetAsync();
            return listPlane.FirstOrDefault(o => o.Id == ob.Aircraft.Id) != null && listCrew.FirstOrDefault(o => o.Id == ob.Crew.Id) != null && listFlight.FirstOrDefault(o => o.Id == ob.Flight.Id) != null;
        }

        public async Task<Departure> IsExistAsync(int id)
        {
            var ob = await _unitOfWork.DepartureRepository.GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Departure, Departure>(ob.FirstOrDefault());
        }

        public DataAccessLayer.Models.Departure ConvertToModel(Departure departure)
            => _mapper.Map<Departure, DataAccessLayer.Models.Departure>(departure);

        public async Task<List<Departure>> GetAllAsync()
            => _mapper.Map<List<DataAccessLayer.Models.Departure>, List<Departure>>(await _unitOfWork.DepartureRepository.GetAsync());

        public async Task<Departure> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Departure departure)
        {
            await _unitOfWork.DepartureRepository.CreateAsync(ConvertToModel(departure));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departure departure)
        {
            _unitOfWork.DepartureRepository.Update(ConvertToModel(departure));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.DepartureRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.DepartureRepository.Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
