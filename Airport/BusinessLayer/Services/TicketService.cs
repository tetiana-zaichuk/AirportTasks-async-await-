using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class TicketService : IService<Ticket>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> ValidationForeignIdAsync(Ticket ob)
        {
            var listF=await _unitOfWork.FlightRepository.GetAsync();
            return listF.FirstOrDefault(o => o.Id == ob.FlightId) != null;
        }

        public async Task<Ticket> IsExistAsync(int id)
        {
            var ob = await _unitOfWork.Set<DataAccessLayer.Models.Ticket>().GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Ticket, Ticket>(ob.FirstOrDefault());
        }
        public DataAccessLayer.Models.Ticket ConvertToModel(Ticket ticket)
            => _mapper.Map<Ticket, DataAccessLayer.Models.Ticket>(ticket);

        public async Task<List<Ticket>> GetAllAsync()
            => _mapper.Map<List<DataAccessLayer.Models.Ticket>, List<Ticket>>(await _unitOfWork.Set<DataAccessLayer.Models.Ticket>().GetAsync());

        public async Task<Ticket> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Ticket ticket)
        {
            await _unitOfWork.Set<DataAccessLayer.Models.Ticket>().CreateAsync(ConvertToModel(ticket));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Ticket>().Update(ConvertToModel(ticket));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Ticket>().Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.Set<DataAccessLayer.Models.Ticket>().Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
