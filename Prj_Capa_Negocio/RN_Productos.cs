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
    public class RN_Productos
    {
        BD_Productos obj=new BD_Productos();

        public void RN_Registrar_Productos(EN_Productos pro)
        {
            obj.BD_Registrar_Productos(pro);
        }

        public void RN_Editar_Productos(EN_Productos pro)
        {
            obj.BD_Editar_Productos(pro);
        }

        public DataTable RN_Cargar_Todas_Productos()
        {
            return obj.BD_Cargar_Todas_Productos();
        }

        public DataTable RN_Buscar_Productos(string valor)
        {
            return obj.BD_Buscar_Productos(valor);
        }

        public void RN_DarBaja_Productos(string idpro)
        {
            obj.BD_DarBaja_Productos(idpro);
        }

        public void RN_Eliminar_Productos(string idpro)
        {
            obj.BD_Eliminar_Productos(idpro);
        }

        public void RN_Sumar_Stock_Productos(string idpro, double stock)
        {
            obj.BD_Sumar_Stock_Productos(idpro,stock);
        }

        public void RN_Restar_Stock_Productos(string idpro, double stock)
        {
            obj.BD_Restar_Stock_Productos(idpro,stock);
        }

        public void RN_Actualizar_Precios_Compra_Productos(string idpro, double precompraSol, double preVentaMnr, double utilidad, double valorAlmacen)
        {
            obj.BD_Actualizar_Precios_Compra_Productos (idpro,precompraSol,preVentaMnr,utilidad,valorAlmacen);
        }

        public String GenerarCodigo(string tabla)
        {
           return obj.GenerarCodigo(tabla);
        }
    }
}
