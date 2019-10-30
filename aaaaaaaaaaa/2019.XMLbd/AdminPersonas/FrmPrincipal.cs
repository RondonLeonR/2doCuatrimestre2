using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;

using Entidades;

namespace AdminPersonas
{
    public partial class FrmPrincipal : Form
    {
        private List<Persona> lista;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.lista = new List<Persona>();
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();

                XmlSerializer xml = new XmlSerializer(typeof(List<Persona>));
                
                using (StreamReader str = new StreamReader(openFileDialog1.FileName))
                {
                    this.lista = (List<Persona>)xml.Deserialize(str);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void guardarEnArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                

                
                this.saveFileDialog1.ShowDialog();

                XmlSerializer xml = new XmlSerializer(typeof(List<Persona>));
                using (StreamWriter str = new StreamWriter(saveFileDialog1.FileName))
                {
                    xml.Serialize(str, this.lista);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisorPersona frm = new frmVisorPersona(this.lista);

            frm.StartPosition = FormStartPosition.CenterScreen;            
            //implementar

            frm.Show();

            this.lista = frm.ListaAux;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //implementar
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(Properties.Settings.Default.Conexion);
                sql.Open();
                SqlCommand sqlc = new SqlCommand();
                sqlc.Connection = sql;
                sqlc.CommandType = CommandType.Text;
                sqlc.CommandText = "SELECT TOP 1000 [id] ,[nombre],[apellido],[edad]FROM[personas_bd].[dbo].[personas]";

                SqlDataReader sqldr = sqlc.ExecuteReader(); // Obj de solo lectura y solo avance, no se pueden hacer busqedas;

                do
                {    
                    MessageBox.Show(sqldr[0].ToString());//indice o nombre de la columna
                } while (sqldr.Read() != false);


                sqldr.Close();
                sql.Close();
            }
            catch (Exception a)
            {

                MessageBox.Show("No hubo Conexion");
            }
        }
    }
}
