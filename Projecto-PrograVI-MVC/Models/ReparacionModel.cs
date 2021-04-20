using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using System.Web.Mvc.Html;
using System.Web.Mvc;


namespace Projecto_PrograVI_MVC.Models
{
    public class ReparacionModel
    {
        
        [Required(ErrorMessage = "Por favor selecione marca")]
        [Display(Name = "Ingrese Marca de Dispositivo ")]
        public string VLSMarca { get; set; }

        public int VLSMarcaID { get; set; }

        public List<ReparacionModel> MarcaInfo { get; set;}
        


    [Required(ErrorMessage = "Por favor ingrese daño")]
        [Display(Name = "Ingrese el daño: ")]
        public string VLSDano { get; set; }

        [Required(ErrorMessage = "Ingrese la Capacidad del Disco es requerida")]
        [Display(Name = "Ingrese capacidad de Disco: ")]
        public string VLSDiscoDuro { get; set; }

        [Required(ErrorMessage = "Ingrese la capacidad de memoria es requerido")]
        [Display(Name = "Ingrese capacidad de memoria: ")]
        public string VLSMemoria { get; set; }

        [Required(ErrorMessage = "Ingrese el Tipo de Dispositivo Laptop/Desktop")]
        [Display(Name = "Ingrese el Tipo de Dispositivo Laptop/Desktop: ")]
        public string VLSTipo { get; set; }

        [Required(ErrorMessage = "Por favor ingrese sistema operativo")]
        [Display(Name = "Ingrese su sistema operativo: ")]
        public string VLSSO{ get; set; }
        
        [Required(ErrorMessage = "Ingrese adicionales")]
        [Display(Name = "Ingrese adicionales: ")]
        public string VLSAdicionales { get; set; }

        [Required(ErrorMessage = "Ingrese Por favor ingrese si require limpieza interna, externa o ambas")]
        [Display(Name = "Ingrese Por favor ingrese si require limpieza interna, externa o ambas: ")]
        public string VLSLimpieza { get; set; }
        
        [Required(ErrorMessage = "Descripcion del Problema")]
        [Display(Name = "Ingrese descripcion del problema: ")]
        public string VLSDescripcion{ get; set; }

        public string VLSCosto { get; set; }
    }
}