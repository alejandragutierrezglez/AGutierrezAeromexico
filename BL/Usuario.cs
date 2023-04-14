using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result UsuarioGetByUsername(string username, string password)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AGutierrezAeromexicoEntities context = new DL.AGutierrezAeromexicoEntities())
                    {
                        var query = context.UsuarioGetByUsername(username, password).FirstOrDefault();

                        if (query != null)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.Username = query.Username;
                            usuario.Password = query.Password;

                            result.Object= usuario;
                            
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
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

