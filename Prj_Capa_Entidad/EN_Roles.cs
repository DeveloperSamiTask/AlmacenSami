using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Roles
    {
        private int _idUsu;
        private string _Nombres;
        private string _Apellidos;
        private int _idDis;
        private string _Usuario;
        private string _Contraseña;
        private string _Foto;
        private DateTime _fechaaniver;
        private int _idRol;
        private string _Correo;
        private string _Estado;

        public int IdUsu { get => _idUsu; set => _idUsu = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public int IdDis { get => _idDis; set => _idDis = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public string Foto { get => _Foto; set => _Foto = value; }
        public DateTime Fechaaniver { get => _fechaaniver; set => _fechaaniver = value; }
        public int IdRol { get => _idRol; set => _idRol = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
