using System;

namespace Mediator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Messager mediator = new Messager();

            Person p1 = new Person("Ivan", mediator);
            Person p2 = new Person("Vova", mediator);
            Person p3 = new Person("Katya", mediator);
            Person p4 = new Person("Tamara", mediator);

            p1.SendMessage();
            p2.SendMessage();
        }
    }
}
