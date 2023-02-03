using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno : ObjectSchoolBase
    {
        public List<Evaluacion> Evaluaciones{ get; set; }
        public Alumno()
        {
            Evaluaciones = new List<Evaluacion>();
        }
    }
}