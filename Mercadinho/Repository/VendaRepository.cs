using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Mercadinho.Model;
using MySql.Data.MySqlClient;

namespace Mercadinho.Repository
{
    public class VendaRepository : BaseRepository, IVendaRepository
    {
        private readonly ProdutoRepository ProdutoRepository;

        public VendaRepository()
        {
            this.connectionString = ConfigurationManager
                .ConnectionStrings["MySQL"]
                .ConnectionString;
            ProdutoRepository = new ProdutoRepository();
            this.CriarTabelas();
        }

        private void CriarTabelas()
        {
            string queryVenda = @"CREATE TABLE IF NOT EXISTS Venda (
                Id INT PRIMARY KEY AUTO_INCREMENT,
                IdCliente INT NOT NULL,
                DataCompra DATETIME NOT NULL,
                ValorTotal DECIMAL(10,2) NOT NULL,
                FOREIGN KEY (IdCliente) REFERENCES Cliente(Id)
            );";

            string queryVendaProduto = @"CREATE TABLE IF NOT EXISTS VendaProduto (
                VendaId INT,
                ProdutoId INT,
                Quantidade INT NOT NULL,
                PrecoUnitario DOUBLE NOT NULL,
                Subtotal DECIMAL(10,2) NOT NULL,
                FOREIGN KEY (VendaId) REFERENCES Venda(Id),
                FOREIGN KEY (ProdutoId) REFERENCES Produto(Id),
                PRIMARY KEY (VendaId, ProdutoId)
            );";

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(queryVenda, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new MySqlCommand(queryVendaProduto, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Adicionar(Venda venda)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Inserir em Venda
                        string queryVenda = @"INSERT INTO Venda (IdCliente, DataCompra, ValorTotal) 
                                           VALUES (@IdCliente, @DataCompra, @ValorTotal);
                                           SELECT LAST_INSERT_ID();";

                        int vendaId;
                        using (var command = new MySqlCommand(queryVenda, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@IdCliente", venda.IdCliente);
                            command.Parameters.AddWithValue("@DataCompra", venda.DataCompra);
                            command.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                            vendaId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        // Inserir em VendaProduto
                        string queryVendaProduto = @"INSERT INTO VendaProduto 
                                                  (VendaId, ProdutoId, Quantidade, PrecoUnitario, Subtotal) 
                                                  VALUES (@VendaId, @ProdutoId, @Quantidade, @PrecoUnitario, @Subtotal)";

                        foreach (var produto in venda.Produtos)
                        {
                            using (var command = new MySqlCommand(queryVendaProduto, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@VendaId", vendaId);
                                command.Parameters.AddWithValue("@ProdutoId", produto.Id);
                                command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                                command.Parameters.AddWithValue("@PrecoUnitario", produto.PrecoUnitario);
                                command.Parameters.AddWithValue("@Subtotal", produto.Subtotal);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public IEnumerable<Venda> Listar()
        {
            var vendas = new List<Venda>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT v.Id, v.IdCliente, v.DataCompra, v.ValorTotal,
                               p.Id as ProdutoId, p.Nome, p.Preco, p.Descricao, p.Marca, p.Modelo,
                               vp.Quantidade, vp.Subtotal
                               FROM Venda v
                               JOIN VendaProduto vp ON v.Id = vp.VendaId
                               JOIN Produto p ON vp.ProdutoId = p.Id
                               ORDER BY v.Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int currentVendaId = -1;
                        Venda currentVenda = null;
                        List<Produto> produtos = null;

                        while (reader.Read())
                        {
                            int vendaId = reader.GetInt32("Id");
                            if (vendaId != currentVendaId)
                            {
                                if (currentVenda != null)
                                {
                                    vendas.Add(currentVenda);
                                }
                                produtos = new List<Produto>();
                                currentVendaId = vendaId;
                                currentVenda = new Venda(
                                    vendaId,
                                    reader.GetInt32("IdCliente"),
                                    produtos,
                                    reader.GetDateTime("DataCompra")
                                );
                            }

                            produtos.Add(new Produto(
                                reader.GetInt32("ProdutoId"),
                                reader.GetString("Nome"),
                                reader.GetDouble("Preco"),
                                reader.GetString("Descricao"),
                                reader.GetString("Marca"),
                                reader.GetString("Modelo"),
                                reader.GetInt32("Quantidade")
                            ));
                        }

                        if (currentVenda != null)
                        {
                            vendas.Add(currentVenda);
                        }
                    }
                }
            }
            return vendas;
        }

        public IEnumerable<Venda> ObterPorCliente(int idCliente)
        {
            return Listar().Where(v => v.IdCliente == idCliente);
        }

        public IEnumerable<Venda> ObterPorPeriodo(DateTime inicio, DateTime fim)
        {
            return Listar().Where(v => v.DataCompra >= inicio && v.DataCompra <= fim);
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
                        // Deletar de VendaProduto primeiro
                        string queryDeleteVendaProduto = "DELETE FROM VendaProduto WHERE VendaId = @Id";
                        using (var command = new MySqlCommand(queryDeleteVendaProduto, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }

                        // Depois deletar de Venda
                        string queryDeleteVenda = "DELETE FROM Venda WHERE Id = @Id";
                        using (var command = new MySqlCommand(queryDeleteVenda, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}