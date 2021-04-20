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

namespace Projecto_PrograVI_MVC.Controllers
{
    [Authorize]
    public class ConsultaController : Controller
    {
        #region DB CONEXION
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conDB"].ToString();
            con = new SqlConnection(constring);
        }
        #endregion

        #region CONSULTA
        // GET: Consulta

        public ActionResult Consulta()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Consulta(ConsultaModel lc)
        {
            connection();
            SqlCommand cmd = new SqlCommand("[dbo].[SP_Consulta]", con);
            
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", lc.VLSNombre);
            cmd.Parameters.AddWithValue("@Numero", lc.VLSNumero);
            cmd.Parameters.AddWithValue("@Correo", lc.VLSCorreo);
            cmd.Parameters.AddWithValue("@Consulta", lc.VLSConsulta);


            MailMessage Correo = new MailMessage();
            Correo.From = new MailAddress("alejoguma94@gmail.com");
            Correo.To.Add(lc.VLSCorreo);
            Correo.Subject = ("Consulta");
            Correo.Body = "Hola," + lc.VLSNombre + " Se envio su consulta correctamente, sera contactado los"+
            "  mas pronto posible, Les Saluda Cordialmente el personal de Warrior Repair";

            Correo.Priority = MailPriority.Normal;

            SmtpClient ServerEmail = new SmtpClient();
            ServerEmail.Credentials = new NetworkCredential("alejoguma94@gmail.com", "C@rl1t0X1");
            ServerEmail.Host = "smtp.gmail.com";
            ServerEmail.Port = 587;
            ServerEmail.EnableSsl = true;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                ServerEmail.Send(Correo);
                Session["Correo"] = lc.VLSCorreo.ToString();
                ViewData["message"] = "Se envio su consulta correctamente";
                return RedirectToAction("Consulta");
                
            }
            else
                return RedirectToAction("Consulta");
            

        }
        #endregion
    }
}