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
            return View();
        }

        public JsonResult GetAccounts(string sFiltro
                                        , FormCollection oCollection)
        {
            List<Models.AccountsGridModel> oAccounts = new List<Models.AccountsGridModel>();
            int iTotal = 0;
            int iTotalFiltered = 0;

            //Obtener Accounts
            List<AccountEN> oAccountsEN = AccountsBS.GetAccounts(ref iTotal
                                                                    , ref iTotalFiltered
                                                                    , int.Parse(oCollection.Get("iSortCol_0"))
                                                                    , oCollection.Get("sSortDir_0"));
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<AccountEN, AccountsGridModel>()
                  .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Propietario.Apellido + " " + src.Propietario.Nombre));
            });

            AutoMapper.Mapper.Map(oAccountsEN, oAccounts);   

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