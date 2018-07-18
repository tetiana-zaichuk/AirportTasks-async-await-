using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class StewardessService : IService<Stewardess>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool ValidationForeignId(Stewardess ob) => true;

        public Stewardess IsExist(int id)
            => _mapper.Map<DataAccessLayer.Models.Stewardess, Stewardess>(_unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Stewardess ConvertToModel(Stewardess stewardess)
            => _mapper.Map<Stewardess, DataAccessLayer.Models.Stewardess>(stewardess);

        public List<Stewardess> GetAll()
            => _mapper.Map<List<DataAccessLayer.Models.Stewardess>, List<Stewardess>>(_unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Get());

        public Stewardess GetDetails(int id) => IsExist(id);

        public void Add(Stewardess stewardess)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Create(ConvertToModel(stewardess));
            _unitOfWork.SaveChages();
        }

        public void Update(Stewardess stewardess)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Update(ConvertToModel(stewardess));
            _unitOfWork.SaveChages();
        }

        public void Remove(int id)
        {
            _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Delete(id);
            _unitOfWork.SaveChages();
        }

        public void RemoveAll()
        {
            _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().Delete();
            _unitOfWork.SaveChages();
        }
    }
}
