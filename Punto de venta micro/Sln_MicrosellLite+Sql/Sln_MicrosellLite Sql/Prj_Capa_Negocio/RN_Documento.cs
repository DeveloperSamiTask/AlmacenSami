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
    public class RN_Documento
    {
        BD_Documento obj = new BD_Documento();

        public bool RN_Verificar_NroDocumento(string nroDoc)
        {
          return  obj.BD_Verificar_NroDocumento(nroDoc);
        }

        public void RN_Registrar_Nuevo_Documento(EN_Documento doc)
        {
            obj.BD_Registrar_Nuevo_Documento(doc);
        }

        public void RN_Actualizar_Nuevo_Documento(string iddoc, double importe, double igv, string son)
        {
            obj.BD_Actualizar_Nuevo_Documento(iddoc, importe, igv, son);
        }

        public DataTable RN_Buscar_Documento_porValor(string valor)
        {
            return obj.BD_Buscar_Documento_porValor(valor);
        }

        public DataTable RN_Listar_Documento_porDia(DateTime diax)
        {
            return obj.BD_Listar_Documento_porDia(diax);
        }

        public DataTable RN_Listar_Documento_porMes(DateTime mesx)
        {
            return obj.BD_Listar_Documento_porMes(mesx);
        }

        public DataTable RN_Leer_Documento_Emitidas_porMes(DateTime mesx, int idtipodoc)
        {
            return obj.BD_Leer_Documento_Emitidas_porMes(mesx, idtipodoc);
        }

        public DataTable RN_Buscar_Documento_yDetalle(string NroDoc)
        {
            return obj.BD_Buscar_Documento_yDetalle(NroDoc);
        }

        public void RN_Anular_Documento(string idDoc, string estadoDoc)
        {
            obj.BD_Anular_Documento(idDoc, estadoDoc);
        }

        public void RN_Cambiar_TipoPago_Documento(string idDoc, string tipoPago)
        {
            obj.BD_Cambiar_TipoPago_Documento(idDoc,tipoPago);
        }

        public DataTable RN_Listar_Todos_Documentos()
        {
            return obj.BD_Listar_Todos_Documentos();
        }
    }
}
