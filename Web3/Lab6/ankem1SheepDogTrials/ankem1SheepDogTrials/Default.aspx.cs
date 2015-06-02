// Author: Matthew Ankerson
// Date: 5 March 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ankem1SheepDogTrials
{
    public partial class Default : System.Web.UI.Page
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
        }

        protected void gvDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Event handler for btnShowDogs
        protected void btnShowDogs_Click(object sender, EventArgs e)
        {
            string selectDogs = "SELECT Name FROM dbo.tblDog";
            db.ExecuteSelectQuery(selectDogs, gvDisplay);
        }

        // Event handler for btnShowFarmers
        protected void btnShowFarmers_Click(object sender, EventArgs e)
        {
            string selectFarmers = "SELECT FirstName, LastName, PhoneNumber FROM dbo.tblFarmer";
            db.ExecuteSelectQuery(selectFarmers, gvDisplay);
        }

        // Event handler for btnDogsAndFarmers
        protected void btnDogsAndFarmers_Click(object sender, EventArgs e)
        {
            string selectDogsAndFarmers = "SELECT f.LastName AS [Farmer Last Name], f.FirstName AS [Farmer First Name], d.Name AS [Dog Name] " +
                                          "FROM dbo.tblDog d JOIN dbo.tblFarmer f ON d.FarmerID = f.FarmerID " + 
                                          "ORDER BY f.LastName";
            db.ExecuteSelectQuery(selectDogsAndFarmers, gvDisplay);
        }

        // Event handler for btnDogResults
        protected void btnDogResults_Click(object sender, EventArgs e)
        {
            string selectDogResults = "SELECT d.Name AS [Dog Name], s.ShowLocation AS [Show Location], r.FinishPlace AS [Finish Place] " +
                                      "FROM dbo.tblDog d JOIN dbo.tblResult r ON d.DogID = r.DogID " +
                                      "JOIN dbo.tblShow s ON r.ShowID = s.ShowID " +
                                      "ORDER BY d.Name asc, r.FinishPlace asc";

            db.ExecuteSelectQuery(selectDogResults, gvDisplay);
        }

        // Event handler for btnPopulate
        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            db.PopulateSheepDogDatabase();
        }
    }
}