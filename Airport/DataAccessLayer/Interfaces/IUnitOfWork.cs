using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Crew> CrewRepository { get; }
        IRepository<Flight> FlightRepository { get; }
        IRepository<Aircraft> AircraftRepository { get;}
        IRepository<Departure> DepartureRepository { get; }

        IRepository<TEntity> Set<TEntity>() where TEntity : Entity;

        int SaveChages();

        Task<int> SaveChangesAsync();
    }
}
