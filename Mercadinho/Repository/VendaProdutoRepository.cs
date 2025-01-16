using Mercadinho.Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace Mercadinho.Repository
{
    public class VendaProdutoRepository : BaseRepository
    {
        public VendaProdutoRepository()
        {
            this.connectionString = ConfigurationManager
                .ConnectionStrings["MySQL"]
                .ConnectionString;
            this.CriarTabela();
        }

        private void CriarTabela()
        {
            string query = @"CREATE TABLE IF NOT EXISTS VendaProduto (
                VendaId INT,
                ProdutoId INT,
                Quantidade INT NOT NULL,
                PrecoUnitario DOUBLE NOT NULL,
                FOREIGN KEY (VendaId) REFERENCES Venda(Id),
                FOREIGN KEY (ProdutoId) REFERENCES Produto(Id),
                PRIMARY KEY (VendaId, ProdutoId)
            );";

            var connection = new MySqlConnection(connectionString);
            var command = new MySqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AdicionarItens(int vendaId, IEnumerable<VendaProduto> itens)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO VendaProduto 
                              (VendaId, ProdutoId, Quantidade, PrecoUnitario) 
                              VALUES (@VendaId, @ProdutoId, @Quantidade, @PrecoUnitario)";

                foreach (var item in itens)
                {
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VendaId", vendaId);
                        command.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
                        command.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                        command.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public IEnumerable<VendaProduto> ObterPorVenda(int vendaId)
        {
            var itens = new List<VendaProduto>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT VendaId, ProdutoId, Quantidade, PrecoUnitario 
                               FROM VendaProduto 
                               WHERE VendaId = @VendaId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VendaId", vendaId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itens.Add(new VendaProduto(
                                reader.GetInt32("VendaId"),
                                reader.GetInt32("ProdutoId"),
                                reader.GetInt32("Quantidade"),
                                reader.GetDouble("PrecoUnitario")
                            ));
                        }
                    }
                }
            }
            return itens;
        }

        public void RemoverItensVenda(int vendaId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM VendaProduto WHERE VendaId = @VendaId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VendaId", vendaId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}