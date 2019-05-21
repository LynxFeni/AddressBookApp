using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressApp.Web.Controllers
{
    public class AddressBookController : Controller
    {
        // GET: AddressBook
        public ActionResult Index()
        {
            return View();
        }
    }
}