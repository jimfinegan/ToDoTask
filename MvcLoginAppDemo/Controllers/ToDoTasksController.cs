using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoTasks.Controllers
{
    public class ToDoTasksController : Controller
    {
        //
        // GET: /ToDoTasks/

        public ActionResult Index()
        {
            return View();
        }

    }
}
