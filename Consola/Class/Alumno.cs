using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Class
{
    public  partial class Alumno
    {
        static int instancias_de_alumnos = 0; //variable estatica para contar las instancias de clase Alumnos
        string nombre;
        string apellido;
        int dni;
        DateOnly fechaNacimiento;
        //Constructor de la clase alumno
        public Alumno()
        {
            
        }
        public Alumno(string nombre, string apellido, int dni = 0, DateOnly fechaNacimiento = new DateOnly())
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.fechaNacimiento = fechaNacimiento;
            instancias_de_alumnos++;
        }
        //Metodo para imprimir la ficha de datos del alumno
        public string ImpresionFichaDeDatos()
        {
            return $"Nombre: {nombre} Apellido: {apellido} \nDNI: {dni} \nFecha de Nacimiento: {fechaNacimiento}";
        }
        public override string ToString()
        {
            return apellido + "" + nombre;
        }
        
    }
}
