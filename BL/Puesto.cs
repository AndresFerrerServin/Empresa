using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Puesto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EmpresaEntities contex = new DL.EmpresaEntities())
                {
                    var usuarios = contex.T_CAT_PUESTOGetall().ToList();
                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Puesto puesto = new ML.Puesto();
                            puesto.IdPuesto = obj.IdPuesto;
                            puesto.Nombre = obj.Nombre;

                            result.Objects.Add(puesto);
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
    }
}
