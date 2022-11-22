using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "App by Mokotowski#2531";
            string server = "116.202.211.83";
            string database = "db_79640";
            string username = "db_79640";
            string password = "DHmGq37Az12O";
            string cs = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            var con = new MySqlConnection(cs);
            con.Open();






            void Logowanie(string login, string password)
            {
                string query = "select count(*) from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int Count = int.Parse(cmd.ExecuteScalar() + "");
                if (Count == 1)
                {
                    Console.WriteLine($"Zalogowano pomyślnie");





                    // dalsze przejście




                }
                else
                {
                    string querry = "select haslo from users WHERE login ='" + login + "'";
                    string querrry = "select login from users WHERE haslo ='" + password + "'";

                    MySqlCommand cmdd = new MySqlCommand(querry, con);
                    MySqlCommand cmddd = new MySqlCommand(querrry, con);
                    string loginem = (string)cmdd.ExecuteScalar();
                    string haslem = (string)cmddd.ExecuteScalar();
                    if  (haslem == password)
                    {
                        Console.WriteLine("Nie poprawny login");
                    }
                    else if (loginem == login) 
                    {
                        Console.WriteLine("Nie poprawne hasło");
                    }
                    else
                    {
                        Console.WriteLine("Takie konto nie istnieje");
                    }


                }
            }

            void Rejestracja(string login, string password)
            {
                string query = "select count(*) from users WHERE login ='" + login + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int Count = int.Parse(cmd.ExecuteScalar() + "");
                if (Count == 0)
                {
                    string cmdText = "insert into users(login,haslo) values('" + login + "','" + password + "');";
                    MySqlCommand cmdd = new MySqlCommand(cmdText, con);
                    cmdd.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine($"Istnieje konto o takim loginie");
                }
            }




           






            void zlehasloo()
            {
                Console.WriteLine($"Podano złe hasło");
                Console.WriteLine($"Zarejestruj się");
                Console.WriteLine($"Podaj login nowego konta");
                Console.Write($"Login:");
                string login11 = Console.ReadLine();
                Console.WriteLine($"Podaj hasło nowego konta");
                Console.Write($"Hasło:");
                string haslo11 = Console.ReadLine();
                Console.WriteLine($"Podaj klucz bezpieczeństwa administratora aby utworzyć nowe konto");
                Console.Write($"Klucz:");
                string kbez = Console.ReadLine();
                Console.WriteLine();
            }



            void wczytajczat()
            {
                string sql = "SELECT user, text FROM czat ORDER BY id DESC LIMIT 10";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                var czat = new List<string> { };
                while (rdr.Read())
                {
                    string s = rdr[0] + ":" + rdr[1];
                    czat.Add(s);
                }
                czat.Reverse();
                rdr.Close();
                foreach (var sss in czat)
                {
                    Console.WriteLine(sss);
                }


            }


            void pisznaczacie(string osoba, string wiadomosci)
            {
                string cmdText = "insert into czat(user,text) values('" + osoba + "','" + wiadomosci + "');";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.ExecuteNonQuery();


            }




       




            while(true == true)
            {
                Console.Clear();
                Console.WriteLine($"Logowanie -- 1");
                Console.WriteLine($"Rejestracja -- 2");
                string start = Console.ReadLine();
                if (start == "1")
                {
                    Console.WriteLine($"Podaj login");
                    Console.Write($"Login:");
                    string login = Console.ReadLine();
                    Console.WriteLine($"Podaj hasło");
                    Console.Write($"Hasło:");
                    string haslo = Console.ReadLine();
                    Logowanie(login, haslo);
                }
                else if (start == "2") 
                {
                    Console.WriteLine("Rejestracja");
                    Console.WriteLine($"Podaj login");
                    Console.Write($"Login:");
                    string login = Console.ReadLine();
                    Console.WriteLine($"Podaj hasło");
                    Console.Write($"Hasło:");
                    string haslo = Console.ReadLine();
                    Console.WriteLine($"Podaj powtórzone hasło");
                    Console.Write($"Powtórzone hasło:");
                    string phaslo = Console.ReadLine();
                    if (phaslo == haslo)
                    {
                        Rejestracja(login, haslo);
                    }
                    else
                    {
                        Console.WriteLine($"Hasła nie są identyczne");
                    }
                }
            Thread.Sleep(5);
            }
        }
    }
}

