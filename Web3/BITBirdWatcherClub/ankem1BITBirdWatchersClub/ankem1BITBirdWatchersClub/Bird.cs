using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1BITBirdWatchersClub
{
    /// <summary>
    /// Holds information for a Bird
    /// </summary>
    public class Bird
    {
        private string maoriName;      
        private string englishName;  
        private string scientificName;

        public Bird(string maoriName, string englishName, string scientificName)
        {
            this.maoriName = maoriName;
            this.englishName = englishName;
            this.scientificName = scientificName;
        }

        // Properties
        public string ScientificName
        {
            get { return scientificName; }
            set { scientificName = value; }
        }
        public string EnglishName
        {
            get { return englishName; }
            set { englishName = value; }
        }
        public string MaoriName
        {
            get { return maoriName; }
            set { maoriName = value; }
        }
    }
}