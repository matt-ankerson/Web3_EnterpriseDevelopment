using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ankem1BirdWatchersDbSetup
{
    public partial class Default : System.Web.UI.Page
    {
        DbManager db;

        // Event handler for Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create the DbManager
            string dbConnectionString = "Data Source = bitdev.ict.op.ac.nz;" +
                                        "Initial Catalog = IN712_201501_ankem1;" +
                                        "User ID = ankem1;" +
                                        "Password = MAn_2A4F;";

            db = new DbManager(dbConnectionString);
        }

        // Event handler for btnResetDatabase_Click
        protected void btnResetDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                db.PopulateDatabase();
                lblResetDb.Text = "Success!";
            }
            catch (Exception ex)
            {
                lblResetDb.Text = "Database error: " + ex.Message;
            }
        }
    }
}