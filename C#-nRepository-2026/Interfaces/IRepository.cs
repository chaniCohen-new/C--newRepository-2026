using System.Collections.Generic;

namespace c__nRepository_2026.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        T AddItem(T item);
        void DeleteItem(int id);
        void UpdateItem(int id, T item);
    }
}