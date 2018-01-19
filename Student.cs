using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    public class Student
    {
        private int _studentId;
        private DatabaseInterface _db = new DatabaseInterface();
        private List<string> _studentList = new List<string>();



        public int GetStudentId(string fullname){

            string firstName = fullname.Split(" ")[0];
            string LastName = fullname.Split(" ")[1];

            _db.Query($"SELECT StudentId FROM Student WHERE FirstName = '{firstName}' AND LastName = '{LastName}'",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        _studentId = reader.GetInt32(0);

                    }
                }
            );

            return _studentId;

        }

        public List<string> GetStudentList(string cohortName){

            _studentList.Clear();

            string iFullName;

            _db.Query($@"SELECT s.FirstName, s.LastName 
                FROM Student s
                LEFT JOIN StudentCohort iC
                ON s.StudentId = iC.StudentId
                LEFT JOIN Cohort c
                ON c.CohortId = iC.CohortId
                WHERE c.Name = '{cohortName}'",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        string first = reader[0].ToString();
                        string last = reader[1].ToString();
                        
                        iFullName = first + " " + last;

                        _studentList.Add(iFullName);

                    }
                }
            );


            return _studentList;

        }  



    }
}