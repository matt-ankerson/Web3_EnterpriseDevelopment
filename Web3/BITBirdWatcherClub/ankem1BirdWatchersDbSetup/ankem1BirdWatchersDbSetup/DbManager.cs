// Author: Matthew Ankerson
// Date: 11 March 2015
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ankem1BirdWatchersDbSetup
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
        public void PopulateDatabase()
        {
            CreateTables();

            // Call all InsertSeedData methods to insert all the data that we need
            InsertSeedBirds();
            InsertSeedMembers();
            InsertSeedBirdMembers();
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
        public void CreateTables()
        {
            Connect();

            // Clean out the database
            DropTable("tblBirdMember");
            DropTable("tblBird");
            DropTable("tblMember");

            // tblBird
            CreateTable("CREATE TABLE tblBird (BirdID INT IDENTITY, MaoriName VARCHAR(30) NOT NULL, EnglishName VARCHAR(30) NOT NULL, ScientificName VARCHAR(30) NOT NULL, " +
                        "PRIMARY KEY (BirdID))");
            // tblMember
            CreateTable("CREATE TABLE tblMember (MemberID INT IDENTITY, LastName VARCHAR(30) NOT NULL, FirstName VARCHAR(30) NOT NULL, Suburb VARCHAR(30) NOT NULL, " +
                        "PRIMARY KEY (MemberID))");
            // tblBirdMember
            CreateTable("CREATE TABLE tblBirdMember (BirdID INT NOT NULL, MemberID INT NOT NULL, " + 
                        "PRIMARY KEY (BirdID, MemberID), " +
                        "FOREIGN KEY (BirdID) REFERENCES tblBird(BirdID) ON UPDATE CASCADE ON DELETE CASCADE, " +
                        "FOREIGN KEY (MemberID) REFERENCES tblMember(MemberID) ON UPDATE CASCADE ON DELETE CASCADE)");
        }

        //-------------------------------------------------------------------
        // Code the Insert methods for inserting all data into each table
        //-------------------------------------------------------------------

        /// <summary>
        /// Add a Bird to tblBird
        /// </summary>
        /// <param name="maoriName">The Maori name of the bird</param>
        /// <param name="englishName">The English name of the bird</param>
        /// <param name="scientificName">The scientific name of the bird</param>
        public void InsertBird(string maoriName, string englishName, string scientificName)
        {
            string insertBird = "INSERT INTO dbo.tblBird VALUES ('" + maoriName + "', '" + englishName + "', '" + scientificName + "');";
            ExecuteNonQuery(insertBird);
        }

        /// <summary>
        /// Add a Member to tblMember
        /// </summary>
        /// <param name="firstName">The Member's first name</param>
        /// <param name="lastName">The Member's last name</param>
        /// <param name="suburb">The Member's suburb</param>
        public void InsertMember(string firstName, string lastName, string suburb)
        {
            string insertMember = "INSERT INTO dbo.tblMember VALUES ('" + lastName + "', '" + firstName + "', '" + suburb + "');";
            ExecuteNonQuery(insertMember);
        }

        /// <summary>
        /// Make an Insert into the intermediary table tblBirdMember
        /// </summary>
        /// <param name="BirdID">The Bird</param>
        /// <param name="MemberID">The Member</param>
        public void InsertBirdMember(int BirdID, int MemberID)
        {
            string insertBirdMember = "INSERT INTO dbo.tblBirdMember VALUES ('" + BirdID + "', '" + MemberID + "');";
            ExecuteNonQuery(insertBirdMember);
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

        public void InsertSeedBirds()
        {
            InsertBird("Kea", "Mountain Parrot", "Nestor notabilis");
            InsertBird("Kereru", "New Zealand Wood Pigeon", "Hemiphaga novaeseelandiae");
            InsertBird("Korimako", "Bell bird", "Anthornis melanura");
            InsertBird("Piwakawaka", "Fantail", "Rhipidura fulginosa");
            InsertBird("Tauhou", "Silvereye", "Zosterops lateralis");
            InsertBird("Toroa", "Royal Albatross", "Diomedea epomophora");
            InsertBird("Tui", "Parson Bird", "Prosthemadera novaeseelandiae");
            InsertBird("Wani", "Black Swan", "Cygnus atratus");
        }

        public void InsertSeedMembers()
        {
            InsertMember("McCormack", "Howard", "Pine Hill");
            InsertMember("Kerford", "Claudia", "Dunedin North");
            InsertMember("Curro", "Benita", "St. Kilda");
            InsertMember("Felsch", "Eva", "Roslyn");
            InsertMember("Vandine", "Erik", "Opoho");
            InsertMember("Moroney", "Louisa", "Ravensbourne");
            InsertMember("Loh", "Jessie", "Waverly");
            InsertMember("Stanford", "Ngaio", "Opoho");
            InsertMember("Mills", "Elva", "Roslyn");
            InsertMember("Woodford", "Sacha", "St. Kilda");
        }

        public void InsertSeedBirdMembers()
        {
            InsertBirdMember(1, 2);
            InsertBirdMember(1, 3);
            InsertBirdMember(1, 7);
            InsertBirdMember(2, 5);
            InsertBirdMember(4, 9);
            InsertBirdMember(8, 5);
            InsertBirdMember(5, 10);
            InsertBirdMember(6, 9);
            InsertBirdMember(4, 7);
            InsertBirdMember(3, 2);
            InsertBirdMember(5, 8);
            InsertBirdMember(6, 7);
            InsertBirdMember(4, 10);
            InsertBirdMember(8, 1);
            InsertBirdMember(2, 4);
            InsertBirdMember(3, 6);
        }
    }
}
