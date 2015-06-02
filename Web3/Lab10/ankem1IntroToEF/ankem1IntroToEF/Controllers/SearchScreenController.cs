using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1IntroToEF.Models;

namespace ankem1IntroToEF.Controllers
{
    public class SearchScreenController : Controller
    {
        // Show the form
        [HttpGet]
        public ActionResult SearchScreen()
        {
            // Display all farmers so the user can choose one.

            // Get the database context
            DogFarmerDbContext context = new DogFarmerDbContext();
            // Get all the farmers
            List<Farmer> farmers = context.Farmers.ToList();

            return View(farmers);
        }

        // Process the post-back data (this will fire when the user clicks on "details")
        public ActionResult FarmerDetails(int farmerID)
        {
            // Get the database context
            DogFarmerDbContext context = new DogFarmerDbContext();

            // Get the list of dogs for the given FarmerID
            List<Dog> dogs = context.Farmers.Find(farmerID).Dogs.ToList();

            // Return the farmer details view (showing the dogs that that farmer owns.)
            return View("FarmerDetails", dogs);
        }
	}
}