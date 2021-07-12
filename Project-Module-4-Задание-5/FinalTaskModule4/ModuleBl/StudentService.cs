using ModuleBL.Models;
using ModuleDal;
using System;
using System.Collections.Generic;
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

            var result = new StudentModel(studentEntity.Id, studentEntity.FirstName, studentEntity.LastName, studentEntity.Age);
            
            List<PaymentModel> payments = new List<PaymentModel>();
            foreach (var pay in studentEntity.Payments)
            {
                payments.Add(new PaymentModel(pay.Id, pay.Date, pay.Value, result));
            }

            result.Payments = payments;

            return result;
        }
    }
}
