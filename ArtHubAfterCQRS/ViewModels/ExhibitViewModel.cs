using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ArtHub.Models;

namespace ArtHub.ViewModels
{
    public class ExhibitViewModel
    {
        public string Heading { get; set; }

        public IEnumerable<Exhibit> Exhibits { get; set; }
    }
}