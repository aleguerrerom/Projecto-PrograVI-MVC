using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Projecto_PrograVI_MVC.Models;
using System.Web.Security;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace Projecto_PrograVI_MVC.Controllers
{
    [Authorize]
    public class ReparacionController : Controller
    {
        #region DB CONEX
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conDB"].ToString();
            con = new SqlConnection(constring);
        }
        #endregion
        // GET: Reparacion

        #region PAGO
        public ActionResult Pago()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public string CargarTarjeta(string correo)
        {
            string numero = "";
            string nombre = "";
            string fecha = "";
            string codigo = "";
            connection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CargarTarjeta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@correo",correo));
            //cmd.Parameters.AddWithValue("@correo", lc.VLSCorreo);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    numero = reader["Num_Tarjeta"].ToString();
                    nombre = reader["Nom_Tarjeta"].ToString();
                    fecha = reader["Fecha_Exp_Tarj"].ToString();
                    codigo = reader["Codigo_Tarj"].ToString();
                }
            }

            return numero;
        }

        #endregion

        #region Reparacion
        public ActionResult Reparacion()
        {
            ModelState.Clear();
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin,Cliente")]
        public ActionResult Reparacion(ReparacionModel lc)
        {

            if (lc.VLSMarca == null || lc.VLSDano == null || lc.VLSDiscoDuro == null || lc.VLSMemoria == null
                || lc.VLSTipo == null || lc.VLSSO == null || lc.VLSAdicionales == null || lc.VLSLimpieza == null
                || lc.VLSDescripcion == null || lc.VLSCosto == null)
            {
                connection();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_RealizarPago]", con);

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", "123");
                cmd.Parameters.AddWithValue("@Correo", "1111");
                cmd.Parameters.AddWithValue("@Marca", lc.VLSMarca);
                cmd.Parameters.AddWithValue("@Dano", lc.VLSDano);
                cmd.Parameters.AddWithValue("@DiscoDuro", lc.VLSDiscoDuro);
                cmd.Parameters.AddWithValue("@Memoria", lc.VLSMemoria);
                cmd.Parameters.AddWithValue("@Tipo", lc.VLSTipo);
                cmd.Parameters.AddWithValue("@SO", lc.VLSSO);
                cmd.Parameters.AddWithValue("@Adicionales", lc.VLSAdicionales);
                cmd.Parameters.AddWithValue("@Limpieza", lc.VLSLimpieza);
                cmd.Parameters.AddWithValue("@Descripcion", lc.VLSDescripcion);
                cmd.Parameters.AddWithValue("@Costo", "1000");
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    ViewData["message"] = "Se registro su cotizacion correctamente";
                    return RedirectToAction("Pago");
                }
                else
                    return RedirectToAction("Pago");
            }

            return View(); }


        /*
         connection();
            ReparacionModel Repara = new ReparacionModel();
            DataSet ds = new DataSet();
          
            SqlCommand sqlCommand = new SqlCommand("select Marca from [dbo].[TB_Marca]", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            sda.Fill(ds);
            List<ReparacionModel> Reparacion1 = new List<ReparacionModel>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ReparacionModel rep = new ReparacionModel();

                rep.VLS_Marca = ds.Tables[0].Rows[i]["Marca"].ToString();
                Reparacion1.Add(rep);
            }
            Repara.MarcaInfo = Reparacion1;
            con.Close();
         // return View(Repara);
            
        [HttpPost]
        public List<ReparacionModel> GetMarca()
        {
            connection();
            List<ReparacionModel> MarcaInfo = new List<ReparacionModel>();

            SqlCommand cmd = new SqlCommand("[dbo].[SP_CargarMarcas]", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                MarcaInfo.Add(
                    new ReparacionModel
                    {
                        VLS_Marca = Convert.ToString(dr["Marca"]),
                        VLS_Marca_ID = Convert.ToInt32(dr["ID"])
                     
     
                    });
            }
            return MarcaInfo;
        }
       */
        #endregion

  



    }




}