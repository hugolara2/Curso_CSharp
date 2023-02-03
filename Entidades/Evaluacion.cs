using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion : ObjectSchoolBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura  { get; set; }

        public float Nota { get; set; }
    }
}