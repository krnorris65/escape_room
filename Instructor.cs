using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    public class Instructor
    {
        private int _instructorId;
        private DatabaseInterface _db = new DatabaseInterface();

        private List<string> _instructorList = new List<string>();

        public int GetInstructorId(string fullname){

            string firstName = fullname.Split(" ")[0];
            string LastName = fullname.Split(" ")[1];

            _db.Query($"SELECT InstructorId FROM Instructor WHERE FirstName = '{firstName}' AND LastName = '{LastName}'",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        _instructorId = reader.GetInt32(0);

                    }
                }
            );

            return _instructorId;

        }        
        public List<string> GetInstructorList(string cohortName){

            string iFullName;

            _db.Query($@"SELECT i.FirstName, i.LastName 
                FROM Instructor i
                LEFT JOIN InstructorCohort iC
                LEFT JOIN Cohort c
                WHERE c.Name = '{cohortName}'",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        string first = reader[0].ToString();
                        string last = reader[1].ToString();
                        
                        iFullName = first + " " + last;

                        _instructorList.Add(iFullName);

                    }
                }
            );


            return _instructorList;

        }        
    }
}