using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pasajero
    {
        public static ML.Result AddEF(ML.Pasajero pasajero)
        {
            using (DL.AGutierrezAeromexicoEntities context = new DL.AGutierrezAeromexicoEntities())
            {
                Result result = new ML.Result();
                try
                {

                    var query = context.PasajeroAdd(pasajero.Nombre,pasajero.Apellidos);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                    result.Ex = ex;
                    result.Correct = false;
                }
                return result;

            }
        }
    }
}
