using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        //10 metodos
        // 5 EF
        static public ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasDiciembreEntities context = new DL_EF.JBecerraProgramacionNCapasDiciembreEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Grado, alumno.FechaNacimiento);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al insertar el alumno";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
