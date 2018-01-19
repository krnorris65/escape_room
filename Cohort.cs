using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    public class Cohort
    {
        private DatabaseInterface _db = new DatabaseInterface();
        private Dictionary<int, string> _cohortDictionary = new Dictionary<int, string>();
        private int _cohortId;
        private string _cohortTech;


        public Dictionary<int, string> GetCohort ()
        {
            _db.Query("SELECT CohortId, Name FROM Cohort",
                (SqliteDataReader reader) => {
                    _cohortDictionary.Clear();
                    while (reader.Read ())
                    {
                        int CohortId = reader.GetInt32(0);
                        string Name = reader[1].ToString();

                        _cohortDictionary.Add(CohortId, Name);

                    }
                }
            );

            return _cohortDictionary;
        }
        public int GetCohortId (string cohortName)
        {
            _db.Query($"SELECT CohortId FROM Cohort WHERE Name = '{cohortName}'",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        _cohortId = reader.GetInt32(0);

                    }
                }
            );

            return _cohortId;
        }
        public string GetCohortTech (string cohortName)
        {
            _cohortTech = "";
            _db.Query($@"SELECT t.Name 
                FROM Tech t
                LEFT JOIN Cohort c 
                ON c.TechId = t.TechId
                WHERE c.Name = '{cohortName}'
                ",
                (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        _cohortTech = reader[0].ToString();

                    }
                }
            );


            return _cohortTech;
        }
    }
}