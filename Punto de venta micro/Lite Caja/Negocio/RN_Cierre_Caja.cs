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
  public   class RN_Cierre_Caja
    {

        public void RN_registrar_Inicio_Caja(EN_cierre_Caja cli)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            obj.BD_registrar_Inicio_Caja(cli);
        }

        public void RN_registrar_Cierrede_Caja(EN_cierre_Caja cli)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            obj.BD_registrar_Cierrede_Caja(cli);

        }

        public DataTable RN_Listar_Cierre_Caja_DelDia(DateTime mes)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
           return  obj.BD_Listar_Cierre_Caja_DelDia(mes);

        }

        public bool RN_validar_InicioDoble_caja()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_validar_InicioDoble_caja();
        }

        public DataTable RN_Calcular_Ventas_PorTipo_Doc(string nomTipoDoc)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Ventas_PorTipo_Doc(nomTipoDoc);
        }

        public DataTable RN_Calcular_Gastos_porTipoPago(string tipopago)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Gastos_porTipoPago(tipopago );

        }

        public DataTable RN_Calcular_ventas_Acredito()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_ventas_Acredito ();
        }

        public DataTable RN_Calcular_ventas_ADeposito()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_ventas_ADeposito();
        }


        public DataTable RN_Calcular_Ganancias_deldia()
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Calcular_Ganancias_deldia();
        }

        public DataTable RN_Listar_Cierre_Caja_DelMes(DateTime mes)
        {
            BD_Cierre_Caja obj = new BD_Cierre_Caja();
            return obj.BD_Listar_Cierre_Caja_DelMes(mes);

        }




    }
}
