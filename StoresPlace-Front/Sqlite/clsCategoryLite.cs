
using Microsoft.Data.Sqlite;
using StoresLand_API;
using StoresLand_API.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresPlace_Front.Sqlite
{
    public class clsCategoryLite
    {
        private static void InitializeDatabaseForCategories()
        {
            if (TableExists("Categories"))
                return;

            try
            {
                using (SqliteConnection connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        // Create Categories table
                        command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        CategoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CategoryNameAr TEXT NOT NULL,
                        CategoryNameEn TEXT NOT NULL
                    )";
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

        public static async Task SaveCategoriesAsync(List<CategoryDTO> categories)
        {
            InitializeDatabaseForCategories();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();

                    foreach (var category in categories)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = @"
                        INSERT OR REPLACE INTO Categories (CategoryNameAr, CategoryNameEn)
                        VALUES ($CategoryNameAr, $CategoryNameEn)";

                            command.Parameters.AddWithValue("$CategoryNameAr", category.CategoryNameAr);
                            command.Parameters.AddWithValue("$CategoryNameEn", category.CategoryNameEn);

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

        public static void SaveCategories(List<CategoryDTO> categories)
        {
            InitializeDatabaseForCategories();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    foreach (var category in categories)
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = @"
                        INSERT OR REPLACE INTO Categories (CategoryNameAr, CategoryNameEn)
                        VALUES ($CategoryNameAr, $CategoryNameEn)";

                            command.Parameters.AddWithValue("$CategoryNameAr", category.CategoryNameAr);
                            command.Parameters.AddWithValue("$CategoryNameEn", category.CategoryNameEn);

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

        public static async Task<List<CategoryDTO>> GetAllCategories()
        {
            var categories = new List<CategoryDTO>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new CategoryDTO(
                                    reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                    reader.GetString(reader.GetOrdinal("CategoryNameAr")),
                                    reader.GetString(reader.GetOrdinal("CategoryNameEn"))
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
            return categories;
        }

        public static bool IsCategoriesSaved()
        {
            bool isFound = false;

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT CategoryID FROM Categories LIMIT 1";

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

            return isFound; // Returns true if any category is found, otherwise false
        }

        public static async Task<CategoryDTO> GetCategoryById(int categoryID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Categories WHERE CategoryID = @CategoryID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                return new CategoryDTO(
                                    reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                    reader.GetString(reader.GetOrdinal("CategoryNameAr")),
                                    reader.GetString(reader.GetOrdinal("CategoryNameEn"))
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

        public static async Task<List<string>> GetAllCategoryAr()
        {
            var categoryNamesAr = new List<string>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoryNameAr FROM Categories";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                categoryNamesAr.Add(reader.GetString(reader.GetOrdinal("CategoryNameAr")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return categoryNamesAr;
        }

        public static async Task<List<string>> GetAllCategoryEn()
        {
            var categoryNamesEn = new List<string>();

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoryNameEn FROM Categories";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                categoryNamesEn.Add(reader.GetString(reader.GetOrdinal("CategoryNameEn")));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return categoryNamesEn;
        }

        public static async Task<string> GetCategoryNameArByCategoryID(int? categoryID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoryNameAr FROM Categories WHERE CategoryID = @CategoryID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        var result = await command.ExecuteScalarAsync();
                        return result as string;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return null;
        }

        public static async Task<string> GetCategoryNameEnByCategoryID(int? categoryID)
        {
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoryNameEn FROM Categories WHERE CategoryID = @CategoryID";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);
                        var result = await command.ExecuteScalarAsync();
                        return result as string;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return null;
        }



        public static async Task<int?> GetCategoryIDByCategoryNameEn(string categoryNameEn)
        {
            int? CategoryID = null; 
            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    await connection.OpenAsync();  

                    string query = "SELECT CategoryID FROM Categories WHERE CategoryNameEn = @CategoryNameEn";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryNameEn", categoryNameEn);

                        var result = await command.ExecuteScalarAsync();

                        CategoryID = int.Parse(result.ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
            }

            return CategoryID;  
        }
        public static async Task<int?> GetCategoryIDByCategoryNameAr(string categoryNameAr)
        {
            int? CategoryID = null;

            try
            {
                using (var connection = new SqliteConnection(clsSqliteString.connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoryID FROM Categories WHERE CategoryNameAr = @CategoryNameAr";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryNameAr", categoryNameAr);
                        var result = await command.ExecuteScalarAsync();

                        CategoryID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex); // Replace with appropriate logging
            }
            return CategoryID;
        }


    }
}
