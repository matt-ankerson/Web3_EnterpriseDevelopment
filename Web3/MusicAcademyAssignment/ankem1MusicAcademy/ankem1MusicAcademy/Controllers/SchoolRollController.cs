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
    public class SchoolRollController : Controller
    {
        /// <summary>
        /// Show the school roll
        /// </summary>
        /// <returns>An ActionResult object</returns>
        public ActionResult ShowSchoolRoll()
        {
            bool groupsAssigned = false;
            List<Student> students = new List<Student>();

            try
            {
                // Get the db context
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                // Get our list of students
                students = context.Students.ToList();

                // Check whether or not groups have been assigned, send a null list to the view if groups are unassigned.
                

                foreach (Student s in students)
                {
                    if (s.TutorID != null)
                        groupsAssigned = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (groupsAssigned)
            {
                // Sort the students by tutorID
                students = students.OrderBy(x => x.TutorID).ToList();
                return View(students);
            }
            else
            {
                students = null;
                return View(students);
            }
        }
	}
}