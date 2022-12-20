using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Prj_Capa_Datos
{
    public class BD_Conexion
    {
        public String Conectar()
        {
            //PARA MYSQL
            //return ("SERVER=149.255.62.23;PORT=3306;DATABASE=technolo_POS_Microsell_Lite;uid=technolo_sistemaventas;pwd =OTDb3.tV2d,T");


            //Para SQLSERVER
            return "Data Source =192.168.100.13;Initial Catalog =ALMACEN; User ID=sa;Password=$axelis123";
        }




        public static String Conectar2()
        {
            //PARA MYSQL
            //return ("SERVER=149.255.62.23;PORT=3306;DATABASE=technolo_POS_Microsell_Lite;uid=technolo_sistemaventas;pwd =OTDb3.tV2d,T");


            //Para SQLSERVER
            return "Data Source =192.168.100.13;Initial Catalog =ALMACEN; User ID=sa;Password=$axelis123";
        }
    }
}
