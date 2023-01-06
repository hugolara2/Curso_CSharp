using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;
using System.Linq;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            ImpimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjectosEscuela();

            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            diccionario.Add(1, "Ipso lorem");
            diccionario.Add(2, "Hugo Lara");
            diccionario.Add(3, "Karen Ruiz");

            foreach (var keyValPair in diccionario)
            {
                Console.WriteLine($"Key: {keyValPair.Key} Value: {keyValPair.Value}");
            }

            var dictmp = engine.GetObjectDictionary();
            engine.PrintDictionary(dictmp);
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {
            
            Printer.WriteTitle("Cursos de la Escuela");
            
            
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }
    }
}
