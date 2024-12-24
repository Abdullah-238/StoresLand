using Microsoft.Data.Sqlite;
using StoresLand_API;
using StoresLand_API.CitiesServices;

namespace StoresPlace_Front.Sqlite.Cities
{
    public class clsCityArDataLite
    {
        //    private static string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "Cities.db");

        //    public static bool TableExists(string tableName)
        //    {
        //        bool IsExists = false;

        //        using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
        //        {
        //            connection.Open();

        //            using (SqliteCommand command = connection.CreateCommand())
        //            {
        //                command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=$tableName";
        //                command.Parameters.AddWithValue("$tableName", tableName);

        //                using (SqliteDataReader reader = command.ExecuteReader())
        //                    IsExists = reader.Read();
        //            }
        //        }

        //        return IsExists;
        //    }
        //    private static void InitializeDatabase()
        //    {

        //        if (TableExists("Cities"))
        //            return;

        //        try
        //        {
        //            using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
        //            {
        //                connection.Open();

        //                using (SqliteCommand command = connection.CreateCommand())
        //                {
        //                    command.CommandText = @"CREATE TABLE IF NOT EXISTS Cities (
        //                                            CityID INTEGER PRIMARY KEY AUTOINCREMENT,  
        //                                            CityNameAr TEXT,                          
        //                                            CityNameEn TEXT,                         
        //                                            RegionNameAr TEXT,
        //                                            RegionNameEn TEXT);";
        //                    command.ExecuteNonQuery();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            clsUtil.WriteExceptionError(ex);

        //        }

        //    }
        //    public static void SaveCitiesArAsync(List<CityDTO> Cities)
        //    {

        //        InitializeDatabase();

        //        try
        //        {
        //            using (SqliteConnection connection = new SqliteConnection($"Data Source={_dbPath}"))
        //            {
        //                connection.Open();

        //                foreach (var City in Cities)
        //                {
        //                    using (SqliteCommand command = connection.CreateCommand())
        //                    {
        //                        command.CommandText = @"INSERT OR REPLACE INTO Cities (CityID, CityNameAr, CityNameEn, RegionNameAr,RegionNameEn)
        //                                                VALUES ($CityID, $CityNameAr, $CityNameEn, $RegionNameAr,$RegionNameEn);";


        //                        command.Parameters.AddWithValue("$CityID", City.CityID);
        //                        command.Parameters.AddWithValue("$CityNameAr", City.CityNameAr);
        //                        command.Parameters.AddWithValue("$CityNameEn", City.CityNameEn);
        //                        command.Parameters.AddWithValue("$RegionNameAr", clsRegion.Find(City.RegionID).RegionNameAr);
        //                        command.Parameters.AddWithValue("$RegionNameEn", clsRegion.Find(City.RegionID).RegionNameEn);

        //                        command.ExecuteNonQuery();
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            clsUtil.WriteExceptionInLogFile(ex);

        //        }
        //    }
        //    public static bool isCitiesArSaved()
        //    {
        //        bool isFound = false;
        //        try
        //        {

        //            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
        //            {
        //                connection.Open();

        //                using (var command = connection.CreateCommand())
        //                {
        //                    command.CommandText = "SELECT CityID FROM Cities LIMIT 1";

        //                    using (var reader = command.ExecuteReader())
        //                    {
        //                        if (reader.HasRows)
        //                        {
        //                            isFound = true;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            clsUtil.WriteExceptionInLogFile(ex);
        //        }
        //        return isFound;
        //    }
        //    public static List<string> LoadCitiesArAsync(string RegionNameAr)
        //    {
        //        List<string> RegionAr = new List<string>();

        //        try
        //        {
        //            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
        //            {
        //                connection.Open();

        //                using (var command = connection.CreateCommand())
        //                {
        //                    command.CommandText = "SELECT CityNameAr FROM Cities where RegionNameAr = $RegionNameAr";

        //                    command.Parameters.AddWithValue("$RegionNameAr", RegionNameAr);


        //                    using (var reader = command.ExecuteReader())
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            RegionAr.Add(reader.GetString(0));
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            clsUtil.WriteExceptionInLogFile(ex);
        //        }
        //        return RegionAr;
        //    }
        //    public static List<string> LoadCitiesEnAsync(string RegionNameEn)
        //    {
        //        List<string> RegionAr = new List<string>();

        //        try
        //        {
        //            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
        //            {
        //                connection.Open();

        //                using (var command = connection.CreateCommand())
        //                {
        //                    command.CommandText = "SELECT CityNameEn FROM Cities where RegionNameEn = RegionNameEn";

        //                    command.Parameters.AddWithValue("RegionNameEn", RegionNameEn);


        //                    using (var reader = command.ExecuteReader())
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            RegionAr.Add(reader.GetString(0));
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            clsUtil.WriteExceptionInLogFile(ex);
        //        }
        //        return RegionAr;
        //    }

        //}
    }
}


