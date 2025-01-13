using Microsoft.Data.Sqlite;
using StoresLand_API;
using StoresLand_API.SavedStoresServices;
using StoresLand_API.Stores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresPlace_Front.Sqlite
{
    public class clsSavedStoreLite
    {
        public static void InitializeDatabase()
        {
            if (TableExists("StoreDetails"))
                return;

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS StoreDetails (
                    StoreID INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    RegionName TEXT,
                    CityName TEXT,
                    DistrictsName TEXT,
                    CommercialNumber TEXT,
                    Website TEXT,
                    Address TEXT,
                    CategoryName TEXT,
                    TypeName TEXT,
                    Rating INTEGER,
                    NumberOfRates REAL,
                    StoreStatus TEXT,
                    NumbersOfClick REAL,
                    Photo TEXT,
                    PersonName TEXT,
                    Email TEXT,
                    Phone TEXT
                )";
                    using (var command = new SqliteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
        }

        public static bool TableExists(string tableName)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name=@TableName";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);
                        var result = command.ExecuteScalar();
                        return Convert.ToInt32(result) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return false;
            }
        }


        public static  bool DoesSavedStoreExist(int storeID, int personID)
        {
            InitializeDatabase();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                     connection.Open();
                    // Modify the query to check for both StoreID and PersonID
                    string query = "SELECT COUNT(*) FROM StoreDetails WHERE StoreID = @StoreID AND PersonID = @PersonID";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        // Add both parameters to the command
                        command.Parameters.AddWithValue("@StoreID", storeID);
                        command.Parameters.AddWithValue("@PersonID", personID);

                        var result =  command.ExecuteScalar();
                        return Convert.ToInt32(result) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return false;
            }
        }


        public static async Task SaveStoreDetailsAsync(StoreDetailsDTO storeDetails)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                    INSERT OR REPLACE INTO StoreDetails (
                        Name, RegionName, CityName, DistrictsName, CommercialNumber, Website,
                        Address, CategoryName, TypeName, Rating, NumberOfRates, StoreStatus,
                        NumbersOfClick, Photo, PersonName, Email, Phone, StoreID)
                    VALUES (
                        $Name, $RegionName, $CityName, $DistrictsName, $CommercialNumber, $Website,
                        $Address, $CategoryName, $TypeName, $Rating, $NumberOfRates, $StoreStatus,
                        $NumbersOfClick, $Photo, $PersonName, $Email, $Phone, $StoreID)";

                        command.Parameters.AddWithValue("$Name", storeDetails.Name);
                        command.Parameters.AddWithValue("$RegionName", storeDetails.RegionName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$CityName", storeDetails.CityName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$DistrictsName", storeDetails.DistrictsName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$CommercialNumber", storeDetails.CommercialNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$Website", storeDetails.Website ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$Address", storeDetails.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$CategoryName", storeDetails.CategoryName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$TypeName", storeDetails.TypeName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$Rating", storeDetails.Rating ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$NumberOfRates", storeDetails.NumberOfRates ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$StoreStatus", storeDetails.StoreStatus ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$NumbersOfClick", storeDetails.NumbersOfClick ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$Photo", storeDetails.Photo ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$PersonName", storeDetails.PersonName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$Email", storeDetails.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$Phone", storeDetails.Phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("$StoreID", storeDetails.StoreID);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
        }
        public static async Task<List<StoreDetailsDTO>> GetAllStoreDetailsAsync()
        {
            var storeDetailsList = new List<StoreDetailsDTO>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT * FROM StoreDetails";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                storeDetailsList.Add(new StoreDetailsDTO(
                                    reader.GetString(reader.GetOrdinal("Name")),
                                    reader.IsDBNull(reader.GetOrdinal("RegionName")) ? null : reader.GetString("RegionName"),
                                    reader.IsDBNull(reader.GetOrdinal("CityName")) ? null : reader.GetString("CityName"),
                                    reader.IsDBNull(reader.GetOrdinal("DistrictsName")) ? null : reader.GetString("DistrictsName"),
                                    reader.IsDBNull(reader.GetOrdinal("CommercialNumber")) ? null : reader.GetString("CommercialNumber"),
                                    reader.IsDBNull(reader.GetOrdinal("Website")) ? null : reader.GetString("Website"),
                                    reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address"),
                                    reader.IsDBNull(reader.GetOrdinal("CategoryName")) ? null : reader.GetString("CategoryName"),
                                    reader.IsDBNull(reader.GetOrdinal("TypeName")) ? null : reader.GetString("TypeName"),
                                    reader.IsDBNull(reader.GetOrdinal("Rating")) ? null : reader.GetByte("Rating"),
                                    reader.IsDBNull(reader.GetOrdinal("NumberOfRates")) ? null : reader.GetDecimal("NumberOfRates"),
                                    reader.IsDBNull(reader.GetOrdinal("StoreStatus")) ? null : reader.GetString("StoreStatus"),
                                    reader.IsDBNull(reader.GetOrdinal("NumbersOfClick")) ? null : reader.GetDecimal("NumbersOfClick"),
                                    reader.IsDBNull(reader.GetOrdinal("Photo")) ? null : reader.GetString("Photo"),
                                    reader.IsDBNull(reader.GetOrdinal("PersonName")) ? null : reader.GetString("PersonName"),
                                    reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                                    reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                                    reader.GetInt32(reader.GetOrdinal("StoreID"))
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

            return storeDetailsList;
        }

    }
}

