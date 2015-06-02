// Author: Matt Ankerson
// Date: 9 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ankem1MusicAcademy.Models;

namespace ankem1MusicAcademy.Controllers
{
    public class AddTutorController : Controller
    {
        /// <summary>
        /// Show the form used for adding a new tutor
        /// </summary>
        /// <returns>An ActionResult object</returns>
        public ActionResult ShowNewTutorForm()
        {
            // Get instruments and skill levels to pass over via viewbag

            try
            {
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                List<Instrument> instruments = context.Instruments.ToList();
                List<SkillLevel> skillLevels = context.SkillLevels.ToList();

                // Put our lists into viewbag
                ViewBag.Instruments = instruments;
                ViewBag.SkillLevels = skillLevels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View();       
        }
        
        /// <summary>
        /// Process an incoming Tutor
        /// </summary>
        /// <param name="t">The tutor to add</param>
        /// <returns>An ActionResult object</returns>
        [HttpPost]
        public ActionResult AddTutor(string FirstName, string LastName, string Phone, int InstrumentID, int SkillLevelID)
        {
            List<Tutor> tutors = new List<Tutor>();

            try
            {
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                // Create the new tutor we need
                Tutor t = new Tutor();
                t.FirstName = FirstName;
                t.LastName = LastName;
                t.Phone = Phone;

                // add the new tutor to the database
                context.Tutors.Add(t);
                context.SaveChanges();      // Push to db

                t = context.Tutors.ToList().LastOrDefault();

                // Create the new TutorInstrument we need
                TutorInstrument ti = new TutorInstrument();
                ti.TutorID = t.TutorID;
                ti.InstrumentID = InstrumentID;
                ti.SkillLevelID = SkillLevelID;

                context.TutorInstruments.Add(ti);

                t.TutorInstruments.Add(ti);

                context.SaveChanges();      // Push to db

                // get a list of all tutors
                tutors = context.Tutors.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // Return the view that displays all tutors, pass through the new list of tutors
            return View("~/Views/Tutor/Tutors.cshtml", tutors);
        }
	}
}