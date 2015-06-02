// Author: Matt Ankerson
// Date: 15 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ankem1MusicAcademy.Models;

namespace ankem1MusicAcademy.Controllers
{
    public class TutorDetailsController : Controller
    {
        /// <summary>
        /// Get the tutor according to the given ID and show the tutor details view
        /// </summary>
        /// <param name="tutorID">The tutor to show</param>
        /// <returns>An ActionResult object</returns>
        public ActionResult ShowTutorDetailsForm(int tutorID)
        {
            Tutor tut = new Tutor();

            try
            {
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                // Get the tutor we want according to the supplied ID
                tut = context.Tutors.Find(tutorID);

                // Put into ViewBag the list of TutorInstruments we require.
                List<TutorInstrument> tutorInstruments = context.TutorInstruments.Where(x => x.TutorID == tutorID).Include("Instrument").Include("SkillLevel").ToList();
                ViewBag.TutorInstruments = tutorInstruments;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(tut);
        }
	}
}