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
    public class RN_Cotizacion
    {
        BD_Cotizacion obj=new BD_Cotizacion();

        public void BD_Registrar_Cotizacion(EN_Cotizacion cot)
        {
            obj.BD_Registrar_Cotizacion(cot);
        }

        public void BD_Editar_Cotizacion(EN_Cotizacion cot)
        {
            obj.BD_Editar_Cotizacion(cot);
        }

        public void BD_Cambiar_Estado_Cotizacion(string idcoti, string estadocoti)
        {
            obj.BD_Cambiar_Estado_Cotizacion(idcoti,estadocoti);
        }

        public DataTable BD_Buscar_Cotizacion_Editar(string idcoti)
        {
            return obj.BD_Buscar_Cotizacion_Editar(idcoti);
        }

        public DataTable BD_Listar_Todos_Cotizaciones()
        {
            return obj.BD_Listar_Todos_Cotizaciones();
        }

        public DataTable BD_Listar_Cotizacion_Estado(string estado)
        {
            return obj.BD_Listar_Cotizacion_Estado(estado);
        }

        public DataTable BD_Buscar_Cotizacion(string valor)
        {
            return obj.BD_Buscar_Cotizacion(valor);
        }

        public DataTable BD_Buscar_Cotizacion_Explorador_Mes_Dia(string tipo, DateTime fechames)
        {
            return obj.BD_Buscar_Cotizacion_Explorador_Mes_Dia(tipo,fechames);
        }
    }
}
