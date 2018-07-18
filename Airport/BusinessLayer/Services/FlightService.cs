using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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

        public async Task<bool> ValidationForeignIdAsync(Flight ob)
        {
            foreach (var t in ob.Tickets)
            {
                var listT = await _unitOfWork.Set<DataAccessLayer.Models.Ticket>().GetAsync(t.Id);
                if (listT.FirstOrDefault() == null) return false;
            }
            return true;
        }

        public async Task<Flight> IsExistAsync(int id)
        {
            var ob = await _unitOfWork.FlightRepository.GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Flight, Flight>(ob.FirstOrDefault());
        }
        public DataAccessLayer.Models.Flight ConvertToModel(Flight flight) => _mapper.Map<Flight, DataAccessLayer.Models.Flight>(flight);

        public async Task<List<Flight>> GetAllAsync()
        {
            return _mapper.Map<List<DataAccessLayer.Models.Flight>, List<Flight>>(
                // await _unitOfWork.FlightRepository.GetAsync());
                await UseTimer());
        }

        public async Task<List<DataAccessLayer.Models.Flight>> UseTimer()
        {
            var tcs = new TaskCompletionSource<List<DataAccessLayer.Models.Flight>>();
            System.Timers.Timer _delayTimer = new System.Timers.Timer(3000) {AutoReset = false};
            var flights = await _unitOfWork.FlightRepository.GetAsync();
            _delayTimer.Elapsed += delegate { _delayTimer.Dispose();tcs.SetResult(flights);};
            _delayTimer.Start();
            return await tcs.Task;
        }

        public async Task<Flight> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Flight flight)
        {
            await _unitOfWork.FlightRepository.CreateAsync(ConvertToModel(flight));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _unitOfWork.FlightRepository.Update(ConvertToModel(flight));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.FlightRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.FlightRepository.Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
