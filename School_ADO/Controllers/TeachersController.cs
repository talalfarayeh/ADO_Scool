using School_ADO.Models.Entity;
using School_ADO.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_ADO.Controllers
{
    
        public class TeachersController : Controller
        {
            private readonly TeacherRepository _repository;

            public TeachersController()
            {
                _repository = new TeacherRepository();
            }

            
            public ActionResult Index()
            {
                var teachers = _repository.GetAllTeachers();
                return View(teachers);
            }

            
            public ActionResult Create()
            {
                return View();
            }

           
            [HttpPost]
            public ActionResult Create(Teacher teacher)
            {
                if (ModelState.IsValid)
                {
                    _repository.InsertTeacher(teacher);
                    return RedirectToAction("Index");
                }
                return View(teacher);
            }

            
            public ActionResult Edit(int id)
            {
                var teacher = _repository.GetTeacherById(id);
                if (teacher == null)
                {
                    return HttpNotFound();
                }
                return View(teacher);
            }

            
            [HttpPost]
            public ActionResult Edit(Teacher teacher)
            {
                if (ModelState.IsValid)
                {
                    _repository.UpdateTeacher(teacher);
                    return RedirectToAction("Index");
                }
                return View(teacher);
            }

          
            public ActionResult Delete(int id)
            {
                var teacher = _repository.GetTeacherById(id);
                if (teacher == null)
                {
                    return HttpNotFound();
                }
                return View(teacher);
            }

           
            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                _repository.DeleteTeacher(id);
                return RedirectToAction("Index");
            }
        }
    
}