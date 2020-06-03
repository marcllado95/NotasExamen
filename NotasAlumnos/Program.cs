using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NotasAlumnos
{
    class Program
    {
        static string EscapeWord = "exit";

        static void Main(string[] args)
        {
            Console.WriteLine("Introduce las notas de cada alumno \n");

            var notasdealumnos = new List<double>();

            bool seguir = true;

            while (seguir)
            {
                Console.WriteLine($"Nota del alumno {notasdealumnos.Count + 1}:");
                var notaText = Console.ReadLine();

                if(notaText == EscapeWord)
                {
                    seguir = false;
                }
                notaText = notaText.Replace(".", ",");  //para que coja buenos tanto los decimales con coma como con punto

                var nota = 0.0;

                if (double.TryParse(notaText, out nota))  // para detectar que es un numero, hacemos un if de: si la conversión a double ha ido bien...
                {
                    notasdealumnos.Add(nota);
                }
                else
                    Console.WriteLine("La nota es incorrecta melón");
            }

            double suma = 0.0, avg = 0.0, max = 0.0, min = 100.00;
            for (int i = 0; i < notasdealumnos.Count; i++)
            {
                suma += notasdealumnos[i];

                if (notasdealumnos[i] < min)
                    min = notasdealumnos[i];
                else if (notasdealumnos[i] > max)
                    max = notasdealumnos[i];
            }
            avg = suma / notasdealumnos.Count;
            Console.WriteLine($"La nota media es {avg}");
            Console.WriteLine($"La mejor nota es un {max}");
            Console.WriteLine($"La peor nota es un {min}");
        }
    }
}
