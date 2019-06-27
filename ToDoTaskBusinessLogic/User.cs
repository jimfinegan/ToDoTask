using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDoTasksDataLayer;
using ToDoTasksDataLayer.Entities;
using ToDoTasksDataLayer.DataService;
using ToDoTasksDataLayer.Repository;

namespace ToDoTaskBusinessLogic
{
    public class User
    {
        private IRepository<TaskUsers, int> iRepository;

        public User (IRepository<TaskUsers, int> iRepository)
        {
            this.iRepository = iRepository;
        }

        public int LoginUser(string userName, string password)
        {
            int userId = 0;
            TaskUserRepository LogonUser = new TaskUserRepository(this.iRepository);
            TaskUsers taskUser = LogonUser.GetUserByUserNameAndPassword(userName, password);

            if (taskUser != null)
            {
                userId = taskUser.UserId;
            }

            return userId;
        }
    }
}
