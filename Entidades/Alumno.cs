using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno : ObjectSchoolBase
    {
        public List<Evaluacion> evaluaciones{ get; set; }
        public Alumno()
        {
            evaluaciones = new List<Evaluacion>();
        }
    }
}