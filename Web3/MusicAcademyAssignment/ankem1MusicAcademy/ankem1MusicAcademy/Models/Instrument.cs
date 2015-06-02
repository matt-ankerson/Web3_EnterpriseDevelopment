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
    /// An Instrument has an optional one to optional many relationship with Student.
    /// An Instrument has an optional one to optional many relationship with TutorInstrument.
    /// </remarks>
    /// </summary>
    public class Instrument
    {
        public int InstrumentID { get; set; }       // Primary Key
        public string Name { get; set; }
        public double RentalCost { get; set; }
        public virtual List<Student> Students { get; set; } // Represents the relationship to Student
        public virtual List<TutorInstrument> TutorInstruments { get; set; } // Represents the relationship to TutorInstrument
    }
}