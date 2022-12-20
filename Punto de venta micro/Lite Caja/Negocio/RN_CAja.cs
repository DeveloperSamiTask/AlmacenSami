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
   public  class RN_CAja
    {

        public void RN_Registrar_Mov_Caja(EN_Caja cja)
        {
            BD_Caja obj = new BD_Caja();
            obj.BD_Registrar_Mov_Caja(cja);

        }

        public void RN_Actualizar_Total_Caja(string nroDoc, double total, double totalUtili, string tipoPago)
        {
            BD_Caja obj = new BD_Caja();
            obj.BD_Actualizar_Total_Caja(nroDoc, total, totalUtili, tipoPago);

        }

        public DataTable RN_Listar_Todas_Cajas()
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_Listar_Todas_Cajas();
        }

        public DataTable RN_lisgar_Cajas_DelDia(DateTime diax)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_lisgar_Cajas_DelDia(diax);

        }

        public DataTable RN_lisgar_Cajas_Del_Mes(DateTime mesx)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_lisgar_Cajas_Del_Mes(mesx);


        }

        public DataTable RN_buscador_General_Cajas(String valor)
        {
            BD_Caja obj = new BD_Caja();
            return obj.BD_buscador_General_Cajas(valor);

        }

        public void RN_editar_Mov_Caja(EN_Caja cja)
        {
            BD_Caja Obj = new BD_Caja();
            Obj.BD_editar_Mov_Caja(cja);
        }

        public void RN_Anular_Mov_Caja(string nroDoc, string estadoCaja)
        {
            BD_Caja Obj = new BD_Caja();
            Obj.BD_Anular_Mov_Caja(nroDoc, estadoCaja);


        }


        public static double RN_Leer_Suma_TotalGanancias_delMes(DateTime fecha1)
        {

            return BD_Caja.BD_Leer_Suma_TotalGanancias_delMes(fecha1);

        }


        public static double RN_Leer_Suma_TotalGanancias_poraño(DateTime fecha1)
        {

            return BD_Caja.BD_Leer_Suma_TotalGanancias_poraño(fecha1);

        }


    }
}
