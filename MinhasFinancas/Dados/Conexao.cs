using System;
using MySql.Data.MySqlClient;

namespace MinhasFinancas.Dados
{
    public class Conexao
    {
        // Baseado nas suas imagens: Host=localhost, Porta=3306, User=root
        // Database: FinancasDB (o nome que definimos no script SQL)
        // Pwd: a sua senha do banco de dados
        private string stringConexao = "Server=localhost;Port=3306;Database=FinancasDB;Uid=root;Pwd=@Herl051014;";

        public MySqlConnection ObterConexao()
        {
            return new MySqlConnection(stringConexao);
        }
    }
}