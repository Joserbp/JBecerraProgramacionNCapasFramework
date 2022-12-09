using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        //5 
        static public void Add()
        {
            ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Ingrese los datos del Alumno");
            Console.WriteLine("Ingrese el Nombre: ");
            alumno.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el ApellidoPaterno: ");
            alumno.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el ApellidoMaterno: ");
            alumno.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingrese el Grupo: ");
            alumno.Grado = byte.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Fecha de Nacimiento: ");
            alumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            //ML.Result result = BL.Alumno.Add(alumno);
            //ML.Result result = BL.Alumno.AddSP(alumno);
            ML.Result result = BL.Alumno.AddEF(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Alumno Insertado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al insertar" + result.ErrorMessage);
            }
            Console.ReadLine();

        }
        static public void GetAll()
        {
            ML.Result result = BL.Alumno.GetAllEF();

            //for ----- Determinado numero de repeticiones
            //while --- Condicion de salida //Solo se ejecuta si la condicion es verdadera
            //do while --- //Siempre 1 vez
            //foreach -- //Recorrer la totalidad de un arreglo 

            foreach (ML.Alumno alumno in result.Objects)
            {
                Console.WriteLine("El IdAlumno del alumno es: " + alumno.IdAlumno);
                Console.WriteLine("El Nombre del alumno es: " + alumno.Nombre);
                Console.WriteLine("El ApellidoPaterno del alumno es: " + alumno.ApellidoPaterno);
                Console.WriteLine("El ApellidoMaterno del alumno es: " + alumno.ApellidoMaterno);
                Console.WriteLine("El Grado del alumno es: " + alumno.Grado);
                Console.WriteLine("---------------------------------------------");
            }
        }
        static public void GetById()
        {

            Console.WriteLine("Ingrese el Id del Alumno: ");
            int IdAlumno = int.Parse(Console.ReadLine());
            ML.Result result = new ML.Result();

            if (result.Correct)
            {
                ML.Alumno alumno = (ML.Alumno)result.Object; //Unboxing 
                Console.WriteLine("El IdAlumno del alumno es: " + alumno.IdAlumno);
                Console.WriteLine("El Nombre del alumno es: " + alumno.Nombre);
                Console.WriteLine("El ApellidoPaterno del alumno es: " + alumno.ApellidoPaterno);
                Console.WriteLine("El ApellidoMaterno del alumno es: " + alumno.ApellidoMaterno);
                Console.WriteLine("El Grado del alumno es: " + alumno.Grado);
                Console.WriteLine("---------------------------------------------");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }


        }
    }
}
