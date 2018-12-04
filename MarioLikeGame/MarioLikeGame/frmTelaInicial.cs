using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mariolikegame.DAL;

namespace MarioLikeGame
{
    public partial class frmTelaInicial : Form
    {
        

        public frmTelaInicial()
        {
            InitializeComponent();
            txtNome.MaxLength = 10;

        }

        private void PreencherGrid()
        {
            //Declarando a DAL
            GamerDAL gamerDAL;

            //Instanciando a DAL na construçao do formulario
            gamerDAL = new GamerDAL();

            //Limpando o DataSource
            dgvListaRecorde.DataSource = null;

            //Listando a DAL
            dgvListaRecorde.DataSource = gamerDAL.Listar();

            //Removendo a coluna id_Jogador
            dgvListaRecorde.Columns.Remove("IdJogador");
            Mudafonte();
        }
        

        private void txtIniciar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show( "Digite o Nome é obrigatório!");
            }
            else
            {
                //Nao exibir a instancia atual da classe
                this.Visible = false;
                //Criar uma nova instancia do frmTelaJogo()
                var frm = new frmTelaJogo();
                //Pega o nome do jogador e envia para o Form1
                frm.nomeGamer = txtNome.Text;
                //Exibir o Formulario
                frm.ShowDialog();
                PreencherGrid();
                //Exibir a nova instancia da classe             
                this.Visible = true;
            }
        }
        

        private void frmTelaInicial_Load(object sender, EventArgs e)
        {

            PreencherGrid();

            //Setar o foco para o TextBox: nome do jogador
            txtNome.Focus();
            txtNome.Select();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListaRecorde_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Mudafonte()
        {
            
            dgvListaRecorde.Columns[0].HeaderText = "Jogador";
            dgvListaRecorde.Columns[0].Width = 200;
            dgvListaRecorde.Columns[1].HeaderText = "Pontos";
            dgvListaRecorde.Columns[1].Width = 130;
            dgvListaRecorde.Columns[2].HeaderText = "Data/Hora";
            dgvListaRecorde.Columns[2].Width = 400;
            dgvListaRecorde.Columns[3].HeaderText = "Tempo";

            dgvListaRecorde.ColumnHeadersDefaultCellStyle.Font = new Font("Tekton Pro", 30, FontStyle.Regular);
            dgvListaRecorde.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dgvListaRecorde.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListaRecorde.EnableHeadersVisualStyles = false;
            dgvListaRecorde.CurrentRow.DefaultCellStyle.BackColor = Color.OrangeRed;
            dgvListaRecorde.DefaultCellStyle.Font = new Font("Tekton Pro", 30, FontStyle.Regular);
            dgvListaRecorde.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
            dgvListaRecorde.DefaultCellStyle.BackColor = Color.Blue;
            dgvListaRecorde.DefaultCellStyle.ForeColor = Color.White;


        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
