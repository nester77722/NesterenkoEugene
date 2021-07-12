using ModuleBL;
using ModulePL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModulePL
{
    public class StudentsController
    {
        public StudentViewModel GetById(int id)
        {
            var service = new StudentService();

            var student = service.GetById(id);

            StudentViewModel result = new StudentViewModel($"{student.FirstName} {student.LastName}", student.Age);

            List<PaymentViewModel> paymentViewModels = new List<PaymentViewModel>();

            foreach (var pay in student.Payments)
            {
                paymentViewModels.Add(new PaymentViewModel(pay.Date, pay.Value));
            }

            result.Payments = paymentViewModels;

            return result;
        }
    }
}
