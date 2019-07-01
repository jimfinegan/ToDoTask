using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTasksDataLayer.Entities
{
    /// <summary>
    /// Database presentation of the Task object
    /// </summary>
    public class ToDoTasks
    {
        /// <summary>
        /// The identity of the task
        /// </summary>
        [AutoIncrement]
        public int ToDoTaskId { get; set; }

        /// <summary>
        /// Identification of the user id
        /// </summary>
        public int TaskUserId  { get; set; }

        /// <summary>
        /// The datetime of the last update to the task object
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The description of the task
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Boolean of a task
        /// </summary>
        public bool CheckedDone { get; set; }
    }
}
