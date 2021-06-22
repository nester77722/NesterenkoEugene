using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class User
    {
        public User(int id, string name)
            : this(id, name, "notStated", 0)
        {
        }

        public User(int id, string name, string gender)
            : this(id, name, gender, 0)
        {

        }

        public User(int id, string name, uint age)
            : this(id,name, "notStated", age)
        {

        }

        public User(int id, string name, string gender, uint age)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
        }

        public int Id { get; init; }

        public string Name { get; init; }

        public string Gender { get; set; }

        public uint Age { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Gender} {Age}";
        }
    }
}
