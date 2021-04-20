using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using System.Web.Mvc.Html;


namespace Projecto_PrograVI_MVC.Models
{
    public class ConsultaModel
    {

        [Required(ErrorMessage = "Por favor ingrese su Consulta")]
        [Display(Name = "Ingrese su Consulta: ")]
        public string VLSConsulta { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Nunmero telefonica para ser contactado")]
        [Display(Name = "Ingrese su Numero de telefono: ")]
        public string VLSNumero { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Nombre")]
        [Display(Name = "Ingrese su Nombre: ")]
        public string VLSNombre { get; set; }

        [DataType(DataType.EmailAddress)]

        [Required(ErrorMessage = "Por favor ingrese su correo electronico")]
        [Display(Name = "Ingrese su correo electronico: ")]
        public string VLSCorreo { get; set; }
    }
}