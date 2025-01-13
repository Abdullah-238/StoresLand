using Microsoft.Data.Sqlite;
using StoresLand_API;
using StoresLand_API.RegionsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresPlace_Front.Sqlite.Regions
{
    public class clsRegionLite
    {
  
     
        private static void InitializeDatabase()
        {
            if (TableExists("Regions"))
                return;

            try
            {
                using (SqliteConnection connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        // Create Regions table
                        command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Regions (
                            RegionID INTEGER PRIMARY KEY ,
                            Code TEXT NOT NULL,
                            RegionNameAr TEXT NOT NULL,
                            RegionNameEn TEXT NOT NULL)";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                // Replace with appropriate logging
            }
        }

        public static bool TableExists(string tableName = "Regions")
        {
            bool exists = false;
            using (SqliteConnection connection = new SqliteConnection(clsSqliteString.connectionString))
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=$tableName";
                    command.Parameters.AddWithValue("$tableName", tableName);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        exists = reader.Read();
                    }
                }
            }
            return exists;
        }

        public static async Task SaveRegionsAsync(List<RegionDTO> regions)
        {
            InitializeDatabase();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    foreach (var region in regions)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = @"
                        INSERT OR REPLACE INTO Regions (RegionID , Code, RegionNameAr, RegionNameEn)
                        VALUES ($RegionID, $Code, $RegionNameAr, $RegionNameEn)";

                            command.Parameters.AddWithValue("$RegionID", region.RegionID);
                            command.Parameters.AddWithValue("$Code", region.Code);
                            command.Parameters.AddWithValue("$RegionNameAr", region.RegionNameAr);
                            command.Parameters.AddWithValue("$RegionNameEn", region.RegionNameEn);

                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
        }

        public async static Task<List<RegionDTO>> ReadRegionsFromFile()
        {
            List<RegionDTO> regions = new List<RegionDTO>();

            using var stream = await FileSystem.OpenAppPackageFileAsync("Regions.txt");
            using var reader = new StreamReader(stream);

            var contents = reader.ReadToEnd();

            var lines = contents.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split('\t');

                if (parts.Length == 4)
                {
                    if (int.TryParse(parts[0], out int regionID))
                    {
                        string code = parts[1];
                        string regionNameAr = parts[2];
                        string regionNameEn = parts[3];

                        var regionDTO = new RegionDTO(regionID, code, regionNameAr, regionNameEn);

                        regions.Add(regionDTO);
                    }
                }
            }

            return regions;
        }
        public static void SaveRegions(List<RegionDTO> regions)
        {
            InitializeDatabase();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    foreach (var region in regions)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = @"
                        INSERT OR REPLACE INTO Regions (Code, RegionNameAr, RegionNameEn)
                        VALUES ($Code, $RegionNameAr, $RegionNameEn)";

                            command.Parameters.AddWithValue("$Code", region.Code);
                            command.Parameters.AddWithValue("$RegionNameAr", region.RegionNameAr);
                            command.Parameters.AddWithValue("$RegionNameEn", region.RegionNameEn);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
        }

        public static async Task<List<RegionDTO>> GetAllRegions()
        {
            var regions = new List<RegionDTO>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Regions";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                regions.Add(new RegionDTO(
                                    reader.GetInt32(reader.GetOrdinal("RegionID")),
                                    reader.GetString(reader.GetOrdinal("Code")),
                                    reader.GetString(reader.GetOrdinal("RegionNameAr")),
                                    reader.GetString(reader.GetOrdinal("RegionNameEn"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return regions;
        }

        public static bool IsRegionsSaved()
        {
            bool isFound = false;

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT RegionID FROM Regions LIMIT 1";

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
                clsUtil.WriteExceptionError(ex); // Log the exception
            }

            return isFound; // Returns true if any region is found, otherwise false
        }

        public static async Task<RegionDTO> GetRegionById(int regionID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Regions WHERE RegionID = @RegionID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RegionID", regionID);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new RegionDTO(
                                    reader.GetInt32(reader.GetOrdinal("RegionID")),
                                    reader.GetString(reader.GetOrdinal("Code")),
                                    reader.GetString(reader.GetOrdinal("RegionNameAr")),
                                    reader.GetString(reader.GetOrdinal("RegionNameEn"))
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
        //        clsUtil.WriteExceptionError(ex.Message);// Replace with appropriate logging
            }
            return null;
        }

        public static async Task<List<RegionDTO>> GetRegionsByCode(string code)
        {
            var regions = new List<RegionDTO>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Regions WHERE Code = @Code";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Code", code);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                regions.Add(new RegionDTO(
                                    reader.GetInt32(reader.GetOrdinal("RegionID")),
                                    reader.GetString(reader.GetOrdinal("Code")),
                                    reader.GetString(reader.GetOrdinal("RegionNameAr")),
                                    reader.GetString(reader.GetOrdinal("RegionNameEn"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
        //        clsUtil.WriteExceptionError(ex.Message);// Replace with appropriate logging
            }
            return regions;
        }

        public static async Task<string> GetRegionNameEnByDistrictsID(int? DistrictsID)
        {
            if (!DistrictsID.HasValue)
            {
                return null; // Return null if DistrictsID is null
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();  // Ensure connection is opened asynchronously

                    string query = @"
                SELECT Regions.RegionNameEn 
                FROM Districts 
                JOIN Cities ON Districts.CityID = Cities.CityID
                JOIN Regions ON Cities.RegionID = Regions.RegionID
                WHERE Districts.DistrictID = @DistrictsID";  // Using parameterized query

                    using (var command = new SqliteCommand(query, connection))
                    {
                        // Add the parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@DistrictsID", DistrictsID.Value);

                        using (var reader = await command.ExecuteReaderAsync())  // Execute asynchronously
                        {
                            if (await reader.ReadAsync())  // Asynchronously read
                            {
                                return reader.IsDBNull(reader.GetOrdinal("RegionNameEn"))
                                    ? null : reader.GetString(reader.GetOrdinal("RegionNameEn"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
        //        clsUtil.WriteExceptionError(ex.Message); // Consider replacing this with appropriate logging
            }

            return null;  // Return null if not found or exception occurs
        }

        public static async Task<string> GetRegionNameArByDistrictsID(int? DistrictsID)
        {
            if (!DistrictsID.HasValue)
            {
                return null; // Return null if DistrictsID is null
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();  // Ensure connection is opened asynchronously

                    string query = @"
                SELECT Regions.RegionNameAr 
                FROM Districts 
                JOIN Cities ON Districts.CityID = Cities.CityID
                JOIN Regions ON Cities.RegionID = Regions.RegionID
                WHERE Districts.DistrictID = @DistrictsID";  // Using parameterized query

                    using (var command = new SqliteCommand(query, connection))
                    {
                        // Add the parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@DistrictsID", DistrictsID.Value);

                        using (var reader = await command.ExecuteReaderAsync())  // Execute asynchronously
                        {
                            if (await reader.ReadAsync())  // Asynchronously read
                            {
                                return reader.IsDBNull(reader.GetOrdinal("RegionNameAr"))
                                    ? null : reader.GetString(reader.GetOrdinal("RegionNameAr"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return null;  // Return null if not found or exception occurs
        }

        public static async Task<string> GetRegionNameArByCityID(int? CityID)
        {
            if (!CityID.HasValue)
            {
                return null; 
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();  

                    string query = @"
            SELECT Regions.RegionNameAr 
            FROM Cities 
            JOIN Regions ON Cities.RegionID = Regions.RegionID
            WHERE Cities.CityID = @CityID";  

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityID", CityID.Value);

                        using (var reader = await command.ExecuteReaderAsync())  
                        {
                            if (await reader.ReadAsync())  
                            {
                                return reader.IsDBNull(reader.GetOrdinal("RegionNameAr"))
                                    ? null : reader.GetString(reader.GetOrdinal("RegionNameAr"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Consider replacing this with appropriate logging
            }

            return null;  // Return null if not found or exception occurs
        }

        public static async Task<string> GetRegionNameEnByCityID(int? CityID)
        {
            if (!CityID.HasValue)
            {
                return null; 
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();  

                    string query = @"
            SELECT Regions.RegionNameEn 
            FROM Cities 
            JOIN Regions ON Cities.RegionID = Regions.RegionID
            WHERE Cities.CityID = @CityID"; 

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityID", CityID.Value);

                        using (var reader = await command.ExecuteReaderAsync())  
                        {
                            if (await reader.ReadAsync())  
                            {
                                return reader.IsDBNull(reader.GetOrdinal("RegionNameEn")) ? null : reader.GetString(reader.GetOrdinal("RegionNameEn"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); 
            }

            return null;  
        }

        public static async Task<string> GetRegionNameArByRegionID(int? RegionID)
        {
            if (!RegionID.HasValue)
            {
                return null; // Return null if RegionID is null
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT RegionNameAr FROM Regions WHERE RegionID = @RegionID";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RegionID", RegionID.Value);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return reader.GetString(reader.GetOrdinal("RegionNameAr"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
        //        clsUtil.WriteExceptionError(ex.Message);// Replace with appropriate logging
            }

            return null; // Return null if not found
        }

        public static async Task<string> GetRegionNameEnByRegionID(int? RegionID)
        {
            if (!RegionID.HasValue)
            {
                return null;
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();  

                    string query = "SELECT RegionNameEn FROM Regions WHERE RegionID = @RegionID"; 

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RegionID", RegionID.Value);

                        using (var reader = await command.ExecuteReaderAsync())  
                        {
                            if (await reader.ReadAsync())  
                            {
                                return reader.IsDBNull(reader.GetOrdinal("RegionNameEn"))
                                    ? null : reader.GetString(reader.GetOrdinal("RegionNameEn"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
        //        clsUtil.WriteExceptionError(ex.Message); 
            }

            return null;  
        }

        public static async Task<List<string>> GetAllRegionsByNameEn()
        {
            var regions = new List<string>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT RegionNameEn FROM Regions";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                regions.Add(reader.GetString(reader.GetOrdinal("RegionNameEn")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               clsUtil.WriteExceptionError(ex);
            }

            return regions;
        }

        public static async Task<List<string>> GetAllRegionsByNameAr()
        {
            var regions = new List<string>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT RegionNameAr FROM Regions";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                regions.Add(reader.GetString(reader.GetOrdinal("RegionNameAr")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return regions;
        }
    }
}



