// Author:      Matt Ankerson
// Date:        18 Feb 2015
// Description: Migrate legacy HTML to ASP.NET

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MigratingHTML
{
    public partial class Default : System.Web.UI.Page
    {
        // Event handler for Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Event handler for the Submit button
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string report = ProduceReport();
            divReport.InnerHtml = report;
        }

        // Produce a report using information gathered from the form controls
        public string ProduceReport()
        {
            // Make a report string
            string report = "";

            // Build the report string
            report += (txtName.Value + "<br />");
            report += (txtEmail.Value + "<br />");
            report += "You like the following musical genres: <br />";

            // Loop over the List of Genres, adding only those that are selected
            foreach(ListItem genreItem in slctGenre.Items)
            {
                if(genreItem.Selected)
                {
                    report += genreItem.Text + "<br />";
                }
            }

            // Decide if the user wants to join the Glee club, append the appropriate string
            if(rbGleeClubYes.Checked)
            {
                report += "You do want to join the BIT Glee club.";
            }
            else
            {
                if(rbGleeClubNo.Checked)
                {
                    report += "You do not want to join the BIT Glee club.";
                }
            }

            return report;
        }
    }
}