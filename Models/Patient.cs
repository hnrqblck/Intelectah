using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intelectah.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name = "Nome Completo")]
        public string Name { get; set; }
        [Required]
        [CpfValidation]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Gênero")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Telefone")]
        public string Telephone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
    }
}
