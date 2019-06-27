using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTasksDataLayer.Entities;
using ToDoTasksDataLayer.Repository;

namespace ToDoTasksDataLayer.DataService
{
    public class TaskUserRepository 
    {
        private IRepository<TaskUsers, int> iRepsoitory;

        public TaskUserRepository(IRepository<TaskUsers, int> iRepsoitory) : base()
        {
            this.iRepsoitory = iRepsoitory;
        }
        public TaskUsers GetUserByUserNameAndPassword(string userName, string password)
        {
            TaskUsers taskUsers = new TaskUsers();
            taskUsers = this.iRepsoitory.FindAll().FirstOrDefault(user => user.UserName.Equals(userName) && user.UserPassword.Equals(password));
            return taskUsers;
        }
    }
}
