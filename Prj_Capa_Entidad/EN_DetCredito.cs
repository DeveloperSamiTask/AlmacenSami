using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_DetCredito
    {
        private string _IdNotaCredito;
        private double _Acuenta;
        private double _SaldoActual;
        private DateTime _FechaPago;
        private string _TipoPago;
        private string _NroOpera;
        private int _IdUsu;

        public string IdNotaCredito { get => _IdNotaCredito; set => _IdNotaCredito = value; }
        public double Acuenta { get => _Acuenta; set => _Acuenta = value; }
        public DateTime FechaPago { get => _FechaPago; set => _FechaPago = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string NroOpera { get => _NroOpera; set => _NroOpera = value; }
        public int IdUsu { get => _IdUsu; set => _IdUsu = value; }
        public double SaldoActual { get => _SaldoActual; set => _SaldoActual = value; }
    }
}
