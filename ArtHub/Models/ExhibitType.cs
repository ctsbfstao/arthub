using System.ComponentModel.DataAnnotations;

namespace ArtHub.Models
{
    public class ExhibitType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}