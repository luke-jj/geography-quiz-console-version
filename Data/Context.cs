using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Sqlite;

using project_stub.Models;

namespace project_stub.Data {

    public class Context {
        public List<Country> countries { get; set; }

        public Context() {
            countries = new List<Country>();

            ReadFromDatabase();
        }

        public void SaveToDatabase() {
        }

        private void ReadFromDatabase() {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();

            connectionStringBuilder.DataSource = "assets/testo.db";

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString)) {
                string queryString = "SELECT * FROM countries";

                connection.Open();
                var selectCmd = connection.CreateCommand();
                selectCmd.CommandText = queryString;

                using (var reader = selectCmd.ExecuteReader()) {

                    // .Read() advances to the next row in the result set
                    while (reader.Read()) {
                        int id = int.Parse(reader.GetString(0));
                        string name = reader.GetString(1);
                        string alpha_2 = reader.GetString(2);
                        string alpha_3 = reader.GetString(3);
                        string capital = reader.GetString(4);
                        countries.Add(new Country(id, name, alpha_2, alpha_3, capital));
                    }
                }
            }
        }
    }
}
