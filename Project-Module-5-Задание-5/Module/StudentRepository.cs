using ModuleDal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
            // TODO: retrieve data from database
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            // TODO: retrieve data from database
            throw new NotImplementedException();
        }
    }
}
