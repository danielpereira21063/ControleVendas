using ControleVendas.br.com.projeto.conexao;
using ControleVendas.br.com.projeto.model;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ControleVendas.br.com.projeto.dao
{
    public class ClienteDao
    {
        private MySqlConnection _connection;

        public ClienteDao()
        {
            _connection = new ConnectionFactory().GetConnection();
        }


        #region CadastrarCliente
        public void CadastrarCliente(Cliente model)
        {
            try
            {
                var sql = "insert into tb_clientes(nome, rg, cpf, email, telefone, celular, endereco, numero, complemento, bairro, cidade, estado)\n";
                sql += "values (@nome, @rg, @cpf, @email, @telefone, @celular, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                var mysqlCmd = new MySqlCommand(sql, _connection);
                mysqlCmd.Parameters.AddWithValue("@nome", model.Nome);
                mysqlCmd.Parameters.AddWithValue("@rg", model.RG);
                mysqlCmd.Parameters.AddWithValue("@cpf", model.CPF);
                mysqlCmd.Parameters.AddWithValue("@email", model.Email);
                mysqlCmd.Parameters.AddWithValue("@telefone", model.Telefone);
                mysqlCmd.Parameters.AddWithValue("@celular", model.Celular);
                mysqlCmd.Parameters.AddWithValue("@endereco", model.Endereco);
                mysqlCmd.Parameters.AddWithValue("@numero", model.Numero);
                mysqlCmd.Parameters.AddWithValue("@complemento", model.Complemento);
                mysqlCmd.Parameters.AddWithValue("@bairro", model.Bairro);
                mysqlCmd.Parameters.AddWithValue("@cidade", model.Cidade);
                mysqlCmd.Parameters.AddWithValue("@estado", model.Estado);

                _connection.Open();
                mysqlCmd.ExecuteNonQuery();

                MessageBox.Show("ClienteCadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar cliente!\n" + ex.Message);
            }
        }
        #endregion


        public DataTable ListarClientes()
        {
            try
            {
                var dtTable = new DataTable();

                string sql = "select * from tb_clientes";
                var mysqlCmd = new MySqlCommand(sql, _connection);

                _connection.Open();

                mysqlCmd.ExecuteNonQuery();
                var dataAdapter = new MySqlDataAdapter(mysqlCmd);
                dataAdapter.Fill(dtTable);

                return dtTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar clients!\n" + ex.Message);
                return null;
            }
        }
    }
}
