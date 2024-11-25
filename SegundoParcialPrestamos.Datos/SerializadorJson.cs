using SegundoParcialPrestamos.Entidades;
using System.Text.Json;
using System.Xml.Serialization;

namespace SegundoParcialPrestamos.Datos
{
    public class SerializadorJson : IArchivo<List<Prestamo>>
    {
        private string nombreArchivo = "prestamos.Json";
        private string rutaArchivo = Environment.CurrentDirectory;
        private string? rutaCompleta;

        public SerializadorJson()
        {
            rutaCompleta = Path.Combine(rutaArchivo, nombreArchivo);
        }

        public void GuardarDatos(List<Prestamo> datos)
        {
            using (var escritor = new StreamWriter(rutaCompleta!))
            {
                SerializadorJson serializadorJson = new SerializadorJson();
                JsonSerializer.Serialize(escritor);
            }
        }


    }
}
