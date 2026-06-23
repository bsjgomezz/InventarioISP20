using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public class Estudiante
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre.ToUpper(); }
            set { nombre = value; }
        }
        public string? Domicilio { get; set; }

        public int Edad { get; set; }

        //creamos una propiedad llamada DatosCompletos que concatena todos los datos del estudiante y los devuelve al llamarlos
        public string DatosCompletos
        {
            get { return $"Nombre: {this.Nombre} Edad: {this.Edad} Domicilio: {this.Domicilio}"; }
        }

        public void Saludar()
        {
            Console.WriteLine($"Hola, soy estudiante, me llamo {this.Nombre} y tengo {this.Edad} años.");
            //si llamo a la propiedad aplica las mayúsculas, si llamo al campo(nombre) no se aplican las mayúsculas.
        }
        public override string ToString()
        {
            return base.ToString();
        }
    
    }
}
