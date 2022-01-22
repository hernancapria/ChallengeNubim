using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChallengeNubim.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre excede la cantidad de caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El nombre excede la cantidad de caracteres")]
        public string apellido { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email es invalido")]
        public string email { get; set; }

        [Display(Name = "Password")]
        public string password { get; set; }

        public List<Ticket> tickets { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date, ErrorMessage = "Fecha incorrecta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? fecha_ingreso { get; set; }

        [Display(Name = "Pais")]
        [Range(1, int.MaxValue, ErrorMessage = "El pais es requerido")]
        [Required(ErrorMessage = "El pais es requerido")]
        public int? id_pais { get; set; }

        public string descripcionPais { get; set; }

        public List<PaisModel> Paises { get; set; }

        

    }
}