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

            List<PaymentViewModel> paymentViewModels = new List<PaymentViewModel>();

            throw new NotImplementedException();
        }
    }
}
