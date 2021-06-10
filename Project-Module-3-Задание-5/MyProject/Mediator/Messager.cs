using System;
using System.Collections.Generic;

namespace Mediator
{
    public class Messager : IMediator
    {
        private List<Person> _people = new List<Person>();

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public void Notify(object sender, string message)
        {
            foreach (var person in _people)
            {
                person.GetMessage(sender, message);
            }
        }

        public void RemovePerson(Person person)
        {
            _people.Remove(person);
        }
    }
}
