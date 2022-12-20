using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
   public class EN_Credito
    {
        private string _IdCredito;
        private string _IdDoc;
        private DateTime _FechaCredito;
        private string _NomCliente;
        private double __TotalCredito;
        private double _Saldo_Pndte;
        private DateTime _Fecha_Vencimiento;

        public string IdCredito { get => _IdCredito; set => _IdCredito = value; }
        public string IdDoc { get => _IdDoc; set => _IdDoc = value; }
        public DateTime FechaCredito { get => _FechaCredito; set => _FechaCredito = value; }
        public string NomCliente { get => _NomCliente; set => _NomCliente = value; }
        public double TotalCredito { get => __TotalCredito; set => __TotalCredito = value; }
        public double Saldo_Pndte { get => _Saldo_Pndte; set => _Saldo_Pndte = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }
    }
}
