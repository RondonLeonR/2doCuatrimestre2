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

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public event limiteSueldoDelegado Sueldo;
        public event LimiteSueldoMejorado SueldoMejorado;

        public Form1()
        {
            InitializeComponent();
            this.cmbLimiteSueldo.Items.Add(TipoManejador.LimiteSueldo);
            this.cmbLimiteSueldo.Items.Add(TipoManejador.LimiteSueldoMejorado);
            this.cmbLimiteSueldo.Items.Add(TipoManejador.Todos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Empleado eAux = new Empleado(this.txtNombre.Text, this.txtApellido.Text, int.Parse(this.txtLegajo.Text));
            
            if (this.cmbLimiteSueldo.SelectedItem is TipoManejador.LimiteSueldo)
            {
                eAux.limiteSueldo += new limiteSueldoDelegado(ManejadorLimiteSueldo);
                
            }
            else if (this.cmbLimiteSueldo.SelectedItem is TipoManejador.LimiteSueldoMejorado)
            {
                eAux.limiteSueldoMejorado += new LimiteSueldoMejorado(ManejadorLimiteSueldoMejorado);
                
            }
            else
            {
                eAux.limiteSueldo += new limiteSueldoDelegado(ManejadorLimiteSueldo);
                eAux.limiteSueldoMejorado += new LimiteSueldoMejorado(ManejadorLimiteSueldoMejorado);
            }
            eAux.Sueldo = double.Parse(this.txtSueldo.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void ManejadorLimiteSueldo(double sueldo, Empleado e)
        {
            MessageBox.Show("Sueldo mayor a 18000 ---> " + e.ToString() + " - " + sueldo.ToString());
        }

        public void ManejadorLimiteSueldoMejorado(Empleado e, EventArgs ev)
        {
            MessageBox.Show("Sueldo mayor a 30000 ---> " + e.ToString(), ev.ToString());
        }
    }
}
