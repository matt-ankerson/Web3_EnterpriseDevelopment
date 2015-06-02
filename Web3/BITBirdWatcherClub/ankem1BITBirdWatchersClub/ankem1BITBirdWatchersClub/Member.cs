// Author: Matt Ankerson
// Date 14 March 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ankem1BITBirdWatchersClub
{
    /// <summary>
    /// Holds information for a Member
    /// </summary>
    public class Member
    {
        private string firstName;       
        private string lastName;    
        private string suburb;

        public Member(string firstName, string lastName, string suburb)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.suburb = suburb;
        }

        // Properties

        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

    }
}