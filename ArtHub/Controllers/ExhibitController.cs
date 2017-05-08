using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ArtHub.Application;
using ArtHub.Models;
using ArtHub.ViewModels;

namespace ArtHub.Controllers
{
    public class ExhibitController : Controller
    {
        private readonly IExhibitService _service;

        public ExhibitController() : this(new ExhibitService())
        {

        }
        public ExhibitController(IExhibitService service)
        {
            _service = service;
        }

        public ActionResult Create()
        {
            return View("Create", new ExhibitCreateViewModel()
            {
                ExhibitTypes = _service.GetExhibitTypes()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExhibitCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", new ExhibitCreateViewModel()
                {
                    ExhibitTypes = _service.GetExhibitTypes()
                });
            }

            var exhibit = new Exhibit()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Created = viewModel.GetCreated(),
                TypeId = viewModel.ExhibitType
            };

            _service.Create(exhibit);
            return RedirectToAction("Index");
        }


        public ActionResult Index()
        {
            //var exhibits = new List<Exhibit>()
            //{
            //    new Exhibit()
            //    {
            //        Id = 1,
            //        Name = "Mona Lisa",
            //        Description = "Oil Painting",
            //        Type = "Painting",
            //        Created = DateTime.MinValue
            //    },
            //    new Exhibit()
            //    {
            //        Id = 2,
            //        Name = "Picasso",
            //        Description = "Water Color",
            //        Type = "Painting",
            //        Created = DateTime.MinValue
            //    }

            //};

            var exhibitViewModel = new ExhibitViewModel()
            {
                Heading = "Current exhibits",
                Exhibits = _service.Get()
            };
            return View("Index", exhibitViewModel);
        }
    }
}