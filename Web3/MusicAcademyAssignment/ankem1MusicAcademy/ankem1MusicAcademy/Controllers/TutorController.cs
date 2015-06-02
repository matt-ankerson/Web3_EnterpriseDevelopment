// Author: Matt Ankerson
// Date: 8 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ankem1MusicAcademy.Models;

namespace ankem1MusicAcademy.Controllers
{
    public class TutorController : Controller
    {
        /// <summary>
        /// Show all currently available tutors
        /// </summary>
        /// <returns>An ActionResult object</returns>
        public ActionResult Tutors()
        {
            // Get all the tutors
            MusicSchoolDbContext context = new MusicSchoolDbContext();
            List<Tutor> tutors = new List<Tutor>();

            try
            {
                tutors = context.Tutors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(tutors);
        }
	}
}