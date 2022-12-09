using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso : ObjectSchoolBase, ILugar
    {
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }
        public string Direccion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Se esta limpiando el curso...");
            Console.WriteLine($"El curso {Nombre} esta limpio");
        }
    }
}