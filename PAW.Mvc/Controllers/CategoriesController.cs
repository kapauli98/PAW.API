﻿//using Microsoft.AspNetCore.Mvc;
//using PAW.Business;
//using PAW.Models;

//namespace PAW.Mvc.Controllers
//{
//    public class CategoriesController : MainController
//    {
//        private readonly ICategoriesManager _categoriesManager;

//        public CategoriesController(IProductManager productManager)
//            : base(productManager)
//        {
//            _categoriesManager = categoriesManager;
//        }

//        // GET: CategoriesController
//        public ActionResult Index()
//        {
//            var categories = _categoriesManager.GetCategories();
//            return View(categories);
//        }

//        // GET: CategoriesController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: CategoriesController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: CategoriesController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: CategoriesController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: CategoriesController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: CategoriesController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: CategoriesController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}