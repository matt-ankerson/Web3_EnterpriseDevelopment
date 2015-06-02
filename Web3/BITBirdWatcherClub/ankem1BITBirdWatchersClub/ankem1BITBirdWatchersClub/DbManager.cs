// Author: Matthew Ankerson
// Date: 11 March 2015
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ankem1BITBirdWatchersClub
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

            bitdevConnection.Close();
        }

        /// <summary>
        /// Perform a SELECT query on the db and return a List of Members
        /// </summary>
        /// <param name="queryString">The query</param>
        public List<Member> ExecuteSelectQueryForMember(string queryString)
        {
            // Open a connection to the database
            Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bitdevConnection;
            cmd.CommandText = queryString;

            List<Member> result = new List<Member>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(new Member(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
            }

            bitdevConnection.Close();

            return result;
        }

        /// <summary>
        /// Perform a SELECT query on the db and return the first column as a List of integers
        /// </summary>
        /// <param name="queryString">The query</param>
        public List<int> ExecuteSelectQueryForKeys(string queryString)
        {
            // Open a connection to the database
            Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bitdevConnection;
            cmd.CommandText = queryString;

            List<int> result = new List<int>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(reader.GetInt32(0));
            }

            bitdevConnection.Close();

            return result;
        }

        /// <summary>
        /// Perform a SELECT query on the db and return a List of Birds
        /// </summary>
        /// <param name="queryString">The query</param>
        public List<Bird> ExecuteSelectQueryForBird(string queryString)
        {
            // Open a connection to the database
            Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bitdevConnection;
            cmd.CommandText = queryString;

            List<Bird> result = new List<Bird>();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(new Bird(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
            }

            bitdevConnection.Close();

            return result;
        }


        /// <summary>
        /// Perform a SELECT query on the db and return the results
        /// This method will only accept a query which returns a three column result set.
        /// </summary>
        /// <param name="queryString">The query</param>
        public Dictionary<int, string> ExecuteSelectQuery(string queryString)
        {
            // Open a connection to the database
            Connect();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bitdevConnection;
            cmd.CommandText = queryString;

            Dictionary<int, string> result = new Dictionary<int, string>();

            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(reader.GetInt32(0), reader.GetString(1) + " " + reader.GetString(2));
            }

            bitdevConnection.Close();

            return result;
        }

        /// <summary>
        /// Execute a non-select query on the database (ie. insert, update, delete)
        /// </summary>
        /// <param name="queryToExecute">The query</param>
        public void ExecuteNonQuery(string queryToExecute)
        {
            Connect();

            SqlCommand sExecute = new SqlCommand(queryToExecute, bitdevConnection);
            sExecute.ExecuteNonQuery();

            bitdevConnection.Close();
        }

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
    }
}