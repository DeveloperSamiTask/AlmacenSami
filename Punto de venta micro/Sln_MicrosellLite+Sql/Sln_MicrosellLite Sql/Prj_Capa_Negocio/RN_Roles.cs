using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Roles
    {
        BD_Roles obj = new BD_Roles();

        public void RN_Registrar_Roles(string nomRol)
        {
            obj.BD_Registrar_Roles(nomRol);
        }

        public void RN_Editar_Roles(int idrol, string nomrol)
        {
            obj.BD_Editar_Roles(idrol,nomrol);
        }

        public void RN_Eliminar_Roles(int idrol)
        {
            obj.BD_Eliminar_Roles(idrol);
        }
        public DataTable RN_Cargar_Todas_Roles()
        {
            return obj.BD_Cargar_Todas_Roles();
        }
    }
}
