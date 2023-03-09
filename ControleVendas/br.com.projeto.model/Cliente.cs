using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVendas.br.com.projeto.model
{
    public class Cliente
    {

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string CEP { get; private set; }
        public string Endereco { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }


        public Cliente() { }

        public Cliente(string nome, string rG, string cPF, string email, string telefone, string celular, string cEP, string endereco, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Nome = nome;
            RG = rG;
            CPF = cPF;
            Email = email;
            Telefone = telefone;
            Celular = celular;
            CEP = cEP;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarCodigo(string codigo)
        {
            Codigo = codigo;
        }
    }
}
