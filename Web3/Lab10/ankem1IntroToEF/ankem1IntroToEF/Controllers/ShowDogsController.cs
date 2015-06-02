using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1IntroToEF.Models;

namespace ankem1IntroToEF.Controllers
{
    public class ShowDogsController : Controller
    {
        //
        // GET: /ShowDogs/
        public ActionResult ShowDogs()
        {
            // Get the db context
            DogFarmerDbContext context = new DogFarmerDbContext();

            // Get all the dogs
            List<Dog> dogs = context.Dogs.ToList();

            return View(dogs);
        }
	}
}