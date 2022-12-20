using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_CierreCaja
    {
        private string _idcierre;
        private double _aperturCaja;
        private double _totalIngreso;
        private double _totalEgreso;
        private double _totalDeposito;
        private int _idUsu;
        private double _totalGanancia;
        private double _totalEntregado;
        private double _saldoSiguiente;
        private double _totalFactura;
        private double _totalBoleta;
        private double _totalNota;
        private double _totalCreditoCobrado;
        private double _totalCreditoEmitido;

        public string Idcierre { get => _idcierre; set => _idcierre = value; }
        public double AperturCaja { get => _aperturCaja; set => _aperturCaja = value; }
        public double TotalIngreso { get => _totalIngreso; set => _totalIngreso = value; }
        public double TotalEgreso { get => _totalEgreso; set => _totalEgreso = value; }
        public double TotalDeposito { get => _totalDeposito; set => _totalDeposito = value; }
        public int IdUsu { get => _idUsu; set => _idUsu = value; }
        public double TotalGanancia { get => _totalGanancia; set => _totalGanancia = value; }
        public double TotalEntregado { get => _totalEntregado; set => _totalEntregado = value; }
        public double SaldoSiguiente { get => _saldoSiguiente; set => _saldoSiguiente = value; }
        public double TotalFactura { get => _totalFactura; set => _totalFactura = value; }
        public double TotalBoleta { get => _totalBoleta; set => _totalBoleta = value; }
        public double TotalNota { get => _totalNota; set => _totalNota = value; }
        public double TotalCreditoCobrado { get => _totalCreditoCobrado; set => _totalCreditoCobrado = value; }
        public double TotalCreditoEmitido { get => _totalCreditoEmitido; set => _totalCreditoEmitido = value; }
    }
}
