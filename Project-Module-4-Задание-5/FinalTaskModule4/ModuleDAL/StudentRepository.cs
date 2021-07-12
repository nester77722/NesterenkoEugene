using ModuleDal.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ModuleDal
{
    public class StudentRepository
    {
        private readonly ModuleContext _context;

        public StudentRepository()
        {
            _context = new ModuleContext();
        }

        public IEnumerable<Student> GetAll()
        {
            var result = _context.Students;
            
            return result;
        }

        public Student GetById(int id)
        {
            var result = (from s in _context.Students
                          where s.Id == id
                          select s).FirstOrDefault();

            var payments = (from p in _context.Payments
                           where p.StudentId == result.Id
                           select p).ToList();

            result.Payments = payments;
            return result;
        }
    }
}
