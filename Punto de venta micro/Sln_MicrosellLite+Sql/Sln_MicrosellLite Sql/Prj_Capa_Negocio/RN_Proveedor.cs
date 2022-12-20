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
    public class RN_Proveedor
    {
        BD_Proveedor obj = new BD_Proveedor();
        public void RN_Registrar_Proveedor(EN_Proveedor pro)
        {
            obj.BD_Registrar_Proveedor(pro);
        }

        public void RN_Editar_Proveedor(EN_Proveedor pro)
        {
            obj.BD_Editar_Proveedor(pro);
        }
        public void RN_Eliminar_Proveedor(String pro)
        {

            obj.BD_Eliminar_Proveedor(pro);
        }
        public DataTable RN_Cargar_Todas_Proveedores()
        {
            return obj.BD_Cargar_Todas_Proveedores();
        }

        public DataTable RN_Buscar_Proveedores(string valor)
        {
            return obj.BD_Buscar_Proveedores(valor);
        }
        public String GenerarCodigo(string tabla)
        {
            return obj.GenerarCodigo(tabla);
        }
    }
}
