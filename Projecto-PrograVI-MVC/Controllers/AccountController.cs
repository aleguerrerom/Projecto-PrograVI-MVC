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
    public class AccountController : Controller
    {

        #region DB conexion
        //Conexion a BD via webconfig
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conDB"].ToString();
            con = new SqlConnection(constring);
        }
        #endregion  //BD com

        #region Reporte Usuario
        public ActionResult ReporteUsuarios()
        {
            ViewBag.showSuccessAlert = false;
            return View();
        }

        /// Obtener Datos de usuario
        public void GetUserReport()
        {
            // connection();
            ReportParms objReporParams = new ReportParms();
            var data = GetUserInfo();
            objReporParams.DataSource = data.Tables[0];
            objReporParams.ReportTitle = "Usuario Info Report";
            objReporParams.RptFileName = "UserInfoReport.rdlc";
            objReporParams.ReportType = "UserInfoReport";
            objReporParams.DataSetName = "dsUserReport";
            this.HttpContext.Session["ReportParam"] = objReporParams;
        }

        /// Obtener informacion de usuarios.
        public DataSet GetUserInfo()
        {
            //string constring = ConfigurationManager.ConnectionStrings["conDB"].ConnectionString;
            //DataSet ds = new DataSet();
            //string sql = "select * From TB_Usuario";
            //SqlConnection con = new SqlConnection(constring);
            //SqlCommand cmd = new SqlCommand(sql, con);
            //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            //adpt.Fill(ds);
            //return ds;
            connection();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("[dbo].[SP_ConsultarUsuarios]");
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(ds);
            con.Close();
            return ds;

        }
        #endregion

        #region Reporte Pago
        /// Obtener Datos de usuario

        public ActionResult Reporte()
        {
            ViewBag.showSuccessAlert = false;
            return View();
        }

        public void GetPagoReport()
        {
            // connection();
            ReportParms objReporParams = new ReportParms();
            var data = GetPagoInfo();
            objReporParams.DataSource = data.Tables[0];
            objReporParams.ReportTitle = "Pago Info Report";
            objReporParams.RptFileName = "PagoInfoReport.rdlc";
            objReporParams.ReportType = "PagoInfoReport";
            objReporParams.DataSetName = "dsPagoReport";
            this.HttpContext.Session["ReportParam"] = objReporParams;
        }

        /// Obtener informacion de usuarios.
        public DataSet GetPagoInfo()
        {
            connection();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("[dbo].[SP_ConsultarPagos]");
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(ds);
            con.Close();
            return ds;

        }
        #endregion

        #region LOGIN
        // GET: Home
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.showSuccessAlert = false;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(AccountModel lc)
        {

            if (lc.VLSCorreo == null || lc.VLSClave == null)
            {
                ViewData["message"] = "Favor llenar los campos correo y clave";
            }
            else
            {
                connection();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_UserLogin]");
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", lc.VLSCorreo);
                cmd.Parameters.AddWithValue("@Clave", lc.VLSClave);
                SqlDataReader sdr = cmd.ExecuteReader();
               

                if (sdr.Read())
                {
                    FormsAuthentication.SetAuthCookie(lc.VLSCorreo, true);
                    Session["Correo"] = lc.VLSCorreo.ToString();
                    con.Close();
                    ViewData["message"] = "Ingreso exitoso";

                    return RedirectToAction("Index");
                    
                }
                else
                {
                    ViewData["message"] = "Ingreso fallido, validar correo y constrasena";
                }
            }
            return View();
        }

        #endregion

        #region ESTADO CLAVE
        //public ActionResult EstadoClave(AccountModel lc)
        //{

        //     AccountModel test = new AccountModel();
        //     SqlCommand cmd = new SqlCommand("[dbo].[SP_EstadoClave]");
        //     con.Open();
        //     cmd.Connection = con;

        //     cmd.CommandType = CommandType.StoredProcedure;
        //     cmd.Parameters.AddWithValue("@Correo", lc.VLSCorreo);
        //     SqlDataReader sdr = cmd.ExecuteReader();
        //     var result = (bool)sdr["RecordarClave"];
        //     con.Close();
        //     return View();
        //}



        //[AllowAnonymous]
        //[HttpPost]
        //public string EstadoClave(AccountModel lc)
        //{
        //    string estado = "";
        //    //  string nombre = "";
        //    //  DateTime fecha = "";
        //    connection();
        //    SqlCommand cmd = new SqlCommand("[dbo].[SP_EstadoClave]", con);
        //    con.Open();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    //cmd.Parameters.Add(new SqlParameter("@Correo",lc.VLSCorreo));
        //    cmd.Parameters.AddWithValue("@correo", lc.VLSCorreo);
        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            estado = reader["RecordarClave"].ToString();
        //            //    nombre = reader["Nom_Tarjeta"].ToString();
        //            //  fecha = reader["Codigo_Tarj"].ToString();
        //        }
        //    }

        //    return estado;
        //}
        /* [AllowAnonymous]
         [HttpPost]
         public string PruebaLeer (string nombre)
         {
             string apellido="";
             connection();
             con.Open();
             SqlCommand cmd = new SqlCommand("SP_Prueba",con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add(new SqlParameter("@nombre", "John"));
             using (SqlDataReader reader = cmd.ExecuteReader() )
             {
                 while (reader.Read())
                 {
                     Debug.WriteLine(reader["cedula"]);
                     Debug.WriteLine(reader["nombre"]);
                    apellido = reader["apellido"].ToString();
                 }
             }

             return apellido;
         }*/
        #endregion

        #region REGISTRAR
        /// Registrar
        /// 
        [AllowAnonymous]
        public ActionResult Register()
        {
            AccountModel lc = new AccountModel();
            ViewBag.showSuccessAlert = false;
            //lc.VLSFechaExp = DateTime.Now.Date;
            return View();
            
        }
        //Proceso de Registro
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(AccountModel lc)
        {

            if (lc.VLSCedula == null || lc.VLSNacionalidad == null || lc.VLSNombre == null || lc.VLSApellido1 == null
                || lc.VLSApellido2 == null || lc.VLSCorreo == null || lc.VLSNumTarjeta == null || lc.VLSNomTarjeta == null
                || lc.VLSCodigoTarjeta == null || lc.VLSFechaExp == null || lc.VLSProvincia == null || lc.VLSCanton == null
                || lc.VLSDistrito == null || lc.VLSClave == null || lc.VLSPreSeg == null)
            {
                ViewData["message"] = "Registro fallido favor validar todos los datos para registrarse";
            }
            else
            {
                connection();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_InsertarUsuarios]", con);

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", lc.VLSCedula);
                cmd.Parameters.AddWithValue("@Nacionalidad", lc.VLSNacionalidad);
                cmd.Parameters.AddWithValue("@Nombre", lc.VLSNombre);
                cmd.Parameters.AddWithValue("@Apellido", lc.VLSApellido1);
                cmd.Parameters.AddWithValue("@Apellido2", lc.VLSApellido2);
                cmd.Parameters.AddWithValue("@Correo", lc.VLSCorreo);
                cmd.Parameters.AddWithValue("@Num_Tarjeta", lc.VLSNumTarjeta);
                cmd.Parameters.AddWithValue("@Nom_Tarjeta", lc.VLSNomTarjeta);
                cmd.Parameters.AddWithValue("@Codigo_Tarj", lc.VLSCodigoTarjeta);
                cmd.Parameters.AddWithValue("@Fecha_Exp_Tarj", lc.VLSFechaExp);
                cmd.Parameters.AddWithValue("@Provincia", lc.VLSProvincia);
                cmd.Parameters.AddWithValue("@Canton", lc.VLSCanton);
                cmd.Parameters.AddWithValue("@Distrito", lc.VLSDistrito);
                cmd.Parameters.AddWithValue("@Clave", lc.VLSClave);
                cmd.Parameters.AddWithValue("@Privilegios", "Cliente");
                cmd.Parameters.AddWithValue("@RecordarClave","0");
                cmd.Parameters.AddWithValue("@Pregunta", lc.VLSPreSeg);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    ViewData["message"] = "Existosamente Registrado";
                   // ViewBag.Message("Existosamente Registrado");
                    return RedirectToAction("Login");

                }


                else
                    return RedirectToAction("Login");
            }
            return View();
        }

        #endregion

        #region INDEX
        // index return view
        [Authorize(Roles = "Admin,Cliente")]
        public ActionResult Index()
        {
            ViewBag.showSuccessAlert = false;

            return View();
        }


        #endregion

        #region OLVIDO CLAVE
        // VIEW FORGOT PASSWORD
       
        public ActionResult ForgotPassword()
        {
            ViewBag.showSuccessAlert = false;
            return View();
        }

        // forgot password email send
        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(AccountModel lc)
        {

            if (lc.VLSCorreo == null || lc.VLSPreSeg == null || lc.VLSCedula == null)
            {

                ViewData["message"] = "Recuperacion fallida, validar cedula, Pregunta de Seguridad y correo";
            }
            else

            {
                connection();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_OlvidoClave]");
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Correo", lc.VLSCorreo);
                cmd.Parameters.AddWithValue("@Pregunta_Seg", lc.VLSPreSeg);
                cmd.Parameters.AddWithValue("@Cedula", lc.VLSCedula);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    con.Close();
                    con.Open();
                    FormsAuthentication.SetAuthCookie(lc.VLSCorreo, true);


                    ///GENERAR PASSWORD ALEATORIO
                    ///
                    int minLenght = 8;
                    int maxLenght = 8;

                    string charAvailable = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPKLMNOPQRSTUWYZ0123456789";
                    StringBuilder Randompassword = new StringBuilder();
                    Random rdm = new Random();


                    int passwordLenght = rdm.Next(minLenght, maxLenght);
                    while (passwordLenght-- > 0)
                        Randompassword.Append(charAvailable[rdm.Next(charAvailable.Length)]);

                    /// Update de datos para recuperacion
                    SqlCommand cmd2 = new SqlCommand("[dbo].[SP_ClaveTemporal]", con);
                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Correo", lc.VLSCorreo);
                    cmd2.Parameters.AddWithValue("@Clave", Randompassword.ToString());
                    cmd2.Parameters.AddWithValue("@RecordarClave", 1);
                    string nombre = lc.VLSNombre;
                    int i2 = cmd2.ExecuteNonQuery();

                    MailMessage Correo = new MailMessage();
                    Correo.From = new MailAddress("alejoguma94@gmail.com");
                    Correo.To.Add(lc.VLSCorreo);
                    Correo.Subject = ("Recuperar Clave");
                    Correo.Body = "Hola," + lc.VLSNombre + " ud solciito recuperar su clave, favor ingresar con la siguiente: " +
                    Randompassword.ToString() + " Al Ingresar nuevamente se le solicitara cambiarla por una nueva";
                    Correo.Priority = MailPriority.Normal;

                    SmtpClient ServerEmail = new SmtpClient();
                    ServerEmail.Credentials = new NetworkCredential("alejoguma94@gmail.com", "C@rl1t0X1");
                    ServerEmail.Host = "smtp.gmail.com";
                    ServerEmail.Port = 587;
                    ServerEmail.EnableSsl = true;

                    try
                    {
                        ViewData["message"] = "Recuperacion Exitosa se envio nueva clave a su correo";
                        ViewBag.Message("Recuperacion Exitosa se envio nueva clave a su correo");
                        ServerEmail.Send(Correo);

                    }
                    catch (Exception e)
                    {

                        Console.Write(e);
                    }

                    Session["Correo"] = lc.VLSCorreo.ToString();
                    return RedirectToAction("Login");
                }
                else
                {

                    ViewData["message"] = "Recuperacion fallida, favor validar correo, pregunta seguridad y cedula";
                }
            }
            con.Close();
            return View();

        }

        #endregion

        #region LOGOUT

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction ("Login" , "Account");
        }
        #endregion

        #region USUARIO
        [Authorize(Roles = "Admin")]
        public ActionResult Usuarios()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Usuarios(AccountModel lc)
        {

            if (lc.VLSCedula == null || lc.VLSNacionalidad == null || lc.VLSNombre == null || lc.VLSApellido1 == null
                || lc.VLSApellido2 == null || lc.VLSCorreo == null || lc.VLSNumTarjeta == null || lc.VLSNomTarjeta == null
                || lc.VLSCodigoTarjeta == null || lc.VLSFechaExp == null || lc.VLSProvincia == null || lc.VLSCanton == null
                || lc.VLSDistrito == null || lc.VLSClave == null || lc.VLSPreSeg == null)
            {
                ViewData["message"] = "Registro fallido favor validar todos los datos para registrarse";
            }
            else
            {
                connection();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_InsertarUsuarios]", con);

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", lc.VLSCedula);
                cmd.Parameters.AddWithValue("@Nacionalidad", lc.VLSNacionalidad);
                cmd.Parameters.AddWithValue("@Nombre", lc.VLSNombre);
                cmd.Parameters.AddWithValue("@Apellido", lc.VLSApellido1);
                cmd.Parameters.AddWithValue("@Apellido2", lc.VLSApellido2);
                cmd.Parameters.AddWithValue("@Correo", lc.VLSCorreo);
                cmd.Parameters.AddWithValue("@Num_Tarjeta", lc.VLSNumTarjeta);
                cmd.Parameters.AddWithValue("@Nom_Tarjeta", lc.VLSNomTarjeta);
                cmd.Parameters.AddWithValue("@Codigo_Tarj", lc.VLSCodigoTarjeta);
                cmd.Parameters.AddWithValue("@Fecha_Exp_Tarj", lc.VLSFechaExp);
                cmd.Parameters.AddWithValue("@Provincia", lc.VLSProvincia);
                cmd.Parameters.AddWithValue("@Canton", lc.VLSCanton);
                cmd.Parameters.AddWithValue("@Distrito", lc.VLSDistrito);
                cmd.Parameters.AddWithValue("@Clave", lc.VLSClave);
                cmd.Parameters.AddWithValue("@Privilegios", lc.VLSPrivilegios);
                cmd.Parameters.AddWithValue("@RecordarClave", "0");
                cmd.Parameters.AddWithValue("@Pregunta", lc.VLSPreSeg);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    ViewData["message"] = "Existosamente Registrado";
                    // ViewBag.Message("Existosamente Registrado");
                    return RedirectToAction("Login");

                }


                else
                    return RedirectToAction("Login");
            }
            return View();
        }
        #endregion
    }
}
