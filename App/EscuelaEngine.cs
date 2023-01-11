using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        public void PrintDictionary(Dictionary<DictionaryKeys,IEnumerable<ObjectSchoolBase>> dictionary,
                                    bool printEval = false)
        {
            foreach(var objDic in dictionary)
            {
                Printer.WriteTitle(objDic.Key.ToString());
                foreach(var val in objDic.Value)
                {

                    switch(objDic.Key) {
                        case DictionaryKeys.Evaluacion:
                            if(printEval)
                                Console.WriteLine(val);
                        break;
                        case DictionaryKeys.Escuela:
                            Console.WriteLine(Escuela.Nombre);
                        break;
                        case DictionaryKeys.Alumno:
                            Console.WriteLine(val.Nombre);
                        break;
                        case DictionaryKeys.Asignatura:
                            Console.WriteLine(val.Nombre);
                        break;
                        case DictionaryKeys.Curso:
                            var cursoTemp = val as Curso;
                            if(cursoTemp != null){
                                int count = cursoTemp.Alumnos.Count;
                                Console.WriteLine($"Curso: {val.Nombre} Cantidad de alumnos: {count}");
                            }
                            
                        break;
                        default:
                            Console.WriteLine(val.Nombre);
                        break;
                    }

                }
            }
        }
        public Dictionary<DictionaryKeys, IEnumerable<ObjectSchoolBase>> GetObjectDictionary()
        {

            var dictionary = new Dictionary<DictionaryKeys,IEnumerable<ObjectSchoolBase>>();

            dictionary.Add(DictionaryKeys.Escuela, new[] {Escuela});
            dictionary.Add(DictionaryKeys.Curso, Escuela.Cursos);
            
            var listaTempEvaluciones = new List<Evaluacion>();
            var listaTempAlumnos = new List<Alumno>();
            var listaTempAsignaturas = new List<Asignatura>();

            foreach(var curso in Escuela.Cursos)
            {
                listaTempAsignaturas.AddRange(curso.Asignaturas);
                listaTempAlumnos.AddRange(curso.Alumnos);
                listaTempAlumnos.ForEach(al => 
                    listaTempEvaluciones.AddRange(al.Evaluaciones));
                
            }
            
            dictionary.Add(DictionaryKeys.Asignatura, listaTempAsignaturas);
            dictionary.Add(DictionaryKeys.Alumno, listaTempAlumnos);
            dictionary.Add(DictionaryKeys.Evaluacion, listaTempEvaluciones);

            return dictionary;
        }

        public IReadOnlyList<ObjectSchoolBase> GetObjectosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjectosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjectSchoolBase> GetObjectosEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjectosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjectSchoolBase> GetObjectosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjectosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjectSchoolBase> GetObjectosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            return GetObjectosEscuela(out conteoEvaluaciones, out conteoAsignaturas, out conteoAlumnos, out int dummy);
        }

        public IReadOnlyList<ObjectSchoolBase> GetObjectosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            conteoEvaluaciones = conteoAsignaturas = conteoAlumnos = 0;

            var listaObj = new List<ObjectSchoolBase>();
            listaObj.Add(Escuela);

            if(traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;

            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                
                if(traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);
                
                if(traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if(traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {   
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }

            return listaObj.AsReadOnly();
        }

        // public List<ObjectSchoolBase> GetObjectosEscuela()
        // {
        //     var listaObj = new List<ObjectSchoolBase>();
        //     listaObj.Add(Escuela);
        //     listaObj.AddRange(Escuela.Cursos);

        //     foreach (var curso in Escuela.Cursos)
        //     {
        //         listaObj.AddRange(curso.Asignaturas);
        //         listaObj.AddRange(curso.Alumnos);

        //         foreach (var alumno in curso.Alumnos)
        //         {
        //             listaObj.AddRange(alumno.Evaluaciones);
        //         }
        //     }

        //     return listaObj;
        // }

#region Metodos de carga
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{ Nombre=$"{n1} {n2} {a1}" };
            
            return listaAlumnos.OrderBy( (al)=> al.UniqueId ).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };
            
            Random rnd = new Random();
            foreach(var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var evaluacion = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = MathF.Round(((float)rnd.NextDouble() * 5), 2),
                                Alumno = alumno                            
                            };
                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }
#endregion Metodos de carga
    }
}