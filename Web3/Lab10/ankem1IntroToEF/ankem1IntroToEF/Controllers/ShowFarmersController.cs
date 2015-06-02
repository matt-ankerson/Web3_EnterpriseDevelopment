using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1IntroToEF.Models;

namespace ankem1IntroToEF.Controllers
{
    public class ShowFarmersController : Controller
    {
        //
        // GET: /ShowFarmers/
        public ActionResult ShowFarmers()
        {
            // Get the db context
            DogFarmerDbContext context = new DogFarmerDbContext();

            // Get all the Farmers
            List<Farmer> farmers = context.Farmers.ToList();

            return View(farmers);
        }

        //[HttpPost]
        //public ActionResult ShowFarmers()
        //{
        //    return View("ShowFarmers");
        //}
	}
}