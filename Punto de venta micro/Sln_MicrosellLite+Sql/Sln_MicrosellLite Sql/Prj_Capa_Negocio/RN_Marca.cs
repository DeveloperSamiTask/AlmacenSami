using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Marca
    {
        BD_Marcas obj = new BD_Marcas();

        public void RN_Registrar_Marca(string nomMar)
        {
            
            obj.BD_Registrar_Marca(nomMar);
        }

        public void RN_Editar_Marca(int idmar, string nomMar)
        {
            
            obj.BD_Editar_Marca(idmar,nomMar);
        }

        public DataTable RN_Cargar_Todas_Marcas()
        {
            
            return obj.BD_Cargar_Todas_Marcas();
        }

        public void RN_Eliminar_Marca(int idmar)
        {
            
            obj.BD_Eliminar_Marca(idmar);
        }
    }
}
