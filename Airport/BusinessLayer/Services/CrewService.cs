using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class CrewService : IServiceCrew
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<Crew10> GetInfo()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync("http://5b128555d50a5c0014ef1204.mockapi.io/crew").Result;
                return JsonConvert.DeserializeObject<List<Crew10>>(response).Take(10).ToList();
            }
        }

        public async Task<List<Crew>> Get10Async()
        {
            var oldList = GetInfo();
            List<Crew> listCrew = new List<Crew>();
            string str = "";
            Pilot pilot;
            List<Stewardess> stewardesses;
            foreach (var c in oldList)
            {
                pilot = _mapper.Map<Pilot10, Pilot>(c.pilot.FirstOrDefault());
                stewardesses = _mapper.Map<List<Stewardess10>, List<Stewardess>>(c.stewardess);
                listCrew.Add(new Crew() { Pilot = pilot, Stewardesses = stewardesses });
                str = str + "\n Crew: " + c.id + " Pilot: " + pilot.Id + " " + pilot.FirstName + " Stewardess count: " + stewardesses.Count;
                c.id = null;
            }

            Task t1 = _unitOfWork.CrewRepository.CreateListAsync(_mapper.Map<List<Crew>, List<DataAccessLayer.Models.Crew>>(listCrew));
            Task t2 = _unitOfWork.SaveChangesAsync();
            Task t3 = WriteDataToFileAsync(str);
            await Task.WhenAll(new[] { t1, t2, t3 });
            return listCrew;
        }

        public async Task WriteDataToFileAsync(string str)
        {
            byte[] array = Encoding.Default.GetBytes("" + str);
            string Path = "log_" + DateTime.UtcNow.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";
            using (var fstream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                fstream.Seek(0, SeekOrigin.End);
                await fstream.WriteAsync(array, 0, array.Length);
            }
        }

        public async Task<bool> ValidationForeignIdAsync(Crew ob)
        {
            //if (ob.Stewardesses == null) return false;
            foreach (var st in ob.Stewardesses)
            {
                var listSt = await _unitOfWork.Set<DataAccessLayer.Models.Stewardess>().GetAsync(st.Id);
                if (listSt.FirstOrDefault() == null) return false;
            }
            var listP = await _unitOfWork.Set<DataAccessLayer.Models.Pilot>().GetAsync();
            return listP.FirstOrDefault(o => o.Id == ob.Pilot.Id) != null;
        }

        public async Task<Crew> IsExistAsync(int id)
        {
            var listCrew = await _unitOfWork.CrewRepository.GetAsync(id);
            return _mapper.Map<DataAccessLayer.Models.Crew, Crew>(listCrew.FirstOrDefault());
        }

        public DataAccessLayer.Models.Crew ConvertToModel(Crew crew) => _mapper.Map<Crew, DataAccessLayer.Models.Crew>(crew);

        public async Task<List<Crew>> GetAllAsync() => _mapper.Map<List<DataAccessLayer.Models.Crew>, List<Crew>>(await _unitOfWork.CrewRepository.GetAsync());

        public async Task<Crew> GetDetailsAsync(int id) => await IsExistAsync(id);

        public async Task AddAsync(Crew crew)
        {
            await _unitOfWork.CrewRepository.CreateAsync(ConvertToModel(crew));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Crew crew)
        {
            _unitOfWork.CrewRepository.Update(ConvertToModel(crew));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.CrewRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAllAsync()
        {
            _unitOfWork.CrewRepository.Delete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
