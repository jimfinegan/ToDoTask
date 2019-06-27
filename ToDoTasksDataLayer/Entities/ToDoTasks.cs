using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTasksDataLayer.Entities
{
    public class ToDoTasks
    {

        [AutoIncrement]
        public int ToDoTaskId { get; set; }
        public int TaskUserId  { get; set; }
        public DateTime LastUpdated { get; set; }
        public string TaskDescription { get; set; }
        public bool CheckedDone { get; set; }
    }
}
