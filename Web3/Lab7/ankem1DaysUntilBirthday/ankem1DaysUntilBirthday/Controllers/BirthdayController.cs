using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ankem1DaysUntilBirthday.Controllers
{
    public class BirthdayController : Controller
    {
        //
        // GET: /Birthday/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewBagDemonstration()
        {
            DateTime now = new DateTime();
            now = DateTime.Now;

            DateTime birthday = new DateTime(2015, 12, 19);

            int difference = (birthday - now).Days;

            ViewBag.Name = "Matthew";
            ViewBag.Birthday = birthday;
            ViewBag.Difference = difference;

            return View();
        }
	}
}