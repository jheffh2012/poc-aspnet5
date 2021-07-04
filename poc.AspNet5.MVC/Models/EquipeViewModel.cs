﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace poc.AspNet5.MVC.Models
{
    public class EquipeViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        public ICollection<UsuarioViewModel> Usuarios { get; set; }
        public ICollection<CalendarioViewModel> Calendarios { get; set; }

    }
}
