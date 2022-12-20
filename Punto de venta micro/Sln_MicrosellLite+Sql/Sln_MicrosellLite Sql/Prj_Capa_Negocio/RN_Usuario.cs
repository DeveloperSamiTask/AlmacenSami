using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;

namespace Prj_Capa_Negocio
{
    public class RN_Usuario
    {
        BD_Usuario obj=new BD_Usuario();
        public bool RN_Login(string usu, string clave)
        {
           return obj.BD_Login(usu, clave);
        }
        public DataTable RN_Buscar_Usuario(string nomusu)
        {
            return obj.BD_Buscar_Usuario(nomusu);

        }

        public void RN_Insertar_Usuario(EN_Roles rol)
        {
            obj.BD_Insertar_Usuario(rol);
        }

        public void BD_Editar_Usuario(EN_Roles rol)
        {
            obj.BD_Editar_Usuario(rol);
        }

        public void RN_Eliminar_Usuario(string idRol)
        {
            obj.BD_Eliminar_Usuario(idRol);
        }

        public String GenerarCodigo(string tabla)
        {
            return obj.GenerarCodigo(tabla);
        }
        public DataTable RN_Cargar_Todos_Usuario()
        {
            return obj.BD_Cargar_Todos_Usuarios();
        }

        public DataTable BD_Buscar_Usuario_Valor(string valor)
        {
            return obj.BD_Buscar_Usuario_Valor(valor);
        }
    }
}
