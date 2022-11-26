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




    internal class Program
    {
       

        static void Main(string[] args)
        {
            Uzytkownik zalogowany = new Uzytkownik();


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



            void zaladujznajomych(string owner, ref List<string> znajomi)
            {
                string que = "select friends from znajomi WHERE owner ='" + owner +"'";
                MySqlCommand gg = new MySqlCommand(que, con);
                string lista = (string)gg.ExecuteScalar();
                lista = lista.Remove(0, 1);
                string znak = "[";
                while (znak != "]")
                {
                    string osoba = "";
                    int index = lista.IndexOf(",");
                    if (index != 0)
                    {
                        if (index == -1)
                        {
                            for (int i = 0; i < lista.IndexOf("]"); i++)
                            {
                                osoba = osoba + lista[i];
                                znak = lista[i].ToString();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < index; i++)
                            {
                                osoba = osoba + lista[i];
                                znak = lista[i].ToString();
                            }
                        }
                        if (index == -1)
                        {
                            lista = lista.Remove(0, lista.IndexOf("]"));
                            lista = lista.Remove(0, 1);
                            znak = "]";

                        }
                        else
                        { 
                            lista = lista.Remove(0, lista.IndexOf(","));
                            lista = lista.Remove(0, 1);
                        }
                    }
                    if (osoba != "")
                    {
                        znajomi.Add(osoba);
                    }
                }
                int j = 0;
                foreach (var znajomy in znajomi)
                {
                    j++;
                    Console.WriteLine(j+"."+znajomy);
                }

            }


            void zaposzeniadoznajomych(string owner, ref List<string> znajomi)
            {
                string que = "select oczekujace from znajomi WHERE owner ='" + owner + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                string lista = (string)gg.ExecuteScalar();
                lista = lista.Remove(0, 1);
                string znak = "[";
                while (znak != "]")
                {
                    string osoba = "";
                    int index = lista.IndexOf(",");
                    if (index != 0)
                    {
                        if (index == -1)
                        {
                            for (int i = 0; i < lista.IndexOf("]"); i++)
                            {
                                osoba = osoba + lista[i];
                                znak = lista[i].ToString();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < index; i++)
                            {
                                osoba = osoba + lista[i];
                                znak = lista[i].ToString();
                            }
                        }
                        if (index == -1)
                        {
                            lista = lista.Remove(0, lista.IndexOf("]"));
                            lista = lista.Remove(0, 1);
                            znak = "]";

                        }
                        else
                        {
                            lista = lista.Remove(0, lista.IndexOf(","));
                            lista = lista.Remove(0, 1);
                        }
                    }
                    if (osoba != "")
                    {
                        znajomi.Add(osoba);
                    }
                }
                int j = 0;
                foreach (var znajomy in znajomi)
                {
                    j++;
                    Console.WriteLine(j + "." + znajomy);
                }

            }


            void zaproszeniadoodbioru(string owner, ref List<string> znajomi)
            {
                string que = "select odebrane from znajomi WHERE owner ='" + owner + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                string lista = (string)gg.ExecuteScalar();
                lista = lista.Remove(0, 1);
                string znak = "[";
                while (znak != "]")
                {
                    string osoba = "";
                    int index = lista.IndexOf(",");
                    if (index != 0)
                    {
                        if (index == -1)
                        {
                            for (int i = 0; i < lista.IndexOf("]"); i++)
                            {
                                osoba = osoba + lista[i];
                                znak = lista[i].ToString();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < index; i++)
                            {
                                osoba = osoba + lista[i];
                                znak = lista[i].ToString();
                            }
                        }
                        if (index == -1)
                        {
                            lista = lista.Remove(0, lista.IndexOf("]"));
                            lista = lista.Remove(0, 1);
                            znak = "]";

                        }
                        else
                        {
                            lista = lista.Remove(0, lista.IndexOf(","));
                            lista = lista.Remove(0, 1);
                        }
                    }
                    if (osoba != "")
                    {
                        znajomi.Add(osoba);
                    }
                }
                int j = 0;
                foreach (var znajomy in znajomi)
                {
                    j++;
                    Console.WriteLine(j + "." + znajomy);
                }

            }




            void dodajznajomego(string owner, string addfriend)
            {
                string que = "select friends from znajomi WHERE owner ='" + owner + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                string lista = (string)gg.ExecuteScalar();
                string q = "select oczekujace from znajomi WHERE owner ='" + owner + "'";
                MySqlCommand y = new MySqlCommand(q, con);
                string oczekujace = (string)y.ExecuteScalar();
                if (!lista.Contains(addfriend))
                {
                    if (!oczekujace.Contains(addfriend))
                    {
                        if (oczekujace == "[]")
                        {
                            oczekujace = oczekujace.Remove(oczekujace.Length - 1, 1);
                            oczekujace = oczekujace + addfriend + "]";
                            string quee = "UPDATE `znajomi` SET `oczekujace`= '" + oczekujace + "' WHERE owner ='" + owner + "'";
                            MySqlCommand ggg = new MySqlCommand();
                            ggg.CommandText = quee;
                            ggg.Connection = con;
                            ggg.ExecuteNonQuery();
                            string ee = "select odebrane from znajomi WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                            MySqlCommand yy = new MySqlCommand(ee, con);
                            string odebrane = (string)yy.ExecuteScalar();
                            if (odebrane == "[]")
                            {
                                odebrane = odebrane.Remove(odebrane.Length - 1, 1);
                                odebrane = odebrane + zalogowany.Addfriend + "]";
                                string queee = "UPDATE `znajomi` SET `odebrane`= '" + odebrane + "' WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                                MySqlCommand gggggg = new MySqlCommand();
                                gggggg.CommandText = queee;
                                gggggg.Connection = con;
                                gggggg.ExecuteNonQuery();
                            }
                            else
                            {
                                odebrane = odebrane.Remove(odebrane.Length - 1, 1);
                                odebrane = odebrane + "," + zalogowany.Addfriend + "]";
                                string queee = "UPDATE `znajomi` SET `odebrane`= '" + odebrane + "' WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                                MySqlCommand gggggg = new MySqlCommand();
                                gggggg.CommandText = queee;
                                gggggg.Connection = con;
                                gggggg.ExecuteNonQuery();
                            }
                            Console.WriteLine("Wysłano zaproszenie do znajomych!");

                        }
                        else
                        {
                            oczekujace = oczekujace.Remove(oczekujace.Length - 1, 1);
                            oczekujace = oczekujace + "," + addfriend + "]";
                            string quee = "UPDATE `znajomi` SET `oczekujace`= '" + oczekujace + "' WHERE owner ='" + owner + "'";
                            MySqlCommand ggg = new MySqlCommand();
                            ggg.CommandText = quee;
                            ggg.Connection = con;
                            ggg.ExecuteNonQuery();
                            string ee = "select odebrane from znajomi WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                            MySqlCommand yy = new MySqlCommand(ee, con);
                            string odebrane = (string)yy.ExecuteScalar();
                            if (odebrane == "[]")
                            {
                                odebrane = odebrane.Remove(odebrane.Length - 1, 1);
                                odebrane = odebrane + zalogowany.Addfriend + "]";
                                string queee = "UPDATE `znajomi` SET `odebrane`= '" + odebrane + "' WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                                MySqlCommand gggggg = new MySqlCommand();
                                gggggg.CommandText = queee;
                                gggggg.Connection = con;
                                gggggg.ExecuteNonQuery();
                            }
                            else
                            {
                                odebrane = odebrane.Remove(odebrane.Length - 1, 1);
                                odebrane = odebrane + "," + addfriend + "]";
                                string queee = "UPDATE `znajomi` SET `odebrane`= '" + odebrane + "' WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                                MySqlCommand gggggg = new MySqlCommand();
                                gggggg.CommandText = queee;
                                gggggg.Connection = con;
                                gggggg.ExecuteNonQuery();
                            }
                            Console.WriteLine("Wysłano zaproszenie do znajomych!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Już wysłałeś tej osobie zaproszenie do znajomych");
                    }
                }
                else
                {
                    Console.WriteLine("Ta osoba już jest twoim znajomym");
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

            string getowner(string login, string password)
            {
                string que = "select owner from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand gg = new MySqlCommand(que, con);
                return (string)gg.ExecuteScalar();
            }
            string getownerfromaddfriend(string addfriend)
            {
                string que = "select owner from users WHERE addfriend ='" + addfriend + "'";
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
                    string cmddText = "insert into znajomi(owner) values('" + s + "');";
                    MySqlCommand cmddd = new MySqlCommand(cmddText, con);
                    cmddd.ExecuteNonQuery();
                    Console.WriteLine("Usawiono ownera");
                    wartowner = true;
                }
                else
                {
                    Console.WriteLine("Istnieje konto o takim ownerze");
                }
            }


            void setnick(string login, string password, string nick, ref bool wartnick, ref Uzytkownik zalogowany)
            {
                if(nick != "")
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
                        zalogowany.Nick = nick;

                    }
                    else
                    {
                        Console.WriteLine("Taki nick istnieje przy koncie o takim samym tagu");
                    }
                }
                else
                {
                    Console.WriteLine("Nie podano nicku");
                }
            }


            void settag(string login, string password, string tag, ref bool warttag, ref Uzytkownik zalogowany)
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
                        zalogowany.Tag = tagg;
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






            void rozdzielnickitag(string ciag, ref string nick, ref string tag)
            {
                if (nick != "")
                {
                    for (int i = 0; i < ciag.IndexOf("#"); i++)
                    {
                        nick = nick + ciag[i].ToString();
                    }
                    ciag = ciag.Remove(0, ciag.IndexOf("#"));
                    for (int i = 0; i < ciag.Length; i++)
                    {
                        tag = tag + ciag[i].ToString();
                    }
                }
            }



            void przyimijznajomego(string owner, string addfriend)
            {
                string quee = "select friends from znajomi WHERE owner ='" + owner + "'";
                MySqlCommand znajomizalogowanegoo = new MySqlCommand(quee, con);
                string znajomizalogowanego = (string)znajomizalogowanegoo.ExecuteScalar();
                string wee = "select odebrane from znajomi WHERE owner ='" + owner + "'";
                MySqlCommand odebranee = new MySqlCommand(wee, con);
                string odebrane = (string)odebranee.ExecuteScalar();
                string que = "select friends from znajomi WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                MySqlCommand znajomidodawanegoo = new MySqlCommand(que, con);
                string znajomidodawanego = (string)znajomidodawanegoo.ExecuteScalar();
                string we = "select oczekujace from znajomi WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                MySqlCommand oczekujacee = new MySqlCommand(we, con);
                string oczekujace = (string)oczekujacee.ExecuteScalar();
                if (znajomizalogowanego == "[]")
                {
                    znajomizalogowanego = znajomizalogowanego.Remove(znajomizalogowanego.Length - 1, 1);
                    znajomizalogowanego = znajomizalogowanego + addfriend + "]";
                }
                else
                {
                    znajomizalogowanego = znajomizalogowanego.Remove(znajomizalogowanego.Length - 1, 1);
                    znajomizalogowanego = znajomizalogowanego + "," + addfriend + "]";
                }
                if (odebrane.Contains("," + addfriend))
                {
                    odebrane = odebrane.Remove(odebrane.IndexOf(addfriend) - 1, addfriend.Length-1);
                }
                else if (odebrane.Contains(addfriend + ","))
                {
                    odebrane = odebrane.Remove(odebrane.IndexOf(addfriend), addfriend.Length+1);
                }
                else if (odebrane == "[" + addfriend + "]")
                {
                    odebrane = "[]";

                }





                if (znajomidodawanego == "[]")
                {
                    znajomidodawanego = znajomidodawanego.Remove(znajomidodawanego.Length - 1, 1);
                    znajomidodawanego = znajomidodawanego + zalogowany.Addfriend + "]";
                }
                else
                {
                    znajomidodawanego = znajomidodawanego.Remove(znajomidodawanego.Length-1, 1);
                    znajomidodawanego = znajomidodawanego + "," + zalogowany.Addfriend + "]";
                }
                if (oczekujace == ("[" + zalogowany.Addfriend + "]"))
                {
                    oczekujace = "[]";
                }
                else if (oczekujace.Contains("," + zalogowany.Addfriend))
                {
                    oczekujace = oczekujace.Remove(oczekujace.IndexOf(zalogowany.Addfriend)-1, zalogowany.Addfriend.Length+1);
                }
                else if (oczekujace.Contains(zalogowany.Addfriend + ","))
                {
                    oczekujace = oczekujace.Remove(oczekujace.IndexOf(zalogowany.Addfriend), zalogowany.Addfriend.Length+1);
                }

                string k = "UPDATE `znajomi` SET `friends`= '" + znajomizalogowanego + "' WHERE owner ='" + zalogowany.Owner + "'";
                MySqlCommand f = new MySqlCommand();
                f.CommandText = k;
                f.Connection = con;
                f.ExecuteNonQuery();

                string kk = "UPDATE `znajomi` SET `odebrane`= '" + odebrane + "' WHERE owner ='" + zalogowany.Owner + "'";
                MySqlCommand ff = new MySqlCommand();
                ff.CommandText = kk;
                ff.Connection = con;
                ff.ExecuteNonQuery();

                string kkk = "UPDATE `znajomi` SET `friends`= '" + znajomidodawanego + "' WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                MySqlCommand fff = new MySqlCommand();
                fff.CommandText = kkk;
                fff.Connection = con;
                fff.ExecuteNonQuery();

                string kkkk = "UPDATE `znajomi` SET `oczekujace`= '" + oczekujace + "' WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                MySqlCommand ffff = new MySqlCommand();
                ffff.CommandText = kkkk;
                ffff.Connection = con;
                ffff.ExecuteNonQuery();

            }

            void usuniprosbeoznajomego(string owner, string addfriend)
            {
                string wee = "select odebrane from znajomi WHERE owner ='" + owner + "'";
                MySqlCommand odebranee = new MySqlCommand(wee, con);
                string odebrane = (string)odebranee.ExecuteScalar();
                string we = "select oczekujace from znajomi WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                MySqlCommand oczekujacee = new MySqlCommand(we, con);
                string oczekujace = (string)oczekujacee.ExecuteScalar();
                if (odebrane == "[" + addfriend + "]")
                {
                    odebrane = "[]";
                }
                else if (odebrane.Contains("," + addfriend))
                {
                    odebrane = odebrane.Remove(odebrane.IndexOf(addfriend) - 1, addfriend.Length + 1);
                }
                else if (odebrane.Contains(addfriend + ","))
                {
                    odebrane = odebrane.Remove(odebrane.IndexOf(addfriend), addfriend.Length + 1);
                }



                if (oczekujace == ("[" + zalogowany.Addfriend + "]"))
                {
                    oczekujace = "[]";
                }
                else if (oczekujace.Contains("," + zalogowany.Addfriend))
                {
                    oczekujace = oczekujace.Remove(oczekujace.IndexOf(zalogowany.Addfriend) - 1, zalogowany.Addfriend.Length + 1);
                }
                else if (oczekujace.Contains(zalogowany.Addfriend + ","))
                {
                    oczekujace = oczekujace.Remove(oczekujace.IndexOf(zalogowany.Addfriend), zalogowany.Addfriend.Length + 1);
                }


                string kk = "UPDATE `znajomi` SET `odebrane`= '" + odebrane + "' WHERE owner ='" + zalogowany.Owner + "'";
                MySqlCommand ff = new MySqlCommand();
                ff.CommandText = kk;
                ff.Connection = con;
                ff.ExecuteNonQuery();

                string kkkk = "UPDATE `znajomi` SET `oczekujace`= '" + oczekujace + "' WHERE owner ='" + getownerfromaddfriend(addfriend) + "'";
                MySqlCommand ffff = new MySqlCommand();
                ffff.CommandText = kkkk;
                ffff.Connection = con;
                ffff.ExecuteNonQuery();
            }






            void Logowanie(string login, string password)
            {
                List<string> znajomi = new List<string>() { };

                string query = "select count(*) from users WHERE login ='" + login + "' AND haslo ='" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int Count = int.Parse(cmd.ExecuteScalar() + "");
                if (Count == 1)
                {
                    zalogowany.Login = login;
                    zalogowany.Haslo = password;
                    zalogowany.Nick  = getnick(login, password);
                    zalogowany.Tag = gettag(login, password);
                    zalogowany.Addfriend = getnick(login, password) + gettag(login, password);
                    zalogowany.Owner = getowner(login, password);

                    Console.WriteLine($"Zalogowano pomyślnie");
                    while (true == true)
                    {
                        Console.Clear();
                        string nazwakonta = getnick(login, password) + gettag(login, password);
                        Console.WriteLine($"Nick:{nazwakonta}");
                        Console.WriteLine("Zmień nick -- 1");
                        Console.WriteLine("Zmień tag -- 2");
                        Console.WriteLine("Dodaj znajomego -- 3");
                        Console.WriteLine("Wysłane zaposzenia do znajomych -- 4");
                        Console.WriteLine("Oczekujace zaposzenia do znajomych -- 5");
                        Console.WriteLine("Czaty ze znajomymi -- 6");
                        Console.WriteLine("Wylogowanie -- 7");

                        Console.WriteLine("Lista znajomych: ");
                        znajomi.Clear();
                        zaladujznajomych(zalogowany.Owner, ref znajomi);


                        string aktyw = Console.ReadLine();
                        if (aktyw == "1")
                        {
                            Console.Write("Podaj nowy nick:");
                            string newnick = Console.ReadLine();
                            bool op = true;
                            setnick(login, password, newnick, ref op, ref zalogowany);
                            Console.ReadLine();
                        }
                        else if (aktyw == "2")
                        {
                            Console.Write("Podaj nowy tag:");
                            string newtag = Console.ReadLine();
                            bool op = true;
                            settag(login, password, newtag, ref op, ref zalogowany);
                            Console.ReadLine();
                        }
                        else if (aktyw == "3")
                        {
                            Console.Write("Podaj nick i tag znajomego:");
                            string newfriend = Console.ReadLine();
                            string nick="", tag="";

                            rozdzielnickitag(newfriend, ref nick, ref tag);
                            if (!nickandtagexist(nick, tag))
                            {
                                Console.WriteLine("Nie istnieje konto o takim nicku lub tagu!");
                                Console.ReadLine();
                            }
                            else
                            {
                                if (!(newfriend == zalogowany.Addfriend))
                                {
                                    dodajznajomego(zalogowany.Owner, newfriend);

                                }
                                else
                                {
                                    Console.WriteLine("Nie możesz sam siebie dodać do znajomych");
                                }
                                Console.ReadLine();
                            }

                        }
                        else if (aktyw == "4")
                        {
                            Console.WriteLine("Zaproszenia które czekają na przyjęcie:");
                            List<string> zaproszenia = new List<string>() { };
                            zaposzeniadoznajomych(zalogowany.Owner, ref zaproszenia);
                            Console.ReadLine();
                        }
                        else if (aktyw == "5")
                        {
                            Console.WriteLine("Oczekujące zaproszenia do znajomych [T--PRZYJĘCIE/N--Odrzucenie]:");
                            List<string> doobioru = new List<string>() { };
                            zaproszeniadoodbioru(zalogowany.Owner, ref doobioru);
                            int j = 1;
                            Console.Write("Wybierz osobę:");
                            string indeks = Console.ReadLine();
                            Console.Write("T aby przyjąć N aby odrzucić:");
                            string warunek = Console.ReadLine();
                            foreach (var kandydat in doobioru)
                            {
                                if(j.ToString() == indeks && warunek == "T")
                                {
                                    przyimijznajomego(zalogowany.Owner, kandydat.ToString());
                                    break;
                                }
                                else if (j.ToString() == indeks && warunek == "N")
                                {
                                    usuniprosbeoznajomego(zalogowany.Owner, kandydat.ToString());
                                }
                            j++;
                            } 

                        }
                        else if (aktyw == "6")
                        {
                            Console.WriteLine("Lista znajomych: ");
                            znajomi.Clear();
                            zaladujznajomych(zalogowany.Owner, ref znajomi);
                            Console.ReadLine();
                        }
                        else if (aktyw == "7")
                        {
                            return;
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
                    if (login != "")
                    {
                        if (password != "")
                        {
                            if (nick != "")
                            {
                                string cmdText = "insert into users(login,haslo) values('" + login + "','" + password + "');";
                                MySqlCommand cmdd = new MySqlCommand(cmdText, con);
                                cmdd.ExecuteNonQuery();
                                ;
                                bool wartnick = false, warttag = false, wartowner = false;
                                setnick(login, password, nick, ref wartnick, ref zalogowany);
                                settag(login, password, losujtag(), ref warttag, ref zalogowany);
                                if (warttag == true && wartnick == true)
                                {
                                    while (wartowner != true)
                                    {
                                        setowner(login, password, ref wartowner);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nie podano nicku!");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nie podano hasła!");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie podano loginu!");
                        Console.ReadLine();
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

