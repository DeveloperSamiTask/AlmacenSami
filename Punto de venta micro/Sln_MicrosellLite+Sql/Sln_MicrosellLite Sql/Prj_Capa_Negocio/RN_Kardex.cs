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
    public class RN_Kardex
    {
        BD_Kardex obj=new BD_Kardex();

        public void RN_Registrar_Kardex(string idkardx, string idproducto, string idprovee)
        {
            obj.BD_Registrar_Kardex(idkardx,idproducto,idprovee);
        }
        public void RN_Registrar_Detalle_Kardex(EN_Kardex kr)
        {
            obj.BD_Registrar_Detalle_Kardex(kr);
        }

        public bool RN_Verificar_Producto_siTieneKardex(string idprod)
        {
            return obj.BD_Verificar_Producto_siTieneKardex(idprod);
        }

        public DataTable RN_Buscar_KardexDetalle_porProducto(string idprod)
        {
          return  obj.BD_Buscar_KardexDetalle_porProducto(idprod);
        }

        public DataTable RN_Cargar_DetalleKardex_delDia(DateTime dia)
        {
            return obj.BD_Cargar_DetalleKardex_delDia(dia);
        }

        public DataTable BD_Cargar_DetalleKardex_delMes(DateTime mes)
        {
            return obj.BD_Cargar_DetalleKardex_delMes(mes);
        }
    }
}
