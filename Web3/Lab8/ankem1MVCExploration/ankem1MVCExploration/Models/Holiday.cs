// Author: Matt Ankerson
// Date: 18 March 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1MVCExploration.Models
{
    /// <summary>
    /// Holds information for a Holiday
    /// </summary>
    public class Holiday
    {
        public string Name { get; set; }
        public DateTime HolidayDate { get; set; }
        public int DaysUntilHoliday { get; set; }
    }
}