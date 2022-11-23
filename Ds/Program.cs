using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Utilities.Collections;
using System.Security.Policy;
using Org.BouncyCastle.Crypto.Modes.Gcm;

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


            string getnick(string login, string password)
            {
                string que = "select nick from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                return (string)gg.ExecuteScalar();
            }
            void setnick(string login, string password,string nick)
            {
                string que = "UPDATE `users` SET `nick`= '" + nick + "' WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                MySqlCommand ggg = new MySqlCommand();
                ggg.CommandText = que;
                ggg.Connection = con;
                ggg.ExecuteNonQuery();
            }



            string gettag(string login, string password)
            {
                string que = "select tag from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                return (string)gg.ExecuteScalar();
            }
            void settag(string login, string password, string tag)
            {
                string que = "UPDATE `users` SET `tag`= '" + tag + "' WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                MySqlCommand ggg = new MySqlCommand();
                ggg.CommandText = que;
                ggg.Connection = con;
                ggg.ExecuteNonQuery();
            } 
            string losujtag()
            {
                Random generator = new Random();
                string tag = $"#{Convert.ToString((generator.Next(10000, 99999)))}";
                return tag;

            }





            void Logowanie(string login, string password)
            {
                string query = "select count(*) from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int Count = int.Parse(cmd.ExecuteScalar() + "");
                if (Count == 1)
                {
                    Console.WriteLine($"Zalogowano pomyślnie");

                    while(true==true)
                    {
                        Console.Clear();
                        string nazwakonta = getnick(login, password) + gettag(login, password);
                        Console.WriteLine($"Nick:{nazwakonta}");
                        Console.WriteLine("Zmień nick -- 1");
                        Console.WriteLine("Zmień tag -- 2");
                        string aktyw = Console.ReadLine();
                        if (aktyw == "1")
                        {
                            Console.Write("Podaj nowy nick:")
                            string newnick = Console.ReadLine();
                            settag(login, password, newnick);

                        }
                        else if (aktyw == "2")
                        {
                            Console.Write("Podaj nowy tag:")
                            string newtag = Console.ReadLine();
                            settag(login, password, newtag);
                        }
                    }
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

            void Rejestracja(string login, string password, string nick)
            {
                string query = "select count(*) from users WHERE login ='" + login + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int Count = int.Parse(cmd.ExecuteScalar() + "");
                if (Count == 0)
                {
                    string cmdText = "insert into users(login,haslo) values('" + login + "','" + password + "');";
                    MySqlCommand cmdd = new MySqlCommand(cmdText, con);
                    cmdd.ExecuteNonQuery();
                    setnick(login, password, nick);
                    settag(login, password, losujtag());  
                }
                else
                {
                    Console.WriteLine($"Istnieje konto o takim loginie");
                }
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









           















            while (true == true)
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
                    Console.WriteLine($"Podaj Nick");
                    Console.Write($"Nick:");
                    string nick = Console.ReadLine();
                    if (phaslo == haslo)
                    {
                        Rejestracja(login, haslo, nick);
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

