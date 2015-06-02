// Author: Matt Ankerson
// Date: 7 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1MusicAcademy.Models
{
    /// <summary>
    /// Holds information about SkillLevel
    /// <remarks>
    /// A SkillLevel has a one to optional many relationship with TutorIntrument.
    /// A SkillLevel has a one to optional many relationship with Student.
    /// </remarks>
    /// </summary>
    public class SkillLevel
    {
        public int SkillLevelID { get; set; }
        public int Skill { get; set; }         // Royal College Exam Level (1 - 9)
        public virtual List<TutorInstrument> TutorInstruments { get; set; }   // Represents the relationship to TutorInstrument
    }
}