using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;
using MySql.Data.MySqlClient;

namespace Mercadinho.Repository
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository()
        {
            this.connectionString = ConfigurationManager
                .ConnectionStrings["MySQL"]
                .ConnectionString;
            this.CriarTabela();
        }

        private void CriarTabela()
        {
            string query = "CREATE TABLE IF NOT EXISTS Cliente ("+
                        "Id INT PRIMARY KEY AUTO_INCREMENT,"+
                        "Nome VARCHAR(100) NOT NULL,"+
                        "Idade INT NOT NULL,"+
                        "Cpf VARCHAR(11) NOT NULL UNIQUE);";
            var connection = new MySqlConnection(connectionString);
            var command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void Adicionar(Cliente cliente)
        {
            string query = "INSERT INTO Cliente (Nome, Idade, Cpf) " +
                           "VALUES (@Nome, @Idade, @Cpf);";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Idade", cliente.Idade);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Atualizar(Cliente cliente)
        {
            string query = "UPDATE Cliente SET Nome = @Nome, Idade = @Idade, Cpf = @Cpf WHERE Id = @Id;";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", cliente.Nome);
                    command.Parameters.AddWithValue("@Idade", cliente.Idade);
                    command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    command.Parameters.AddWithValue("@Id", cliente.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Cliente> Listar()
        {
            var clientes = new List<Cliente>();
            string query = "SELECT Id, Nome, Idade, Cpf FROM Cliente;";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                Idade = reader.GetInt32("Idade"),
                                Cpf = reader.GetString("Cpf")
                            };
                            clientes.Add(cliente);
                        }
                    }
                    connection.Close();
                }
            }
            return clientes;
        }

        public IEnumerable<Cliente> ObterPorvalor(string valor)
        {
            string query;
            int id;
            bool isId = int.TryParse(valor, out id);

            if (isId)
            {
                query = @"SELECT Id, Nome, Idade, Cpf FROM Cliente WHERE Id = @Valor";
            }
            else
            {
                query = @"SELECT Id, Nome, Idade, Cpf FROM Cliente WHERE Nome LIKE @Valor";
                valor = "%" + valor + "%";
            }

            var connection = new MySqlConnection(this.connectionString);
            var command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@Valor", valor);
            var reader = command.ExecuteReader();
            var clientes = new List<Cliente>();
            while (reader.Read())
            {
                var cliente = new Cliente
                {
                    Id = reader.GetInt32("Id"),
                    Nome = reader.GetString("Nome"),
                    Idade = reader.GetInt32("Idade"),
                    Cpf = reader.GetString("Cpf")
                };
                clientes.Add(cliente);
            }
            connection.Close();
            return clientes;
        }

        public void Remover(int id)
        {
            string query = "DELETE FROM Cliente WHERE Id = @Id;";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
