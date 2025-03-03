using apiRESTCenso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiRESTCenso.Controllers
{
    public class CensoController : ApiController
    {
        //Definición del arreglo de objetos
        public static clsCensoPoblacion[] objCenso = null;

        // GET: api/Censo
        public IEnumerable<clsCensoPoblacion> Get()
        {
            return objCenso;
        }


        // GET: api/Censo/5
        public clsCensoPoblacion Get(int id)
        {
            //Elemento de uso para lectura
            clsCensoPoblacion elemento = new clsCensoPoblacion();
            for (int i = 0; i < objCenso.Length; i++)
            {
                if (objCenso[i].id == id)
                {
                    elemento = objCenso[i];
                    break;
                }
            }

            return elemento;
        }

        // POST: api/Censo
        public string Post(int posicion, [FromBody] clsCensoPoblacion modelo)
        {
            string ban = "";
            //validacion del arreglo de elementos
            if (objCenso == null)
            {
                //Creacion del arreglo de objetos
                //Creacion de los 7 elementos 
                objCenso = new clsCensoPoblacion[7];
                objCenso[0] = new clsCensoPoblacion();
                objCenso[1] = new clsCensoPoblacion();
                objCenso[2] = new clsCensoPoblacion();
                objCenso[3] = new clsCensoPoblacion();
                objCenso[4] = new clsCensoPoblacion();
                objCenso[5] = new clsCensoPoblacion();
                objCenso[6] = new clsCensoPoblacion();

            }

            //Validar la posicion e insertar datos
            if (posicion >= 0 && posicion <= 6)
            {
                objCenso[posicion].id = modelo.id;
                objCenso[posicion].curp = modelo.curp;
                objCenso[posicion].nombre = modelo.nombre;
                objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                objCenso[posicion].direccion = modelo.direccion;
                objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                ban = "1";

            }
            else
            {
                ban = "0";
            }

            return ban;
        }

        // PUT: api/Censo/5
        public string Put(int posicion, [FromBody] clsCensoPoblacion modelo)
        {
            string ban;

            if (objCenso != null)
            {
                if (posicion >= 0 && posicion <= 6)
                {

                    objCenso[posicion].id = modelo.id;
                    objCenso[posicion].curp = modelo.curp;
                    objCenso[posicion].nombre = modelo.nombre;
                    objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                    objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                    objCenso[posicion].direccion = modelo.direccion;
                    objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                    ban = "1";

                }
                else
                {
                    ban = "0";
                }
            }
            else
            {
                ban = "-1";
            }
            return ban;
        }

        // DELETE: api/Censo/5
        public String Delete(int posicion)
        {
            string ban = "0";
            if (objCenso != null)
            {
                if (posicion >= 0 && posicion <= 6)
                {

                    objCenso[posicion].id = 0;
                    objCenso[posicion].curp = null;
                    objCenso[posicion].nombre = null;
                    objCenso[posicion].apellidoPaterno = null;
                    objCenso[posicion].apellidoMaterno = null;
                    objCenso[posicion].direccion = null;
                    objCenso[posicion].actividadEconomica = null;
                    ban = "1";

                }
                else
                {
                    ban = "0";
                }
            }
            else
            {
                ban = "-1";
            }
            return ban;
        }
    }
}

