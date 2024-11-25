namespace SegundoParcialPrestamos.Entidades
{
    public class PrestamoDolares : Prestamo
    {
        public Dictionary<Plazo, decimal>? TazaPorPlazo { get; }
        public PrestamoDolares()
        {

        }
        public PrestamoDolares(Persona persona, decimal monto, Plazo plazo, DateTime fechaInicio, decimal tasa, TipoPrestamo tipo) : base(persona, monto, plazo, fechaInicio, tasa, tipo)
        {
            tipo = TipoPrestamo.Dolares;
        }

        public static new decimal ConfigurarTasaIntereses(Plazo plazo, decimal monto)
        {
            decimal total = 0;
            if(plazo == Plazo.DoceMeses)
            {
                total = monto * 5 ;
            }
            else if(plazo == Plazo.VeinticuatroMeses)
            {
                total = monto * 6;
            }
            else if(plazo == Plazo.TreintaYSeisMeses)
            {
                total =monto * 7;
            }
            else
            {
                total = monto * 8;
            }
            return total;
        }


    }
}
