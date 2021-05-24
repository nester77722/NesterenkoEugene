using System;
using System.IO;
using MyProject.Exceptions;
using MyProject.Registrator;
using MyProject.Users;
using Newtonsoft.Json;

namespace MyProject.PersonalDatabase
{
    public class UserDataBase
    {
        private User[] _users;
        private string _path;
        private string[] _userTypes;
        public UserDataBase(RegistratorConfig config)
        {
            _users = new User[0];
            _path = config.DataBasePath + "UsersDataBase.json";
            _userTypes = config.UserTypes;
            ReadBase();
        }

        public User[] Users => _users;

        public void AddUser(User newUser)
        {
            var temp = _users;

            _users = new User[temp.Length + 1];

            temp.CopyTo(_users, 0);

            _users[_users.Length - 1] = newUser;

            SaveBase();
        }

        private void ReadBase()
        {
            try
            {
                foreach (string userType in _userTypes)
                {
                    var type = Type.GetType(typeof(User).Namespace + "." + userType).MakeArrayType();

                    using (StreamReader streamReader = new StreamReader(_path))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string line = streamReader.ReadLine();

                            if (line == userType)
                            {
                                string nextLine = streamReader.ReadLine();

                                if (!string.IsNullOrEmpty(nextLine))
                                {
                                    User[] users = JsonConvert.DeserializeObject(nextLine, type) as User[];

                                    var temp = _users;
                                    Array.Resize(ref _users, _users.Length + users.Length);
                                    temp.CopyTo(_users, 0);
                                    users.CopyTo(_users, temp.Length);
                                }

                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserDataBaseException("Не удалось прочитать базу данных.", ex);
            }
        }

        private void SaveBase()
        {
            File.WriteAllText(_path, string.Empty);

            foreach (string userType in _userTypes)
            {
                User[] users = new User[_users.Length];
                int currentLength = 0;

                foreach (var user in _users)
                {
                    if (user.GetType().Name == userType.ToString())
                    {
                        users[currentLength] = user;
                        currentLength++;
                    }
                }

                Array.Resize(ref users, currentLength);

                using (StreamWriter streamWriter = new StreamWriter(_path, true))
                {
                    string json = $"{userType.ToString()}\n{JsonConvert.SerializeObject(users)}";
                    streamWriter.WriteLine(json);
                }
            }
        }
    }
}
