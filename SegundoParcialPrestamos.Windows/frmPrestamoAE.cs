using SegundoParcialPrestamos.Entidades;
using SegundoParcialPrestamos.Windows.Helpers;

namespace SegundoParcialPrestamos.Windows
{
    public partial class frmPrestamoAE : Form
    {
        TipoPrestamo tipoPrestamo;
        Plazo plazosTasas;
        Prestamo? prestamo;
        public frmPrestamoAE()
        {
            InitializeComponent();
            CargarDatosComboPlazos();
        }

        public Prestamo GetPrestamo()
        {
            return prestamo;
        }

        private void rbtDolares_CheckedChanged(object sender, EventArgs e)
        {


        }
        private void CargarDatosComboPlazos()
        {
            var lista = Enum.GetValues(typeof(Plazo)).Cast<Plazo>().ToList();
            cboPlazos.DataSource = lista;
            cboPlazos.SelectedIndex = 0;
        }

        private void rbtPesos_CheckedChanged(object sender, EventArgs e)
        {
            //tipoPrestamo = TipoPrestamo.Pesos;
            //plazosTasas = PrestamoPesos.TasasPorPlazo;
            //cboPlazos.SelectedIndex = 0;
            //MostrarTasaInteres();


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Validardatos())
            {
                if (rbtDolares.Checked)
                {
                    prestamo = new PrestamoDolares();
                    prestamo.Plazo = (Plazo)cboPlazos.SelectedValue!;
                    prestamo.Monto = decimal.Parse(txtMonto.Text);
                    prestamo.Persona = new Persona(txtApellido.Text, txtNombres.Text, txtDni.Text);
                    prestamo.Tipo = TipoPrestamo.Dolares;
                    prestamo.FechaInicio = dtpFecha.Value;
                }
                else
                {
                    prestamo = new PrestamoPesos();
                    prestamo.Plazo = (Plazo)cboPlazos.SelectedValue!;
                    prestamo.Monto = decimal.Parse(txtMonto.Text);
                    prestamo.Persona = new Persona(txtApellido.Text, txtNombres.Text, txtDni.Text);
                    prestamo.Tipo = TipoPrestamo.Dolares;
                    prestamo.FechaInicio = dtpFecha.Value;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private bool Validardatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                valido = false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text)) { valido = false; }
            if (string.IsNullOrEmpty(txtDni.Text)) { valido = false; }
            if (!decimal.TryParse(txtMonto.Text, out var tasa)) { valido = false; }
            return valido;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Persona.ValidarDni(txtDni.Text);
        }

        private void txtTasa_TextChanged(object sender, EventArgs e)
        {
            if (txtMonto.Text.Length == 0)
            {
                txtTasa.Text = "";
            }
            else
            {
                decimal cantidad = decimal.Parse(txtMonto.Text);
                decimal total = PrestamoDolares.ConfigurarTasaIntereses((Plazo)cboPlazos.SelectedValue, cantidad);
                txtTasa.Text = total.ToString();
            }
        }

        private void cboPlazos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosComboPlazos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
