using ModuleBL;
using ModulePL.ViewModels;
using System;
using System.Linq;

namespace ModulePL
{
    public class StudentsController
    {
        public StudentViewModel GetById(int id)
        {
            var service = new StudentService();

            var student = service.GetById(id);

            //TODO: implement mapping model from service to view model
            throw new NotImplementedException();
        }
    }
}
