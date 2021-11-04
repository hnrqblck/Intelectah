using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intelectah.Models
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }
        public Patient Patients { get; set; }
        [Display(Name = "Paciente")]
        public int PatientId { get; set; }
        [Display(Name = "Tipo de Exame")]
        public ExamsTypes ExamType { get; set; }
        [Display(Name = "Tipo de Exame")]
        public int? ExamsTypesId { get; set; }
        [Display(Name = "Exame")]
        public Exams Exam { get; set; }
        [Display(Name = "Exame")]
        public int ExamsId { get; set; }
        [Required]
        [Display(Name = "Data e Horário")]
        public DateTime AppointmentTime { get; set; }
        [Display(Name = "Protocolo")]
        public int Protocol { get; set; }

        public int randomNum()
        {
            Random rnd = new Random();
            int protocol = rnd.Next(1000000000, 1999999999);
            return protocol;
        }
    }

}
