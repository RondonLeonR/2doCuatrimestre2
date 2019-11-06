using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Xml.Serialization;
using System.Xml;
using System.Data.SqlClient;

namespace AdminPersonas
{
    public partial class frmVisorPersona : Form
    {
        private List<Persona> listaAux = new List<Persona>();

        public List<Persona> Personas
        {
            get
            {
                return this.listaAux;
            }
        }

        public frmVisorPersona()
        {
            this.MostrarLista(listaAux);
            InitializeComponent();

        }

        public frmVisorPersona(List<Persona> l) : this()
        {
            this.listaAux = l;
            this.MostrarLista(this.listaAux);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                this.lstVisor.Items.Clear();
                this.listaAux.Add(frm.Persona);
                this.lstVisor.Items.Clear();
                this.MostrarLista(this.listaAux);

            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = this.lstVisor.SelectedIndex;
            if (indice >= 0)
            {
                Persona p = listaAux[indice];
                frmPersona frm = new frmPersona(p);
                frm.StartPosition = FormStartPosition.CenterScreen;

                //implementar
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string consulta = $"UPDATE Personas SET nombre = '{frm.Persona.nombre}',apellido = '{frm.Persona.apellido}',edad = {frm.Persona.edad} where id = {indice + 1} ";

                        this.listaAux.Remove(p);
                        this.listaAux.Add(frm.Persona);

                        using (SqlConnection sql = new SqlConnection(Properties.Settings.Default.Conexion))
                        {
                            sql.Open();
                            using (SqlCommand command = new SqlCommand())
                            {
                                command.Connection = sql;
                                command.CommandType = CommandType.Text;
                                command.CommandText = consulta;
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                    }
                    this.ActualizarLista();
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            //implementar
            int indice = this.lstVisor.SelectedIndex;

            if (indice >= 0)
            {
                string consulta = $"DELETE FROM Personas WHERE id = {indice + 1}";
                try
                {
                    using (SqlConnection sql = new SqlConnection(Properties.Settings.Default.Conexion))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand())
                        {
                            sqlCommand.Connection = sql;
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.CommandText = consulta;
                            sql.Open();
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.ToString());
                }

                this.listaAux.Remove(listaAux[indice]);
                this.ActualizarLista();
            }
        }


        protected void ActualizarLista()
        {
            lstVisor.Items.Clear();
            foreach (Persona item in this.listaAux)
            {
                if(this.lstVisor.Items.IndexOf(item) >= 0)
                    lstVisor.Items.Add(item.ToString());
            }
        }


        private void frmVisorPersona_Load(object sender, EventArgs e)
        {

        }

        private void MostrarLista(List<Persona> l)
        {

            foreach (Persona item in this.listaAux)
            {
                this.lstVisor.Items.Add(item.ToString());
            }
        }

        public void lstVisor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
