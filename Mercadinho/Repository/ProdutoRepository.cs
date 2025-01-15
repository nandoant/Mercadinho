using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Mercadinho.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository() 
        { 
            this.connectionString = ConfigurationManager
                .ConnectionStrings["MySQL"]
                .ConnectionString;
            this.CriarTabela();
        }

        private void CriarTabela()
        {
            string query = "CREATE TABLE IF NOT EXISTS Produto (" +
                "Id INT AUTO_INCREMENT PRIMARY KEY," +
                "Nome VARCHAR(100) NOT NULL," +
                "Preco DOUBLE NOT NULL," +
                "Descricao TEXT," +
                "Marca VARCHAR(50)," +
                "Modelo VARCHAR(50)" +
                ");";
            var connection = new MySqlConnection(connectionString);
            var command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Adicionar(Produto produto)
        {
            string query = "INSERT INTO Produto (Nome, Preco, Descricao, Marca, Modelo) " +
                           "VALUES (@Nome, @Preco, @Descricao, @Marca, @Modelo);";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", produto.Nome);
                    command.Parameters.AddWithValue("@Preco", produto.Preco);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Marca", produto.Marca);
                    command.Parameters.AddWithValue("@Modelo", produto.Modelo);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Atualizar(Produto produto)
        {
            string query = "UPDATE Produto SET Nome = @Nome, Preco = @Preco, Descricao = @Descricao, Marca = @Marca, Modelo = @Modelo WHERE Id = @Id;";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", produto.Id);
                    command.Parameters.AddWithValue("@Nome", produto.Nome);
                    command.Parameters.AddWithValue("@Preco", produto.Preco);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Marca", produto.Marca);
                    command.Parameters.AddWithValue("@Modelo", produto.Modelo);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Produto> Listar()
        {
            string query = "SELECT Id, Nome, Preco, Descricao, Marca, Modelo FROM Produto;";
            var produtos = new List<Produto>();

            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var produto = new Produto
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                Preco = reader.GetDouble("Preco"),
                                Descricao = reader.GetString("Descricao"),
                                Marca = reader.GetString("Marca"),
                                Modelo = reader.GetString("Modelo")
                            };
                            produtos.Add(produto);
                        }
                    }
                    connection.Close();
                }
            }
            return produtos;
        }

        public IEnumerable<Produto> ObterPorvalor(string valor)
        {
            string query;
            int id;
            bool isId = int.TryParse(valor, out id);

            if (isId)
            {
                query = @"SELECT Id, Nome, Preco, Descricao, Marca, Modelo FROM Produto WHERE Id = @Valor";
            }
            else
            {
                query = @"SELECT Id, Nome, Preco, Descricao, Marca, Modelo FROM Produto WHERE Nome LIKE @Valor";
                valor = "%" + valor + "%";
            }

            var connection = new MySqlConnection(this.connectionString);
            var command = new MySqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@Valor", valor);
            var reader = command.ExecuteReader();
            var produtos = new List<Produto>();
            while (reader.Read())
            {
                var produto = new Produto
                {
                    Id = reader.GetInt32("Id"),
                    Nome = reader.GetString("Nome"),
                    Preco = reader.GetDouble("Preco"),
                    Descricao = reader.GetString("Descricao"),
                    Marca = reader.GetString("Marca"),
                    Modelo = reader.GetString("Modelo")
                };
                produtos.Add(produto);
            }
            connection.Close();
            return produtos;
        }

        public void Remover(int id)
        {
            string query = "DELETE FROM Produto WHERE Id = @Id;";
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
