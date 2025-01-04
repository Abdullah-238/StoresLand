using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresPlace_Front.Sqlite
{
    public class clsSqliteString
    {
        private static string _dbPath = Path.Combine(FileSystem.AppDataDirectory, "storesland.db");

        public static string connectionString = $"Data Source={_dbPath};";
    }
}
