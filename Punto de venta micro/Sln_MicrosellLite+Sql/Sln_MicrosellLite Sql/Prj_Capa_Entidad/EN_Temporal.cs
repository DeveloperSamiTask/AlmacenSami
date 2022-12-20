using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Temporal
    {

        private string _idTemporal;
        private string _fechaEmi;
        private string _nomCliente;
        private string _Ruc;
        private string _direccion;
        private string _subTotal;
        private string _igv;
        private string _total;
        private string _Sonletra;
        private string _vendedor;
        private object _codigoQR;

        public string IdTemporal { get => _idTemporal; set => _idTemporal = value; }
        public string FechaEmi { get => _fechaEmi; set => _fechaEmi = value; }
        public string NomCliente { get => _nomCliente; set => _nomCliente = value; }
        public string Ruc { get => _Ruc; set => _Ruc = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string SubTotal { get => _subTotal; set => _subTotal = value; }
        public string Igv { get => _igv; set => _igv = value; }
        public string Total { get => _total; set => _total = value; }
        public string Sonletra { get => _Sonletra; set => _Sonletra = value; }
        public string Vendedor { get => _vendedor; set => _vendedor = value; }
        public object CodigoQR { get => _codigoQR; set => _codigoQR = value; }
    }
}
