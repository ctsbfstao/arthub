using System;
using System.ComponentModel.DataAnnotations;

namespace ArtHub.Models
{
    public class Exhibit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(255)]

        public string Description { get; set; }

        public ExhibitType Type { get; set; }

        [Required]
        public byte TypeId { get; set; }

        public string Image { get; set; }

        public DateTime Created { get; set; }

    }
}