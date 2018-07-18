using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IService<T>
    {
        bool ValidationForeignId(T ob);

        T IsExist(int id);

        List<T> GetAll();
        
        T GetDetails(int id);

        void Add(T entity);

        void Update(T entity);

        void Remove(int id);

        void RemoveAll();
    }
}
