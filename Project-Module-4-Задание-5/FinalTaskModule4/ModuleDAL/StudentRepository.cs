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
            return result;
        }
    }
}
