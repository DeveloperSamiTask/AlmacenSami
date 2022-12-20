using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Cliente
    {

        private string _idcliente;
        private string _razonsocial;
        private string _dni;
        private string _direccion;
        private string _telefono;
        private string _email;
        private int _Iddis;
        private DateTime _fechaaniver;
        private string _contacto;
        private double _LimiteCredito;

        public string Idcliente { get => _idcliente; set => _idcliente = value; }
        public string Razonsocial { get => _razonsocial; set => _razonsocial = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public int Iddis { get => _Iddis; set => _Iddis = value; }
        public DateTime Fechaaniver { get => _fechaaniver; set => _fechaaniver = value; }
        public string Contacto { get => _contacto; set => _contacto = value; }
        public double LimiteCredito { get => _LimiteCredito; set => _LimiteCredito = value; }
    }
}
