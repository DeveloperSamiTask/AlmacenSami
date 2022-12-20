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
    public class RN_Cliente
    {
        BD_Cliente obj=new BD_Cliente();

        public bool RN_Verificar_NroDni(string NroDni)
        {
           return obj.BD_Verificar_NroDni(NroDni);
        }
        public void RN_Insertar_Cliente(EN_Cliente cli)
        {
            obj.BD_Insertar_Cliente(cli);
        }
        public void RN_Editar_Cliente(EN_Cliente cli)
        {
            obj.BD_Editar_Cliente(cli);
        }
        public DataTable RN_Cargar_Todos_Cliente(string estado)
        {
            return obj.BD_Cargar_Todos_Cliente(estado);
        }
        public DataTable RN_Buscar_Cliente(string valor, string estado)
        {
            return obj.BD_Buscar_Cliente(valor,estado);
        }
        public void RN_DarBaja_Cliente(string idcliente)
        {
            obj.BD_DarBaja_Cliente(idcliente);
        }
        public void RN_Eliminar_Cliente(string idcliente)
        {
            obj.BD_Eliminar_Cliente(idcliente);
        }

        public String GenerarCodigo(string tabla)
        {
            return obj.GenerarCodigo(tabla);
        }
    }
}
