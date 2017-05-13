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
        private readonly IExhibitQuery _query;
        private readonly IExhibitCommand _command;

        public ExhibitController() : this(new ExhibitQuery(), new ExhibitCommand())
        {

        }
        public ExhibitController(IExhibitQuery query, IExhibitCommand command)
        {
            _query = query;
            _command = command;
        }

        public ActionResult Create()
        {
            return View("Create", new ExhibitCreateViewModel()
            {
                ExhibitTypes = _query.GetExhibitTypes()
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
                    ExhibitTypes = _query.GetExhibitTypes()
                });
            }

            var exhibit = new Exhibit()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Created = viewModel.GetCreated(),
                TypeId = viewModel.ExhibitType
            };



            _command.Create(exhibit);


            return RedirectToAction("Index");
        }


        public ActionResult Index()
        {
            var exhibitViewModel = new ExhibitViewModel()
            {
                Heading = "Current exhibits",
                Exhibits = _query.Get()
            };
            return View("Index", exhibitViewModel);
        }
    }
}