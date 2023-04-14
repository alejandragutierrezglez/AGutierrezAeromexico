using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Reservacion
    {
        public int IdReservacion { get; set; }
        public ML.Pasajero Pasajero { get; set; }
        public ML.Vuelo Vuelo { get; set; }
    }
}
