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
    public class RN_Pedido
    {

        BD_Pedido obj = new BD_Pedido();

        public void RN_Registrar_Pedido(EN_Pedido ped)
        {
            obj.BD_Registrar_Pedido(ped);
        }

        public void RN_Editar_Pedido(EN_Pedido ped)
        {
            obj.BD_Editar_Pedido(ped);
        }

        public bool RN_Verificar_NroPedido(string NroPedido)
        {
            return obj.BD_Verificar_NroPedido(NroPedido);
        }

        public void RN_Registrar_Detalle_Pedido(EN_Detalle_Pedido det)
        {
            obj.BD_Registrar_Detalle_Pedido(det);
        }

        public void RN_Eliminar_Detalle_Pedido(string idpedido)
        {
            obj.BD_Eliminar_Detalle_Pedido(idpedido);
        }

        public void RN_Poner_Pedido_Atendido(string idpedido)
        {
            obj.BD_Poner_Pedido_Atendido(idpedido);
        }

        public void RN_Cambiar_Cliente_Pedido(string idpedido, string idcliente)
        {
            obj.BD_Cambiar_Cliente_Pedido(idpedido, idcliente);
        }

        public void RN_Eliminar_Pedido_Permanente(string idpedido)
        {
            obj.BD_Eliminar_Pedido_Permanente(idpedido);
        }

        public DataTable RN_Buscar_Pedido_Editar(string idped)
        {
            return obj.BD_Buscar_Pedido_Editar(idped);
        }

        public DataTable RN_Buscar_Pedido_porValor(string idped)
        {
            return obj.BD_Buscar_Pedido_porValor(idped);
        }
        public DataTable RN_Buscar_Pedido_Fecha(string tipo, DateTime xfecha)
        {
            return obj.BD_Buscar_Pedido_Fecha(tipo,xfecha);
        }

        public DataTable RN_Buscar_Pedido_porAtender()
        {
            return obj.BD_Buscar_Pedido_porAtender();
        }

        public DataTable RN_Buscar_Pedido_ConDetalle(string idped)
        {
            return obj.BD_Buscar_Pedido_ConDetalle(idped);
        }
    }
}
