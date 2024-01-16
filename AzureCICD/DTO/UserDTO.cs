using System.ComponentModel.DataAnnotations;

namespace AzureCICD.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
