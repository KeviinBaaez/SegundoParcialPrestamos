using System.Text;

namespace SegundoParcialPrestamos.Entidades
{
    public abstract class Prestamo
    {
        public DateTime FechaInicio { get; set; }
        public decimal Monto { get; set; }
        public Guid PrestamoNro { get; set; }
        public decimal TasaInteres { get; set; }
        public Persona? Persona { get; set; }
        public TipoPrestamo Tipo { get; set; }
        public Plazo Plazo { get; set; }

        public Prestamo()
        {
            
        }
        public Prestamo(Persona persona, decimal monto, Plazo periodo, DateTime fechaInicio, decimal tasa, TipoPrestamo tipo) : this()
        {
            Persona = persona;
            Monto = monto;
            FechaInicio = fechaInicio;
            TasaInteres = tasa;
            PrestamoNro = Guid.NewGuid();
            Tipo = tipo;
            Plazo = periodo;
        }

        public virtual void ConfigurarTasaIntereses(Plazo plazo, decimal tasa)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Tipo}");
            sb.AppendLine($"{FechaInicio}");
            sb.AppendLine($"{Monto}");
            sb.AppendLine($"{TasaInteres}");
            sb.AppendLine($"{Plazo}");
            return sb.ToString();
        }

    }
}
