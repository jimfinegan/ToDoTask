using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ToDoTasksDataLayer.Entities;
using ToDoTaskBusinessLogic;

using ToDoTasksDataLayer;
using ToDoTasksDataLayer.Repository;
using ToDoTasks.Models;

namespace ToDoTasks.Facade
{
    public class ToDoTasksFacade
    {

        private IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> resporitoryToDoTasks;

        public ToDoTasksFacade()
        {
        }

        public ToDoTasksFacade(IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> resporitoryToDoTasks)
        {
            this.resporitoryToDoTasks = resporitoryToDoTasks;
        }
        
        public List<Models.UIToDoTask> GetAllTasksForUser(int userId)
        {
             IList<ToDoTasksDataLayer.Entities.ToDoTasks> tasks = new List<ToDoTasksDataLayer.Entities.ToDoTasks>();

            ToDoTask toDoTask = new ToDoTask(this.resporitoryToDoTasks);
            tasks = toDoTask.GetAllTasksForUser (userId);

            List<Models.UIToDoTask> uiToDoTasks = new List<Models.UIToDoTask>();

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

        public UIToDoTask GetTask (int taskId)
        {
            IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> resporitory = new RepositoryOrmlite<ToDoTasksDataLayer.Entities.ToDoTasks, int>();
            ToDoTasksDataLayer.Entities.ToDoTasks task = new ToDoTasksDataLayer.Entities.ToDoTasks();

            ToDoTask toDoTask = new ToDoTask(resporitory);
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
        public void Save(Models.UIToDoTask uiTask)
        {
            ToDoTask toDoTask = new ToDoTask(this.resporitoryToDoTasks);

            ToDoTasksDataLayer.Entities.ToDoTasks task = new ToDoTasksDataLayer.Entities.ToDoTasks
            {
                CheckedDone = uiTask.CheckedDone,
                LastUpdated = uiTask.LastUpdated,
                TaskDescription = uiTask.TaskDescription,
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
    }
}