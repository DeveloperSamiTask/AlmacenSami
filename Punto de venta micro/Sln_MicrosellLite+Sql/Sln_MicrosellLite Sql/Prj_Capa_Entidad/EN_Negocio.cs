using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Negocio
    {
        private int idNegocio;
        private string razon_Social;
        private string rUC;
        private string direccion;
        private string telefono;
        private string correo;

        public int IdNegocio { get => idNegocio; set => idNegocio = value; }
        public string Razon_Social { get => razon_Social; set => razon_Social = value; }
        public string RUC { get => rUC; set => rUC = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
