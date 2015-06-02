// Author: Matt Ankerson
// Date: 7 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1MusicAcademy.Models
{
    /// <summary>
    /// Holds information for a Tutor
    /// <remarks>
    /// A Tutor has an optional one to optional many relationship with Student.
    /// A Tutor has a one to optional many relationship with TutorInstrument.
    /// </remarks>
    /// </summary>
    public class Tutor
    {
        public int TutorID { get; set; }      // The Primary Key. Required by convention
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public virtual List<TutorInstrument> TutorInstruments { get; set; } // Represents the relationship to TutorInstrument
        public virtual List<Student> Students { get; set; }
    }
}