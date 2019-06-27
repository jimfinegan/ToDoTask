using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoTasks.Models
{
    public class UIToDoTask
    {
        [DisplayName("Task Id")]
        public int ToDoTaskId { get; set; }
        public int TaskUserId { get; set; }
        [DisplayName("Last updated")]
        public DateTime LastUpdated { get; set; }
        [DisplayName("Description")]
        public string TaskDescription { get; set; }
        [DisplayName("Checked")]
        public bool CheckedDone { get; set; }
    }
}