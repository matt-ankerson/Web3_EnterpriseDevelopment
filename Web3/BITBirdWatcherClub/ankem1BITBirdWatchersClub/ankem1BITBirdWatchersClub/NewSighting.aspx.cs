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
    public partial class NewSighting : System.Web.UI.Page
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

            // Populate the drop-down boxes
            try
            {
                getMemberNamesForListBox();
                getBirdNamesForListBox();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Database Error: " + ex.Message;
            }

            txtMaori.Enabled = false;
            txtEnglish.Enabled = false;
            txtScientific.Enabled = false;
            ddlBird.Enabled = true;

            lblError.Visible = false;

        }

        /// <summary>
        /// Build a SELECT query to get all the member names we require for the drop down list
        /// </summary>
        public void getMemberNamesForListBox()
        {
            string query = "SELECT MemberID, FirstName, LastName FROM tblMember ORDER BY LastName asc;";
            Dictionary<int, string> members = db.ExecuteSelectQuery(query);

            foreach(KeyValuePair<int, string> m in members)
            {
                ddlMember.Items.Add(new ListItem(m.Value, m.Key.ToString()));
            }
            
            //ddlMember.DataSource = members.Values;
            //ddlMember.DataBind();
        }

        /// <summary>
        /// Build a SELECT query to get all the bird names we require for the drop down list
        /// </summary>
        public void getBirdNamesForListBox()
        {
            string query = "SELECT BirdID, MaoriName, EnglishName FROM tblBird ORDER BY MaoriName asc;";
            Dictionary<int, string> birds = db.ExecuteSelectQuery(query);

            foreach(KeyValuePair<int, string> b in birds)
            {
                ddlBird.Items.Add(new ListItem(b.Value, b.Key.ToString()));
            }

            //ddlBird.DataSource = birds.Values;
            //ddlBird.DataBind();
        }

        // Event handler for rbExisting
        protected void rbExisting_CheckedChanged(object sender, EventArgs e)
        {
            txtMaori.Enabled = false;
            txtEnglish.Enabled = false;
            txtScientific.Enabled = false;
            ddlBird.Enabled = true;
        }

        // Event handler for rbNew
        protected void rbNew_CheckedChanged(object sender, EventArgs e)
        {
            txtMaori.Enabled = true;
            txtEnglish.Enabled = true;
            txtScientific.Enabled = true;
            ddlBird.Enabled = false;
        }

        // Event handler for btnConfirm
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // Gather information from the form and perform an insert

            int memberID = Convert.ToInt32(ddlMember.SelectedItem.Value);

            // Determine whether or not we are inserting with a new bird, or an existing bird.
            if(rbExisting.Checked)
            {
                // Make an INSERT using the selected existing bird

                int birdID = Convert.ToInt32(ddlBird.SelectedItem.Value);

                try
                {
                    db.InsertBirdMember(birdID, memberID);
                }
                catch (Exception ex)
                {
                    lblInfo.Text = "Failed to insert bird / member relationship: " + ex.Message;
                }
                
            }
            else
            {
                if ((!string.IsNullOrEmpty(txtMaori.Text)) &&
                   (!string.IsNullOrEmpty(txtEnglish.Text)) &&
                   (!string.IsNullOrEmpty(txtScientific.Text)))
                {
                    lblError.Visible = false;

                    

                    string q = "SELECT BirdID FROM tblBird ORDER BY BirdID desc;";

                    try
                    {
                        // Make an INSERT using the new bird info provided
                        db.InsertBird(txtMaori.Text, txtEnglish.Text, txtScientific.Text);
                        // Create a new bird/member relationship
                        int birdID = db.ExecuteSelectQueryForKeys(q).FirstOrDefault();
                        db.InsertBirdMember(birdID, memberID);
                    }
                    catch (Exception ex)
                    {
                        lblInfo.Text = "Failed to insert bird / member relationship: " + ex.Message;
                    }
                }
                else
                {
                    lblError.Visible = true;
                }
            }
        }
    }
}