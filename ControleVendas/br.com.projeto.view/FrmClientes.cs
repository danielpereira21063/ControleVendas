using ControleVendas.br.com.projeto.dao;
using ControleVendas.br.com.projeto.model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControleVendas.br.com.projeto.view
{
    public partial class FrmClientes : Form
    {
        private ClienteDao _dao;

        public FrmClientes()
        {
            InitializeComponent();
            _dao = new ClienteDao();
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

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            dgvCliente.DefaultCellStyle.ForeColor = Color.Black;
            dgvCliente.DataSource = _dao.ListarClientes();
        }
    }
}
