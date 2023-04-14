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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezAeromexicoEntities context = new DL.AGutierrezAeromexicoEntities())
                    {
                        var query = context.PasajeroGetAll().ToList();


                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultPasajero in query)
                            {
                                ML.Pasajero pasajero = new ML.Pasajero();
                                pasajero.IdPasajero = resultPasajero.IdPasajero;
                                pasajero.Nombre = resultPasajero.Nombre;
                                pasajero.Apellidos = resultPasajero.Apellidos;

                                result.Objects.Add(pasajero);
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

        public static ML.Result VueloPasajeroGetAll()
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezAeromexicoEntities context = new DL.AGutierrezAeromexicoEntities())
                    {
                        var query = context.VuelosPasajerosGetAll().ToList();


                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var resultVuelosPasajeros in query)
                            {
                                ML.Pasajero pasajero = new ML.Pasajero();
                                pasajero.IdPasajero = resultVuelosPasajeros.IdPasajero.Value;
                                pasajero.Nombre = resultVuelosPasajeros.Nombre;
                                pasajero.Apellidos = resultVuelosPasajeros.Apellidos;
                                pasajero.Vuelo = new ML.Vuelo();
                                pasajero.Vuelo.IdVuelo = resultVuelosPasajeros.IdVuelo.Value;
                                pasajero.Vuelo.NumeroVuelo = resultVuelosPasajeros.NumeroVuelo;
                                pasajero.Vuelo.Origen = resultVuelosPasajeros.Origen;
                                pasajero.Vuelo.Destino = resultVuelosPasajeros.Destino;
                                pasajero.Vuelo.FechaSalida = resultVuelosPasajeros.FechaSalida.Value;

                                result.Objects.Add(pasajero);
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
