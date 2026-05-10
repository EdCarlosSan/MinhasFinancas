using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using MinhasFinancas.Negocio;

namespace MinhasFinancas.Dados
{
    public class CategoriaDAO
    {
        private Conexao conexao = new Conexao();

        public void Inserir(Categoria categoria)
        {
            using (var conn = conexao.ObterConexao())
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "INSERT INTO Categoria (Nome) VALUES (@Nome)", conn);

                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            using (var conn = conexao.ObterConexao())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Categoria", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categoria c = new Categoria();
                        c.Id = Convert.ToInt32(reader["Id"]);
                        c.Nome = reader["Nome"].ToString();
                        lista.Add(c);
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
                var cmd = new MySqlCommand("DELETE FROM Categoria WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}