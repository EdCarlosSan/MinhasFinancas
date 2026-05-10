using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient; // Adicione esta linha
using MinhasFinancas.Negocio;

namespace MinhasFinancas.Dados
{
    public class TransacaoDAO
    {
        private Conexao conexao = new Conexao();

        public void Inserir(Transacao transacao)
        {
            using (var conn = conexao.ObterConexao())
            {
                conn.Open();
                // SQL que salva no banco de verdade
                string sql = "INSERT INTO Transacao (Descricao, Valor, Tipo, Data, CategoriaId) " +
                             "VALUES (@Descricao, @Valor, @Tipo, @Data, @CategoriaId)";

                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Descricao", transacao.Descricao);
                cmd.Parameters.AddWithValue("@Valor", transacao.Valor);
                cmd.Parameters.AddWithValue("@Tipo", transacao.Tipo);
                cmd.Parameters.AddWithValue("@Data", transacao.Data);
                cmd.Parameters.AddWithValue("@CategoriaId", transacao.CategoriaId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Transacao> Listar()
        {
            List<Transacao> lista = new List<Transacao>();
            using (var conn = conexao.ObterConexao())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Transacao", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transacao t = new Transacao();
                        t.Id = Convert.ToInt32(reader["Id"]);
                        t.Descricao = reader["Descricao"].ToString();
                        t.Valor = Convert.ToDouble(reader["Valor"]);
                        t.Tipo = reader["Tipo"].ToString();

                        // ESSA LINHA É VITAL PARA O FILTRO FUNCIONAR:
                        t.Data = Convert.ToDateTime(reader["Data"]);

                        t.CategoriaId = Convert.ToInt32(reader["CategoriaId"]);
                        lista.Add(t);
                    }
                }
            }
            return lista;
        }

        public void Remover(int id)
        {
            using (var conn = conexao.ObterConexao())
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Transacao WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}