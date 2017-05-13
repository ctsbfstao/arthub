using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ArtHub.Models;

namespace ArtHub.ViewModels
{
    public class ExhibitCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public byte ExhibitType { get; set; }

        public string Image { get; set; }

        [Required]
        public string Created { get; set; }

        public IEnumerable<ExhibitType> ExhibitTypes { get; set; }

        public DateTime GetCreated()
        {
            return DateTime.Parse(string.Format("{0}", Created));
        }
    }
}