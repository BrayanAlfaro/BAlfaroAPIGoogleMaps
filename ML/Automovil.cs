using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Automovil
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public List<object> Automoviles { get; set; }
        public string LatitudInicial { get; set; }
        public string LongitudInicial { get; set; }
        public string LatitudFinal { get; set; }
        public string LongitudFinal { get; set; }
        public string Accion { get; set; }
    }
}
