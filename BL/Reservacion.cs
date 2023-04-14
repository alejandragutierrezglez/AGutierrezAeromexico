using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Reservacion
    {
        public static ML.Result ReservacionAdd(int idPasajero, int idVuelo)
        {
            using (DL.AGutierrezAeromexicoEntities context = new DL.AGutierrezAeromexicoEntities())
            {
                Result result = new ML.Result();
                try
                {
                    var query = context.ReservacionAdd(idPasajero, idVuelo);

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
