// Author: Matt Ankerson
// Date: 7 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1MusicAcademy.Models
{
    /// <summary>
    /// Holds information about a Student
    /// <remarks>
    /// A Student has a optional many to optional one relationship with Tutor
    /// A Student has a optional many to one relationship to SkillLevel
    /// </remarks>
    /// </summary>
    public class Student
    {
        public int StudentID { get; set; }      // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public int? TutorID { get; set; }        // Represents the relationship to Tutor
        public int? InstrumentID { get; set; }   // Represents the relationship to Student

        public virtual Tutor Tutor { get; set; }
        public virtual Instrument Instrument { get; set; }
    }
}