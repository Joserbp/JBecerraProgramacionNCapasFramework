using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BL
{
    public class Alumno   //15 metodos LINQ
    {
        static public ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "INSERT INTO [Almno]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Grado])VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Grado)";

                    SqlParameter[] collection = new SqlParameter[4];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = alumno.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = alumno.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoMaterno;
                    collection[3] = new SqlParameter("Grado", SqlDbType.TinyInt);
                    collection[3].Value = alumno.Grado;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
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
        static public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [IdAlumno],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Grado] FROM [Alumno]";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable alumnoTable = new DataTable();

                    da.Fill(alumnoTable);

                    if (alumnoTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in alumnoTable.Rows)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            alumno.Grado = byte.Parse(row[4].ToString());

                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla Alumno";
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
        static public ML.Result AddSP(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "AlumnoDelete";
                    // AlumnoAdd 3
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[4];
                    collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[0].Value = alumno.Nombre;
                    collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = alumno.ApellidoPaterno;
                    collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoMaterno;
                    collection[3] = new SqlParameter("Grado", SqlDbType.TinyInt);
                    //collection[3].Value = alumno.Grado;

                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al insertar el alumno";
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
        static public ML.Result GetByIdSP(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "AlumnoGetById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                    collection[0].Value = IdAlumno;

                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable alumnoTable = new DataTable();

                    da.Fill(alumnoTable);

                    if (alumnoTable.Rows.Count > 0)
                    {
                        DataRow row = alumnoTable.Rows[0];

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = int.Parse(row[0].ToString());
                        alumno.Nombre = row[1].ToString();
                        alumno.ApellidoPaterno = row[2].ToString();
                        alumno.ApellidoMaterno = row[3].ToString();
                        alumno.Grado = byte.Parse(row[4].ToString());

                        result.Object = alumno; //BOXING

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla Alumno";
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
        static public ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasDiciembreEntities context = new DL_EF.JBecerraProgramacionNCapasDiciembreEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.Grado, alumno.FechaNacimiento) ;

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
        static public ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.JBecerraProgramacionNCapasDiciembreEntities context = new DL_EF.JBecerraProgramacionNCapasDiciembreEntities())
                {
                    var query = context.AlumnoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        
                        foreach (var objAlumno in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = objAlumno.IdAlumno;
                            alumno.Nombre = objAlumno.NombreAlumno; 
                            alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                            alumno.ApellidoMaterno = objAlumno.ApellidoMaterno;
                            alumno.Grado = byte.Parse(objAlumno.Grado);
                            alumno.FechaNacimiento = objAlumno.FechaNacimiento.ToString("dd-M-yy");
                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre = objAlumno.IdSemestre.Value;
                            alumno.Semestre.Nombre = objAlumno.NombreSemestre;


                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla Alumno";
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
        static public ML.Result GetByIdEF(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.JBecerraProgramacionNCapasDiciembreEntities context = new DL_EF.JBecerraProgramacionNCapasDiciembreEntities())
                {
                    var objAlumno = context.AlumnoGetById(IdAlumno).Single();


                    if (objAlumno != null)
                    {

                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = objAlumno.IdAlumno;
                        alumno.Nombre = objAlumno.Nombre;
                        alumno.ApellidoPaterno = objAlumno.ApellidoPaterno;
                        alumno.ApellidoMaterno = objAlumno.ApellidoMaterno; 
                        alumno.Grado = byte.Parse(objAlumno.Grado);
                        alumno.FechaNacimiento = objAlumno.FechaNacimiento.ToString();

                        result.Object = alumno;

                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla Alumno";
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

        static public ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasDiciembreEntities context = new DL_EF.JBecerraProgramacionNCapasDiciembreEntities())  
                {
                    var query = (from alumnos in context.Alumnoes where alumnos.IdAlumno == 6 select alumnos).Single();
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }
        static public ML.Result AddLINQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.JBecerraProgramacionNCapasDiciembreEntities context = new DL_EF.JBecerraProgramacionNCapasDiciembreEntities())
                {
                    DL_EF.Alumno alumnoLINQ = new DL_EF.Alumno();
                    alumnoLINQ.Nombre = alumno.Nombre;
                    alumnoLINQ.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumnoLINQ.ApellidoMaterno = alumno.ApellidoMaterno;
                    alumnoLINQ.Grado = alumno.Grado.ToString();
                    alumnoLINQ.FechaNacimiento = DateTime.ParseExact(alumno.FechaNacimiento,"dd-MM-yyyy",CultureInfo.InvariantCulture); // MM/dd/yyyy dd-MM-yyy
                    alumnoLINQ.IdSemestre = alumno.Semestre.IdSemestre;

                    context.Alumnoes.Add(alumnoLINQ);
                    context.SaveChanges();

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }
    }
}
