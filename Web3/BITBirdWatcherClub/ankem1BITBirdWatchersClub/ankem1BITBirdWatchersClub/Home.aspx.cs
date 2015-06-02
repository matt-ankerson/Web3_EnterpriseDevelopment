// Author: Matthew Ankerson
// Date: 11 March 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ankem1BITBirdWatchersClub
{
    public partial class Home : System.Web.UI.Page
    {
        DbManager db;

        // Event handler for Page_Load
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

            
        }

    }
}