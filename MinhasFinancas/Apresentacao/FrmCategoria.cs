using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms; // Necessário para o MessageBox
using MinhasFinancas.Negocio;
using MinhasFinancas.Dados;

namespace MinhasFinancas.Apresentacao
{
    // A classe do formulário precisa existir aqui!
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            // Cria uma nova "cópia" da tela de categorias
            FrmCategoria telaCategoria = new FrmCategoria();

            // Mostra a tela para o usuário
            telaCategoria.Show();
        }
        // Agora sim, o botão fica DENTRO da classe
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria(txtNome.Text);

                CategoriaDAO dao = new CategoriaDAO();
                dao.Inserir(categoria);

                MessageBox.Show("Categoria salva com sucesso!");

                txtNome.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            label1 = new Label();
            txtNome = new TextBox();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(436, 42);
            label1.Name = "label1";
            label1.Size = new Size(143, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome da Categoria:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(552, 71);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(125, 27);
            txtNome.TabIndex = 1;
            txtNome.TextChanged += textBox1_TextChanged;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(310, 113);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // FrmCategoria
            // 
            ClientSize = new Size(932, 253);
            Controls.Add(btnSalvar);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Name = "FrmCategoria";
            ResumeLayout(false);
            PerformLayout();

        }

        private Label label1;
        private Button btnSalvar;
        private TextBox txtNome;
    }
}