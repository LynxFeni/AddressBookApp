using AddressApp.Models.Models;
using System.Collections.Generic;

namespace AddressApp.Repository.Interfaces
{
    public interface IRepository<T> where T : AddressBook
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}


