using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace HistoriasPais.Services  // Cambia si tu proyecto tiene otro namespace
{
    using Microsoft.Data.SqlClient;
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> ObtenerCiudadesPorPais(string pais)
        {
            var ciudades = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Nombre FROM Ciudades WHERE Pais = @Pais";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pais", pais);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ciudades.Add(reader.GetString(0));
                    }
                }
            }

            return ciudades;
        }
    }
}
