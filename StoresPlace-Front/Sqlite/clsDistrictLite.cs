using Microsoft.Data.Sqlite;
using StoresLand_API;
using StoresLand_API.DistrictServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoresPlace_Front.Sqlite
{
    class clsDistrictLite
    {


        public static string ReadAssetFile(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = @"C:\Users\good1\source\repos\StoresLand\StoresPlace-Front\Resources\Raw\Districts.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


        public async static Task<List<DistrictDTO>> ReadDistrictsFromFile()
        {
            List<DistrictDTO> districts = new List<DistrictDTO>();


            using var stream = await FileSystem.OpenAppPackageFileAsync("Districts.txt");
            using var reader = new StreamReader(stream);

            var contents = reader.ReadToEnd();

            var lines = contents.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split('\t');

                if (parts.Length == 4)
                {

                    if (int.TryParse(parts[0], out int districtID) &&
                        int.TryParse(parts[1], out int cityID))
                    {
                        string districtNameAr = parts[2];
                        string districtNameEn = parts[3];

                        var districtDTO = new DistrictDTO(districtID, cityID, districtNameAr, districtNameEn);

                        districts.Add(districtDTO);
                    }
                }
            }

            return districts;
        }



        private static void InitializeDatabase()
        {
            if (TableExists("Districts"))
                return;

            try
            {
                using (SqliteConnection connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Districts (
                            DistrictID INTEGER PRIMARY KEY AUTOINCREMENT,
                            CityID INTEGER,
                            DistrictsNameAr TEXT NOT NULL,
                            DistrictsNameEn TEXT NOT NULL)";

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
        }

        private static bool TableExists(string tableName)
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

        public static async Task SaveDistrictsAsync(List<DistrictDTO> districts)
        {
            InitializeDatabase();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    try
                    {
                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                foreach (var district in districts)
                                {
                                    using (var command = connection.CreateCommand())
                                    {
                                        command.CommandText = @"
                                    INSERT OR REPLACE INTO Districts (CityID, DistrictsNameAr, DistrictsNameEn)
                                    VALUES ($CityID, $DistrictsNameAr, $DistrictsNameEn)";

                                        command.Parameters.AddWithValue("$CityID", district.CityID.HasValue ? (object)district.CityID.Value : DBNull.Value);
                                        command.Parameters.AddWithValue("$DistrictsNameAr", district.DistrictsNameAr);
                                        command.Parameters.AddWithValue("$DistrictsNameEn", district.DistrictsNameEn);

                                        await command.ExecuteNonQueryAsync();
                                    }
                                }

                                // Commit the transaction after all inserts are completed
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                // Rollback transaction if an error occurs
                                transaction.Rollback();
                                clsUtil.WriteExceptionError(ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsUtil.WriteExceptionError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
        }


        public static void SaveDistricts(List<DistrictDTO> districts)
        {
            InitializeDatabase();

            using (var connection = new SqliteConnection(clsSqliteString.connectionString))
            {

                connection.Open();

                try
                {
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {

                            foreach (var district in districts)
                            {
                                using (var command = connection.CreateCommand())
                                {
                                    command.CommandText = @"
                            INSERT INTO Districts (DistrictID,CityID, DistrictsNameAr, DistrictsNameEn)
                            VALUES ($DistrictID, $CityID, $DistrictsNameAr, $DistrictsNameEn)";

                                    command.Parameters.AddWithValue("$DistrictID", district.DistrictsID);
                                    command.Parameters.AddWithValue("$CityID", district.CityID);
                                    command.Parameters.AddWithValue("$DistrictsNameAr", district.DistrictsNameAr);
                                    command.Parameters.AddWithValue("$DistrictsNameEn", district.DistrictsNameEn);

                                    command.ExecuteNonQuery();
                                }
                                transaction.Commit();

                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();

                            clsUtil.WriteExceptionError(ex);

                        }
                    }
                }
                catch (Exception ex)
                {
                    clsUtil.WriteExceptionError(ex);

                }
            }
        }


        //public static void SaveDistricts(List<DistrictDTO> districts)
        //{
        //    InitializeDatabase();

        //    using (var connection = new SqliteConnection(clsSqliteString.connectionString))
        //    {
        //        connection.Open();

        //        try
        //        {
        //            using (var transaction = connection.BeginTransaction())
        //            {
        //                try
        //                {
        //                    foreach (var district in districts)
        //                    {
        //                        using (var command = connection.CreateCommand())
        //                        {
        //                            command.CommandText = "SELECT COUNT(1) FROM Cities WHERE CityID = $CityID";
        //                            command.Parameters.AddWithValue("$CityID", district.CityID);

        //                            var cityExists = (long)command.ExecuteScalar() > 0;

        //                            if (!cityExists)
        //                            {
        //                                Console.WriteLine($"CityID {district.CityID} does not exist in Cities table, skipping district.");
        //                                continue; // Skip district if CityID is invalid
        //                            }

        //                            // Insert the district if CityID exists
        //                            using (var districtCommand = connection.CreateCommand())
        //                            {
        //                                districtCommand.CommandText = @"
        //                            INSERT OR REPLACE INTO Districts (CityID, DistrictsNameAr, DistrictsNameEn)
        //                            VALUES ($CityID, $DistrictsNameAr, $DistrictsNameEn)";
        //                                districtCommand.Parameters.AddWithValue("$CityID", district.CityID);
        //                                districtCommand.Parameters.AddWithValue("$DistrictsNameAr", district.DistrictsNameAr);
        //                                districtCommand.Parameters.AddWithValue("$DistrictsNameEn", district.DistrictsNameEn);

        //                                districtCommand.ExecuteNonQuery();
        //                            }
        //                        }
        //                    }

        //                    transaction.Commit();
        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.Rollback();
        //                    Console.WriteLine($"Error during insert: {ex.Message}");
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Error opening connection or starting transaction: {ex.Message}");
        //        }
        //    }
        //}

        public static async Task<List<DistrictDTO>> GetAllDistricts()
        {
            var districts = new List<DistrictDTO>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Districts";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                districts.Add(new DistrictDTO(
                                    reader.GetInt32(reader.GetOrdinal("DistrictID")),
                                    reader.IsDBNull(reader.GetOrdinal("CityID")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("CityID")),
                                    reader.GetString(reader.GetOrdinal("DistrictsNameAr")),
                                    reader.GetString(reader.GetOrdinal("DistrictsNameEn"))
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
            return districts;
        }

        public static async Task<DistrictDTO> GetDistrictById(int districtID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Districts WHERE DistrictID = @DistrictID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DistrictID", districtID);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new DistrictDTO(
                                    reader.GetInt32(reader.GetOrdinal("DistrictID")),
                                    reader.IsDBNull(reader.GetOrdinal("CityID")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("CityID")),
                                    reader.GetString(reader.GetOrdinal("DistrictsNameAr")),
                                    reader.GetString(reader.GetOrdinal("DistrictsNameEn"))
                                );
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

        public static async Task<List<DistrictDTO>> GetDistrictsByCityId(int cityID)
        {
            var districts = new List<DistrictDTO>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Districts WHERE CityID = @CityID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityID", cityID);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                districts.Add(new DistrictDTO(
                                    reader.GetInt32(reader.GetOrdinal("DistrictID")),
                                    reader.IsDBNull(reader.GetOrdinal("CityID")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("CityID")),
                                    reader.GetString(reader.GetOrdinal("DistrictsNameAr")),
                                    reader.GetString(reader.GetOrdinal("DistrictsNameEn"))
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
            return districts;
        }

        public static async Task<string> GetDistrictsNameEnByDistrictsID(int? DistrictsID)
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

                    string query = "SELECT DistrictsNameEn FROM Districts WHERE DistrictID = @DistrictID";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DistrictID", DistrictsID.Value);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return reader.GetString(reader.GetOrdinal("DistrictsNameEn"));
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

        public static async Task<string> GetDistrictsNameArByDistrictsID(int? DistrictsID)
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

                    string query = "SELECT DistrictsNameAr FROM Districts WHERE DistrictID = @DistrictID";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DistrictID", DistrictsID.Value);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return reader.GetString(reader.GetOrdinal("DistrictsNameAr"));
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

        public static async Task<int?> GetDistrictsIDByDistrictNameEn(string DistrictNameEn)
        {
            if (string.IsNullOrEmpty(DistrictNameEn))
            {
                return null; // Return null if the district name is null or empty
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT DistrictID FROM Districts WHERE DistrictsNameEn = @DistrictNameEn";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DistrictNameEn", DistrictNameEn);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return reader.GetInt32(reader.GetOrdinal("DistrictID"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return null; // Return null if not found
        }

        public static async Task<int?> GetDistrictsIDByDistrictNameAr(string DistrictNameAr)
        {
            if (string.IsNullOrEmpty(DistrictNameAr))
            {
                return null; // Return null if the district name is null or empty
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT DistrictID FROM Districts WHERE DistrictsNameAr = @DistrictNameAr";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DistrictNameAr", DistrictNameAr);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return reader.GetInt32(reader.GetOrdinal("DistrictID"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return null; // Return null if not found
        }

        public static async Task<List<string>> GetAllDistrictByCityNameEn(string CityNameEn)
        {
            var districts = new List<string>();

            if (string.IsNullOrEmpty(CityNameEn))
            {
                return districts; // Return an empty list if the city name is null or empty
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT Districts.DistrictsNameEn FROM Districts " +
                                   "JOIN Cities ON Districts.CityID = Cities.CityID " +
                                   "WHERE Cities.CityNameEn = @CityNameEn";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityNameEn", CityNameEn);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                districts.Add(reader.GetString(reader.GetOrdinal("DistrictsNameEn")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return districts;
        }

        public static async Task<List<string>> GetAllDistrictByCityNameAr(string CityNameAr)
        {
            var districts = new List<string>();

            if (string.IsNullOrEmpty(CityNameAr))
            {
                return districts; // Return an empty list if the city name is null or empty
            }

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT Districts.DistrictsNameAr FROM Districts " +
                                   "JOIN Cities ON Districts.CityID = Cities.CityID " +
                                   "WHERE Cities.CityNameAr = @CityNameAr";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityNameAr", CityNameAr);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                districts.Add(reader.GetString(reader.GetOrdinal("DistrictsNameAr")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return districts;
        }

        public static bool IsDistrictsSaved()
        {
            bool isFound = false;

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT DistrictID FROM Districts LIMIT 1";

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
                clsUtil.WriteExceptionError(ex); 
            }

            return isFound; 
        }

    }

}
