using iso810_asignacion2.Model;

namespace iso810_asignacion2
{
    public partial class Form1 : Form
    {
        //TO-DO: hacer que el gridview funcione y kcy
        private ArchivoTSS ArchivoTSS { get; set; }
        private List<Empleado> Empleados { get; set; }

        public Form1()
        {
            InitializeComponent();
            ArchivoTSS = new ArchivoTSS();
            Empleados = new List<Empleado>();
            dtpFechaTransmicion.Value = DateTime.Now;
            SetGridView();
            ConfigurarEncabezados();
        }

        private void ConfigurarEncabezados()
        {
            if (dataGridView1.Columns["TipoRegistro"] != null)
                dataGridView1.Columns["TipoRegistro"].Visible = false;

            if (dataGridView1.Columns["Nss"] != null)
                dataGridView1.Columns["Nss"].HeaderText = "NSS";

            if (dataGridView1.Columns["Cedula"] != null)
                dataGridView1.Columns["Cedula"].HeaderText = "Cédula";

            if (dataGridView1.Columns["Nombres"] != null)
                dataGridView1.Columns["Nombres"].HeaderText = "Nombres";

            if (dataGridView1.Columns["Apellidos"] != null)
                dataGridView1.Columns["Apellidos"].HeaderText = "Apellidos";

            if (dataGridView1.Columns["SueldoMensual"] != null)
                dataGridView1.Columns["SueldoMensual"].HeaderText = "Sueldo Mensual";

            if (dataGridView1.Columns["MontoCotizable"] != null)
                dataGridView1.Columns["MontoCotizable"].HeaderText = "Monto Cotizable";

            if (dataGridView1.Columns["FechaIngreso"] != null)
                dataGridView1.Columns["FechaIngreso"].HeaderText = "Fecha Ingreso";

            if (dataGridView1.Columns["TipoContrato"] != null)
                dataGridView1.Columns["TipoContrato"].HeaderText = "Tipo Contrato";

            if (dataGridView1.Columns["Estado"] != null)
                dataGridView1.Columns["Estado"].HeaderText = "Estado";
        }


        private void SetGridView()
        {
            dataGridView1.DataSource = Empleados;
        }

        private void txtRncEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtRncEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (txtRnc.Text.Length > 11)
            {
                txtRnc.Text = txtRnc.Text.Substring(0, 11);
                txtRnc.SelectionStart = txtRnc.Text.Length;
            }
        }

        private void btnGenerarArchivo_Click(object sender, EventArgs e)
        {
            //aqui se supone que debo crear el archivo xd
        }
    }
}
