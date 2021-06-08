using System.ComponentModel.DataAnnotations;

namespace ProjectY.Logic.Models
{
    public class AddHomeDto
    {
        [Required]
        public int Number { get; set; }
    }
}
