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
    public partial class Sightings : System.Web.UI.Page
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
            

            // Show all members
            try
            {
                getSightings();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Database Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Build a SELECT query to get all bird sightings.
        /// </summary>
        public void getSightings()
        {
            string query = "SELECT MaoriName AS [Te Reo], EnglishName AS [English], ScientificName AS [Scientific] FROM tblBird ORDER BY EnglishName;";
            db.ExecuteSelectQuery(query, gvDisplay);
        }

        public void getSightingsByMember()
        {
            string query = "SELECT m.FirstName AS [First Name], m.LastName AS [Last Name], b.MaoriName AS [Te Reo], b.EnglishName AS [English], b.ScientificName AS [Scientific] FROM tblBird b " +
                           "JOIN tblBirdMember bm ON b.BirdID = bm.BirdID " + 
                           "JOIN tblMember m ON m.MemberID = bm.MemberID " +
                           "ORDER BY m.LastName;";
            db.ExecuteSelectQuery(query, gvDisplay);
        }

        // Event handler for btnViewBirds
        protected void btnViewBirds_Click(object sender, EventArgs e)
        {
            // Show all bird sightings (withut the sighting club member)
            try
            {
                getSightings();
                lblInfo.Text = "Listed below are all birds that have been sighted by our club.";
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Database Error: " + ex.Message;
            }
        }

        // Event handler for btnBirdsMember
        protected void btnBirdsMember_Click(object sender, EventArgs e)
        {
            // Show all bird sightings by sighting member
            try
            {
                getSightingsByMember();
                lblInfo.Text = "Listed below are all birds that have been sighted, by sighting member.";
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Database Error: " + ex.Message;
            }
        }
    }
}