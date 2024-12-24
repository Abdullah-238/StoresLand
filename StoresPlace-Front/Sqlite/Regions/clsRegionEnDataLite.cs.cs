using Microsoft.Data.Sqlite;
using StoresLand_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresPlace_Front.Sqlite.Regions
{
    public class clsRegionEnDataLite
    {
        private static string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "RegionsEn.db");

        public static bool TableExists(string tableName)
        {
            bool IsExists = false;

            using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=$tableName";
                    command.Parameters.AddWithValue("$tableName", tableName);

                    using (SqliteDataReader reader = command.ExecuteReader())
                        IsExists = reader.Read();
                }
            }

            return IsExists;
        }
        private static void InitializeDatabase()
        {

            if (TableExists("RegionsEn"))
                return;

            try
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS RegionsEn (
                        RegionNameEn TEXT NOT NULL)";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);

            }

        }
        public static void SaveRegionsEnAsync(List<string> RegionEn)
        {

            InitializeDatabase();


            try
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    foreach (var item in RegionEn)
                    {
                        using (SqliteCommand command = connection.CreateCommand())
                        {
                            command.CommandText = @"INSERT OR REPLACE INTO RegionsEn (RegionNameEn) 
                                                    VALUES ($RegionNameEn)";

                            // Add the parameter for the current item in the loop
                            command.Parameters.AddWithValue("$RegionNameEn", item);

                            // Execute the command to insert or replace
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);

            }
        }
        public static bool isRegionsEnSaved()
        {
            bool isFound = false;
            try
            {

                using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT RegionNameEn FROM RegionsEn LIMIT 1";

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return isFound;
        }
        public static List<string> LoadRegionsEnAsync()
        {
            List<string> RegionEn = new List<string>();

            try
            {

                using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT RegionNameEn FROM RegionsEn";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RegionEn.Add(reader.GetString(0));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return RegionEn;
        }

    }
}
