using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using System.Web.Mvc.Html;

namespace Projecto_PrograVI_MVC.Models
{
    public class AccountModel
    {
        [Key]
        [StringLength(maximumLength: 40, MinimumLength = 9,
        ErrorMessage = "Ingrese una cedula valida")]
        [Required(ErrorMessage = "Por favor ingrese su Cedula")]
        [Display(Name = "Ingrese su cedula: ")]
        public string VLSCedula { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Nacionalidad")]
        [Display(Name = "Ingrese su Nacionalidad: ")]
        public string VLSNacionalidad { get; set; }
        public IEnumerable<SelectListItem> Countries;

        [Required(ErrorMessage = "El Nombre es requerido")]
        [Display(Name = "Ingrese su Nombre: ")]
        public string VLSNombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [Display(Name = "Ingrese su Primer Apellido: ")]
        public string VLSApellido1 { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [Display(Name = "Ingrese su Segundo Apellido: ")]
        public string VLSApellido2 { get; set; }

        [DataType(DataType.EmailAddress)]
       
        [Required, MinLength(1)]//[Required(ErrorMessage = "Por favor ingrese su correo electronico")]
        [Display(Name = "Ingrese su correo electronico: ")]
        public string VLSCorreo { get; set; }

        [StringLength(maximumLength: 16, MinimumLength = 16,
        ErrorMessage = "Ingrese un numero de tarjeta valido")]
        [Required(ErrorMessage = "Por favor ingrese su Numero de Tarjeta")]
        [Display(Name = "Ingrese su Numero de Tarjeta: ")]
        public string VLSNumTarjeta { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su Nombre de Tarjeta")]
        [Display(Name = "Ingrese su Nombre de Tarjeta: ")]
        public string VLSNomTarjeta { get; set; }

        [StringLength(maximumLength: 4, MinimumLength = 4,
        ErrorMessage = "Ingrese un Codigo Valido")]
        [Required(ErrorMessage = "Por favor ingrese su Codigo de Tarjeta")]
        [Display(Name = "Ingrese su Codigo de Tarjeta: ")]
        public string VLSCodigoTarjeta { get; set; }

       // [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Por favor ingrese la Fecha de expiracion de la tarjeta")]
        [Display(Name = "Ingrese la Fecha de Expiracion Tarjeta: ")]
        public string VLSFechaExp { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese la Provincia en donde vive")]
        [Display(Name = "Ingrese la Provincia en donde vive: ")]
        public string VLSProvincia { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el Canton en donde vive")]
        [Display(Name = "Ingrese la Fecha el Canton en donde vive ")]
        public string VLSCanton { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el distrito en donde vive")]
        [Display(Name = "Ingrese la Fecha el Distrito en donde vive ")]
        public string VLSDistrito { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la Pregunta de Seguridad")]
        [Display(Name = "Ingrese la Pregunta de Seguridad: ")]
        public string VLSPreSeg { get; set; }

        [StringLength(maximumLength: 12, MinimumLength = 4,
        ErrorMessage = "La Clave debe ser de minimo 5 caracteres y 12 maximo")]
        [Required,MinLength(4)]//(ErrorMessage = "Por favor ingrese su Contrasena")]
        [Display(Name = "Ingrese su contrasena: ")]
        [DataType(DataType.Password)]
        public string VLSClave { get; set; }
        
        public bool VLSRecordarClave { get; set; }
        
        public string VLSPrivilegios { get; set; }
        [Required]
        [Compare("VLSClave", ErrorMessage = "Las claves no coinciden favor revisar")]
        [DataType(DataType.Password)]
        [Display(Name = "Ingrese su confirmacion de contrasena: ")]
        public string VLSConfirmar { get; set; }

       /* private string mensaje;

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

        public AccountModel(string pvnMensaje, string pvnCorreo)
        {
            mensaje = pvnMensaje;
            VLS_Correo = pvnCorreo;
            
        }*/
    }


}