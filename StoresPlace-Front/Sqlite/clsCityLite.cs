
using Microsoft.Data.Sqlite;
using StoresLand_API;
using StoresLand_API.CitiesServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoresPlace_Front.Sqlite;

public class clsCityLite
{

  

    public static bool TableExists(string tableName)
    {
        bool IsExists = false;

        using (SqliteConnection connection = new SqliteConnection(clsSqliteString.connectionString))
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

        if (TableExists("Cities"))
            return;

        try
        {
            using (SqliteConnection connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Cities (
                            CityID INTEGER PRIMARY KEY AUTOINCREMENT,
                            CityNameAr TEXT NOT NULL,
                            CityNameEn TEXT NOT NULL,
                            RegionID INTEGER,
                            FOREIGN KEY (RegionID) REFERENCES Regions(RegionID) ON DELETE SET NULL)";
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            clsUtil.WriteExceptionError(ex.Message);

        }

    }

    public static async Task SaveCitiesAsync(List<CityDTO> cities)
    {

        InitializeDatabase();

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                await connection.OpenAsync();

                foreach (var city in cities)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                        INSERT OR REPLACE INTO Cities (CityNameAr, CityNameEn, RegionID)
                        VALUES ($CityNameAr, $CityNameEn, $RegionID)";


                        command.Parameters.AddWithValue("$CityNameAr", city.CityNameAr);
                        command.Parameters.AddWithValue("$CityNameEn", city.CityNameEn);
                        command.Parameters.AddWithValue("$RegionID", city.RegionID.HasValue ? (object)city.RegionID.Value : DBNull.Value);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            clsUtil.WriteExceptionError(ex.Message);
        }
    }

    public static void SaveCities(List<CityDTO> cities)
    {

        InitializeDatabase();

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                connection.Open();

                foreach (var city in cities)
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                        INSERT OR REPLACE INTO Cities (CityNameAr, CityNameEn, RegionID)
                        VALUES ($CityNameAr, $CityNameEn, $RegionID)";


                        command.Parameters.AddWithValue("$CityNameAr", city.CityNameAr);
                        command.Parameters.AddWithValue("$CityNameEn", city.CityNameEn);
                        command.Parameters.AddWithValue("$RegionID", city.RegionID.HasValue ? (object)city.RegionID.Value : DBNull.Value);

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
    public static bool IsCitiesSaved()
    {
        bool isFound = false;

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT CityID FROM Cities LIMIT 1";

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

    public static async Task<bool> InsertCitiesAsync(List<CityDTO> cities)
    {
        using (var connection = new SqliteConnection(clsSqliteString.connectionString))
        {
            await connection.OpenAsync();

            var transaction = connection.BeginTransaction();
            try
            {
                string query = "INSERT INTO Cities (CityNameAr, CityNameEn, RegionID) VALUES (@CityNameAr, @CityNameEn, @RegionID)";

                foreach (var city in cities)
                {
                    using (var command = new SqliteCommand(query, connection, transaction))
                    {

                        command.Parameters.AddWithValue("@CityNameAr", city.CityNameAr ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CityNameEn", city.CityNameEn ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@RegionID", city.RegionID ?? (object)DBNull.Value);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                clsUtil.WriteExceptionError(ex.Message);

                return false;
            }
        }

        return false;
    }

    public static async Task<CityDTO> GetCity(int cityID)
    {
        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Cities WHERE CityID = @CityID";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityID", cityID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new CityDTO(
                                reader.GetInt32(reader.GetOrdinal("CityID")),
                                reader.GetString(reader.GetOrdinal("CityNameAr")),
                                reader.GetString(reader.GetOrdinal("CityNameEn")),
                                reader.GetInt32(reader.GetOrdinal("RegionID"))
                            );
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            clsUtil.WriteExceptionError(ex.Message);
        }

        return null;
    }

    public static async Task<List<CityDTO>> GetAllCities()
    {
        var cities = new List<CityDTO>();

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cities";
                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            cities.Add(new CityDTO(
                                reader.GetInt32(reader.GetOrdinal("CityID")),
                                reader.GetString(reader.GetOrdinal("CityNameAr")),
                                reader.GetString(reader.GetOrdinal("CityNameEn")),
                                reader.IsDBNull(reader.GetOrdinal("RegionID")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("RegionID"))
                            ));
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            clsUtil.WriteExceptionError(ex.Message);
        }
        return cities;

    }

    public static async Task<List<CityDTO>> GetCitiesByRegion(int regionID)
    {
        var cities = new List<CityDTO>();

        try
        {

            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cities WHERE RegionID = @RegionID";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RegionID", regionID);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            cities.Add(new CityDTO(
                                reader.GetInt32(reader.GetOrdinal("CityID")),
                                reader.GetString(reader.GetOrdinal("CityNameAr")),
                                reader.GetString(reader.GetOrdinal("CityNameEn")),
                                reader.IsDBNull(reader.GetOrdinal("RegionID")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("RegionID"))
                            ));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            clsUtil.WriteExceptionError(ex.Message);
        }

        return cities;

    }

    public static async Task<List<string>> GetAllCitiesByRegionNameEn(string RegionNameEn)
    {
        var cities = new List<string>();

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    SELECT City.CityNameEn
                    FROM Cities AS City
                    JOIN Regions AS R ON City.RegionID = R.RegionID
                    WHERE R.RegionNameEn = @RegionNameEn";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RegionNameEn", RegionNameEn);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cities.Add(reader.GetString(reader.GetOrdinal("CityNameEn")));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // Log appropriately in your application
        }

        return cities;
    }

    public static async Task<List<string>> GetAllCitiesByRegionNameAr(string RegionNameAr)
    {
        var cities = new List<string>();

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    SELECT City.CityNameAr
                    FROM Cities AS City
                    JOIN Regions AS R ON City.RegionID = R.RegionID
                    WHERE R.RegionNameAr = @RegionNameAr";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RegionNameAr", RegionNameAr);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            cities.Add(reader.GetString(reader.GetOrdinal("CityNameAr")));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // Log appropriately in your application
        }

        return cities;
    }

    public static async Task<string> GetCityNameEnByDistrictsID(int? DistrictsID)
    {
        if (!DistrictsID.HasValue)
        {
            return null;
        }

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    SELECT City.CityNameEn
                    FROM Districts AS D
                    JOIN Cities AS City ON D.CityID = City.CityID
                    WHERE D.DistrictID = @DistrictsID";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DistrictsID", DistrictsID.Value);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return reader.GetString(reader.GetOrdinal("CityNameEn"));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null; 
    }

    public static async Task<string> GetCityNameArByDistrictsID(int? DistrictsID)
    {
        if (!DistrictsID.HasValue)
        {
            return null; 
        }

        try
        {
            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    SELECT City.CityNameAr
                    FROM Districts AS D
                    JOIN Cities AS City ON D.CityID = City.CityID
                    WHERE D.DistrictID = @DistrictsID";

                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DistrictsID", DistrictsID.Value);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return reader.GetString(reader.GetOrdinal("CityNameAr"));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null; 
    }
}

