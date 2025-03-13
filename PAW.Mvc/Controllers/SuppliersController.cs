﻿//using Microsoft.AspNetCore.Mvc;
//using PAW.Business;
//using PAW.Models;

//namespace PAW.Mvc.Controllers
//{
//    public class SuppliersController : MainController
//    {
//        private readonly ISuppliersManager _suppliersManager;

//        public SuppliersController(ISuppliersManager suppliersManager, IProductManager productManager, ICategoriesManager categoriesManager)
//            : base(productManager, categoriesManager, suppliersManager)
//        {
//            _suppliersManager = suppliersManager;
//        }

//        // GET: SuppliersController
//        public ActionResult Index()
//        {
//            var suppliers = _suppliersManager.GetSuppliers();
//            return View(suppliers);
//        }

//        // GET: SuppliersController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: SuppliersController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: SuppliersController/Create
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

//        // GET: SuppliersController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: SuppliersController/Edit/5
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

//        // GET: SuppliersController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: SuppliersController/Delete/5
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