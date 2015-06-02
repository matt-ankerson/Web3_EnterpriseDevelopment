using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1IntroToEF.Models;

namespace ankem1IntroToEF.Controllers
{
    public class AddFarmerController : Controller
    {
        //
        // GET: /AddFarmer/
        [HttpGet]
        public ActionResult AddFarmer()
        {
            return View();
        }

        // Process the postback data
        [HttpPost]
        public ActionResult AddFarmer(Farmer f)
        {
            // Get the database context
            DogFarmerDbContext context = new DogFarmerDbContext();

            context.Farmers.Add(f);
            context.SaveChanges();

            // Get all farmers for display
            List<Farmer> farmers = context.Farmers.ToList();

            return View("../ShowFarmers/ShowFarmers", farmers);
        }
	}
}