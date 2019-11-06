using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPersonas
{
    public partial class frmVisorDataTable : frmVisorPersona
    {
        private DataTable dataTable;

        public DataTable DataTable
        {
            get
            {
                return this.dataTable;
            }
        }

        public frmVisorDataTable(): base()
        {
            InitializeComponent();
        }

        public frmVisorDataTable(DataTable dt) : this()
        {
            try
            {
                DataRow row;
                for(int i = 0; i < dt.Rows.Count; i ++)
                {
                    row = dt.Rows[i];
                    this.lstVisor.Items.Add(row["id"].ToString() + " - " + row["nombre"].ToString() + " - " + row["apellido"].ToString() + " - " + row["edad"].ToString());
                }
                this.dataTable = dt;

                
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void frmVisorDataTable_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //datatable.row.add(recibe obj de tipo datarow)
            //generar una fila que se adapte a nuestro datatable
            //metodo(   dt.NewRow()   )
            //fila[0] = ojb.persona.nombre;

            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            DataRow row = this.dataTable.NewRow();

            row["nombre"] = frm.Persona.nombre;
            row["apellido"] = frm.Persona.apellido;
            row["edad"] = frm.Persona.edad;

            this.dataTable.Rows.Add(row);
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DataRow row = this.dataTable.Rows[this.lstVisor.SelectedIndex];
            frmPersona frm = new frmPersona(new Entidades.Persona(row["nombre"].ToString(), row["apellido"].ToString(), int.Parse(row["edad"].ToString())));
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                row["nombre"] = frm.Persona.nombre;
                row["apellido"] = frm.Persona.nombre;
                row["edad"] = frm.Persona.nombre;
            }
            this.ActualizarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //seleccionar elemento de la lista
            //marcar fila[indice].deleted()   (borrado logico, solo cambia el estado)
            DataRow row = this.dataTable.Rows[this.lstVisor.SelectedIndex];
            row.Delete();
            this.ActualizarLista();
        }

        //sqldataadapter = permite intercambiar inf. desde la base de datos y la aplicacion.
    }
}
