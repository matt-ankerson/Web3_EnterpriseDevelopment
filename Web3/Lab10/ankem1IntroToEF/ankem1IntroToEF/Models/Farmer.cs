// Author: Matt Ankerson
// Date: 28 March 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1IntroToEF.Models
{
    /// <summary>
    /// Stores information about a Farmer
    /// </summary>
    public class Farmer
    {
        public int FarmerID { get; set; }           // Required by convention in this format
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public virtual List<Dog> Dogs { get; set; } // Represents the many-many relationship
    }
}