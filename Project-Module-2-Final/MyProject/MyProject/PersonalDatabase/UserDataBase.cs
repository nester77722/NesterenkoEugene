using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MyProject.Attributes;
using MyProject.Exceptions;
using MyProject.Users;
using Newtonsoft.Json;

namespace MyProject.PersonalDatabase
{
    public class UserDataBase
    {
        private User[] _users;
        private string _playersPath;
        private string _adminsPath;
        public UserDataBase(string path)
        {
            _users = new User[0];
            _playersPath = path + "PlayersDataBase.json";
            _adminsPath = path + "AdminsDataBase.json";
            ReadBase();
        }

        public void AddUser(User newUser)
        {
            ReadBase();

            var temp = _users;

            _users = new User[temp.Length + 1];

            temp.CopyTo(_users, 0);

            _users[_users.Length - 1] = newUser;

            SaveBase();
        }

        public User[] GetUsers()
        {
            return _users;
        }

        public Player[] GetPlayers()
        {
            Player[] players = new Player[_users.Length];
            int i = 0;

            foreach (var user in _users)
            {
                Player temp = user as Player;
                if (temp != null)
                {
                    players[i] = temp;
                    i++;
                }
            }

            Array.Resize(ref players, i);

            return players;
        }

        public Admin[] GetAdmins()
        {
            Admin[] admins = new Admin[_users.Length];
            int i = 0;

            foreach (var user in _users)
            {
                Admin temp = user as Admin;
                if (temp != null)
                {
                    admins[i] = temp;
                    i++;
                }
            }

            Array.Resize(ref admins, i);

            return admins;
        }

        private void ReadBase()
        {
            var players = ReadFile<Player>(_playersPath);
            var admins = ReadFile<Admin>(_adminsPath);

            _users = new User[players.Length + admins.Length];
            int i = 0;

            foreach (var player in players)
            {
                _users[i] = player;
                i++;
            }

            foreach (var admin in admins)
            {
                _users[i] = admin;
                i++;
            }
        }

        private T[] ReadFile<T>(string path)
        {
            T[] users = new T[0];
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string json = streamReader.ReadToEnd();

                    if (!string.IsNullOrEmpty(json))
                    {
                        users = JsonConvert.DeserializeObject<List<T>>(json).ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new UserDataBaseException("Не удалось прочитать базу данных.", ex);
            }

            return users;
        }

        private void SaveBase()
        {
            using (StreamWriter streamWriter = new StreamWriter(_playersPath))
            {
                string json = JsonConvert.SerializeObject(GetPlayers());
                streamWriter.Write(json);
            }

            using (StreamWriter streamWriter = new StreamWriter(_adminsPath))
            {
                string json = JsonConvert.SerializeObject(GetAdmins());
                streamWriter.Write(json);
            }
        }
    }
}
