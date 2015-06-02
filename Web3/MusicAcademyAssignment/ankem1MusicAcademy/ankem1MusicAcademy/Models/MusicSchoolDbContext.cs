// Author: Matt Ankerson
// Date: 7 April 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ankem1MusicAcademy.Models
{
    /// <summary>
    /// The object we use to interact with the database
    /// </summary>
    public class MusicSchoolDbContext : DbContext
    {
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TutorInstrument> TutorInstruments { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
    }
}