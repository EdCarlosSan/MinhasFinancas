using System;
using System.Collections.Generic;
using System.Drawing; // Necessário para os tamanhos (Point, Size)
using System.Windows.Forms;
using MinhasFinancas.Negocio;
using MinhasFinancas.Dados;
using System.Linq; // Necessário para cálculos e filtros

namespace MinhasFinancas.Apresentacao
{
    public partial class FrmExtrato : Form
    {
        private TransacaoDAO dao = new TransacaoDAO();

        public FrmExtrato()
        {
            InitializeComponent();
        }

        // Carrega os dados assim que a tela abre
        private void FrmExtrato_Load(object sender, EventArgs e)
        {
            AtualizarGrade();
        }

        // Método para buscar no MySQL e calcular o saldo
        private void AtualizarGrade()
        {
            try
            {
                List<Transacao> lista = dao.Listar();
                dgvExtrato.DataSource = null; // Limpa antes
                dgvExtrato.DataSource = lista; // Preenche a tabela

                // Calcula o Saldo Total (Somatório)
                double saldo = lista.Sum(t => t.Tipo.ToLower() == "receita" ? t.Valor : -t.Valor);
                lblSaldo.Text = $"Saldo Total: {saldo:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados do banco: " + ex.Message);
            }
        }

        // Exclui a linha que estiver selecionada na tabela
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvExtrato.CurrentRow != null)
            {
                int id = (int)dgvExtrato.CurrentRow.Cells["Id"].Value;
                dao.Remover(id);
                AtualizarGrade(); // Recarrega a tabela após excluir
                MessageBox.Show("Transação removida!");
            }
            else
            {
                MessageBox.Show("Selecione uma linha na tabela primeiro!");
            }
        }

        // Desafio: Filtrar entre duas datas
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtpInicio.Value.Date;
            DateTime fim = dtpFim.Value.Date;

            var filtrados = dao.Listar().Where(t => t.Data.Date >= inicio && t.Data.Date <= fim).ToList();

            dgvExtrato.DataSource = null;
            dgvExtrato.DataSource = filtrados;

            double saldoFiltrado = filtrados.Sum(t => t.Tipo.ToLower() == "receita" ? t.Valor : -t.Valor);
            lblSaldo.Text = $"Saldo no Período: {saldoFiltrado:C2}";
        }

        private void InitializeComponent()
        {
            dgvExtrato = new DataGridView();
            btnExcluir = new Button();
            lblSaldo = new Label();
            dtpInicio = new DateTimePicker();
            dtpFim = new DateTimePicker();
            btnFiltrar = new Button(); // Adicionei o botão que faltava

            ((System.ComponentModel.ISupportInitialize)dgvExtrato).BeginInit();
            SuspendLayout();

            // dgvExtrato
            dgvExtrato.Location = new Point(12, 12);
            dgvExtrato.Name = "dgvExtrato";
            dgvExtrato.Size = new Size(300, 188);

            // btnExcluir
            btnExcluir.Location = new Point(334, 12);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(150, 29);
            btnExcluir.Text = "Excluir Selecionado";
            btnExcluir.Click += btnExcluir_Click; // LIGAÇÃO CORRIGIDA

            // lblSaldo
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(334, 61);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(139, 20);
            lblSaldo.Text = "Saldo Total: R$ 0,00";

            // dtpInicio
            dtpInicio.Location = new Point(334, 104);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(250, 27);

            // dtpFim
            dtpFim.Location = new Point(334, 153);
            dtpFim.Name = "dtpFim";
            dtpFim.Size = new Size(250, 27);

            // btnFiltrar (Adicionado para seu desafio funcionar)
            btnFiltrar.Location = new Point(334, 190);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(94, 29);
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.Click += btnFiltrar_Click; // LIGAÇÃO DO FILTRO

            // FrmExtrato
            ClientSize = new Size(620, 250);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpFim);
            Controls.Add(dtpInicio);
            Controls.Add(lblSaldo);
            Controls.Add(btnExcluir);
            Controls.Add(dgvExtrato);
            Name = "FrmExtrato";
            Text = "Meu Extrato";
            Load += FrmExtrato_Load; // LIGAÇÃO CORRIGIDA (Removido o "_1")

            ((System.ComponentModel.ISupportInitialize)dgvExtrato).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvExtrato;
        private Button btnExcluir;
        private Label lblSaldo;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFim;
        private Button btnFiltrar;
    }
}