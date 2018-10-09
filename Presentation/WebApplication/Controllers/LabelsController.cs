using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    using MyExpenses.Application.AppServices.Interfaces;
    using MyExpenses.Application.Dtos;
    using MyExpenses.Domain.IoT.Services;

    public class LabelsController : Controller
    {
        //private readonly ILabelAppService _service;

        public LabelsController()
        {
            //_service = service;

            //var a = _service.Get().ToList();
            //a.ForEach(x => Console.WriteLine(x.Name));
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