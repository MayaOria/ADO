using Exo_3.Models;
using System;
using System.Data.SqlClient;

namespace Exo_3
{
    class Program

    {
        private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True";
        static void Main(string[] args)
        {
            Spectacle romeoJuliette = new Spectacle() { nom = "Roméo et Juliette", description = "Pièce de Shakespeare" };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @$"INSERT INTO [Spectacle] ([nom], [description])
                                            OUTPUT [inserted].[idSpectacle]
                                            VALUES ('{romeoJuliette.nom}', '{romeoJuliette.description}')";
                    connection.Open();
                    romeoJuliette.idSpectacle = (int)command.ExecuteScalar();
                    connection.Close();
                }

                Representation r1 = new Representation()
                {
                    dateRepresentation = new DateTime(2022, 12, 24),
                    heureRepresentation = new DateTime(1,1,1,18,0,0),
                    idSpectacle = romeoJuliette.idSpectacle
                };
                Representation r2 = new Representation()
                {
                    dateRepresentation = new DateTime(2022, 12, 31),
                    heureRepresentation = new DateTime(1, 1, 1, 16, 0, 0),
                    idSpectacle = romeoJuliette.idSpectacle
                };

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @$"INSERT INTO [Representation] ([dateRepresentation], [heureRepresentation], [idSpectacle])
                                                VALUES
                                                    ('{r1.dateRepresentation.ToString("yyyy-MM-dd")}',
                                                     '{r1.heureRepresentation.TimeOfDay}', {r1.idSpectacle}),
                                                    ('{r2.dateRepresentation.ToString("yyyy-MM-dd")}',
                                                     '{r2.heureRepresentation.TimeOfDay}', { r2.idSpectacle})";
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                Spectacle newInauguration = new Spectacle { nom = "Inauguration", description = "Réception d'inauguration seulement sur invitation" };
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @$"UPDATE [Spectacle]
                                             SET [description] = '{newInauguration.description.Replace("'", "''")}'
                                             OUTPUT [deleted].[idSpectacle]
                                             WHERE [nom] = '{newInauguration.nom}'";

                    connection.Open();
                    newInauguration.idSpectacle = (int)command.ExecuteScalar();
                    connection.Close();
                        
                }

                Console.WriteLine($"Le spectacle : '{newInauguration.nom}' (identifiant : {newInauguration.idSpectacle}) a été mis à jour.");

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @$"DELETE FROM [Representation]
                                             WHERE [idSpectacle] = {newInauguration.idSpectacle}";

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
