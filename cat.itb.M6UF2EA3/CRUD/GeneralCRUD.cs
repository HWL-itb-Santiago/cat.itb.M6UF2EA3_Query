using cat.itb.M6UF2EA3.Connections;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.CRUD
{
    //CRUD General que contiene los metodos para la creacion y eliminación de las tablas
    public class GeneralCRUD
    {
        //Script necesario para crear las tablas de la base de datos
        public void CreateTables()
        {
            try
            {
                //ruta donde se encuentra el sql script
                string sqlPath = "../../../hr2.sql";
                if (!File.Exists(sqlPath))
                {
                    Console.WriteLine("El archivo no existe");
                    return;
                }
                string creationCommand = "";
                StreamReader sr = new(sqlPath);
                creationCommand = sr.ReadToEnd();
                //creacion de la conexion con la base de datos
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
        //script con el que se eliminan la informacion de las tablas
        public void DeleteTables(List<string> tablas)
        {
            try
            {
                //creacion de la conexion con la base de datos
                CloudConnection db = new();
                using NpgsqlConnection conn = db.GetConnection();
                foreach (string tab in tablas)
                {
                    if (!IsValidTableName(tab))
                    {
                        Console.WriteLine($"Nombre de tabla inválido: {tab}");
                        continue;
                    }
                    //elimina cada tabla si existe
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
        //validacion del nombre de las tablas
        private bool IsValidTableName(string tableName)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(tableName, @"^[a-zA-Z0-9_]+$");
        }
    }
}
