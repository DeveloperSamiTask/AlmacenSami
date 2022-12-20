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
   public class RN_Credito
    {
        BD_Credito obj = new BD_Credito();

        public void RN_Registrar_Credito(EN_Credito cre)
        {
            obj.BD_Registrar_Credito(cre);
        }
        public void RN_Registrar_Detalle_Credito(EN_DetCredito cre)
        {
            obj.BD_Registrar_Detalle_Credito(cre);
        }
        public static double RN_Sumar_Total_Credito_poCliente(string idcliente)
        {
           return BD_Credito.BD_Sumar_Total_Credito_poCliente(idcliente);
        }

        public DataTable RN_Listar_Todos_Creditos()
        {
            return obj.BD_Listar_Todos_Creditos();
        }
        public DataTable RN_Listar_Creditos_porValor(string valor)
        {
            return obj.BD_Listar_Creditos_porValor(valor);
        }

        public DataTable RN_VerDetalle_deCredito(string idCred)
        {
            return obj.BD_VerDetalle_deCredito(idCred);
        }

        public void RN_Eliminar_Creditp(string idcate)
        {
            obj.BD_Eliminar_Creditp(idcate);
        }

        public void RN_Abonar_Credito(string idnota, double saldopnd, string stado)
        {
            obj.BD_Abonar_Credito(idnota,saldopnd,stado);
        }
    }
}
