using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTasksDataLayer.Entities;
using ToDoTasksDataLayer.Repository;

namespace ToDoTasksDataLayer.DataService
{
    public class ToDoTaskRepository
    {
        private IRepository<ToDoTasks, int> iRepsoitory;

        public ToDoTaskRepository(IRepository<ToDoTasks, int> iRepsoitory)
        {
            this.iRepsoitory = iRepsoitory;
        }
        public IList<ToDoTasks> GetTasksForUser(int userId)
        {
            IList<ToDoTasks> tasks = new List<ToDoTasks>();
            tasks = this.iRepsoitory.FindAll().Where(task => task.TaskUserId == userId).ToList();
            return tasks;
        }

        public ToDoTasks GetTasks(int taskd)
        {
            ToDoTasks task = new ToDoTasks();
            task = this.iRepsoitory.FindBy(taskd);
            return task;
        }

        public void SaveNew (ToDoTasks newTask)
        {
            this.iRepsoitory.Add(newTask);
        }
        
        public void UpdateTask(ToDoTasks newTask)
        {
            this.iRepsoitory.Save(newTask);
        }
    }
}
