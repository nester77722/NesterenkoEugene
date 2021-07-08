using ModuleBL.Models;
using ModuleDal;
using System;
using System.Linq;

namespace ModuleBL
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public StudentModel GetById(int id)
        {
            var studentEntity = _studentRepository.GetById(id);

            if (studentEntity == null)
                throw new ArgumentException("Student not fount");

            var results = new StudentModel();

            //TODO: map data from repository to model

            return results;
        }
    }
}
