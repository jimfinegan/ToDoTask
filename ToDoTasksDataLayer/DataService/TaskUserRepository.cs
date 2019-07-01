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
    /// <summary>
    /// Database interaction of the user repositary
    /// </summary>
    public class TaskUserRepository 
    {
        private IRepository<TaskUsers, int> iRepsoitory;

        public TaskUserRepository(IRepository<TaskUsers, int> iRepsoitory) 
        {
            this.iRepsoitory = iRepsoitory;
        }

        /// <summary>
        /// Gets the user object from the user name and password
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>The user object return</returns>
        public TaskUsers GetUserByUserNameAndPassword(string userName, string password)
        {
            TaskUsers taskUsers = new TaskUsers();
            taskUsers = this.iRepsoitory.FindAll().FirstOrDefault(user => user.UserName.Equals(userName) && user.UserPassword.Equals(password));
            return taskUsers;
        }
    }
}
