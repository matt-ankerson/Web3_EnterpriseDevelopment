// Author: Matthew Ankerson
// Date: 5 March 2015
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ankem1SheepDogTrials
{
    /// <summary>
    /// Manages a connection to the database and exposes methods useful for the manipulation of data.
    /// </summary>
    public class DbManager
    {
        private string connectionString;
        private SqlConnection bitdevConnection;

        /// <summary>
        /// Construct a DbManager
        /// </summary>
        /// <param name="connectionString">The connection string for the appropriate db</param>
        public DbManager(string connectionString)
        {
            this.connectionString = connectionString;

            // Create the SqlConnection instance
            bitdevConnection = new SqlConnection();
        }

        /// <summary>
        /// Drop tables, create tables, and fill them with data
        /// </summary>
        public void PopulateSheepDogDatabase()
        {
            CreateSheepDogTables();

            InsertSeedBreeds();
            InsertSeedFarmers();
            InsertSeedShows();
            InsertSeedDogs();
            InsertSeedResults();
        }

        /// <summary>
        /// Open a connection to the db
        /// </summary>
        public void Connect()
        {
            // Add the connection string
            bitdevConnection.ConnectionString = connectionString;

            // Open the connection
            bitdevConnection.Open();
        }

        /// <summary>
        /// Perform a SELECT query on the db and bind to the given GridView
        /// </summary>
        /// <param name="queryString">The query</param>
        /// <param name="gvDisplay">GridView to bind the data to</param>
        public void ExecuteSelectQuery(string queryString, GridView gvDisplay)
        {
            // Open a connection to the database
            Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bitdevConnection;
            cmd.CommandText = queryString;

            // Bind the datasource
            gvDisplay.DataSource = cmd.ExecuteReader();
            gvDisplay.DataBind();
        }

        /// <summary>
        /// Execute a non-select query on the database (ie. insert, update, delete)
        /// </summary>
        /// <param name="queryToExecute">The query</param>
        public void ExecuteNonQuery(string queryToExecute)
        {
            SqlCommand sExecute = new SqlCommand(queryToExecute, bitdevConnection);
            sExecute.ExecuteNonQuery();
        }

        /// <summary>
        /// Create the Tables required for the SheepDogTrails database
        /// </summary>
        /// <param name="bitdevConnection">The connection to the database</param>
        public void CreateSheepDogTables()
        {
            Connect();

            // Clean out the database
            DropTable("tblResult");
            DropTable("tblDog");
            DropTable("tblFarmer");
            DropTable("tblShow");
            DropTable("tblBreed");

            // tblBreed
            CreateTable("CREATE TABLE tblBreed (BreedID INT IDENTITY, BreedName VARCHAR(30) NOT NULL, " +
                        "PRIMARY KEY (BreedID))");
            // tblFarmer
            CreateTable("CREATE TABLE tblFarmer (FarmerID INT IDENTITY, LastName VARCHAR(30) NOT NULL, FirstName VARCHAR(30) NOT NULL, PhoneNumber VARCHAR(30) NOT NULL, " +
                        "PRIMARY KEY (FarmerID))");
            // tblDog
            CreateTable("CREATE TABLE tblDog (DogID INT IDENTITY, Name VARCHAR(30) NOT NULL, BreedID INT NOT NULL, FarmerID INT NOT NULL, " + 
                        "PRIMARY KEY (DogID), " +
                        "FOREIGN KEY (BreedID) REFERENCES tblBreed(BreedID) ON UPDATE CASCADE ON DELETE CASCADE)");
            // tblShow
            CreateTable("CREATE TABLE tblShow (ShowID INT IDENTITY, ShowLocation VARCHAR(30) NOT NULL, ShowDate datetime NOT NULL " +
                        "PRIMARY KEY (ShowID))");
            // tblResult
            CreateTable("CREATE TABLE tblResult (ShowID INT NOT NULL, DogID INT NOT NULL, FinishPlace INT NOT NULL, " +
                        "PRIMARY KEY (ShowID, DogID), " +
                        "FOREIGN KEY (ShowID) REFERENCES tblShow(ShowID) ON UPDATE CASCADE ON DELETE CASCADE, " +
                        "FOREIGN KEY (DogID) REFERENCES tblDog(DogID) ON UPDATE CASCADE ON DELETE CASCADE)");
        }

        /// <summary>
        /// Add a Dog to tblDog
        /// </summary>
        /// <param name="name">Name of the dog</param>
        /// <param name="breedID">The dog's BreedID</param>
        /// <param name="farmerID">the dog's FarmerID</param>
        public void InsertDog(string name, int breedID, int farmerID)
        {
            string insertDog = "INSERT INTO dbo.tblDog VALUES ('" + name + "', '" + breedID + "', '" + farmerID + "');";
            ExecuteNonQuery(insertDog);
        }

        /// <summary>
        /// Add a Breed to tblBreed
        /// </summary>
        /// <param name="breedName">The breed to add</param>
        public void InsertBreed(string breedName)
        {
            string insertBreed = "INSERT INTO dbo.tblBreed VALUES ('" + breedName + "');";
            ExecuteNonQuery(insertBreed);
        }

        /// <summary>
        /// Add a Farmer to tblFarmer
        /// </summary>
        /// <param name="lastName">The farmer's last name</param>
        /// <param name="firstName">The farmer's first name</param>
        /// <param name="phoneNumber">The farmer's phone number</param>
        public void InsertFarmer(string lastName, string firstName, string phoneNumber)
        {
            string insertFarmer = "INSERT INTO dbo.tblFarmer VALUES ('" + lastName + "', '" + firstName + "', '" + phoneNumber + "');";
            ExecuteNonQuery(insertFarmer);
        }

        /// <summary>
        /// Add a Show to tblShow
        /// </summary>
        /// <param name="showLocation">The location of the dog show</param>
        /// <param name="showDate">The date the show took place</param>
        public void InsertShow(string showLocation, string showDate)
        {
            string insertShow = "INSERT INTO dbo.tblShow VALUES ('" + showLocation + "', '" + showDate + "');";
            ExecuteNonQuery(insertShow);
        }

        /// <summary>
        /// Add a Result to tblResult
        /// </summary>
        /// <param name="showID">ID of the show</param>
        /// <param name="dogID">ID of the dog</param>
        /// <param name="finishPlace">Podium placement of the dog</param>
        public void InsertResult(int showID, int dogID, int finishPlace)
        {
            string insertResult = "INSERT INTO dbo.tblResult VALUES ('" + showID + "', '" + dogID + "', '" + finishPlace + "');";
            ExecuteNonQuery(insertResult);
        }
 
        /// <summary>
        /// Drop a given table in the database, providing it exists.
        /// </summary>
        /// <param name="tableName">The table to drop</param>
        public void DropTable(string tableName)
        {
            string dropTable = "IF OBJECT_ID('dbo." + tableName + "', 'U') IS NOT NULL DROP TABLE dbo." + tableName + ";";
            ExecuteNonQuery(dropTable);
        }

        /// <summary>
        /// Create a table in the database
        /// </summary>
        /// <param name="createString">The string to execute</param>
        public void CreateTable(string createString)
        {
            ExecuteNonQuery(createString);
        }

        //--------------------------------------------------------
        // Insert Data
        //--------------------------------------------------------

        public void InsertSeedBreeds()
        {
            InsertBreed("Border Collie");
            InsertBreed("Huntaway");
        }

        public void InsertSeedFarmers()
        {
            InsertFarmer("Bob", "Mackensie", "4774756");
            InsertFarmer("Sally", "Clark", "4721534");
            InsertFarmer("Kim", "Fincher", "4797842");
        }

        public void InsertSeedDogs()
        {
            // name, breedID, ownerID
            InsertDog("Peg", 1, 1);
            InsertDog("Sam", 1, 2);
            InsertDog("Kip", 2, 2);
            InsertDog("Max", 1, 3);
        }

        public void InsertSeedShows()
        {
            InsertShow("Lawrence", "2014-02-01");
            InsertShow("Dunedin", "2014-03-17");
            InsertShow("Ranfurly", "2014-04-01");
        }

        public void InsertSeedResults()
        {
            // showID, dogID, finishPlace
            InsertResult(1, 1, 1);
            InsertResult(1, 2, 2);
            InsertResult(1, 3, 3);
            InsertResult(1, 4, 6);

            InsertResult(2, 1, 4);
            InsertResult(2, 2, 3);
            InsertResult(2, 3, 1);
            InsertResult(2, 4, 2);

            InsertResult(3, 1, 1);
            InsertResult(3, 2, 12);
            InsertResult(3, 3, 8);
        }
    }
}