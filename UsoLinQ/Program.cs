using System;
using System.Collections.Generic;
using System.Linq;

namespace UsoLinQ
{
    internal class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal Salario { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var empleados = new List<Empleado>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Ingrese información para el empleado {i + 1}:");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                string apellido = Console.ReadLine();

                Console.Write("Salario: ");
                decimal salario = Convert.ToDecimal(Console.ReadLine());

                empleados.Add(new Empleado
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Salario = salario
                });

                Console.Clear();
            }

            var empleadosFiltrados = from emp in empleados
                                     where emp.Salario >= 4000 && emp.Salario <= 6000
                                     select emp;

            Console.WriteLine("\nEmpleados con salarios entre 4000 y 6000:");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("|   Nombre   |   Apellido   |   Salario   |");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var emp in empleadosFiltrados)
            {
                Console.WriteLine($"| {emp.Nombre,-10} | {emp.Apellido,-12} | {emp.Salario,-10:C} |");
            }
            Console.WriteLine("------------------------------------------------------------");

            var salariosFiltrados = from emp in empleados
                                    where emp.Salario >= 4000 && emp.Salario <= 6000
                                    select emp.Salario;

            Console.WriteLine("\nSalarios entre 4000 y 6000:");
            foreach (var salario in salariosFiltrados)
            {
                Console.Write($"{salario:C} ");
            }
            Console.WriteLine();

            var empleadosOrdenados = from emp in empleados
                                     orderby emp.Apellido, emp.Nombre
                                     select emp;

            Console.WriteLine("\nEmpleados ordenados por apellido, nombres:");
            foreach (var emp in empleadosOrdenados)
            {
                Console.WriteLine($"{emp.Apellido}, {emp.Nombre} - {emp.Salario:C}");
            }

            var primerEmpleado = empleadosOrdenados.First();
            Console.WriteLine("\nPrimer empleado del listado anterior:");
            Console.WriteLine($"{primerEmpleado.Apellido}, {primerEmpleado.Nombre} - {primerEmpleado.Salario:C}");

            var apellidos = from emp in empleados
                            select emp.Apellido;

            Console.WriteLine("\nApellidos de los empleados (sin ordenar):");
            foreach (var apellido in apellidos)
            {
                Console.Write($"{apellido} ");
            }
            Console.WriteLine();

            var apellidosUnicos = apellidos.Distinct();

            Console.WriteLine("\nApellidos únicos de los empleados:");
            foreach (var apellido in apellidosUnicos)
            {
                Console.Write($"{apellido} ");
            }
            Console.WriteLine();

            Console.WriteLine("\n\nPresione Enter para salir.");
            Console.ReadLine();
        }
    }
}
