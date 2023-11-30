using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroFuncionario.Uteis;

namespace CadastroFuncionario.Forms
{
    public partial class Consultar_fun : Form
    {

        List<Funcionario> listaFuncionarios = new List<Funcionario>();
        public Consultar_fun()
        {
            InitializeComponent();
            Consultar();
        }

        void Consultar()
        {
            try
            {
                var conexao = new Conexao();
                var comando = conexao.Comando("SELECT * FROM funcionario");
                var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var funcionario = new Funcionario();
                    funcionario.Id = leitor.GetInt32("id_fun");
                    funcionario.Nome = DAOHelper.GetString(leitor, "nome_fun");
                    funcionario.Data_nas = DAOHelper.GetDateTime(leitor, "data_nascimento_fun");
                    funcionario.Cpf = DAOHelper.GetString(leitor, "cpf_fun");
                    funcionario.Rg = DAOHelper.GetString(leitor, "rg_fun");
                    funcionario.Telefone = DAOHelper.GetString(leitor, "telefone_fun");
                    funcionario.Email = DAOHelper.GetString(leitor, "email_fun");
                    funcionario.Rua = DAOHelper.GetString(leitor, "rua_fun");
                    funcionario.Bairro = DAOHelper.GetString(leitor, "bairro_fun");
                    funcionario.Numero = leitor.GetInt32("numero_fun");
                    funcionario.Complemento = DAOHelper.GetString(leitor, "complemento_fun");
                    funcionario.Estado_civil = DAOHelper.GetString(leitor, "estado_civil_fun");
                    funcionario.Funcao = DAOHelper.GetString(leitor, "funcao_fun");
                    funcionario.Salario = DAOHelper.GetDouble(leitor, "salario_fun");
                    funcionario.Estado = DAOHelper.GetString(leitor, "estado_fun");
                    funcionario.Cidade = DAOHelper.GetString(leitor, "cidade_fun");

                    listaFuncionarios.Add(funcionario);
                }
                dataGridViewFuncionario.DataSource = listaFuncionarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tela_inicial AbrirForms = new Tela_inicial();
            AbrirForms.Visible = true;
            this.Close();
        }

        private void Consultar_fun_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cadastro_fun abrirForms = new Cadastro_fun();
            this.Visible = false;
            abrirForms.ShowDialog();

        }
    }
}