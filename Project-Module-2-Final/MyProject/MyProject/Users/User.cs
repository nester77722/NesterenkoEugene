using MyProject.Attributes;

namespace MyProject.Users
{
    public abstract class User
    {
        [RequiredField]
        public string Login { get; init; }

        [RequiredField]
        public string Password { get; init; }

        public int Age { get; init; }

        public int Level { get; init; }
    }
}
