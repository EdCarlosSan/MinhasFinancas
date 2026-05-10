using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Negocio
{
    public class Transacao
    {
        // Propriedades automáticas (Atributos da atividade)
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; } // "receita" ou "despesa"
        public int CategoriaId { get; set; }

        // Construtor vazio (importante para o banco de dados)
        public Transacao() { }

        // Construtor completo para facilitar a criação
        public Transacao(string descricao, double valor, DateTime data, string tipo, int categoriaId)
        {
            this.Descricao = descricao;
            this.Valor = valor;
            this.Data = data;
            this.Tipo = tipo;
            this.CategoriaId = categoriaId;
        }
    }
}