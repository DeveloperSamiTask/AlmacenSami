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
    public class RN_TipoDoc
    {
        BD_Tipo_Doc obj = new BD_Tipo_Doc();

        public static string RN_NroId(int idtipo)
        {
           return BD_Tipo_Doc.BD_NroId(idtipo);
        }

        public static void RN_Actualizar_Tipo_Doc(int Id_Tipo)
        {
            BD_Tipo_Doc.BD_Actualizar_Tipo_Doc(Id_Tipo);
        }
        public void RN_Actualizar_Tipo_Cambio(int Id_Tipo, double TipoCambio)
        {
            BD_Tipo_Doc.BD_Actualizar_Tipo_Cambio(Id_Tipo, TipoCambio);
        }

        public static double RN_Leer_TipoCambio(int idtipo)
        {
           return BD_Tipo_Doc.BD_Leer_TipoCambio(idtipo);
        }

        public DataTable RN_Listar_Doc_Especial()
        {
            return obj.BD_Listar_Doc_Especial();
        }

        public void RN_Editar_Nro_Correlativo(int Id_Tipo, string docu, string sre, string numero)
        {
            obj.BD_Editar_Nro_Correlativo(Id_Tipo,docu,sre,numero);
        }

        public DataTable RN_Listar_Todos_TipoDoc_porId(int idtipo)
        {
            return obj.BD_Listar_Todos_TipoDoc_porId(idtipo);
        }

        public DataTable RN_Listar_Todos_TipoDoc()
        {
            return obj.BD_Listar_Todos_TipoDoc();
        }
    }
}
