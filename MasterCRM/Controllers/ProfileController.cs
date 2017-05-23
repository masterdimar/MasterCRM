using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MasterCRM.Models;
namespace MasterCRM.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        public ActionResult Profile()
        {
            ProfileViewModel oViewModel = new Models.ProfileViewModel();
            oViewModel.Language = System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            List<KeyValuePair<string, string>> oLanguages = new List<KeyValuePair<string, string>>();
            oLanguages.Add(new KeyValuePair<string, string>("en", "English"));
            oLanguages.Add(new KeyValuePair<string, string>("es", "Spanish"));
            ViewData.Add("Languages", oLanguages);

            return View(oViewModel);
        }

        [HttpPost]
        public ActionResult Save(ProfileViewModel oViewModel)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(oViewModel.Language);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(oViewModel.Language);

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = oViewModel.Language;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Profile");
        }
    }
}