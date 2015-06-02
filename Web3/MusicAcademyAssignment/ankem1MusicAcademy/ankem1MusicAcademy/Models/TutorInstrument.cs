// Author: Matt Ankerson
// Date: 7 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1MusicAcademy.Models
{
    /// <summary>
    /// Facilitates the many-many relationship between Tutor and Instrument
    /// <remarks>
    /// A TutorInstrument has a many to one relationship with Instrument
    /// A TutorInstrument has a many to one relationship with Tutor
    /// A TutorInstrument has a one to many relationship with SkillLevel
    /// </remarks>
    /// </summary>
    public class TutorInstrument
    {
        public int TutorInstrumentID { get; set; }
        public int InstrumentID { get; set; }
        public int TutorID { get; set; }
        public int SkillLevelID { get; set; }
        public virtual SkillLevel SkillLevel { get; set; }  // Represents the relationship to SkillLevel
        public virtual Tutor Tutor { get; set; }            // Represents the relationship to Tutor
        public virtual Instrument Instrument { get; set; }  // Represents the relationship to Instrument
    }
}