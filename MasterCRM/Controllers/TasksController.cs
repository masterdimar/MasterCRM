using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterCRM.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Tasks()
        {
            return View();
        }
    }
}