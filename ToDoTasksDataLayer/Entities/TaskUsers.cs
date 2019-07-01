using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTasksDataLayer.Entities
{
    /// <summary>
    /// Datbase presentation of the User object
    /// </summary>
    public class TaskUsers
    {
        /// <summary>
        /// The user id of the user object
        /// </summary>
        [AutoIncrement]
        public int UserId { get; set; }

        /// <summary>
        /// The username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        public string UserPassword { get; set; }
    }
}
