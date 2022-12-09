using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjectSchoolBase, ILugar
    {
        public int AñoDeCreación { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);

        public Escuela(string nombre, int año, 
                       TiposEscuela tipo, 
                       string pais = "", string ciudad = "") : base()
        {
            (Nombre, AñoDeCreación) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Se esta limpiando el establecimiento");
            foreach(var curso in Cursos)
            {   
                curso.LimpiarLugar();
            }
            Console.WriteLine($"La escuela {Nombre} esta limpia");
        }
    }
}
