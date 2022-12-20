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
        BD_Cierre_Caja obj = new BD_Cierre_Caja();
        public void RN_registrar_Inicio_Caja(EN_CierreCaja cli)
        {
            
            obj.BD_registrar_Inicio_Caja(cli);
        }

        public void RN_registrar_Cierrede_Caja(EN_CierreCaja cli)
        {
            
            obj.BD_registrar_Cierrede_Caja(cli);

        }

        public DataTable RN_Listar_Todas_CierreCajas()
        {
            return obj.BD_Listar_Todas_CierreCajas();
        }
        public DataTable RN_Listar_Cierre_Caja_DelDia()
        {
            
           return  obj.BD_Listar_Cierre_Caja_DelDia();

        }

        public DataTable RN_cargar_Cierre_Caja_DelDia(DateTime dia)
        {
            return obj.BD_cargar_Cierre_Caja_DelDia(dia);
        }

        public DataTable RN_Buscar_General_Cierrecajas(string valor)
        {
            return obj.BD_Buscar_General_Cierrecajas(valor);
        }

        public bool RN_validar_InicioDoble_caja()
        {
           
            return obj.BD_validar_InicioDoble_caja();
        }

        public DataTable RN_Calcular_Ventas_PorTipo_Doc(string nomTipoDoc)
        {
            
            return obj.BD_Calcular_Ventas_PorTipo_Doc(nomTipoDoc);
        }

        public DataTable RN_Calcular_Gastos_porTipoPago(string tipopago)
        {
            
            return obj.BD_Calcular_Gastos_porTipoPago(tipopago );

        }

        public DataTable RN_Calcular_ventas_Acredito()
        {
           
            return obj.BD_Calcular_ventas_Acredito ();
        }

        public DataTable RN_Calcular_ventas_ADeposito()
        {
            
            return obj.BD_Calcular_ventas_ADeposito();
        }


        public DataTable RN_Calcular_Ganancias_deldia()
        {
           
            return obj.BD_Calcular_Ganancias_deldia();
        }

        public DataTable RN_Listar_Cierre_Caja_DelMes(DateTime mes)
        {
           
            return obj.BD_Listar_Cierre_Caja_DelMes(mes);

        }




    }
}
