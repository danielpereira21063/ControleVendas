using ControleVendas.br.com.projeto.dao;
using ControleVendas.br.com.projeto.model;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ControleVendas.br.com.projeto.view
{
    public partial class FrmClientes : Form
    {
        private ClienteDao _dao;
        private Helpers _helpers;

        public FrmClientes()
        {
            InitializeComponent();
            _dao = new ClienteDao();
            _helpers = new Helpers();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente(
                    txtNome.Text,
                    txtRG.Text,
                    txtCPF.Text,
                    txtEmail.Text,
                    txtTelefone.Text,
                    txtCelular.Text,
                    txtCEP.Text,
                    txtEndereco.Text,
                    int.Parse(txtNumero.Text),
                    txtComplemento.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    tabPage1.Text);

                _dao.CadastrarCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente(
                    txtNome.Text,
                    txtRG.Text,
                    txtCPF.Text,
                    txtEmail.Text,
                    txtTelefone.Text,
                    txtCelular.Text,
                    txtCEP.Text,
                    txtEndereco.Text,
                    int.Parse(txtNumero.Text),
                    txtComplemento.Text,
                    txtBairro.Text,
                    txtCidade.Text,
                    cbUF.Text);

                _dao.AlterarCliente(cliente);
                dgvCliente.DataSource = _dao.ListarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            dgvCliente.DefaultCellStyle.ForeColor = Color.Black;
            dgvCliente.DataSource = _dao.ListarClientes();
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgvCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = dgvCliente.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = dgvCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgvCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = dgvCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = dgvCliente.CurrentRow.Cells[6].Value.ToString();
            txtCEP.Text = dgvCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = dgvCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = dgvCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = dgvCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = dgvCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = dgvCliente.CurrentRow.Cells[12].Value.ToString();
            cbUF.Text = dgvCliente.CurrentRow.Cells[13].Value.ToString();

            tabClientes.SelectedTab = tabPage1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var codigo = int.Parse(txtCodigo.Text);

            _dao.ExcluirCliente(codigo);

            dgvCliente.DataSource = _dao.ListarClientes();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dgvCliente.DataSource = _dao.BuscarClientePorNome(txtPesquisa.Text);

            if (dgvCliente.Rows.Count == 0)
            {
                dgvCliente.DataSource = _dao.ListarClientes();
            }
        }

        private void txtPesquisaNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            var nome = $"%{txtPesquisa.Text}%";

            dgvCliente.DataSource = _dao.BuscarClientePorNome(nome);
        }

        private void btnBuscarCep_Click(object sender, EventArgs e)
        {
            try
            {
                var dados = new DataSet();
                string xml = $"https://viacep.com.br/ws/{txtCEP.Text}/xml";

                dados.ReadXml(xml);

                var rows = dados?.Tables[0]?.Rows[0];

                txtEndereco.Text = rows["logradouro"]?.ToString();
                txtBairro.Text = rows["bairro"]?.ToString();
                txtCidade.Text = rows["localidade"]?.ToString();
                txtComplemento.Text = rows["complemento"]?.ToString();
                cbUF.Text = rows["uf"]?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Endereço não encontrado, por favor digite manualmente.");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _helpers.LimparTela(this);
        }
    }
}
