using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ToDoTasksDataLayer.Entities;
using ToDoTaskBusinessLogic;

using ToDoTasksDataLayer;
using ToDoTasksDataLayer.Repository;

namespace ToDoTasks.Facade
{
    public class UserFacade
    {
        public int GetUserIdLogon(string userName, string password)
        {
            IRepository<TaskUsers, int> reporitory = new RepositoryOrmlite<TaskUsers, int>();

            User user = new User(reporitory);

            int userId = user.LoginUser(userName, password);

            return userId;
        }
    } 
}