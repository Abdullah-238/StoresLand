using Microsoft.Data.Sqlite;
using StoresLand_API;
using StoresLand_API.TypesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresPlace_Front.Sqlite
{
    public class clsTypeLite
    {

        private static void InitializeDatabaseForTypes()
        {
            if (TableExists("Types"))
                return;

            try
            {
                using (SqliteConnection connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        // Create Types table
                        command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Types (
                        TypeID INTEGER PRIMARY KEY AUTOINCREMENT,
                        TypeNameAr TEXT NOT NULL,
                        TypeNameEn TEXT NOT NULL
                    )";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
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

        public static async Task SaveTypesAsync(List<TypeDTO> types)
        {
            InitializeDatabaseForTypes();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    foreach (var type in types)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = @"
                        INSERT OR REPLACE INTO Types (TypeNameAr, TypeNameEn)
                        VALUES ($TypeNameAr, $TypeNameEn)";

                            command.Parameters.AddWithValue("$TypeNameAr", type.TypeNameAr);
                            command.Parameters.AddWithValue("$TypeNameEn", type.TypeNameEn);

                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
        }

        public static void SaveTypes(List<TypeDTO> types)
        {
            InitializeDatabaseForTypes();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    foreach (var type in types)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = @"
                        INSERT OR REPLACE INTO Types (TypeNameAr, TypeNameEn)
                        VALUES ($TypeNameAr, $TypeNameEn)";

                            command.Parameters.AddWithValue("$TypeNameAr", type.TypeNameAr);
                            command.Parameters.AddWithValue("$TypeNameEn", type.TypeNameEn);

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

        public static async Task<List<TypeDTO>> GetAllTypes()
        {
            var types = new List<TypeDTO>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Types";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                types.Add(new TypeDTO(
                                    reader.GetInt32(reader.GetOrdinal("TypeID")),
                                    reader.GetString(reader.GetOrdinal("TypeNameAr")),
                                    reader.GetString(reader.GetOrdinal("TypeNameEn"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return types;
        }

        public static bool IsTypesSaved()
        {
            bool isFound = false;

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT TypeID FROM Types LIMIT 1";

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

            return isFound; // Returns true if any type is found, otherwise false
        }

        public static async Task<List<string>> GetAllTypesAr()
        {
            var typeNamesAr = new List<string>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT TypeNameAr FROM Types";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                typeNamesAr.Add(reader.GetString(reader.GetOrdinal("TypeNameAr")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return typeNamesAr;
        }

        public static async Task<List<string>> GetAllTypesEn()
        {
            var typeNamesEn = new List<string>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT TypeNameEn FROM Types";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                typeNamesEn.Add(reader.GetString(reader.GetOrdinal("TypeNameEn")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return typeNamesEn;
        }

        public static async Task<TypeDTO> GetTypeById(int typeID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Types WHERE TypeID = @TypeID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeID", typeID);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new TypeDTO(
                                    reader.GetInt32(reader.GetOrdinal("TypeID")),
                                    reader.GetString(reader.GetOrdinal("TypeNameAr")),
                                    reader.GetString(reader.GetOrdinal("TypeNameEn"))
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return null;
        }

        public static async Task<TypeDTO> FindTypeAr(string typeNameAr)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Types WHERE TypeNameAr = @TypeNameAr";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeNameAr", typeNameAr);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new TypeDTO(
                                    reader.GetInt32(reader.GetOrdinal("TypeID")),
                                    reader.GetString(reader.GetOrdinal("TypeNameAr")),
                                    reader.GetString(reader.GetOrdinal("TypeNameEn"))
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return null;
        }


        public static async Task<TypeDTO> FindTypeEn(string typeNameEn)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Types WHERE TypeNameEn = @TypeNameEn";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeNameEn", typeNameEn);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new TypeDTO(
                                    reader.GetInt32(reader.GetOrdinal("TypeID")),
                                    reader.GetString(reader.GetOrdinal("TypeNameAr")),
                                    reader.GetString(reader.GetOrdinal("TypeNameEn"))
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


        public static async Task<string> GetTypeNameArByTypeID(int? typeID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT TypeNameAr FROM Types WHERE TypeID = @TypeID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeID", typeID);
                        var result = await command.ExecuteScalarAsync();
                        return result as string;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }

        public static async Task<string> GetTypeNameEnByTypeID(int? typeID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT TypeNameEn FROM Types WHERE TypeID = @TypeID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeID", typeID);
                        var result = await command.ExecuteScalarAsync();
                        return result as string;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return null;
        }


        public static async Task<int?> GetTypeIDByTypeNameEn(string typeNameEn)
        {
            int? TypeID = 0; 

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT TypeID FROM Types WHERE TypeNameEn = @TypeNameEn";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeNameEn", typeNameEn);
                        var result = await command.ExecuteScalarAsync();
                        TypeID = int.Parse(result.ToString()) ;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return TypeID;
        }

        public static async Task<int?> GetTypeIDByTypeNameAr(string typeNameAr)
        {
            int? TypeID = 0;

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT TypeID FROM Types WHERE TypeNameAr = @TypeNameAr";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeNameAr", typeNameAr);
                        var result = await command.ExecuteScalarAsync();
                        TypeID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }
            return TypeID;
        }
    }


}
