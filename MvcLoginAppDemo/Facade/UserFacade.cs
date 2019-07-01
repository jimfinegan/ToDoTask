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
    /// <summary>
    /// Class to separate the business layer interaction from the UI for user logic.
    /// </summary>
    public class UserFacade
    {
        private IRepository<TaskUsers, int> resporitoryUsers;

        /// <summary>
        /// The inject abstraction of the database user object.
        /// </summary>
        /// <param name="resporitoryUsers">abstraction of the database user object</param>
        public UserFacade(IRepository<TaskUsers, int> resporitoryUsers)
        {
            this.resporitoryUsers = resporitoryUsers;
        }

        /// <summary>
        /// Queries the database to find a user for a given username and password.
        /// </summary>
        /// <param name="userName">The username</param>
        /// <param name="password">The password</param>
        /// <returns>The int of the userid</returns>
        public int GetUserIdLogon(string userName, string password)
        {
            User user = new User(resporitoryUsers);

            int userId = user.LoginUser(userName, password);

            return userId;
        }
    } 
}