﻿namespace SuperCharacters.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SuperCharactersApp.Services.CRUD.Services;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;

    /// <summary>
    /// Controller responsible for SuperPowers Entity.
    /// </summary>
    [Authorize]
    public class SuperpowerController : Controller
    {
        private readonly SuperpowerServices _superpowerServices;
        private readonly PaginationServices<SuperPowersListingViewModel> _paginationServices;


        public SuperpowerController(
            SuperpowerServices superpowerServices,
            PaginationServices<SuperPowersListingViewModel> paginationServices
            )
        {
            _paginationServices = paginationServices;
            _superpowerServices = superpowerServices;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SuperPowersListingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create", "Character");
            }

            _superpowerServices.Create(viewModel);

            return RedirectToAction("ListSuperpowers");
        }

        [HttpGet]
        public IActionResult ListSuperpowers(int? pageNumber)
        {
            var paginatedSuperpowersList = _paginationServices.Pagination(pageNumber, _superpowerServices);

            return View(paginatedSuperpowersList);
;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string formModal)
        {
            var id = formModal;

            var superpower = _superpowerServices.GetById(id);

            if (superpower != null)
            {
                _superpowerServices.DeleteById(id);

                var currentSuperPowersList = _superpowerServices.GetAll();
                return RedirectToAction("ListSuperpowers", currentSuperPowersList);
            }
            else
            {
                return Json("Invalid Id.Try again");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SuperPowersListingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _superpowerServices.Edit(viewModel);

            return RedirectToAction("ListSuperpowers", "SuperPower");
        }
    }
}