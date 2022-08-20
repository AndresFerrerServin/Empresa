using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EmpresaEntities contex = new DL.EmpresaEntities())
                {
                    var usuarios = contex.T_EMPLEADOSGetAll().ToList();
                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.Id_NumEmp = obj.Id_NumEmp;
                            empleado.Nombre = obj.Nombre;
                            empleado.Apellido_Paterno = obj.Apellido_Paterno;
                            empleado.Apellido_Materno = obj.Apellido_Materno;

                            empleado.Puesto = new ML.Puesto();
                            empleado.Puesto.IdPuesto = obj.IdPuesto;
                            empleado.Puesto.Nombre = obj.Nombre_Puesto;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpresaEntities context = new DL.EmpresaEntities())
                {

                    var query = context.T_EMPLEADOSAdd(empleado.Nombre, empleado.Apellido_Paterno,empleado.Apellido_Materno,empleado.Puesto.IdPuesto);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto el registro";
                    }
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpresaEntities context = new DL.EmpresaEntities())
                {
                    var query = context.T_EMPLEADOSUpdate(empleado.Id_NumEmp, empleado.Nombre, empleado.Apellido_Paterno,empleado.Apellido_Materno,empleado.Puesto.IdPuesto);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpresaEntities context = new DL.EmpresaEntities())
                {
                    var query = context.T_EMPLEADOSDelete(empleado.Id_NumEmp);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }
        public static ML.Result GetById(int Id_NumEmp)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EmpresaEntities context = new DL.EmpresaEntities())
                {
                    var query = context.T_EMPLEADOSGetById(Id_NumEmp).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.Id_NumEmp = query.Id_NumEmp;
                        empleado.Nombre = query.Nombre;
                        empleado.Apellido_Paterno = query.Apellido_Paterno;
                        empleado.Apellido_Materno = query.Apellido_Materno;

                        empleado.Puesto = new ML.Puesto();
                        empleado.Puesto.IdPuesto = query.IdPuesto;
                        empleado.Puesto.Nombre = query.Nombre_Puesto;

                        result.Object = empleado;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
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
