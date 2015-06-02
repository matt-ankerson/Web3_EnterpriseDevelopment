// Author: Matt Ankerson
// Date: 19 March 2015
// This is the controller for the Holiday Form
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1MVCExploration.Models;
using System.Globalization;

namespace ankem1MVCExploration.Controllers
{
    public class HolidayController : Controller
    {
        //
        // GET: /Holiday/
        public ActionResult Index()
        {
            return View();
        }

        // This version of the action result method shows the form
        [HttpGet]
        public ActionResult ShowHoliday()
        {
            // Return the default View
            return View();
        }

        // This version of the action result method processes the post-back data
        // Because the form view is strongly typed, we can pass in a whole Holiday object
        [HttpPost]
        public ActionResult ShowHoliday(Holiday holiday)
        {
            DateTime now = DateTime.Now;
            holiday.DaysUntilHoliday = (holiday.HolidayDate - now).Days;

            // Send in the given Holiday instance to this view
            return View("ShowHolidayConfirm", holiday);
        }
	}
}