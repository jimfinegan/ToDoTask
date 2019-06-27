using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTasksDataLayer.Entities;
using ToDoTasksDataLayer.DataService;
using ToDoTasksDataLayer.Repository;

namespace ToDoTaskBusinessLogic
{
    public class ToDoTask
    {

        private IRepository<ToDoTasks, int> iRepository;

        public ToDoTask(IRepository<ToDoTasks, int> iRepository)
        {
            this.iRepository = iRepository;
        }
        
        public List<ToDoTasks> GetAllTasksForUser(int userId)
        {
            IList<ToDoTasks> tasks = new List<ToDoTasks>();
            
            ToDoTaskRepository toDoTask = new ToDoTaskRepository(this.iRepository);
            tasks = toDoTask.GetTasksForUser(userId);
            return tasks.ToList();
        }
        
        public ToDoTasks GetTasks(int taskId)
        {
            ToDoTasks task = new ToDoTasks();

            ToDoTaskRepository toDoTask = new ToDoTaskRepository(this.iRepository);
            task = toDoTask.GetTasks(taskId);
            return task;
        }

        public void SaveNew(ToDoTasks newTask)
        {
            ToDoTaskRepository toDoTask = new ToDoTaskRepository(this.iRepository);
            toDoTask.SaveNew (newTask);
        }

        public void UpdateTask(ToDoTasks existingTask)
        {
            ToDoTaskRepository toDoTask = new ToDoTaskRepository(this.iRepository);
            toDoTask.UpdateTask (existingTask);
        }
    }
}
