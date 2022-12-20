using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Caja
    {
               

        private DateTime _Fecha_Caja;
        private string _Tipo_Caja;
        private string _Concepto;
        private string _DePara_Cliente;
        private string _Nr_Documento;
        private double _ImporteCaja;
        private int _Idusu;
        private double _TotalUtilidad;
        private string _TipoPago;
        private string _GeneradoPor;

        public DateTime Fecha_Caja { get => _Fecha_Caja; set => _Fecha_Caja = value; }
        public string Tipo_Caja { get => _Tipo_Caja; set => _Tipo_Caja = value; }
        public string Concepto { get => _Concepto; set => _Concepto = value; }
        public string DePara_Cliente { get => _DePara_Cliente; set => _DePara_Cliente = value; }
        public string Nr_Documento { get => _Nr_Documento; set => _Nr_Documento = value; }
        public double ImporteCaja { get => _ImporteCaja; set => _ImporteCaja = value; }
        public int Idusu { get => _Idusu; set => _Idusu = value; }
        public double TotalUtilidad { get => _TotalUtilidad; set => _TotalUtilidad = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string GeneradoPor { get => _GeneradoPor; set => _GeneradoPor = value; }
    }
}
