﻿using System.Collections.Generic;
using System.Web.Mvc;
using ArtHub.Models;
using ArtHub.ViewModels;

namespace ArtHub.Application
{
    public interface IExhibitService
    {
        void Create(Exhibit exhibit);
        IEnumerable<Exhibit> Get();
        IEnumerable<ExhibitType> GetExhibitTypes();
    }
}