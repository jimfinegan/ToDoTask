using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToDoTasks.Facade;
using ToDoTasks.Models;
using ToDoTasksDataLayer.Repository;

namespace ToDoTasks.Controllers
{
    /// <summary>
    /// UI concentric layer handles the data to and from the views
    /// </summary>
    public class HomeController : Controller
    {
        private IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> resporitoryToDoTasks;
        private IRepository<ToDoTasksDataLayer.Entities.TaskUsers, int> resporitoryUsers;

        /// <summary>
        /// Default constructor. Repositary objects are injected.
        /// </summary>
        /// <param name="repoTasks">The Repositary tasks object</param>
        /// <param name="repoUsers">The Repositary Users object</param>
        public HomeController(IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> repoTasks, IRepository<ToDoTasksDataLayer.Entities.TaskUsers, int> repoUsers)
        {
            this.resporitoryToDoTasks = repoTasks;
            this.resporitoryUsers = repoUsers;
        }

        /// <summary>
        /// HTTP Get the first view to be shown
        /// </summary>
        /// <returns>Login view.</returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// HTTP Post accepts a user model from the ui view
        /// </summary>
        /// <param name="objUser">The model object of the user</param>
        /// <returns>The dashbourd view if login is sucessful</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TaskUser objUser)
        {
            if (ModelState.IsValid)
            {
                objUser.UserId = new UserFacade(this.resporitoryUsers).GetUserIdLogon(objUser.UserName, objUser.UserPassword);
                if (objUser.UserId > 0)
                {
                    objUser.UserName = objUser.UserName;
                    Session["UserID"] = objUser.UserId.ToString();
                    Session["UserName"] = objUser.UserName.ToString();
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    objUser.LoginErrorMessage = "User does not exist.";
                }
            }
            return View(objUser);
        }

        /// <summary>
        /// The view to add a new task
        /// </summary>
        /// <returns>The add a new task view</returns>
        public ActionResult CreateTask()
        {
            return View();
        }

        /// <summary>
        /// The completed task model when adding a new task.
        /// </summary>
        /// <param name="task">Thew task model object from the ui.</param>
        /// <returns>The userDashboard if sucessful</returns>
        [HttpPost]
        public ActionResult CreateNewUser(UIToDoTask task)
        {
            ToDoTasksFacade facade = new ToDoTasksFacade(resporitoryToDoTasks);
            task.TaskUserId = Convert.ToInt32(Session["UserID"]);
            task.LastUpdated = System.DateTime.Now;

            facade.Save(task);
            if (Session["UserID"] != null)
            {
                int userId = Convert.ToInt32(Session["UserID"]);
                facade = new ToDoTasksFacade(resporitoryToDoTasks);
                List<UIToDoTask> tasks = facade.GetAllTasksForUser(userId);
                return View("UserDashBoard", tasks);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        /// <summary>
        /// The controller function to save edited task
        /// </summary>
        /// <param name="task">The task object to save</param>
        /// <returns>The user dashboard if sucessful</returns>
        [HttpPost]
        public ActionResult SaveEditedTask(UIToDoTask task)
        {
            ToDoTasksFacade facade = new ToDoTasksFacade(resporitoryToDoTasks);
            task.TaskUserId = Convert.ToInt32(Session["UserID"]);
            task.LastUpdated = System.DateTime.Now;

            facade.Save(task);

            if (Session["UserID"] != null)
            {
                int userId = Convert.ToInt32(Session["UserID"]);
                facade = new ToDoTasksFacade(resporitoryToDoTasks);
                List<UIToDoTask> tasks = facade.GetAllTasksForUser(userId);
                return View("UserDashBoard", tasks);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        /// <summary>
        /// HTTP Get for the update of a task
        /// </summary>
        /// <param name="id">The id of the task to update</param>
        /// <returns>The view to edit a task</returns>
        public ActionResult UpdateTask(int id)
        {
            ToDoTasksFacade facade = new ToDoTasksFacade(resporitoryToDoTasks);
            UIToDoTask task = facade.GetTask(id);

            if (task != null)
            {
                return View("UpdateTask", task);
            }
            else
            {
                return UserDashBoard();

            }
        }

        /// <summary>
        /// Deletion of a given task
        /// </summary>
        /// <param name="id">Thwe id of a task</param>
        /// <returns>View of dashboard if sucessful</returns>
        public ActionResult DeleteTask(int id)
        {
            if (Session["UserID"] != null)
            {

                ToDoTasksFacade facade = new ToDoTasksFacade(resporitoryToDoTasks);
                facade.DelTask(id);


                int userId = Convert.ToInt32(Session["UserID"]);

                List<UIToDoTask> tasks = facade.GetAllTasksForUser(userId);
                return View("UserDashBoard", tasks);
            }
            else
            {
                return RedirectToAction("Login");
            }            
        }
        
        /// <summary>
        /// Loads the tasks for a given user in to main page.
        /// </summary>
        /// <returns>The dashboard of the user.</returns>
        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                int userId = Convert.ToInt32(Session["UserID"]);

                ToDoTasksFacade facade = new ToDoTasksFacade(resporitoryToDoTasks);
                List<UIToDoTask> tasks = facade.GetAllTasksForUser  (userId);

                return View(tasks);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
