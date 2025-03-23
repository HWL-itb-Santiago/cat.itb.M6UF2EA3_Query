using cat.itb.M6UF2EA3.Connections;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.CRUD
{
    public class GeneralCRUD
    {
        public void CreateTables()
        {
            try
            {
                string sqlPath = "../../../hr2.sql";
                if (!File.Exists(sqlPath))
                {
                    Console.WriteLine("El archivo no existe");
                    return;
                }
                string creationCommand = "";
                StreamReader sr = new(sqlPath);
                creationCommand = sr.ReadToEnd();

                CloudConnection db = new();
                using NpgsqlConnection conn = db.GetConnection();
                using var cmd = new NpgsqlCommand(creationCommand, conn);
                if (cmd.ExecuteNonQuery() != 0)
                    Console.WriteLine("Tablas creadas con éxito");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteTables(List<string> tablas)
        {
            try
            {
                CloudConnection db = new();
                using NpgsqlConnection conn = db.GetConnection();
                foreach (string tab in tablas)
                {
                    if (!IsValidTableName(tab))
                    {
                        Console.WriteLine($"Nombre de tabla inválido: {tab}");
                        continue;
                    }

                    var sql = $"DROP TABLE IF EXISTS {tab} CASCADE";
                    using var cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine($"Tabla {tab} eliminada correctamente.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool IsValidTableName(string tableName)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(tableName, @"^[a-zA-Z0-9_]+$");
        }
    }
}
