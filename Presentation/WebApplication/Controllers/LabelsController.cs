/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;

    public class LabelsController : Controller
    {
        private readonly ILabelAppService _service;

        public LabelsController(ILabelAppService service)
        {
            _service = service;

            var l = new LabelDto { Id = Guid.NewGuid(), Name = "Foca" };
            _service.Add(l);

            var a = _service.GetAll().ToList();
            a.ForEach(x => Console.WriteLine(x.Name));
        }

        // GET: Labels
        public ActionResult Index()
        {
            var l = new List<LabelDto> { new LabelDto { Id = Guid.NewGuid(), Name = "Foca" } };
            return View(l);
        }

        // GET: Labels/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Labels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Labels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Labels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Labels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Labels/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Labels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}