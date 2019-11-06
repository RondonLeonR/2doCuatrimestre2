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
        private SqlCommand sqlc;
        private SqlConnection sql;
        private SqlDataAdapter sqlDataAdapter;
        private DataTable tablaPersonas;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            this.lista = new List<Persona>();
        }

        public FrmPrincipal(SqlDataAdapter sql)
        {
            this.sqlDataAdapter = new SqlDataAdapter(this.sqlc.ToString(), this.sql);
            this.sqlDataAdapter.Fill(new DataSet());
            this.sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Persona VALUES(@p1, @p2, @p3)", this.sql);
            this.sqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Persona WHERE id = @p0");
            this.sqlDataAdapter.UpdateCommand = new SqlCommand("UPDATE Persona SET @p1, @p2, @p3 WHERE id = @p0");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@p1", SqlDbType.VarChar, 50, "nombre");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@p2", SqlDbType.VarChar, 50, "apellido");
            this.sqlDataAdapter.InsertCommand.Parameters.Add("@p3", SqlDbType.Int, 10, "edad");
            this.sqlDataAdapter.DeleteCommand.Parameters.Add("@p0", SqlDbType.Int, 10, "id");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@p0", SqlDbType.Int, 10, "id");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@p1", SqlDbType.VarChar, 50, "nombre");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@p2", SqlDbType.VarChar, 50, "apellido");
            this.sqlDataAdapter.UpdateCommand.Parameters.Add("@p3", SqlDbType.Int, 10, "edad");

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
            try
            {
                frmVisorPersona frm = new frmVisorPersona(this.lista);

                frm.StartPosition = FormStartPosition.CenterScreen;

                //implementar

                frm.Show();

                this.lista = frm.Personas;//prop para obtener la lista del visor

            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
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
                this.sql = new SqlConnection(Properties.Settings.Default.Conexion);
                sql.Open();
                this.sqlc = new SqlCommand();
                sqlc.Connection = sql;
                sqlc.CommandType = CommandType.Text;
                sqlc.CommandText = "SELECT TOP 1000 [id] ,[nombre],[apellido],[edad]FROM[personas_bd].[dbo].[personas]";

                SqlDataReader sqldr = sqlc.ExecuteReader(); // Obj de solo lectura y solo avance, no se pueden hacer busqedas;


                while (sqldr.Read() != false)//o null, leo de a uno y lo musetro
                {
                    MessageBox.Show(sqldr[0].ToString() /*+ " " + sqldr[1].ToString()*/);//dataReader[indice o "nombre de columna"].toString() para mostrarlo

                }
                //do
                //{    
                //    MessageBox.Show(sqldr[0].ToString());//indice o nombre de la columna
                //} while (sqldr.Read() != false);


                sqldr.Close();
                sql.Close();
            }
            catch (Exception )
            {

                MessageBox.Show("No hubo Conexion");
            }
        }

        private void traerTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(Properties.Settings.Default.Conexion);

                sql.Open();
                MessageBox.Show("EXITO!");
                SqlCommand comando = new SqlCommand();

                comando.Connection = sql;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM[personas_bd].[dbo].[personas]";

                SqlDataReader dataReader = comando.ExecuteReader(); // no se puede hacer busquedas, solo va para adelante, TODOS LOS REGISTROS DE LA BASE DE DATOS VAN A ESTAR EN ESTE OBJETO, PERO SE LE UNA SOLA VEZ
                //EL EXECTUE READER TRAE TODOS LOS DATOS DEL SERVIDOR Y LA IDEA ES RECUPERARLO, PASANDOLE LOS PARAMETROS AL CONSTRUCTOR DE LA LISTA A PARTIR DE LA BASE DE DATOS
                while (dataReader.Read() != false)
                {
                    this.lista.Add(new Persona(dataReader[1].ToString(), dataReader[2].ToString(), Convert.ToInt32(dataReader[3])));

                    MessageBox.Show($"Id: {dataReader[0].ToString()}\nNombre: {dataReader[1].ToString()}\nApellido: {dataReader[2].ToString()}\nEdad: {dataReader[3].ToString()}");
                    /*MessageBox.Show(dataReader[0].ToString()); id
                    MessageBox.Show(dataReader[1].ToString()); nombre
                    MessageBox.Show(dataReader[2].ToString()); apellido
                    MessageBox.Show(dataReader[3].ToString()); edad
                    */
                }

                comando.Connection.Close();
                dataReader.Close();
                sql.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sincronizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.sqlDataAdapter.Update(this.tablaPersonas);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo sincronizar");
            }
        }
    }
}
