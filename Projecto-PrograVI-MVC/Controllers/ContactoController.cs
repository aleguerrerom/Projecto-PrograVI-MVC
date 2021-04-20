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
    public class ContactoController : Controller
    {
        
        private SqlConnection con;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["conDB"].ToString();
            con = new SqlConnection(constring);
        }
        // GET: Contacto


        public ActionResult Contacto()
        {
            return View();
        }

        



    }
    }
