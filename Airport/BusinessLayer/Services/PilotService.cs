using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class PilotService : IService<Pilot>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool ValidationForeignId(Pilot ob) => true;

        public Pilot IsExist(int id)
            => _mapper.Map<DataAccessLayer.Models.Pilot, Pilot>(_unitOfWork.Set<DataAccessLayer.Models.Pilot>().Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Pilot ConvertToModel(Pilot pilot)
            => _mapper.Map<Pilot, DataAccessLayer.Models.Pilot>(pilot);

        public List<Pilot> GetAll()
            => _mapper.Map<List<DataAccessLayer.Models.Pilot>, List<Pilot>>(_unitOfWork.Set<DataAccessLayer.Models.Pilot>().Get());

        public Pilot GetDetails(int id) => IsExist(id);

        public void Add(Pilot pilot)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Pilot>().Create(ConvertToModel(pilot));
            _unitOfWork.SaveChages();
        }

        public void Update(Pilot pilot)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Pilot>().Update(ConvertToModel(pilot));
            _unitOfWork.SaveChages();
        }

        public void Remove(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Pilot>().Delete(id);
            _unitOfWork.SaveChages();
        }

        public void RemoveAll()
        {
            _unitOfWork.Set<DataAccessLayer.Models.Pilot>().Delete();
            _unitOfWork.SaveChages();
        }
    }
}
