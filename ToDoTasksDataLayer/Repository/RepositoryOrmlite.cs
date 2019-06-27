using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using ServiceStack.OrmLite;
using System.Linq;

namespace ToDoTasksDataLayer.Repository
{

    public class RepositoryOrmlite<T, TEntityKey> : IRepository<T, TEntityKey> where T : new()
    {
        IDbCommand dbCmd;
        public RepositoryOrmlite()
        {
            string SqliteFileDb = ConfigurationManager.AppSettings["ConnectionString"].ToString(); // @"Data Source=LAPTOP132\LOCAL;Initial Catalog=ToDoTasks;User ID=jim;Password=Madbilly1!";

            OrmLiteConfig.DialectProvider = new ServiceStack.OrmLite.SqlServer.SqlServerOrmLiteDialectProvider();

            IDbConnection db = SqliteFileDb.OpenDbConnection();

            dbCmd = db.CreateCommand();

        }

        public void Add(T entity)
        {
            dbCmd.Insert<T>(entity);
        }

        public void Remove(T entity)
        {
            dbCmd.Delete<T>(entity);
        }
        public void Save(T entity)
        {
            dbCmd.Update<T>(entity);
        }

        #region readonly
        public T FindBy(TEntityKey id)
        {
            return dbCmd.GetById<T>(id);
        }
        public IEnumerable<T> FindAll()
        {
            return dbCmd.Select<T>();
        }
        public IEnumerable<T> FindAll(int index, int count)
        {
            return dbCmd.Select<T>().Skip(index).Take(count);
        }
        public IEnumerable<T> FindBy(Query query)
        {
            return new List<T>();
        }
        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            return new List<T>();
        }
        #endregion
    }
}
