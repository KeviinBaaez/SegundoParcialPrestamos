namespace SegundoParcialPrestamos.Datos
{
    public interface IArchivo<T> where T : class
    {
        void GuardarDatos(T datos);
    }
}
