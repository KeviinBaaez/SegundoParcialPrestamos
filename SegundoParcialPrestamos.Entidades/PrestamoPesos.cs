namespace SegundoParcialPrestamos.Entidades
{
    public class PrestamoPesos : Prestamo
    {
        public Dictionary<Plazo, decimal>? TazaPorPlazo{ get; }
        public PrestamoPesos()
        {
            
        }
        public PrestamoPesos(Persona persona, decimal monto, Plazo plazo, DateTime fechaInicio, decimal tasa, TipoPrestamo tipo):base(persona, monto, plazo, fechaInicio, tasa, tipo)
        {
            tipo = TipoPrestamo.Pesos;
        }
        public void ConfigurarTasaIntereses(Plazo plazo, decimal tasa)
        {
            if (plazo == Plazo.DoceMeses)
            {
                tasa = 25;
            }
            else if (plazo == Plazo.VeinticuatroMeses)
            {
                tasa = 30;
            }
            else if (plazo == Plazo.TreintaYSeisMeses)
            {
                tasa = 35;
            }
            else
            {
                tasa = 40;
            }
        }
    }
}
