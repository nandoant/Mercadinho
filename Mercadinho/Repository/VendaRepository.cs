using System;
using System.Collections.Generic;
using System.Configuration;
using Mercadinho.Model;
using MySql.Data.MySqlClient;

namespace Mercadinho.Repository
{
    public class VendaRepository : BaseRepository, IVendaRepository
    {
        public VendaRepository()
        {
            this.connectionString = ConfigurationManager
                .ConnectionStrings["MySQL"]
                .ConnectionString;
            CriarTabelas();
        }

        private void CriarTabelas()
        {
            string queryVenda = @"CREATE TABLE IF NOT EXISTS Venda (
                Id INT PRIMARY KEY AUTO_INCREMENT,
                IdCliente INT NOT NULL,
                DataCompra DATETIME NOT NULL
            );";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(queryVenda, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public int Inserir(Venda venda)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Venda (IdCliente, DataCompra) 
                               VALUES (@IdCliente, @DataCompra);
                               SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", venda.IdCliente);
                    command.Parameters.AddWithValue("@DataCompra", venda.DataCompra);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public Venda ObterVendaPorId(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, IdCliente, DataCompra FROM Venda WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Venda(
                            reader.GetInt32("Id"),
                            reader.GetInt32("IdCliente"),
                            reader.GetDateTime("DataCompra")
                        );
                    }
                }
            }
        }

        public IEnumerable<Venda> ObterPorCliente(int idCliente)
        {
            var vendas = new List<Venda>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, IdCliente, DataCompra FROM Venda WHERE IdCliente = @IdCliente";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCliente", idCliente);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendas.Add(new Venda(
                                reader.GetInt32("Id"),
                                reader.GetInt32("IdCliente"), 
                                reader.GetDateTime("DataCompra")
                            ));
                        }
                    }
                }
            }
            return vendas;
        }

        public IEnumerable<Venda> ObterPorPeriodo(DateTime inicio, DateTime fim)
        {
            var vendas = new List<Venda>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Id, IdCliente, DataCompra 
                                FROM Venda 
                                WHERE DataCompra BETWEEN @Inicio AND @Fim";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Inicio", inicio);
                    command.Parameters.AddWithValue("@Fim", fim);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendas.Add(new Venda(
                                reader.GetInt32("Id"),
                                reader.GetInt32("IdCliente"),
                                reader.GetDateTime("DataCompra")
                            ));
                        }
                    }
                }
            }
            return vendas;
        }

        public IEnumerable<Venda> ListarVendas()
        {
            var vendas = new List<Venda>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, IdCliente, DataCompra FROM Venda";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vendas.Add(new Venda(
                            reader.GetInt32("Id"),
                            reader.GetInt32("IdCliente"),
                            reader.GetDateTime("DataCompra")
                        ));
                    }
                }
            }
            return vendas;
        }

        public void Remover(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string queryDeleteVendaProduto = "DELETE FROM VendaProduto WHERE VendaId = @Id";
                        using (var command = new MySqlCommand(queryDeleteVendaProduto, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }

                        string queryDeleteVenda = "DELETE FROM Venda WHERE Id = @Id";
                        using (var command = new MySqlCommand(queryDeleteVenda, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}