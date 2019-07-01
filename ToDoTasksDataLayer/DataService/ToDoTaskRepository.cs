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
    /// The database interaction of the abstracted Tasks object.
    /// </summary>
    public class ToDoTaskRepository
    {
        private IRepository<ToDoTasks, int> iRepsoitory;

        public ToDoTaskRepository(IRepository<ToDoTasks, int> iRepsoitory)
        {
            this.iRepsoitory = iRepsoitory;
        }

        /// <summary>
        /// A list of tasks for a given user
        /// </summary>
        /// <param name="userId">The user id of the user</param>
        /// <returns>List of tasks</returns>
        public IList<ToDoTasks> GetTasksForUser(int userId)
        {
            IList<ToDoTasks> tasks = new List<ToDoTasks>();
            tasks = this.iRepsoitory.FindAll().Where(task => task.TaskUserId == userId).ToList();
            return tasks;
        }

        /// <summary>
        /// Gets the task for a given task id
        /// </summary>
        /// <param name="taskid">The task id</param>
        /// <returns>The task object</returns>
        public ToDoTasks GetTasks(int taskid)
        {
            ToDoTasks task = new ToDoTasks();
            task = this.iRepsoitory.FindBy(taskid);
            return task;
        }

        /// <summary>
        /// Save a new task object to the database
        /// </summary>
        /// <param name="newTask">The task object to save.</param>
        public void SaveNew (ToDoTasks newTask)
        {
            this.iRepsoitory.Add(newTask);
        }
        
        /// <summary>
        /// Updates a task object to the database
        /// </summary>
        /// <param name="newTask">The task object to update.</param>
        public void UpdateTask(ToDoTasks newTask)
        {
            this.iRepsoitory.Save(newTask);
        }

        /// <summary>
        /// Deletes a task object from the database
        /// </summary>
        /// <param name="toDoTask">The task object to remove from thwe database</param>
        public void Del(ToDoTasks toDoTask)
        {
            this.iRepsoitory.Remove(toDoTask);
        }
    }
}
