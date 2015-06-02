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
    public class AssignTutorsController : Controller
    {
        /// <summary>
        /// Show the view that presents the user with the interface for assigning tutor-student groups
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAssignTutorsForm()
        {
            // Return the view we need, nothing is required to be passed over.
            return View();
        }


        /// <summary>
        /// Perform computation necessary to assign tutors, then show the school roll.
        /// </summary>
        /// <returns>An ActionResult object</returns>
        public ActionResult AssignTutors()
        {
            // Essentially, we first need to address each student by looping over them. 
            // We then want to assign an appropriate TutorID to them, based on tutor availability and business rules.
            // We will loop over the tutors for each student in order to select the most suitable.
            // It is important also that we pay attention to tutor workload balancing.

            // * Note that if we run this multiple times in a single session, tutor groups will change. 
            //   This is because we are not removing existing relationships between Student and Tutor, thus the existing
            //   relationships are being factored into the logic when deciding upon suitable tutors.
            //   -->> The premise of this deliberate short-coming is the assumtion that we will only run this once a semester,
            //        on a fresh group of Students and Tutors.

            List<Student> properlyGroupedStudents = new List<Student>();

            try
            {
                // Get the database context
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                // Get our students and tutors
                List<Student> students = context.Students.ToList();
                List<Tutor> tutors = context.Tutors.ToList();

                bool assignmentSuccessful = false;

                // Declare a List of type Tutor to hold the possible tutors for a student.
                List<Tutor> suitableTutors = new List<Tutor>();

                // Loop over the students
                foreach (Student s in students)
                {
                    // Loop over the tutors
                    foreach (Tutor t in tutors)
                    {
                        // Determine if this tutor is suitable
                        if (AssessTutorSuitability(t, s))
                        {
                            suitableTutors.Add(t);
                            assignmentSuccessful = true;
                        }
                    }

                    // Get the first suitable tutor
                    Tutor freeTutor = suitableTutors.FirstOrDefault();

                    // Loop over the suitable tutors
                    foreach (Tutor st in suitableTutors)
                    {
                        if (st.Students.Count < freeTutor.Students.Count)
                        {
                            freeTutor = st;
                        }

                        s.TutorID = freeTutor.TutorID;
                    }

                    // If there were no suitable tutors:
                    if (!assignmentSuccessful)
                    {
                        // We can now deal with this later
                        s.TutorID = null;
                    }

                    context.SaveChanges();
                    assignmentSuccessful = false;
                }


                properlyGroupedStudents = context.Students.ToList();

                properlyGroupedStudents = properlyGroupedStudents.OrderBy(x => x.TutorID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // Show the school roll, pass in our list of students, which is now ordered by TutorID
            return View("~/Views/SchoolRoll/ShowSchoolRoll.cshtml", properlyGroupedStudents);
        }

        /// <summary>
        /// Assess the suitability of the given Tutor for the given Student
        /// </summary>
        /// <param name="t">The Tutor to assess</param>
        /// <param name="s">The Student we are currently dealing with</param>
        /// <returns>Boolean value indicating suitability.</returns>
        public bool AssessTutorSuitability(Tutor t, Student s)
        {
            // A Tutor must be level 6 in an instrument in order to teach it.
            // A Tutor must be level 8 in an instrument in order to teach it to 16 y/os and above.

            bool suitable = false;

            // Get the student's age and instrument
            int studentAge = ((DateTime.Now - s.DOB).Days / 365);
            int? studentInstrumentID = s.InstrumentID;

            // Loop over the tutor's instruments
            foreach (TutorInstrument ti in t.TutorInstruments)
            {
                // If the tutor teaches the instrument we want:
                if ((studentInstrumentID != null) && (ti.InstrumentID == studentInstrumentID))
                {
                    // Decide if the tutor is suitable based on tutor skill level and student age.

                    if (studentAge >= 16)
                    {
                        // The tutor needs to be level 8 or higher at this instrument
                        if (ti.SkillLevel.Skill >= 8)
                        {
                            suitable = true;
                        }
                    }
                    else
                    {
                        // The tutor simply needs to be level 6 or higher at this instrument
                        if (ti.SkillLevel.Skill >= 6)
                        {
                            suitable = true;
                        }
                    }
                }
            } // end foreach

            return suitable;
        }

	}
}