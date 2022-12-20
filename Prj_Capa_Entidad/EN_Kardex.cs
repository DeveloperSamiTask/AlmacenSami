using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Kardex
    {

        //        @Id_Krdx char (11),
        //@Item int,
        //@Fecha_Krdx Date,
        //@Doc_Soport nchar(29),
        //@Det_Operacion varchar(50),
        //--entrada
        //@Cantidad_In Real,
        //@Precio_Unt_In Real,
        //@Costo_Total_In Real,
        //--salida
        //@Cantidad_Out Real,
        //@Precio_Unt_Out Real,
        //@Importe_Total_Out Real,
        //--saldo
        //@Cantidad_Saldo Real,
        //@Promedio Real,
        //@Costo_Total_Saldo Real

        private string _idkardex;
        private int _item;
        private string _doc_soporte;
        private string _det_operacion;
        private double _cantidad_in;
        private double _precio_in;
        private double _total_in;

        private double _cantidad_out;
        private double _precio_out;
        private double _total_out;

        private double _cantidad_saldo;
        private double _promedio;
        private double _total_saldo;

        public string Idkardex { get => _idkardex; set => _idkardex = value; }
        public string Doc_soporte { get => _doc_soporte; set => _doc_soporte = value; }
        public string Det_operacion { get => _det_operacion; set => _det_operacion = value; }
        public double Cantidad_in { get => _cantidad_in; set => _cantidad_in = value; }
        public double Precio_in { get => _precio_in; set => _precio_in = value; }
        public double Total_in { get => _total_in; set => _total_in = value; }
        public double Cantidad_out { get => _cantidad_out; set => _cantidad_out = value; }
        public double Precio_out { get => _precio_out; set => _precio_out = value; }
        public double Total_out { get => _total_out; set => _total_out = value; }
        public double Cantidad_saldo { get => _cantidad_saldo; set => _cantidad_saldo = value; }
        public double Promedio { get => _promedio; set => _promedio = value; }
        public double Total_saldo { get => _total_saldo; set => _total_saldo = value; }
        public int Item { get => _item; set => _item = value; }
    }
}
