using Microsoft.Data.Sqlite;
using SQLitePCL;
using StoresLand_API;
using System;

namespace StoresPlace_Front.Sqlite.Regions
{
    public class clsRegionArDataLite
    {
        private static string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "RegionsAr.db");

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

            if (TableExists("RegionsAr"))
                return;

            try
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS RegionsAr (
                        RegionNameAr TEXT NOT NULL)";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);

            }

        }
        public static void SaveRegionsArAsync(List<string> RegionAr)
        {

            InitializeDatabase();


            try
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    foreach (var item in RegionAr)
                    {
                        using (SqliteCommand command = connection.CreateCommand())
                        {
                            command.CommandText = @"INSERT OR REPLACE INTO RegionsAr (RegionNameAr) 
                                                    VALUES ($RegionNameAr)";

                            // Add the parameter for the current item in the loop
                            command.Parameters.AddWithValue("$RegionNameAr", item);

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
        public static bool isRegionsArSaved()
        {
            bool isFound = false;
            try
            {

                using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT RegionNameAr FROM RegionsAr LIMIT 1";

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

        public static List<string> LoadRegionsArAsync()
        {
            List<string> RegionAr = new List<string>();

            try
            {

                using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT RegionNameAr FROM RegionsAr";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RegionAr.Add(reader.GetString(0));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return RegionAr;
        }

    }
}
