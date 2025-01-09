using School_ADO.Models.Entity;
using School_ADO.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_ADO.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentRepository _repository;

        public StudentsController()
        {
            _repository = new StudentRepository();
        }

         
        public ActionResult Index()
        {
            var students = _repository.GetAllStudents();
            return View(students);
        }

         
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        
        public ActionResult Edit(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
 
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
 
        public ActionResult Delete(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}