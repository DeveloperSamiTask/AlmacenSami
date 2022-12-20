using Prj_Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Negocio
    {
        BD_Negocio objr = new BD_Negocio();

        public EN_Negocio BD_Obtener_Datos()
        {
            return objr.BD_Obtener_Datos();
        }

        public bool BD_Guardar_Datos(EN_Negocio obj)
        {
            return objr.BD_Guardar_Datos(obj);
        }
        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objr.ObtenerLogo(out obtenido);
        }
        public bool ActualizarLogo(byte[] image)
        {
            return objr.ActualizarLogo(image);
        }
    }
}
