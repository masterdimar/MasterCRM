﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterCRM.Controllers
{
    public class LeadsController : Controller
    {
        // GET: Leads
        public ActionResult Leads()
        {
            return View();
        }
    }
}