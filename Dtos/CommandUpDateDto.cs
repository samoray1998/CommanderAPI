using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandUpDateDto
    {
         [Required]
        [MaxLength(500)]

        public string HowTo { get; set; }
        [Required]
        
        public string Line { get; set; }
        [Required]
       
        public string Platform { get; set; }
    }
}