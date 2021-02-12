using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCadastroEstagio
{
    public partial class Form1 : Form
    {
        CadastroEntities db;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            panel1.Enabled = false;
            db = new CadastroEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
           
            
            ShowTelefone();
        }
        private void ShowTelefone() {
            CLIENTE obj = cLIENTEBindingSource.Current as CLIENTE;
            if (obj != null) {
                if (obj.TELEFONEs != null) {
                    tELEFONEBindingSource.DataSource = obj.TELEFONEs.ToList();
                }
            }
        }

        private void dataGridViewCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCliente.Columns[e.ColumnIndex].Name == "Deletar")
            {
                if (MessageBox.Show("você tem certeza que deseja excluir-lo? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    db.CLIENTEs.Remove(cLIENTEBindingSource.Current as CLIENTE);
                cLIENTEBindingSource.RemoveCurrent();
            }
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            btnAdicionar.Enabled = false;
            panel1.Enabled = true;
            txtNome.Focus();
            CLIENTE c = new CLIENTE();
            db.CLIENTEs.Add(c);
            cLIENTEBindingSource.Add(c);
            cLIENTEBindingSource.MoveLast();
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            panel1.Enabled = true;
            txtNome.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            btnAdicionar.Enabled = true;
            btnEditar.Enabled = true;
            cLIENTEBindingSource.ResetBindings(false);

        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                await db.SaveChangesAsync();
                panel1.Enabled = false;
                btnAdicionar.Enabled = true;
                btnEditar.Enabled = true;
                MessageBox.Show("Seu cadastro foi salvo com sucesso!", "massage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLIENTE c = cLIENTEBindingSource.Current as CLIENTE;
            if (c != null)
            {
                if (tELEFONEBindingSource.DataSource == null)
                    tELEFONEBindingSource.DataSource = c.TELEFONEs.ToList();
                TELEFONE t = new TELEFONE() { CLIENTE = c };
                tELEFONEBindingSource.Add(t);
                db.TELEFONEs.Add(t);
            }
        }

        private void dataGridViewCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowTelefone();
            }
        }

        private void dataGridViewTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("você tem certeza que deseja excluir-lo? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    db.TELEFONEs.Remove(tELEFONEBindingSource.Current as TELEFONE);
                tELEFONEBindingSource.RemoveCurrent();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

