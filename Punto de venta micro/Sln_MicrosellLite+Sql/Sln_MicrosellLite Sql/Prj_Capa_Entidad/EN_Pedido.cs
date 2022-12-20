using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Pedido
    {

        private string _idPedido;
        private string _idCliente;
        private double _subTotal;
        private DateTime _FechaPed;
        private double _Igv;
        private double _TotalPed;
        private int _idUsu;
        private double _TotalGanancia;

        public string IdPedido { get => _idPedido; set => _idPedido = value; }
        public string IdCliente { get => _idCliente; set => _idCliente = value; }
        public double SubTotal { get => _subTotal; set => _subTotal = value; }
        public DateTime FechaPed { get => _FechaPed; set => _FechaPed = value; }
        public double Igv { get => _Igv; set => _Igv = value; }
        public double TotalPed { get => _TotalPed; set => _TotalPed = value; }
        public int IdUsu { get => _idUsu; set => _idUsu = value; }
        public double TotalGanancia { get => _TotalGanancia; set => _TotalGanancia = value; }
    }
}
