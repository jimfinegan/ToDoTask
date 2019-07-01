using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoTasks.Models
{
    /// <summary>
    /// The model of the task object
    /// </summary>
    public class UIToDoTask
    {
        /// <summary>
        /// The identity of the task
        /// </summary>
        [DisplayName("Task Id")]
        public int ToDoTaskId { get; set; }

        /// <summary>
        /// The user id of a given task
        /// </summary>
        public int TaskUserId { get; set; }

        /// <summary>
        /// The datetime of the last updated
        /// </summary>
        [DisplayName("Last updated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// The description of the task
        /// </summary>
        [DisplayName("Description")]
        public string TaskDescription { get; set; }

        /// <summary>
        /// Boolean indicating weather or not the task was done.
        /// </summary>
        [DisplayName("Checked")]
        public bool CheckedDone { get; set; }
    }
}