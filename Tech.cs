using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EscapeRoom
{
    public class Tech
    {
        private DatabaseInterface _db = new DatabaseInterface();
        private Dictionary<int, string> _techDictionary = new Dictionary<int, string>();

        public Dictionary<int, string> GetTech ()
        {
            _db.Query("SELECT TechId, Name FROM Tech",
                (SqliteDataReader reader) => {
                    _techDictionary.Clear();
                    while (reader.Read ())
                    {
                        int TechId = reader.GetInt32(0);
                        string Name = reader[1].ToString();

                        _techDictionary.Add(TechId, Name);

                    }
                }
            );

            return _techDictionary;
        }
    }
}