using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MinhasFinancas.Apresentacao
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategoria tela = new FrmCategoria();
            tela.Show();
        }
        private void btnAbrirTransacao_Click(object sender, EventArgs e)
        {
            FrmTransacao tela = new FrmTransacao();
            tela.Show(); // Abre a tela de transação
        }
        private void btnAbrirExtrato_Click(object sender, EventArgs e)
        {
            FrmExtrato tela = new FrmExtrato();
            tela.Show(); // Abre a tela que mostra a tabela e o saldo
        }

        private Button btnAbrirTransacao;
        private Button btnAbrirExtrato;
        private Button btnCategorias;

        private void InitializeComponent()
        {
            btnCategorias = new Button();
            btnAbrirTransacao = new Button();
            btnAbrirExtrato = new Button();
            SuspendLayout();
            // 
            // btnCategorias
            // 
            btnCategorias.Location = new Point(29, 32);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(94, 29);
            btnCategorias.TabIndex = 0;
            btnCategorias.Text = "Categorias";
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnAbrirTransacao
            // 
            btnAbrirTransacao.Location = new Point(154, 32);
            btnAbrirTransacao.Name = "btnAbrirTransacao";
            btnAbrirTransacao.Size = new Size(123, 29);
            btnAbrirTransacao.TabIndex = 1;
            btnAbrirTransacao.Text = "Nova Transação";
            btnAbrirTransacao.UseVisualStyleBackColor = true;
            btnAbrirTransacao.Click += btnAbrirTransacao_Click;
            // 
            // btnAbrirExtrato
            // 
            btnAbrirExtrato.Location = new Point(305, 32);
            btnAbrirExtrato.Name = "btnAbrirExtrato";
            btnAbrirExtrato.Size = new Size(123, 29);
            btnAbrirExtrato.TabIndex = 2;
            btnAbrirExtrato.Text = "Ver Extrato";
            btnAbrirExtrato.UseVisualStyleBackColor = true;
            btnAbrirExtrato.Click += btnAbrirExtrato_Click;
            // 
            // FrmMenu
            // 
            ClientSize = new Size(440, 253);
            Controls.Add(btnAbrirExtrato);
            Controls.Add(btnAbrirTransacao);
            Controls.Add(btnCategorias);
            Name = "FrmMenu";
            ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}