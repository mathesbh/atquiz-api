using System;
using System.ComponentModel.DataAnnotations;

namespace AtQuiz.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter no minimo 3 caracteres")]
        public string Response { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int QuestionnaireId { get; set; }

        public Questionnaire Questionnaire { get; set; }
    }
}