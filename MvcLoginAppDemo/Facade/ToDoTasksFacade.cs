using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoTaskBusinessLogic;
using ToDoTasksDataLayer.Repository;
using ToDoTasks.Models;

namespace ToDoTasks.Facade
{
    /// <summary>
    /// This class is used as an interaction between the business layer for task operations and the UI
    /// </summary>
    public class ToDoTasksFacade
    {

        private IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> resporitoryToDoTasks;

        public ToDoTasksFacade()
        {
        }

        /// <summary>
        /// Injected abstraction of the database tasks object.
        /// </summary>
        /// <param name="resporitoryToDoTasks">The injected repositary object of the task</param>
        public ToDoTasksFacade(IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> resporitoryToDoTasks)
        {
            this.resporitoryToDoTasks = resporitoryToDoTasks;
        }
        
        /// <summary>
        /// Method to get all tasks for a given user
        /// </summary>
        /// <param name="userId">The user id to get the tasks from</param>
        /// <returns>The UITask model object</returns>
        public List<Models.UIToDoTask> GetAllTasksForUser(int userId)
        {
             IList<ToDoTasksDataLayer.Entities.ToDoTasks> tasks = new List<ToDoTasksDataLayer.Entities.ToDoTasks>();

            ToDoTask toDoTask = new ToDoTask(this.resporitoryToDoTasks);
            tasks = toDoTask.GetAllTasksForUser (userId);

            List<Models.UIToDoTask> uiToDoTasks = new List<Models.UIToDoTask>();

            // Can use auto mapper here!
            foreach (ToDoTasksDataLayer.Entities.ToDoTasks entityTask in tasks.ToList())
            {
                Models.UIToDoTask uiToDoTask = new Models.UIToDoTask
                {
                    ToDoTaskId = entityTask.ToDoTaskId,
                    CheckedDone = entityTask.CheckedDone,
                    LastUpdated = entityTask.LastUpdated,
                    TaskDescription = entityTask.TaskDescription,
                    TaskUserId = entityTask.TaskUserId 
                };

                uiToDoTasks.Add(uiToDoTask);
            }
            return uiToDoTasks;
        }

        /// <summary>
        /// Get the individual task for a given taskid
        /// </summary>
        /// <param name="taskId">The task id</param>
        /// <returns>Returns a task object for use by the UI.</returns>
        public UIToDoTask GetTask (int taskId)
        {
            ToDoTasksDataLayer.Entities.ToDoTasks task = new ToDoTasksDataLayer.Entities.ToDoTasks();

            ToDoTask toDoTask = new ToDoTask(this.resporitoryToDoTasks);
            ToDoTasksDataLayer.Entities.ToDoTasks entityTask = toDoTask.GetTasks(taskId);

            
                Models.UIToDoTask uiToDoTask = new Models.UIToDoTask
                {
                    ToDoTaskId = entityTask.ToDoTaskId,
                    CheckedDone = entityTask.CheckedDone,
                    LastUpdated = entityTask.LastUpdated,
                    TaskDescription = entityTask.TaskDescription,
                    TaskUserId = entityTask.TaskUserId
                };

            
            return uiToDoTask;
        }

        /// <summary>
        /// Adds new or updates a task object to the database
        /// </summary>
        /// <param name="uiTask">The task object to save</param>
        public void Save(Models.UIToDoTask uiTask)
        {
            ToDoTask toDoTask = new ToDoTask(this.resporitoryToDoTasks);

            ToDoTasksDataLayer.Entities.ToDoTasks task = new ToDoTasksDataLayer.Entities.ToDoTasks
            {
                CheckedDone = uiTask.CheckedDone,
                LastUpdated = uiTask.LastUpdated,
                TaskDescription = HttpUtility.HtmlEncode(uiTask.TaskDescription),
                TaskUserId = uiTask.TaskUserId,
                ToDoTaskId = uiTask.ToDoTaskId 
            };
            if (task.ToDoTaskId == 0)
            {
                toDoTask.SaveNew(task);
            }
            else
            {
                toDoTask.UpdateTask(task);
            }
        }

        /// <summary>
        /// Deletes a task from the database for a given id
        /// </summary>
        /// <param name="id">The id of the task to delete.</param>
        public void DelTask(int id)
        {
            ToDoTask toDoTask = new ToDoTask(this.resporitoryToDoTasks);
            ToDoTasksDataLayer.Entities.ToDoTasks entityTask = toDoTask.GetTasks(id);
        
                toDoTask.Del(entityTask);
        
        }
    }
}