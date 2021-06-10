using System;

namespace Mediator
{
    public class Person
    {
        private Messager _mediator;
        public Person(string name, Messager mediator)
        {
            Name = name;
            _mediator = mediator;
            _mediator.AddPerson(this);
        }

        public string Name { get; init; }

        public void GetMessage(object sender, string message)
        {
            if (sender != this)
            {
                string senderName = (sender as Person).Name;
                Console.WriteLine($"{Name} recieved message \"{message}\" from {senderName}");
            }
        }

        public void SendMessage()
        {
            string message = "Hello!";

            Console.WriteLine($"{Name} sending message {message}");
            _mediator.Notify(this, message);
        }
    }
}
