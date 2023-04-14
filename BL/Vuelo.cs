using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static ML.Result GetAll(DateTime fechaInicio, DateTime fechaFin)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezAeromexicoEntities context = new DL.AGutierrezAeromexicoEntities())
                    {
                        var query = context.VueloGetAll(fechaInicio, fechaFin).ToList();


                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultVuelo in query)
                            {
                                ML.Vuelo vuelo = new ML.Vuelo();
                                vuelo.IdVuelo = resultVuelo.IdVuelo;
                                vuelo.NumeroVuelo = resultVuelo.NumeroVuelo;
                                vuelo.Origen = resultVuelo.Origen;
                                vuelo.Destino= resultVuelo.Destino;
                                vuelo.FechaSalida = resultVuelo.FechaSalida.Value;


                                result.Objects.Add(vuelo);
                            }
                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }
        }
    }
}
