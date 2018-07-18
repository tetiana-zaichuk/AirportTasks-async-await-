using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
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

        public bool ValidationForeignId(Ticket ob)
            => _unitOfWork.FlightRepository.Get().FirstOrDefault(o => o.Id == ob.FlightId) != null;

        public Ticket IsExist(int id)
            => _mapper.Map<DataAccessLayer.Models.Ticket, Ticket>(_unitOfWork.Set<DataAccessLayer.Models.Ticket>().Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Ticket ConvertToModel(Ticket ticket)
            => _mapper.Map<Ticket, DataAccessLayer.Models.Ticket>(ticket);

        public List<Ticket> GetAll()
            => _mapper.Map<List<DataAccessLayer.Models.Ticket>, List<Ticket>>(_unitOfWork.Set<DataAccessLayer.Models.Ticket>().Get());

        public Ticket GetDetails(int id) => IsExist(id);

        public void Add(Ticket ticket)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Ticket>().Create(ConvertToModel(ticket));
            _unitOfWork.SaveChages();
        }

        public void Update(Ticket ticket)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Ticket>().Update(ConvertToModel(ticket));
            _unitOfWork.SaveChages();
        }

        public void Remove(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Ticket>().Delete(id);
            _unitOfWork.SaveChages();
        }

        public void RemoveAll()
        {
            _unitOfWork.Set<DataAccessLayer.Models.Ticket>().Delete();
            _unitOfWork.SaveChages();
        }
    }
}
