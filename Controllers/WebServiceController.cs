using Callcenter.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Callcenter.Controllers
{
    public class WebServiceController : ApiController
    {
        static string cn = "Server=localhost\\SQLEXPRESS;DataBase= callcenter;Integrated Security=true";
        // GET: api/WebService
        public List<consulta> Get(string cedula)
        {
            //Listado Final
            List<consulta> listado = new List<consulta>();

            //Si la cedula viene vacia, pasamos la palabra null al procedimiento de almacenado
            if (string.IsNullOrEmpty(cedula))
            {
                cedula = "null";
            }

            //abrimos conexion a la base de datos y ejecutamos el procedimiento de almacenado
            using (SqlConnection db = new SqlConnection(cn))
            {
                db.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = db;
                comando.CommandText = "ConsultaPagosCliente";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@cedula", cedula);

                SqlDataReader query = comando.ExecuteReader();
                
                consulta con;

                while (query.Read())
                {
                    con = new consulta();
                    con.cedula = query[0].ToString();
                    con.nombreCompleto = query[1].ToString();
                    DateTime fecha = Convert.ToDateTime(query[2].ToString());
                    con.fechaPago = fecha.ToString("dd MMMM yyyy");
                    con.monto = Convert.ToDecimal(query[3].ToString());
                    listado.Add(con);
                }

                return listado;
            }

        }

        
    }
}
