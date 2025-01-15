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
                "Modelo VARCHAR(50)," +
                "Quantidade INT DEFAULT 0," +
                "Subtotal DECIMAL(10,2) DEFAULT 0.00" +
                ");";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Adicionar(Produto produto)
        {
            string query = "INSERT INTO Produto (Nome, Preco, Descricao, Marca, Modelo, Quantidade, Subtotal) " +
                          "VALUES (@Nome, @Preco, @Descricao, @Marca, @Modelo, @Quantidade, @Subtotal);";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", produto.Nome);
                    command.Parameters.AddWithValue("@Preco", produto.PrecoUnitario);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Marca", produto.Marca);
                    command.Parameters.AddWithValue("@Modelo", produto.Modelo);
                    command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                    command.Parameters.AddWithValue("@Subtotal", produto.Subtotal);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Atualizar(Produto produto)
        {
            string query = "UPDATE Produto SET Nome = @Nome, Preco = @Preco, Descricao = @Descricao, " +
                          "Marca = @Marca, Modelo = @Modelo, Quantidade = @Quantidade, Subtotal = @Subtotal " +
                          "WHERE Id = @Id;";
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", produto.Id);
                    command.Parameters.AddWithValue("@Nome", produto.Nome);
                    command.Parameters.AddWithValue("@Preco", produto.PrecoUnitario);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Marca", produto.Marca);
                    command.Parameters.AddWithValue("@Modelo", produto.Modelo);
                    command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                    command.Parameters.AddWithValue("@Subtotal", produto.Subtotal);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<Produto> Listar()
        {
            string query = "SELECT Id, Nome, Preco, Descricao, Marca, Modelo, Quantidade, Subtotal FROM Produto;";
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
                                PrecoUnitario = reader.GetDouble("Preco"),
                                Descricao = reader.GetString("Descricao"),
                                Marca = reader.GetString("Marca"),
                                Modelo = reader.GetString("Modelo"),
                                Quantidade = reader.GetInt32("Quantidade"),
                                Subtotal = reader.GetDecimal("Subtotal")
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
            bool isId = int.TryParse(valor, out int id);

            if (isId)
            {
                query = @"SELECT Id, Nome, Preco, Descricao, Marca, Modelo, Quantidade, Subtotal 
                         FROM Produto WHERE Id = @Valor";
            }
            else
            {
                query = @"SELECT Id, Nome, Preco, Descricao, Marca, Modelo, Quantidade, Subtotal 
                         FROM Produto WHERE Nome LIKE @Valor";
                valor = "%" + valor + "%";
            }

            var produtos = new List<Produto>();
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Valor", valor);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var produto = new Produto
                            {
                                Id = reader.GetInt32("Id"),
                                Nome = reader.GetString("Nome"),
                                PrecoUnitario = reader.GetDouble("Preco"),
                                Descricao = reader.GetString("Descricao"),
                                Marca = reader.GetString("Marca"),
                                Modelo = reader.GetString("Modelo"),
                                Quantidade = reader.GetInt32("Quantidade"),
                                Subtotal = reader.GetDecimal("Subtotal")
                            };
                            produtos.Add(produto);
                        }
                    }
                    connection.Close();
                }
            }
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