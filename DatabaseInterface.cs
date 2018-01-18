using System;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    public class DatabaseInterface
    {
        private string _connectionString;
        private SqliteConnection _connection;


        public DatabaseInterface()
        {
            // Replace {you} with the correct value
            _connectionString = $"Data Source=/Users/knorris/workspace/csharp/group/EscapeRoom/escaperoom.db";

            
            _connection = new SqliteConnection(_connectionString);
        }

        //creates the Student Table
        public void CheckStudentTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the student table to see if table is created
                dbcmd.CommandText = $"SELECT `StudentId` FROM `Student`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Student` (
                            `StudentId` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `FirstName` TEXT NOT NULL,
                            `LastName` TEXT NOT NULL
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }
        public void CheckInstructorTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the instructor table to see if table is created
                dbcmd.CommandText = $"SELECT `InstructorId` FROM `Instructor`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Instructor` (
                            `InstructorId` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `FirstName` TEXT NOT NULL,
                            `LastName` TEXT NOT NULL
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }
        public void CheckTechTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the tech table to see if table is created
                dbcmd.CommandText = $"SELECT `TechId` FROM `Tech`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Tech` (
                            `TechId` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name` TEXT NOT NULL
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }
        public void CheckCohortTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the cohort table to see if table is created
                dbcmd.CommandText = $"SELECT `CohortId` FROM `Cohort`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `Cohort` (
                            `CohortId` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `Name` TEXT NOT NULL,
                            `TechId` INTEGER,
                            FOREIGN KEY(`TechId`) REFERENCES `Tech`(`TechId`)
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }
        public void CheckStudentCohortTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the student/cohort table to see if table is created
                dbcmd.CommandText = $"SELECT `StudentCohortId` FROM `StudentCohort`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `StudentCohort` (
                            `StudentCohortId` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `StudentId` INTEGER,
                            `CohortId` INTEGER,
                            FOREIGN KEY(`StudentId`) REFERENCES `Student`(`StudentId`),
                            FOREIGN KEY(`CohortId`) REFERENCES `Cohort`(`CohortId`)
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }
        public void CheckInstructorCohortTable ()
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query the instructor/cohort table to see if table is created
                dbcmd.CommandText = $"SELECT `InstructorCohortId` FROM `InstructorCohort`";

                try
                {
                    // Try to run the query. If it throws an exception, create the table
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        dbcmd.CommandText = $@"CREATE TABLE `InstructorCohort` (
                            `InstructorCohortId` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `InstructorId` INTEGER,
                            `CohortId` INTEGER,
                            FOREIGN KEY(`InstructorId`) REFERENCES `Instructor`(`InstructorId`),
                            FOREIGN KEY(`CohortId`) REFERENCES `Cohort`(`CohortId`)
                        )";

                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Table already exists. Ignoring");
                        }
                    }
                }
                _connection.Close();
            }
        }

        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader())
                {
                    handler (dataReader);
                }

                dbcmd.Dispose ();
            }
        }

        public void Update(string command)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                dbcmd.ExecuteNonQuery ();
                dbcmd.Dispose ();
            }
        }

        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                dbcmd.ExecuteNonQuery ();

                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbcmd.Dispose ();
            }

            //returns id of the data entered
            return insertedItemId;
        }

        internal void Query(string v, object p)
        {
            throw new NotImplementedException();
        }        

    }
}