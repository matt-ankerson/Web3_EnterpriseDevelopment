// Author: Matt Ankerson
// Date: 16 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ankem1MusicAcademy.Models;

namespace ankem1MusicAcademy.Controllers
{
    public class AddTutorInstrumentController : Controller
    {
        /// <summary>
        /// Show the form for adding an instrument to an existing tutor
        /// </summary>
        /// <param name="tutorID">The tutor to add to.</param>
        /// <returns>An ActionResult object</returns>
        public ActionResult ShowNewTutorInstrumentForm(int tutorID)
        {
            // Get instruments and skill levels to pass over via viewbag

            try
            {
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                // Get the tutor's current instruments from the tutor we are dealing with
                List<TutorInstrument> tutorInstruments = context.Tutors.Find(tutorID).TutorInstruments.ToList();
                // Get all the possible instruments
                List<Instrument> allInstruments = context.Instruments.ToList();

                // Get all instruments that the tutor could still add
                var availableInstruments = from ins in allInstruments
                                       where !(from tutins in tutorInstruments
                                                   select tutins.InstrumentID)
                                                   .Contains(ins.InstrumentID)
                                       select ins;

                List<SkillLevel> skillLevels = context.SkillLevels.ToList();

                // Put our lists into viewbag
                ViewBag.Instruments = availableInstruments.ToList();
                ViewBag.SkillLevels = skillLevels;
                // Put our tutorID into ViewBag also
                ViewBag.TutorID = tutorID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return View();
        }

        /// <summary>
        /// Process an incoming TutorInstrument
        /// </summary>
        /// <param name="tutorInstrument">The TutorInstrument to add.</param>
        /// <returns>Ad ActionResult object</returns>
        [HttpPost]
        public ActionResult AddTutorInstrument(TutorInstrument tutorInstrument)
        {
            Tutor t = new Tutor();

            try
            {
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                // Add the new TutorInstrument
                context.TutorInstruments.Add(tutorInstrument);
                context.SaveChanges();

                // Get the Tutor that we were just dealing with, we will pass this into the view
                t = context.Tutors.Find(tutorInstrument.TutorID);

                // Put into ViewBag the list of TutorInstruments we require.
                List<TutorInstrument> tutorInstruments = context.TutorInstruments.Where(x => x.TutorID == tutorInstrument.TutorID).Include("Instrument").Include("SkillLevel").ToList();
                ViewBag.TutorInstruments = tutorInstruments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View("~/Views/TutorDetails/ShowTutorDetailsForm.cshtml", t);
        }
	}
}