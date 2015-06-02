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
    public class StudentDetailsController : Controller
    {
        /// <summary>
        /// Show the form that displays all data for a particular student
        /// </summary>
        /// <param name="studentID">The student to find and display</param>
        /// <returns>An ActionResult object</returns>
        public ActionResult ShowStudentDetailsForm(int studentID)
        {
            Student stu = new Student();

            try
            {
                MusicSchoolDbContext context = new MusicSchoolDbContext();

                // Get the student we want according to the supplied ID.
                stu = context.Students.Find(studentID);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            // Return the view that displays full information for a single student, pass in the student
            return View(stu);
        }
	}
}