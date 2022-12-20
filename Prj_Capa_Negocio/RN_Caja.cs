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
    public class RN_Caja
    {
        BD_Caja obj = new BD_Caja();

        public void RN_Registrar_Mov_Caja(EN_Caja cja)
        {
            obj.BD_Registrar_Mov_Caja(cja);
        }

        public void RN_Actualizar_Total_Caja(string NroDoc, double Total, double totalUtili, string tipoPago)
        {
            obj.BD_Actualizar_Total_Caja(NroDoc,Total,totalUtili,tipoPago);
        }

        public DataTable RN_Listar_Todas_Cajas()
        {
            return obj.BD_Listar_Todas_Cajas();
        }

        public DataTable RN_Listar_Caja_porDia(DateTime diax)
        {
            return obj.BD_Listar_Caja_porDia(diax);
        }

        public DataTable RN_Listar_Caja_pormes(DateTime mesx)
        {
            return obj.BD_Listar_Caja_pormes(mesx);
        }

        public DataTable RN_Buscar_General_cajas(string valor)
        {
            return obj.BD_Buscar_General_cajas(valor);
        }
    }
}
