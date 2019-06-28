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
        private IRepository<TaskUsers, int> resporitoryUsers;

        public UserFacade(IRepository<TaskUsers, int> resporitoryUsers)
        {
            this.resporitoryUsers = resporitoryUsers;
        }

        public int GetUserIdLogon(string userName, string password)
        {
            User user = new User(resporitoryUsers);

            int userId = user.LoginUser(userName, password);

            return userId;
        }
    } 
}