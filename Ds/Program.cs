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
using System.Diagnostics.SymbolStore;

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



            // wartowniki
            bool nickandtagexist(string nick, string tag)
            {
                string query = "select count(*) from users WHERE nick ='" + nick + "' AND tag ='" + tag + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                if (int.Parse(cmd.ExecuteScalar() + "") == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            bool ownerexist(string owner)
            {
                string query = "select count(*) from users WHERE owner ='" + owner + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                if (int.Parse(cmd.ExecuteScalar() + "") == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            bool istag(string tag)
            {
                string tab = "0123456789";
                if (tag.Length == 6)
                {
                    if (tag[0] == '#')
                    {
                        for (int i = 1; i < 6; i++)
                        {
                            bool rt = false;
                            for (int j = 0; j < 10; j++)
                            {
                                if (tag[i] == tab[j])
                                {
                                    rt = true;
                                }
                            }
                            if (rt != true)
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }








            // Losowania jednorazowe
            string losujowner()
            {
                string ow = "";
                Random generator = new Random();
                for (int i = 0; i < 36; i++)
                {
                    ow = ow + $"{Convert.ToString((generator.Next(1, 9)))}";
                }
                return ow;
            }
            string losujtag()
            {
                Random generator = new Random();
                string tag = $"#{Convert.ToString((generator.Next(10000, 99999)))}";
                return tag;

            }







            //Pobrania
            string getnick(string login, string password)
            {
                string que = "select nick from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                return (string)gg.ExecuteScalar();
            }

            string gettag(string login, string password)
            {
                string que = "select tag from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                return (string)gg.ExecuteScalar();
            }



            //Usawianie na sql
            void setowner(string login, string password, ref bool wartowner)
            {
                string s = losujowner();
                if (ownerexist(s))
                {
                    string que = "UPDATE `users` SET `owner`= '" + s + "' WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                    MySqlCommand ggg = new MySqlCommand();
                    ggg.CommandText = que;
                    ggg.Connection = con;
                    ggg.ExecuteNonQuery();
                    Console.WriteLine("Usawiono ownera");
                    wartowner = true;
                }
                else
                {
                    Console.WriteLine("Istnieje konto o takim ownerze");
                }
            }


            void setnick(string login, string password, string nick, ref bool wartnick)
            {
                string re = "select tag from users WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                MySqlCommand h = new MySqlCommand(re, con);
                string tag = (string)h.ExecuteScalar();
                if (nickandtagexist(nick, tag))
                {
                    string que = "UPDATE `users` SET `nick`= '" + nick + "' WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                    MySqlCommand ggg = new MySqlCommand();
                    ggg.CommandText = que;
                    ggg.Connection = con;
                    ggg.ExecuteNonQuery();
                    Console.WriteLine("Zmieniono nick");



                    string gh = "select nick from users WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                    MySqlCommand hj = new MySqlCommand(gh, con);
                    string nickk = (string)hj.ExecuteScalar();
                    string ghh = "select tag from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                    MySqlCommand hh = new MySqlCommand(ghh, con);
                    string tagg = (string)hh.ExecuteScalar();
                    string addfriend = nickk + tagg;
                    string quee = "UPDATE `users` SET `addfriend`= '" + addfriend + "' WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                    MySqlCommand gggg = new MySqlCommand();
                    gggg.CommandText = quee;
                    gggg.Connection = con;
                    gggg.ExecuteNonQuery();
                    wartnick = true;

                }
                else
                {
                    Console.WriteLine("Taki nick istnieje przy koncie o takim samym tagu");
                }

            }




            void settag(string login, string password, string tag, ref bool warttag)
            {
                tag.Trim();
                if (istag(tag))
                {
                    string re = "select nick from users WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                    MySqlCommand h = new MySqlCommand(re, con);
                    string nick = (string)h.ExecuteScalar();

                    if (nickandtagexist(nick, tag))
                    {
                        string que = "UPDATE `users` SET `tag`= '" + tag + "' WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                        MySqlCommand ggg = new MySqlCommand();
                        ggg.CommandText = que;
                        ggg.Connection = con;
                        ggg.ExecuteNonQuery();
                        Console.WriteLine("Zmieniono tag");


                        string gh = "select nick from users WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                        MySqlCommand hj = new MySqlCommand(gh, con);
                        string nickk = (string)hj.ExecuteScalar();
                        string ghh = "select tag from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                        MySqlCommand hh = new MySqlCommand(ghh, con);
                        string tagg = (string)hh.ExecuteScalar();
                        string addfriend = nickk + tagg;
                        string quee = "UPDATE `users` SET `addfriend`= '" + addfriend + "' WHERE `login`= '" + login + "'AND`haslo`= '" + password + "'; ";
                        MySqlCommand gggg = new MySqlCommand();
                        gggg.CommandText = quee;
                        gggg.Connection = con;
                        gggg.ExecuteNonQuery();
                        warttag = true;
                    }
                    else
                    {
                        Console.WriteLine("Taki tag istnieje przy koncie o takiej samej nazwie");
                    }
                }
                else
                {
                    Console.WriteLine("To nie jest tag przykład #12345");
                }
            }



























            void Logowanie(string login, string password)
            {
                string query = "select count(*) from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int Count = int.Parse(cmd.ExecuteScalar() + "");
                if (Count == 1)
                {
                    Console.WriteLine($"Zalogowano pomyślnie");

                    while (true == true)
                    {
                        Console.Clear();
                        string nazwakonta = getnick(login, password) + gettag(login, password);
                        Console.WriteLine($"Nick:{nazwakonta}");
                        Console.WriteLine("Zmień nick -- 1");
                        Console.WriteLine("Zmień tag -- 2");
                        Console.WriteLine("Lista znajomych: ");


                        string aktyw = Console.ReadLine();
                        if (aktyw == "1")
                        {
                            Console.Write("Podaj nowy nick:");
                            string newnick = Console.ReadLine();
                            bool op=true;
                            setnick(login, password, newnick, ref op);
                            Console.ReadLine();
                        }
                        else if (aktyw == "2")
                        {
                            Console.Write("Podaj nowy tag:");
                            string newtag = Console.ReadLine();
                            bool op = true;
                            settag(login, password, newtag, ref op);
                            Console.ReadLine();
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
                    if (haslem == password)
                    {
                        Console.WriteLine("Nie poprawny login");
                        Console.ReadLine();
                    }
                    else if (loginem == login)
                    {
                        Console.WriteLine("Nie poprawne hasło");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Takie konto nie istnieje");
                        Console.ReadLine();
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
                    bool wartnick = false, warttag = false, wartowner = false;
                    setnick(login, password, nick, ref wartnick);
                    settag(login, password, losujtag(), ref warttag);
                    if (warttag==true && wartnick == true)
                    {
                        while (wartowner != true)
                        {
                            setowner(login, password, ref wartowner);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Istnieje konto o takim loginie");
                    Console.ReadLine();
                }
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
                        Console.ReadLine();
                    }
                }
                Thread.Sleep(5);
            }
        }
    }
}

