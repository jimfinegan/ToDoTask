using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTasksDataLayer.Repository
{
    public interface IRepository<T, TEntityKey> where T : new()
    {
        void Add(T entity);
        void Remove(T entity);
        void Save(T entity);

        #region readonly
        T FindBy(TEntityKey id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(int index, int count);
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);

        #endregion
    }
}
