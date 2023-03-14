using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primerTarea
{
    class Program
    {
        static void Main(string[] args)
        {
            // Defino las tres Variables
            int myInteger = 32;
            string myString = "Hola!. Estoy resolviendo la primer tarea";
            DateTime myDateTime = DateTime.Now;

            // Muestro las variables por Consola
            Console.WriteLine($"{myString}.\n" +
                $"El numero de mi entero es {myInteger}");
            Console.WriteLine($"La fecha de hoy es: " + 
                myDateTime.ToString("dd/MM/yy") + " y son las " + myDateTime.ToString(" hh:mm tt"));

            // Confirmo que Hice la tarea
            Console.WriteLine("\t------------------------------------------");
            Console.WriteLine("\tHice la primer tarea del bootcamp de .net");
            Console.WriteLine("\t------------------------------------------");
            Console.ReadKey();
        }
    }
}
