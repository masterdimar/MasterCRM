using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterCRM.Controllers
{
    public class ContactsController : Controller
    {
        public JsonResult GetContacts(string sFiltro
                                        , FormCollection oCollection)
        {
            int iTotal = 0;
            int iTotalFiltered = 0;

            List<Models.ContactsGridModel> oContacts = new List<Models.ContactsGridModel>();

            for (int i = 0; i < 1521; i++)
            {
                Models.ContactsGridModel oContact = new Models.ContactsGridModel() { Account = "Account", Email= "Email@Email.com", Mobile = "1159391044", Name = "Pablo Di Martino", Owner ="masterdimar", Phone = "47129489" };
                oContacts.Add(oContact);
            }

            iTotal = oContacts.Count();
            iTotalFiltered = oContacts.Count();

            int iColumnSort = int.Parse(oCollection.Get("iSortCol_0"));
            string sSortDir = oCollection.Get("sSortDir_0");

            switch (iColumnSort)
            {
                case 0:
                    if (sSortDir == "desc")
                        oContacts = oContacts.OrderByDescending(CON => CON.Name).ToList<Models.ContactsGridModel>();
                    else
                        oContacts = oContacts.OrderBy(CON => CON.Name).ToList<Models.ContactsGridModel>();
                    break;
                case 1:
                    if (sSortDir == "desc")
                        oContacts = oContacts.OrderByDescending(CON => CON.Account).ToList<Models.ContactsGridModel>();
                    else
                        oContacts = oContacts.OrderBy(CON => CON.Account).ToList<Models.ContactsGridModel>();
                    break;
                case 2:
                    if (sSortDir == "desc")
                        oContacts = oContacts.OrderByDescending(CON => CON.Email).ToList<Models.ContactsGridModel>();
                    else
                        oContacts = oContacts.OrderBy(CON => CON.Email).ToList<Models.ContactsGridModel>();
                    break;
                case 3:
                    if (sSortDir == "desc")
                        oContacts = oContacts.OrderByDescending(CON => CON.Mobile).ToList<Models.ContactsGridModel>();
                    else
                        oContacts = oContacts.OrderBy(CON => CON.Mobile).ToList<Models.ContactsGridModel>();
                    break;
                case 4:
                    if (sSortDir == "desc")
                        oContacts = oContacts.OrderByDescending(CON => CON.Phone).ToList<Models.ContactsGridModel>();
                    else
                        oContacts = oContacts.OrderBy(CON => CON.Phone).ToList<Models.ContactsGridModel>();
                    break;
                case 5:
                    if (sSortDir == "desc")
                        oContacts = oContacts.OrderByDescending(CON => CON.Owner).ToList<Models.ContactsGridModel>();
                    else
                        oContacts = oContacts.OrderBy(CON => CON.Owner).ToList<Models.ContactsGridModel>();
                    break;
            }

            return Json(new
            {
                sHecho = oCollection.Get("sHecho"),
                iTotalRecords = iTotal,
                iTotalDisplayRecords = iTotalFiltered,
                aaData = oContacts.Skip(int.Parse(oCollection.Get("iDisplayStart"))).Take(int.Parse(oCollection.Get("iDisplayLength"))).ToList<Models.ContactsGridModel>()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}