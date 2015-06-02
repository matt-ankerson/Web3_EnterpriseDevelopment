// Author: Matt Ankerson
// Date: 8 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ankem1MusicAcademy.Models;

namespace ankem1MusicAcademy.Controllers
{
    public class AddStudentController : Controller
    {
        /// <summary>
        /// Show the form used for adding a new student
        /// </summary>
        /// <returns>An ActionResult object</returns>
        public ActionResult ShowNewStudentForm()
        {
            MusicSchoolDbContext context = new MusicSchoolDbContext();

            try
            {
                List<Instrument> instruments = context.Instruments.ToList();

                // Put our list of Instruments into ViewBag
                ViewBag.Instruments = instruments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View();       
        }

        /// <summary>
        /// Process an incoming student
        /// </summary>
        /// <param name="stu">The student to add</param>
        /// <returns>An ActionResult object</returns>
        [HttpPost]
        public ActionResult AddStudent(Student stu)
        {
            MusicSchoolDbContext context = new MusicSchoolDbContext();
            List<Student> students = new List<Student>();

            try
            {
                // Add the new student to the database
                context.Students.Add(stu);
                context.SaveChanges();

                // Get a list of all students. Eagerly load the instruments.
                students = context.Students.Include("Instrument").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            // Pass through the list of Students
            return View("~/Views/Student/Students.cshtml", students);
        }
	}
}