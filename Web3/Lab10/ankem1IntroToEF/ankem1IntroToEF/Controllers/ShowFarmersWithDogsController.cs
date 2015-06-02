using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1IntroToEF.Models;

namespace ankem1IntroToEF.Controllers
{
    public class ShowFarmersWithDogsController : Controller
    {
        //
        // GET: /ShowFarmersWithDogs/
        public ActionResult ShowFarmersWithDogs()
        {
            // Get the database context
            DogFarmerDbContext context = new DogFarmerDbContext();

            // Get all the farmers
            List<Farmer> farmers = context.Farmers.ToList();

            return View(farmers);
        }
	}
}