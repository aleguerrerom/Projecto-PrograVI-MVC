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
    public class AdministrarController : Controller
    {

        #region Con DB
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conDB"].ToString();
            con = new SqlConnection(constring);
        }
        #endregion

        //DB_ProyectoDataSet db = new DB_ProyectoDataSet();
        //// GET: Administrar
        //[Authorize(Roles = "Admin")]
        //public ActionResult Administrar(string searchBy,string search)
        //{
        //    if (searchBy == "Correo")
        //    {
        //        return View(db.TB_Usuario.Where(x => x.Correo == search).ToList());
        //    }
        //    else
        //    {
        //        return View(db.TB_Usuario.Where(x => x.Cedula.StartsWith(search)).ToList());
        //    }
        //}

      
    }
}