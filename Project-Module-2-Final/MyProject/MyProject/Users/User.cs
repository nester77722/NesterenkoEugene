using MyProject.Attributes;
using Newtonsoft.Json;

namespace MyProject.Users
{
    public abstract class User
    {
        [RequiredField]
        [JsonProperty]
        public string Login { get; init; }

        [RequiredField]
        [JsonProperty]
        public string Password { get; init; }

        [JsonProperty]
        public int Age { get; init; }

        [JsonProperty]
        public int Level { get; init; }
    }
}
