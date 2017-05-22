using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MasterCRM.Models;
using MasterCRM_Entities;
using MasterCRM_BS;
namespace MasterCRM.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Accounts()
        {
            ViewData.Add("AccountTypes", AccountTypesBS.GetAccountTypes().OrderBy(ACT => ACT.Descripcion));
            ViewData.Add("AccountSectors", AccountSectorsBS.GetAccountSectors().OrderBy(ACS => ACS.Descripcion));
            return View();
        }

        public JsonResult GetAccounts(FormCollection oCollection)
        {
            int[] aAccountTypes = null;
            int[] aAccountSector = null;

            string sAccountName = oCollection.Get("AccountName");

            if (oCollection.Get("AccountType[]") != null)
                aAccountTypes = oCollection.Get("AccountType[]").Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            if (oCollection.Get("AccountSector[]") != null)
                aAccountSector = oCollection.Get("AccountSector[]").Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            string sWeb = oCollection.Get("Web");
            string sOwner = oCollection.Get("Owner");

            int iTotal = 0;
            int iTotalFiltered = 0;

            //Obtener Accounts
            List<AccountEN> oAccountsEN = AccountsBS.GetAccounts(sAccountName
                                                                    , aAccountTypes
                                                                    , aAccountSector
                                                                    , sWeb
                                                                    , sOwner
                                                                    , ref iTotal
                                                                    , ref iTotalFiltered
                                                                    , int.Parse(oCollection.Get("iSortCol_0"))
                                                                    , oCollection.Get("sSortDir_0"));

            List<AccountsGridModel> oAccounts = AutomapperConfiguration.mapper.Map<List<AccountsGridModel>>(oAccountsEN);   

            return Json(new
            {
                sHecho = oCollection.Get("sHecho"),
                iTotalRecords = iTotal,
                iTotalDisplayRecords = iTotalFiltered,
                aaData = oAccounts.Skip(int.Parse(oCollection.Get("iDisplayStart"))).Take(int.Parse(oCollection.Get("iDisplayLength"))).ToList<Models.AccountsGridModel>()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}