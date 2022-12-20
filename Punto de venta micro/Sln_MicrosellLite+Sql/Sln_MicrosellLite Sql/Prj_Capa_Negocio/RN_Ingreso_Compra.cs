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
    public class RN_Ingreso_Compra
    {
        BD_Ingreso_Compra obj=new BD_Ingreso_Compra();
        public void RN_Ingresar_RegistroCompra(EN_IngresoCompras com)
        {
            obj.BD_Ingresar_RegistroCompra(com);
        }

        public void RN_Detalle_RegistroCompra(EN_Det_IngresoCompra det)
        {
            obj.BD_Detalle_RegistroCompra(det);
        }

        public bool RN_Verificar_NroDoc_Fisico(string idfisico)
        {
            return obj.BD_Verificar_NroDoc_Fisico(idfisico);
        }

        public String GenerarCodigo(string tabla)
        {
            return obj.GenerarCodigo(tabla);
        }

        public DataTable RN_Buscar_Compras_Explorador(string valor)
        {
            return obj.BD_Buscar_Compras_Explorador(valor);
        }
        public DataTable RN_Cargar_Todas_Compras()
        {
            return obj.BD_Cargar_Todas_Compras();
        }

        public DataTable RN_Buscar_Compras_Explorador_Mes_Dia(string tipo, DateTime fechames)
        {
            return obj.BD_Buscar_Compras_Explorador_Mes_Dia(tipo,fechames);
        }

        public void RN_Borrar_Compra(string idfac) 
        {
            obj.BD_Borrar_Compra(idfac);
        }

        public DataTable RN_Buscar_Compras_ConDetalle(string idcompra)
        {
            return obj.BD_Buscar_Compras_ConDetalle(idcompra);
        }

    }
}
