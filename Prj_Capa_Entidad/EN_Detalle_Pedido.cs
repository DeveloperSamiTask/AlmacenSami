using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Detalle_Pedido
    {

        private string _idPed;
        private string _idProd;
        private double _precio;
        private double _cantidad;
        private double _importe;
        private string _tipoProd;
        private string _und;
        private double _utilidad_Unit;
        private double _totalUtilidad;

        public string IdPed { get => _idPed; set => _idPed = value; }
        public string IdProd { get => _idProd; set => _idProd = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public double Cantidad { get => _cantidad; set => _cantidad = value; }
        public double Importe { get => _importe; set => _importe = value; }
        public string TipoProd { get => _tipoProd; set => _tipoProd = value; }
        public string Und { get => _und; set => _und = value; }
        public double Utilidad_Unit { get => _utilidad_Unit; set => _utilidad_Unit = value; }
        public double TotalUtilidad { get => _totalUtilidad; set => _totalUtilidad = value; }
    }
}
