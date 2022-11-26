using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Uzytkownik
    {
        public Uzytkownik() { }
        public Uzytkownik(string login, string haslo, string nick, string tag, string addfriend, string owner)
        {
            Login = login;
            Haslo = haslo;
            Nick = nick;
            Tag = tag;
            Addfriend = addfriend;
            Owner = owner;
        }

        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Nick { get; set; }
        public string Tag { get; set; }
        public string Addfriend { get; set; }
        public string Owner { get; set; }
    }
    public class Znajomy
    {
        public Znajomy() { }
        public Znajomy(string nick, string tag, string addfriend, string owner)
        {
            Nick = nick;
            Tag = tag;
            Addfriend = addfriend;
            Owner = owner;
        }
        public string Nick { get; set; }
        public string Tag { get; set; }
        public string Addfriend { get; set; }
        public string Owner { get; set; }
    }
}

