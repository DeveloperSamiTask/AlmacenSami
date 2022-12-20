using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    
    public class RN_Distritos
    {

        BD_Distritos obj = new BD_Distritos();

        public void RN_Registrar_Distritos(string nomDis)
        {
            obj.BD_Registrar_Distritos(nomDis);
        }

        public void RN_Editar_Distrito(int IdDis, string nomDis)
        {
            obj.BD_Editar_Distrito(IdDis, nomDis);
        }

        public void RN_Eliminar_Distritos(int idmar)
        {
            obj.BD_Eliminar_Distritos(idmar);
        }

        public DataTable RN_Cargar_Todas_Distritos()
        {
            return obj.BD_Cargar_Todas_Distritos();
        }
    }
}
