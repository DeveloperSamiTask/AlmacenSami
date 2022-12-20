using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Prj_Capa_Entidad
{
    public class EN_Documento
    {
        private string _idDoc;
        private string _idPedido;
        private int _idTipo;
        private DateTime _FechaDoc;
        private double _Importe;
        private string _TipoPago;
        private string _Nr_Operacion;
        private int _IdUsu;
        private double _Igv;
        private string _SonLetra;
        private double _TotalGanancia;

        public string IdDoc { get => _idDoc; set => _idDoc = value; }
        public string IdPedido { get => _idPedido; set => _idPedido = value; }
        public int IdTipo { get => _idTipo; set => _idTipo = value; }
        public DateTime FechaDoc { get => _FechaDoc; set => _FechaDoc = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string Nr_Operacion { get => _Nr_Operacion; set => _Nr_Operacion = value; }
        public int IdUsu { get => _IdUsu; set => _IdUsu = value; }
        public double Igv { get => _Igv; set => _Igv = value; }
        public string SonLetra { get => _SonLetra; set => _SonLetra = value; }
        public double TotalGanancia { get => _TotalGanancia; set => _TotalGanancia = value; }
    }
}
