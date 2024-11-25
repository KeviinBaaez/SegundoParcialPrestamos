using SegundoParcialPrestamos.Datos;
using SegundoParcialPrestamos.Entidades;
using SegundoParcialPrestamos.Windows.Helpers;

namespace SegundoParcialPrestamos.Windows
{
    public partial class frmPrestamos : Form
    {
        private EntidadFinanciera? entidadFinanciera = new EntidadFinanciera("Kevin");
        public frmPrestamos()
        {
            InitializeComponent();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmPrestamoAE frm = new frmPrestamoAE() { Text = "Nuevo Prestamo" };
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel) return;
            Prestamo prestamo = frm.GetPrestamo();
            if (prestamo is null) return;
            var resultado = entidadFinanciera!.AgregarPrestamo(prestamo);
            if (resultado.exito)
            {
                MessageBox.Show($"{resultado.mensaje}","mensaje", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridHelper.MostrarDatosEnGrilla<Prestamo>(entidadFinanciera!.prestamos!, dgvDatos);
            }
        }
    }
}
