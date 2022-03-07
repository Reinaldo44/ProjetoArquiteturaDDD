using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Infrastructure.Data.Common;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Cadastro.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;
        private readonly IClientViewModelService _clientViewModelService;
        private readonly ICategoryViewModelService _categoryViewModelService;
        // private readonly RegisterContext _context;
        public ProductController(IProductViewModelService productViewModelService,
            IClientViewModelService clientViewModelService, ICategoryViewModelService categoryViewModelService)
        {
            //_context = registerContext;
            _productViewModelService = productViewModelService;
            _clientViewModelService = clientViewModelService;
            _categoryViewModelService = categoryViewModelService;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            var list = _productViewModelService.GetAll();
            return View(list);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {

            var produto = _productViewModelService.Get(id);
          
            return View(produto);

        }

        // GET: Clients/Create
        public ActionResult Create()

        {

            ViewBag.ClientId = new SelectList(_clientViewModelService.GetAll(), "ClientId", "Name");
            ViewBag.CategoryId = new SelectList(_categoryViewModelService.GetAll(), "CategoryId", "Name");
            return View();

        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _productViewModelService.Get(id);
            ViewBag.ClientId = new SelectList(_productViewModelService.GetAll(), "ClientId", "Name", produto.ClientId);
            ViewBag.CategoryId = new SelectList(_productViewModelService.GetAll(), "CategoryId", "Name", produto.CategoryId);
            return View(produto);


        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: Clients/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
