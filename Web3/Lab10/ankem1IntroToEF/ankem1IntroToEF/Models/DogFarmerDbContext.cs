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
    /// The object we use to interact with the Database
    /// </summary>
    public class DogFarmerDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
    }
}