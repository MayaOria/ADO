using ADO_Console.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Console
{
    class Program
    {
        static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True";
        static void Main(string[] args)
        {

            Spectacle sp1 = new Spectacle();
            Spectacle sp2 = new Spectacle();

            sp2.nom = "Roméo et Juliette";
            sp2.description = "Pièce de Shakespeare";

            Representation repre1 = new Representation();
            repre1.dateRepresentation = new DateTime(2022, 12, 24);
            repre1.heureRepresentation = new DateTime(2022, 12, 24, 18, 00, 00);

            Representation repre2 = new Representation();
            repre2.dateRepresentation = new DateTime(2022, 12, 31);
            repre2.heureRepresentation = new DateTime(2022, 12, 31, 16, 00, 00);

            int id;
            int id_inauguration;

            //pour pouvoir récupérer de l'unicode dans la console (rien à voir avec l'ADO)
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //on crée "l'enveloppe"
            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //on crée le "contenu de l'enveloppe" (le courrier)
            //using (SqlCommand commande = connection.CreateCommand())

            //{
            //EXECUTE SCALAR
            //On paramètre d'abord la commande SQL
            //on "écrit ce qu'il y a dans le contenu du courrier
            //tip : on vérifie d'abord en SSMS si la commande qu'on envoie est correcte et va bien renvoyer un résultat
            //commande.CommandText = "SELECT [nom] FROM [Type] WHERE [idType] = 1";
            //On ouvre ensuite la connexion
            //connection.Open();
            //Console.WriteLine(connection.State);

            //Enfin on exécute la commande SQL
            //On récupère une seule réponse grâce à la méthode ExecuteScalar, qui renvoie un objet (d'où le casting)
            //string ticketTypeName = (string)commande.ExecuteScalar();

            //Console.WriteLine(ticketTypeName);
            //}

            //using (SqlCommand commande = connection.CreateCommand())
            //{
            //    //EXECUTE READER
            //    commande.CommandText = "SELECT * FROM [type]";
            //    connection.Open();
            //    using (SqlDataReader reader = commande.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            Console.WriteLine($"{reader["idType"]}.{reader["nom"]} : {reader["prix"]} €");
            //            Console.WriteLine($"{reader[0]}. {reader[1]} : {reader[2]} €");
            //        }
            //    }
            //}
            //{
            //EN MODE HORS CONNEXION - SQLDATAADAPTER
            //on prépare la commande
            //commande.CommandText = "SELECT * FROM [Type]";
            //on prépare l'adaptater pour remplir ensuite le DataSet ou le DataTable

            //SqlDataAdapter adapter = new SqlDataAdapter(commande);
            //On crée notre data table
            //Attention, il faut implémenter le using system.data pour avoir accès au DataSet/DataTable

            //DataTable table_type = new DataTable();
            //On demande à l'adapter de remplir le DataSet/DataTable grâce à la commande .Fill
            //La méthode Fill() établit lui-même la connexion (pas besoin d'open(), close()...
            //adapter.Fill(table_type);


            //On manipule le DataSet/DataTable grâce à ses propriétés (Tables, Rows et Column)
            //        foreach(DataRow row in table_type.Rows)
            //        {
            //            Console.WriteLine($"{row["idType"]}.{row["Nom"]}: {row["prix"]}€");
            //        }
            //    }

            //}
            //À la fin des using, le Idisposable est activé pour vider la connexion 

            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {

                using (SqlCommand command = cnx.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [spectacle]";
                    cnx.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sp1.IdSpectacle = (int)reader["IdSpectacle"];
                            sp1.nom = (string)reader["nom"];
                            sp1.description = (string)reader["description"];
                        }
                    }

                    cnx.Close();
                }

               
                
                
                using(SqlCommand command = cnx.CreateCommand())
                {
                    command.CommandText = @$"INSERT INTO [Spectacle] ([nom], [description])
                                            OUTPUT ([inserted].[idSpectacle])
                                            VALUES ('{sp2.nom}', '{sp2.description}')";
                                            

                    cnx.Open();
                    id = (int)command.ExecuteScalar();
                    Console.WriteLine(id);

                    cnx.Close();
                }

                using(SqlCommand command = cnx.CreateCommand())
                {
                    command.CommandText = @$"INSERT INTO [Representation] ([dateRepresentation], [heureRepresentation], [idSpectacle])
                                            VALUES ('{repre1.dateRepresentation.Year}-{repre1.dateRepresentation.Month}-{repre1.dateRepresentation.Day}', '{repre1.heureRepresentation.TimeOfDay}', {id}),
                                                   ('{repre2.dateRepresentation.Year}-{repre2.dateRepresentation.Month}-{repre2.dateRepresentation.Day}', '{repre2.heureRepresentation.TimeOfDay}', {id})";

                    cnx.Open();

                    command.ExecuteNonQuery();

                    cnx.Close();
                }

                using (SqlCommand command = cnx.CreateCommand())
                {
                    command.CommandText = $@"UPDATE [Spectacle]
                                                SET [description] = 'Réception d''inauguration seulement sur invitation'
                                                OUTPUT [deleted].[idSpectacle]
                                                WHERE [nom] = 'inauguration'";

                    cnx.Open();
                    id_inauguration = (int)command.ExecuteScalar();
                    cnx.Close();
                }

                using(SqlCommand command = cnx.CreateCommand())
                {
                    command.CommandText = $@"DELETE
                                             FROM [representation]
                                             WHERE [idSpectacle] = {id_inauguration}";

                    cnx.Open();
                    command.ExecuteNonQuery();
                }

            }



        }
    }
}
