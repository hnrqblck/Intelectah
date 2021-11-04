using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intelectah.Models
{
    public class ExamsTypes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome do Exame")]
        public string ExamName { get; set; }
        [Required]
        [MaxLength(256)]
        [Display(Name = "Descrição")]
        public string ExamDescription { get; set; }
    }
}
