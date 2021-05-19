using System;
using System.ComponentModel.DataAnnotations;

namespace AtQuiz.Models
{
    public class Questionnaire
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter no mínimo 3 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter no mínimo 3 caracteres")]
        public string User { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}