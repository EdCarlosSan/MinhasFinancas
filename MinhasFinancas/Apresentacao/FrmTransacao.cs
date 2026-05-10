using System;
using System.Windows.Forms;
using MinhasFinancas.Negocio;
using MinhasFinancas.Dados;
using System.Drawing; // Necessário para o Point e Size

namespace MinhasFinancas.Apresentacao
{
    public partial class FrmTransacao : Form
    {
        public FrmTransacao()
        {
            // O InitializeComponent deve ser chamado primeiro!
            InitializeComponent();
        }

        // Evento Load: Carrega as categorias assim que a tela abre
        private void FrmTransacao_Load(object sender, EventArgs e)
        {
            try
            {
                CategoriaDAO catDAO = new CategoriaDAO();
                // Agora o nome bate com o que está no InitializeComponent abaixo
                cboCategoria.DataSource = catDAO.Listar();
                cboCategoria.DisplayMember = "Nome";
                cboCategoria.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
        }

        // Organizei o InitializeComponent para os nomes baterem com sua lógica
        private void InitializeComponent()
        {
            txtDescricao = new TextBox();
            txtValor = new TextBox();
            cboTipo = new ComboBox();
            cboCategoria = new ComboBox();
            dtpData = new DateTimePicker();
            btnSalvar = new Button();
            SuspendLayout();

            // Descrição
            txtDescricao.Location = new Point(27, 28);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(125, 27);
            txtDescricao.PlaceholderText = "Descrição";

            // Valor
            txtValor.Location = new Point(175, 28);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(125, 27);
            txtValor.PlaceholderText = "Valor";

            // Tipo (Receita/Despesa)
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(27, 72);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(151, 28);
            cboTipo.Items.AddRange(new object[] { "Receita", "Despesa" });

            // Categoria
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(203, 72);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(151, 28);

            // Data
            dtpData.Location = new Point(27, 119);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(250, 27);

            // Botão Salvar
            btnSalvar.Location = new Point(27, 166);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.Text = "Salvar";
            btnSalvar.Click += btnSalvar_Click; // Liga o botão ao código de salvar

            // FrmTransacao
            ClientSize = new Size(400, 250);
            Controls.Add(btnSalvar);
            Controls.Add(dtpData);
            Controls.Add(cboCategoria);
            Controls.Add(cboTipo);
            Controls.Add(txtValor);
            Controls.Add(txtDescricao);
            Name = "FrmTransacao";
            Text = "Nova Transação";
            Load += FrmTransacao_Load; // Garante que carrega os dados ao abrir
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Transacao novaTransacao = new Transacao();
                novaTransacao.Descricao = txtDescricao.Text;
                novaTransacao.Valor = double.Parse(txtValor.Text);
                novaTransacao.Data = dtpData.Value;
                novaTransacao.Tipo = cboTipo.SelectedItem.ToString();
                novaTransacao.CategoriaId = (int)cboCategoria.SelectedValue;

                TransacaoDAO dao = new TransacaoDAO();
                dao.Inserir(novaTransacao);

                MessageBox.Show("Transação registrada com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        // Definição dos componentes (Agora com os nomes corretos)
        private Button btnSalvar;
        private TextBox txtDescricao;
        private TextBox txtValor;
        private ComboBox cboTipo;
        private ComboBox cboCategoria;
        private DateTimePicker dtpData;
    }
}