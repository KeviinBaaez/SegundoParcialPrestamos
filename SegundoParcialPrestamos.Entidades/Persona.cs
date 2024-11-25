using System.Text.RegularExpressions;

namespace SegundoParcialPrestamos.Entidades
{
    public class Persona
    {
        private string? apellido;

        public string? Apellido
        {
            get { return apellido; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    apellido = value;
                }
                else
                {
                    throw new ArgumentException("El apellido es requerido");
                }
            }
        }

        private string? dni;

        public string? Dni
        {
            get { return dni; }
            set
            {
                if(ValidarDni(value))
                {
                    dni = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un dni valido");
                }
            }
        }
        private string? nombre;

        public string? Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
                else
                {
                    throw new ArgumentException("El nombre es requerido");
                }
            }
        }

        public Persona()
        {
            
        }
        public Persona(string? nombre, string? apellido, string? dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;  
        }

        public static bool ValidarDni(string dni)
        {
            string patron = @"^[0-9]{8}$";
            Regex regex = new Regex(patron);
            if (regex.IsMatch(patron))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Apellido}, {Nombre}, {Dni}";
        }

    }
}
