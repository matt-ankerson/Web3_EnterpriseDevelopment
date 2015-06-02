// Author: Matt Ankerson
// Date: 14 March 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ankem1BITBirdWatchersClub
{
    public partial class Members : System.Web.UI.Page
    {
        private DbManager db;

        // Page_Load event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnectionString = "Data Source = bitdev.ict.op.ac.nz;" +
                                        "Initial Catalog = IN712_201501_ankem1;" +
                                        "User ID = ankem1;" +
                                        "Password = MAn_2A4F;";

            db = new DbManager(dbConnectionString);

            // Set up the Hyperlinks
            hplHome.NavigateUrl = "Home.aspx";
            hplMembers.NavigateUrl = "Members.aspx";
            hplSightings.NavigateUrl = "Sightings.aspx";
            hplNewSighting.NavigateUrl = "NewSighting.aspx";

            // Show all members
            try
            {
                getMembers();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Database Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Build a SELECT query to get all members of the club
        /// </summary>
        public void getMembers()
        {
            string query = "SELECT FirstName AS [First Name], LastName AS [Last Name], Suburb AS [Suburb] FROM tblMember ORDER BY LastName asc;";
            db.ExecuteSelectQuery(query, gvDisplay);
        }
    }
}