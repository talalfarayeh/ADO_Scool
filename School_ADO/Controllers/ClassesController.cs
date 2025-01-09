using School_ADO.Models.Entity;
using School_ADO.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_ADO.Controllers
{
    public class ClassesController : Controller
    {
        private readonly ClassRepository _repository;

        public ClassesController()
        {
            _repository = new ClassRepository();
        }

        
        public ActionResult Index()
        {
            var classes = _repository.GetAllClasses();
            return View(classes);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Class classItem)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertClass(classItem);
                return RedirectToAction("Index");
            }
            return View(classItem);
        }

        
        public ActionResult Edit(int id)
        {
            var classItem = _repository.GetClassById(id);
            if (classItem == null)
            {
                return HttpNotFound();
            }
            return View(classItem);
        }

         
        [HttpPost]
        public ActionResult Edit(Class classItem)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateClass(classItem);
                return RedirectToAction("Index");
            }
            return View(classItem);
        }

         
        public ActionResult Delete(int id)
        {
            var classItem = _repository.GetClassById(id);
            if (classItem == null)
            {
                return HttpNotFound();
            }
            return View(classItem);
        }

        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteClass(id);
            return RedirectToAction("Index");
        }
    }
}