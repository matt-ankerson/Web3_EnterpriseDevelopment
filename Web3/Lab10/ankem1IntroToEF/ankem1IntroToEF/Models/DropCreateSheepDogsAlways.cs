// Author: Matt Ankerson
// Date: 28 March 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ankem1IntroToEF.Models
{
    /// <summary>
    /// Drop, create and seed the database every time the application is run
    /// </summary>
    public class DropCreateSheepDogsAlways : DropCreateDatabaseAlways<DogFarmerDbContext>
    {
        private DogFarmerDbContext dbContext = new DogFarmerDbContext();
        protected override void Seed(DogFarmerDbContext context)
        {
            base.Seed(context);

            PopulateFarmerTable();
            PopulateDogTable();
        }

        /// <summary>
        /// Seed the Dog table
        /// </summary>
        private void PopulateDogTable()
        {
            List<Dog> dogs = new List<Dog>
            {
                new Dog {Name = "Peg", Breed = "Border Collie", FarmerID = 1},
                new Dog {Name = "Sam", Breed = "Border Collie", FarmerID = 2},
                new Dog {Name = "Kip", Breed = "Huntaway", FarmerID = 2},
                new Dog {Name = "Max", Breed = "Border Collie", FarmerID = 3}
            };

            foreach (Dog d in dogs)
                dbContext.Dogs.Add(d);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Seed the Farmer table
        /// </summary>
        private void PopulateFarmerTable()
        {
            List<Farmer> farmers = new List<Farmer>
            {
                new Farmer {LastName = "McKensie", FirstName = "Bob", Phone = "1233521"},
                new Farmer {LastName = "Clark", FirstName = "Sally", Phone = "456732"},
                new Farmer {LastName = "Finchie", FirstName = "Nigel", Phone = "7809326"}
            };

            foreach (Farmer f in farmers)
                dbContext.Farmers.Add(f);
            dbContext.SaveChanges();
            
        }
    }
}