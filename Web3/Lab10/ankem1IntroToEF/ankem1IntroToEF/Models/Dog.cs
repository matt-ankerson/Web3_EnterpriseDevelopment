// Author: Matt Ankerson
// Date: 28 March 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1IntroToEF.Models
{
    /// <summary>
    /// Stores information about a Dog
    /// </summary>
    public class Dog
    {
        public int DogID { get; set; }      // Conventionally required in this format
        public string Name { get; set; }
        public string Breed { get; set; }

        public int FarmerID { get; set; }   // Represents the relationship

        public virtual Farmer Farmer { get; set; }
    }
}