using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChallengeNubim.Models
{
    public class PaisModel
    {
        public int id { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre excede la cantidad de caracteres")]
        public string descripcion { get; set; }

    }
}