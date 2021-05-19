using System;
using System.IO;
using MyProject.Exceptions;
using MyProject.Registrator;
using Newtonsoft.Json;
using MyProject.Users;

namespace MyProject
{
    public class View
    {
        private Registrator.Registrator _registrator;

        public View()
        {
            try
            {
                string path = @"D:\/RegistratorProgram\Config\RegistratorConfig.json";

                var configJson = File.ReadAllText(path);
                var config = JsonConvert.DeserializeObject<RegistratorConfig>(configJson);
                _registrator = new Registrator.Registrator(config);
            }
            catch (UserDataBaseException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Menu();
        }

        public void Menu()
        {
            bool openMenu = true;
            while (openMenu)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Registration();
                            break;
                        }

                    case "2":
                        {
                            Login();
                            break;
                        }

                    case "101":
                        {
                            LoginAdmin();
                            break;
                        }

                    case "3":
                        {
                            openMenu = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Неверный ввод!");
                            break;
                        }
                }
            }
        }

        private void Registration()
        {
            try
            {
                User newUser = InputUser();

                _registrator.AddUser(newUser);
            }
            catch (FieldRequiredException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UserExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла ошибка, попробуйте снова.");
            }
        }

        private void Login()
        {
            User user = InputUser();

            bool result = _registrator.LoginUser(user);

            if (result)
            {
                Console.WriteLine("Вход выполнен.");
            }
            else
            {
                Console.WriteLine("Ошибка авторизации.");
            }
        }

        private User InputUser()
        {
            string login;
            string password;

            Console.Write("Введите логин: ");
            login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            password = Console.ReadLine();

            User newUser = new Player { Login = login, Password = password };
            return newUser;
        }

        private void LoginAdmin()
        {
            string login;
            string password;

            Console.Write("Введите логин: ");
            login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            password = Console.ReadLine();

            User admin = new Admin { Login = login, Password = password };

            bool result = _registrator.LoginUser(admin);

            if (result)
            {
                Console.WriteLine("Вход выполнен.");
            }
            else
            {
                Console.WriteLine("Ошибка авторизации.");
            }
        }
    }
}
