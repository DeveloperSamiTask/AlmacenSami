using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Productos
    {
        private string _idpro;
        private string _idprove;
        private string _codigo;
        private string _modelo;
        private string _descripcion;
        private double _frank;
        private double _PreCompra_Sol;
        private double _PreCompra_Dlr;
        private double _stock;
        private int _idcat;
        private int _idmark;
        private string _foto;
        private double _PreVenta_Mnr;
        private double _PreVenta_Myr;
        private double _PreVenta_Dolr;
        private string _UndMedida;
        private double _PesoUnit;
        private double _UtilidadUnit;
        private string _TipoProduct;
        private double _valorGeneral;

        public string Idprove { get => _idprove; set => _idprove = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Frank { get => _frank; set => _frank = value; }
        public double PreCompra_Sol { get => _PreCompra_Sol; set => _PreCompra_Sol = value; }
        public double PreCompra_Dlr { get => _PreCompra_Dlr; set => _PreCompra_Dlr = value; }
        public double Stock { get => _stock; set => _stock = value; }
        public int Idcat { get => _idcat; set => _idcat = value; }
        public int Idmark { get => _idmark; set => _idmark = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public double PreVenta_Mnr { get => _PreVenta_Mnr; set => _PreVenta_Mnr = value; }
        public double PreVenta_Myr { get => _PreVenta_Myr; set => _PreVenta_Myr = value; }
        public double PreVenta_Dolr { get => _PreVenta_Dolr; set => _PreVenta_Dolr = value; }
        public string UndMedida { get => _UndMedida; set => _UndMedida = value; }
        public double PesoUnit { get => _PesoUnit; set => _PesoUnit = value; }
        public double UtilidadUnit { get => _UtilidadUnit; set => _UtilidadUnit = value; }
        public string TipoProduct { get => _TipoProduct; set => _TipoProduct = value; }
        public double ValorGeneral { get => _valorGeneral; set => _valorGeneral = value; }
        public string Idpro { get => _idpro; set => _idpro = value; }
    }
}
