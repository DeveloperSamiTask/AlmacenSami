using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Det_IngresoCompra
    {
        private string _id_Ingreso;
        private string _idproducto;
        private double _precio;
        private double _cantidad;
        private double _importe;

        public string Id_Ingreso { get => _id_Ingreso; set => _id_Ingreso = value; }
        public string Idproducto { get => _idproducto; set => _idproducto = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public double Cantidad { get => _cantidad; set => _cantidad = value; }
        public double Importe { get => _importe; set => _importe = value; }
    }
}
