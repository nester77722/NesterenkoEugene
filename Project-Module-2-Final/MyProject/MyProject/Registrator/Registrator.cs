using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            _userDataBase = new UserDataBase(_registratorConfig.DataBasePath);
        }

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
            var users = _userDataBase.GetUsers();

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

        public Admin[] GetAdmins()
        {
            return _userDataBase.GetAdmins();
        }

        public Player[] GetPlayers()
        {
            return _userDataBase.GetPlayers();
        }

        public User[] GetUsers()
        {
            return _userDataBase.GetUsers();
        }

        private void CheckRequired(User user)
        {
            var props = user.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop.GetCustomAttribute<RequiredField>() != null)
                {
                    if (string.IsNullOrEmpty((string)prop.GetValue(user)))
                    {
                        throw new FieldRequiredException($"Field {prop.Name} is empty!");
                    }
                }
            }
        }

        private bool IsExist(User user)
        {
            var users = _userDataBase.GetUsers();
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
