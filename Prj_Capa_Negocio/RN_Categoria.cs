using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Categoria
    {
        BD_Categoria obj = new BD_Categoria();
        public void RN_Registrar_Categoria(string nomCateg)
        {
            
            obj.BD_Registrar_Categoria(nomCateg);
        }

        //editar:

        public void RN_Editar_Categoria(int idcate, string nomCateg)
        {
            
            obj.BD_Editar_Categoria(idcate,nomCateg);
        }

        //consultar:

        public DataTable RN_Cargar_Todas_Categorias()
        {
           
            return obj.BD_Cargar_Todas_Categorias();
        }

        public void RN_Eliminar_Marca(int idmar)
        {
            
            obj.BD_Eliminar_Categoria(idmar);
        }

    }
}
