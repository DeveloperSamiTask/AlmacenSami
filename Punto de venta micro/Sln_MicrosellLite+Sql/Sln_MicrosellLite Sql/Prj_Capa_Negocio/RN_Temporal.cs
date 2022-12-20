using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System.Data;

namespace Prj_Capa_Negocio
{
   public class RN_Temporal
    {
        BD_Temporal obj = new BD_Temporal();

        public void RN_Registrar_Temporal(EN_Temporal temp)
        {
            obj.BD_Registrar_Temporal(temp);
        }
        public void RN_Registrar_DetTemporal(EN_Det_Temporal temp)
        {
            obj.BD_Registrar_DetTemporal(temp);
        }

        public DataTable RN_Leer_Temporal_porID(string idTemp)
        {
            return obj.BD_Leer_Temporal_porID(idTemp);
        }

        public void RN_Eliminar_Temporal(string idTemp)
        {
            obj.BD_Eliminar_Temporal(idTemp);
        }

    }
}
