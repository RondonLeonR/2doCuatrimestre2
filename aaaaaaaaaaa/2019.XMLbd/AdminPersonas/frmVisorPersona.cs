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

namespace AdminPersonas
{
    public partial class frmVisorPersona : Form
    {
        private List<Persona> listaAux = new List<Persona>();

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

        public List<Persona> ListaAux
        {
            get
            {
                return this.listaAux;
            }
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
            frmPersona frm = new frmPersona(/*params*/);
            frm.StartPosition = FormStartPosition.CenterScreen;

            //implementar
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            //implementar
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
    }
}
