using System;
using System.Reflection;
using MyProject.Attributes;
using MyProject.Exceptions;
using MyProject.PersonalDatabase;
using MyProject.Users;

namespace MyProject.Registrator
{
    public class Registrator
    {
        private UserDataBase _userDataBase;

        private RegistratorConfig _registratorConfig;

        public Registrator(RegistratorConfig config)
        {
            _registratorConfig = config;
            _userDataBase = new UserDataBase(_registratorConfig);
        }

        public User[] Users => _userDataBase.Users;

        public void AddUser(User user)
        {
            CheckRequired(user);

            if (IsExist(user))
            {
                throw new UserExistsException("Данный пользователь уже зарегестриован.");
            }

            try
            {
                _userDataBase.AddUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка. {ex.Message}");
            }
        }

        public bool LoginUser(User user)
        {
            var users = _userDataBase.Users;

            foreach (var user1 in users)
            {
                if (user1.Login == user.Login)
                {
                    if (user1.Password == user.Password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CheckRequired(User user)
        {
            var props = user.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop.GetCustomAttribute<RequiredField>() != null)
                {
                    if (prop.GetValue(user).GetType() == typeof(string))
                    {
                        if (string.IsNullOrEmpty(prop.GetValue(user) as string))
                        {
                            throw new FieldRequiredException($"Field {prop.Name} is empty!");
                        }
                    }

                    if (prop.GetValue(user).GetType() == typeof(int))
                    {
                        if ((int)prop.GetValue(user) == default(int))
                        {
                            throw new FieldRequiredException($"Field {prop.Name} is empty!");
                        }
                    }

                    if (prop.GetValue(user).GetType() == typeof(double))
                    {
                        if ((double)prop.GetValue(user) == default(double))
                        {
                            throw new FieldRequiredException($"Field {prop.Name} is empty!");
                        }
                    }
                }
            }
        }

        private bool IsExist(User user)
        {
            var users = _userDataBase.Users;
            foreach (var user1 in users)
            {
                if (user1.Login == user.Login)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
