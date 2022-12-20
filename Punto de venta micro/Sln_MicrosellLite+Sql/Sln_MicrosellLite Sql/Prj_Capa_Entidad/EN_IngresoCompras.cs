using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_IngresoCompras
    {
        //        @idCom char (11),
        //@Nro_Fac_Fisico char (20),
        //@IdProvee char (6),
        //@SubTotal_Com real,
        //@FechaIngre datetime,
        //@TotalCompra real,
        //@IdUsu int,
        //@ModalidadPago varchar(50),
        //@TiempoEspera int,
        //@FechaVence date,
        //@EstadoIngre varchar(20),
        //@RecibiConforme bit,
        //@Datos_Adicional varchar(150),
        //@Tipo_Doc_Compra varchar(12)

        private string _idcompra;
        private string _NroDoc_fisico;
        private string _idproveedor;
        private Double _subtotal;
        private DateTime _fechaIngreso;
        private double _Totalcompra;
        private int _idusu;
        private string _modali_Pago;
        private int _TiempoEspera;
        private DateTime _fechaVence;
        private string _EstadoIngreso;
        private bool _RecibiConforme;
        private string _Datos_Adicional;
        private string _TipoDoc_Compra;

        public string Idcompra { get => _idcompra; set => _idcompra = value; }
        public string NroDoc_fisico { get => _NroDoc_fisico; set => _NroDoc_fisico = value; }
        public string Idproveedor { get => _idproveedor; set => _idproveedor = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public double Totalcompra { get => _Totalcompra; set => _Totalcompra = value; }
        public int Idusu { get => _idusu; set => _idusu = value; }
        public string Modali_Pago { get => _modali_Pago; set => _modali_Pago = value; }
        public int TiempoEspera { get => _TiempoEspera; set => _TiempoEspera = value; }
        public DateTime FechaVence { get => _fechaVence; set => _fechaVence = value; }
        public string EstadoIngreso { get => _EstadoIngreso; set => _EstadoIngreso = value; }
        public bool RecibiConforme { get => _RecibiConforme; set => _RecibiConforme = value; }
        public string Datos_Adicional { get => _Datos_Adicional; set => _Datos_Adicional = value; }
        public string TipoDoc_Compra { get => _TipoDoc_Compra; set => _TipoDoc_Compra = value; }
    }
}
