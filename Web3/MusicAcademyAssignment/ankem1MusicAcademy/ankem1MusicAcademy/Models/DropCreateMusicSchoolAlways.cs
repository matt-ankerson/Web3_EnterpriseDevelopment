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
    /// Drop, create and seed the database every time the application is started.
    /// </summary>
    public class DropCreateMusicSchoolAlways : DropCreateDatabaseAlways<MusicSchoolDbContext>
    {
        // Create the context
        private MusicSchoolDbContext dbContext = new MusicSchoolDbContext();

        /// <summary>
        /// Seed the database
        /// </summary>
        /// <param name="context">The database context</param>
        protected override void Seed(MusicSchoolDbContext context)
        {
            base.Seed(context);

            // Populate all tables in the appropriate order.
            PopulateSkillLevelTable();
            PopulateInstrumentTable();
            PopulateTutorTable();
            PopulateTutorInstrumentTable();
            PopulateStudentTable();
        }

        /// <summary>
        /// Seed the Tutor table
        /// </summary>
        public void PopulateTutorTable()
        {
            List<Tutor> tutors = new List<Tutor>
            {
                new Tutor {FirstName = "Craig", LastName = "Foss", Phone = "03 4859 142"},
                new Tutor {FirstName = "Kevin", LastName = "Hague", Phone = "06 6558 585"},
                new Tutor {FirstName = "Kris", LastName = "Faafoi", Phone = "02 1253 182"},
                new Tutor {FirstName = "Nanaia", LastName = "Mahuta", Phone = "09 5862 185"},
                new Tutor {FirstName = "Stuart", LastName = "Nash", Phone = "03 6548 265"}
            };

            foreach (Tutor t in tutors)
                dbContext.Tutors.Add(t);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Seed the Student table
        /// </summary>
        public void PopulateStudentTable()
        {
            List<Student> students = new List<Student>
            {
                new Student {FirstName = "Arthur", LastName = "Miller", Phone = "022 7386 654", DOB = new DateTime(2001, 12, 10), TutorID = null, InstrumentID = 1},
                new Student {FirstName = "Leonard", LastName = "Cohen", Phone = "021 6589 963", DOB = new DateTime(2006, 11, 12), TutorID = null, InstrumentID = 3},
                new Student {FirstName = "Maria", LastName = "Callas", Phone = "025 2356 741", DOB = new DateTime(2010, 10, 16), TutorID = null, InstrumentID = 3},
                new Student {FirstName = "Jessye", LastName = "Norman", Phone = "027 4587 852", DOB = new DateTime(1998, 12, 14), TutorID = null, InstrumentID = 4},
                new Student {FirstName = "Kathleen", LastName = "Battle", Phone = "029 3265 523", DOB = new DateTime(1997, 12, 19), TutorID = null, InstrumentID = 6}
            };

            foreach (Student s in students)
                dbContext.Students.Add(s);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Seed the Instrument table
        /// </summary>
        public void PopulateInstrumentTable()
        {
            List<Instrument> instruments = new List<Instrument>
            {
                new Instrument {Name = "Cello", RentalCost = 40},
                new Instrument {Name = "Flute", RentalCost = 25},
                new Instrument {Name = "Violin", RentalCost = 25},
                new Instrument {Name = "Clarinet", RentalCost = 40},
                new Instrument {Name = "Trumpet", RentalCost = 60},
                new Instrument {Name = "Trombone", RentalCost = 65},
                new Instrument {Name = "Saxophone", RentalCost = 60}
            };

            foreach (Instrument i in instruments)
                dbContext.Instruments.Add(i);
            dbContext.SaveChanges();
        }

        // Seed the SkillLevel table
        public void PopulateSkillLevelTable()
        {
            List<SkillLevel> skillLevels = new List<SkillLevel>
            {
                new SkillLevel {Skill = 1},
                new SkillLevel {Skill = 2},
                new SkillLevel {Skill = 3},
                new SkillLevel {Skill = 4},
                new SkillLevel {Skill = 5},
                new SkillLevel {Skill = 6},
                new SkillLevel {Skill = 7},
                new SkillLevel {Skill = 8},
                new SkillLevel {Skill = 9}
            };

            foreach (SkillLevel sl in skillLevels)
                dbContext.SkillLevels.Add(sl);
            dbContext.SaveChanges();
        }

        // Seed the TutorInstrument table
        public void PopulateTutorInstrumentTable()
        {
            List<TutorInstrument> tutorInstruments = new List<TutorInstrument>
            {
                new TutorInstrument {TutorID = 1, InstrumentID = 1, SkillLevelID = 7},
                new TutorInstrument {TutorID = 1, InstrumentID = 2, SkillLevelID = 6},
                new TutorInstrument {TutorID = 1, InstrumentID = 3, SkillLevelID = 8},
                new TutorInstrument {TutorID = 2, InstrumentID = 2, SkillLevelID = 6},
                new TutorInstrument {TutorID = 2, InstrumentID = 4, SkillLevelID = 9},
                new TutorInstrument {TutorID = 3, InstrumentID = 5, SkillLevelID = 9},
                new TutorInstrument {TutorID = 3, InstrumentID = 6, SkillLevelID = 7},
                new TutorInstrument {TutorID = 3, InstrumentID = 4, SkillLevelID = 6},
                new TutorInstrument {TutorID = 4, InstrumentID = 3, SkillLevelID = 9},
                new TutorInstrument {TutorID = 4, InstrumentID = 1, SkillLevelID = 6},
                new TutorInstrument {TutorID = 5, InstrumentID = 2, SkillLevelID = 8},
                new TutorInstrument {TutorID = 5, InstrumentID = 7, SkillLevelID = 8}
            };

            foreach (TutorInstrument ti in tutorInstruments)
                dbContext.TutorInstruments.Add(ti);
            dbContext.SaveChanges();
        }
    }
}