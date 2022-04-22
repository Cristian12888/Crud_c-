using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudianteCrud.Modelo
{
    internal class Estudiante
    {
        private string Documento;
        private string Nombre;
        private string Apellido;
        private int Edad;
        private string Correo;
        private string Telefono;

        public Estudiante()
        {
            this.Documento = "";
            this.Nombre= "";
            this.Apellido= "";
            this.Edad = 0;
            this.Correo = "";
            this.Telefono = "";
        }

        
        public string Documento1 { get => Documento; set => Documento = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apellido1 { get => Apellido; set => Apellido = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public string Correo1 { get => Correo; set => Correo = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
    }
}
