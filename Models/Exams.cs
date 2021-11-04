using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intelectah.Models
{
    public class Exams
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome do Exame")]
        public string ExamName { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Observações")]
        public string ExamDescription { get; set; }
        [Display(Name = "Tipo de Exame")]
        public ExamsTypes ExamType { get; set; }
        public int ExamsTypesId { get; set; }
    }
}
