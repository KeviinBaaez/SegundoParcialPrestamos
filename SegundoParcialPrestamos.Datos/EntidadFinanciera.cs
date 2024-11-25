using SegundoParcialPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcialPrestamos.Datos
{
    public class EntidadFinanciera
    {
        private static string? nombre;
        public List<Prestamo>? prestamos;

        private EntidadFinanciera()
        {
            prestamos = new List<Prestamo>();
        }
        static EntidadFinanciera()
        {
            nombre = "Kevin";
        }
        public EntidadFinanciera(string nombre):this()
        {
            
        }

        public (bool exito, string mensaje) AgregarPrestamo(Prestamo prestamo)
        {
            if (!ExistePrestamo(prestamo))
            {
                prestamos!.Add(prestamo);
                return (true, prestamo.ToString());
            }
            else
            {
                return (false, "Este prestamo ya existe");
            }
        }

        //public Prestamo GetPrestamo(Guid prestamoNro)
        //{
        //    var estaPrestamo = prestamos.Any(p => p.PrestamoNro == prestamoNro);
        //    if (estaPrestamo)
        //    {
        //        foreach (var p in prestamos)
        //        {
        //            p.PrestamoNro = prestamoNro;
        //            return p;
        //        }
        //    }
        //}

        private bool ExistePrestamo(Prestamo prestamo)
        {
            var existe = prestamos!.Any(p => p.Persona == prestamo.Persona && p.FechaInicio == prestamo.FechaInicio &&
            p.Monto == prestamo.Monto && p.Plazo == prestamo.Plazo && p.Monto == prestamo.Monto);
            return existe;
        }
    }
}
