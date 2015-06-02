// Author: Matt Ankerson
// Date: 7 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1MusicAcademy.Models;

namespace ankem1MusicAcademy.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// Show the Students page
        /// </summary>
        /// <returns>An ActionResult object</returns>
        public ActionResult Students()
        {
            // Display all Students
            List<Student> students = new List<Student>();

            try
            {
                MusicSchoolDbContext context = new MusicSchoolDbContext();
                students = context.Students.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // Return the default view, pass through our list of Students
            return View(students);
        }
	}
}