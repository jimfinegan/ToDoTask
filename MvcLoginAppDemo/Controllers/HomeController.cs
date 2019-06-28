using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToDoTasks.Facade;
using ToDoTasks.Models;
using ToDoTasksDataLayer.Repository;

namespace ToDoTasks.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> resporitoryToDoTasks;
        private IRepository<ToDoTasksDataLayer.Entities.TaskUsers, int> resporitoryUsers;

        public HomeController(IRepository<ToDoTasksDataLayer.Entities.ToDoTasks, int> repoTasks, IRepository<ToDoTasksDataLayer.Entities.TaskUsers, int> repoUsers)
        {
            this.resporitoryToDoTasks = repoTasks;
            this.resporitoryUsers = repoUsers;
        }

        public ActionResult Login()
        {
            return View();
        }

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

        public ActionResult CreateTask()
        {
            return View();
        }

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

        public ActionResult UpdateUser(int id)
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
