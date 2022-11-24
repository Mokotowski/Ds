// Ogólne 
// stawiać średniki
// Wyświetlanie w konsoli i przejście do kolejnej lini Console.WriteLine();
// Wyświetlanie w konsoli Console.Write();
// pobranie lni jako string i zdelarowanie jako double double.Parse(Console.ReadLine())
// odpowiada za czekanie Thread.Sleep(1000) w milisekundach


// Konsola
// resetowanie konsoli  Console.ResetColor()
//Ustawia kolor czcionki Console.ForegroundColor = ConsoleColor.Blue;
//Ustawia kolor tła Console.BackgroundColor = ConsoleColor.Red;



// Metody ogólne
// pokazuje aktualny czas DateTime.Now 2017-07-17 20:21:24







// Metody (FUNKCJE)
// Budowa modyfkator, typ zwracanej danej, nzwa, lista argumentów
// static void Main(string[] args)
// [Modyfikatory] Typ Nazwa ([Lista argumentów])
// Modyfikatory public udostępniają funkcje wszystkim klasą, private umożliwia uzycie metody tylko w tej klasie,  static void Metoda(int x) == private static void Metoda(int x) (private jest domyślne nie trzeba podawać, publc trzeba podawać





// Stringi
// deklaracja string zmienna = Mk
// $ odpowiada za czytelność kodu to wypisania
// $"teskt  {zmienna}"
// zmienna.Length  długość ciągu
// zmienna.TrimStart() wycina spacje z początku
// zmienna.TrimEnd() wycina spacje z końca
// zmienna.Trim()  wycina spacje
// zmienna.Replace("Tekst do wyszukania", "Tekst którym zastąpi");
// zmienna.ToUpper() zamienia wszystko na duże litery 
// zmienna.ToLower() zamienia wszystko na małe litery
// zmienna.Contains("tekst") sprawdza czy tekst wystapił w ciągu zwraca true/false
// zmienna.StartsWith("tekst") srawdza czy ciąg zaczyna się od tekst zwraca true/false
// zmienna.EndsWith("tekst") srawdza czy ciąg kończy się na tekst zwraca true/false
// zmienna.Length podaje długość łańcucha 
// zmienna.Substring(indeksodktoregozaczyna, ilekolejnych ma wyciąć) wycinanie ze stringów

// Liczby 
// deklaracja int = liczba (całkowite) float = liczba (zmienno przecinkowa) double = liczba (zmienno przecinkowa dokładniejsza) decimal = liczba (zmienno przecinkowa jeszcze dokładniejsza)
// operatory + dodwawanie | - odejmowanie | * mnożenie |  / dzielenie | () standard z matmy | % dzielenie całkowite
// dokonywać obliczeni tylko na liczbach w tym samym typie 
// można zwiększać o 1 w sposób liczba++;

// Logika

//  if (a + b > 10)
//  {
//    Console.WriteLine("The answer is greater than 10");
//  }
//  else
//  {
//    Console.WriteLine("The answer is not greater than 10");
//  }
// == równość && i || lub

//  Pętla while
// int counter = 0;
// while (counter < 10)
//  {
//   Console.WriteLine($"Hello World! The counter is {counter}");
//   counter++;
//  }

// Pętla for 
//  for (int counter = 0; counter < 10; counter++)
//  {
//    Console.WriteLine($"Hello World! The counter is {counter}");
//  }

// Pętla foreach najczęściej wykorzystywana z tablicami powtarza instrukcje dla każdego elemoentu po koleji
//   foreach (var name in names)
//    {
//    Console.WriteLine($"Hello {name}!");
//    }




// Tablica
// tablica zaczyna się od wartości 0 
//  var nazwatablicy = new List<typdanych> { "argument", "argument", "argument" };
//  nazwatablicy.Add("argument"); dodaje argument do tablicy
//  nazwatablicy.Remove("argument"); usuwa argument z tablicy
// argument można wywołać przez nazwatablicy[indeks]
// pokazuje długość tablicy nazwatablicy.Count
// znajduje indeks tekstu nazwatablicy.IndexOf("tekstdowyszukania") jezeli nie znajdzie zwraca -1
// alfabetycznie albo rosnąco w zależność o typudanych nazwatablicy.Sort()


// Operacje na plikach      trzeba używać System.IO 
// deklaracja ścieżki jako string               string scieżka = "C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//test.txt";
// spradza czy plik isynieje    File.Exists(scieżka) zwraca true/false
// wczytuje tekst z pliku jako string   File.ReadAllText(scieżka) trzeba przypisa i wywołać przez consolewrite
// zapisuje tekst do pliku jeżeli coś w pliku było czyści go       File.WriteAllText(scieżka, tekstdozapisaniawpliku);


//bardziej efektywny system zapisu można pisać wiele lini naraz jeżeli chcesz kończyć wpisujesz exit czyści plik przy zapisie
//  using (StreamWriter sciezka = new StreamWriter("C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//test.txt"))
//  {
//    string newContent = Console.ReadLine();
//    while (newContent != "exit")
//      {
//             sciezka.Write(newContent + Environment.NewLine);
//               newContent = Console.ReadLine();
//      }
//  }

// usuwanie pliku
//  string sciezka = "C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//test.txt";
//  if (File.Exists(sciezka))
//  {
//    File.Delete(sciezka);
//    if (File.Exists(sciezka) == false)
//        Console.WriteLine("Plik usunięty...");
//  }
//  else
//   Console.WriteLine("Plik nie istniał!");

// Casey
// scheat danych do wywołania ala funkcja
// wyrażenie może być stringiem lub intem
//  switch (nazwisko)
//  {
//       case „Kowalski”:
//      ZrobCos();
//            break;
//        case „Nowak”:
//  ZrobCosInnego();
//            break;
//  }











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


            int Count(string qfdsfrq, string rgwewgert)
            {
                string query = "select count(*) from users WHERE login ='" + qfdsfrq + "' AND haslo ='" + rgwewgert + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int Counttt = int.Parse(cmd.ExecuteScalar() + "");
                return Counttt;

            }

            void Tworzhaslo(string typserverhaslaaa)
            {
                Console.WriteLine("Wpisz exit aby przestać zapisywać hasła");
                string ez = $"C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//hasla//{typserverhaslaaa}hasla.txt";
                if (File.Exists(ez))
                {
                    string werd = File.ReadAllText(ez);
                    using (StreamWriter sciezka = new StreamWriter(ez))
                    {
                        string newContent = Console.ReadLine();
                        while (newContent != "exit")
                        {
                            sciezka.Write(werd + newContent + Environment.NewLine);
                            newContent = Console.ReadLine();
                        }
                    }
                }
                else
                {
                    File.Create(ez).Close();
                    string newContent = File.ReadAllText(ez);
                    using (StreamWriter sciezka = new StreamWriter(ez))
                    {
                        newContent = Console.ReadLine();
                        while (newContent != "exit")
                        {
                            sciezka.Write(newContent + Environment.NewLine);
                            newContent = Console.ReadLine();
                        }
                    }
                }

            }

            void sshplikhasel()
            {
                string sciezka = "C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//hasla//sshhasla.txt";
                if (File.Exists(sciezka))
                {
                    string content = File.ReadAllText(sciezka);
                    Console.WriteLine(content);

                }
                else
                {
                    Console.WriteLine($"Plik z hasłami nie istnieje");
                    Console.WriteLine($"Zarejestruj nowe hasła");
                }
            }
            void sqlplikhasel()
            {
                string sciezka = "C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//hasla//sqlhasla.txt";
                if (File.Exists(sciezka))
                {
                    string content = File.ReadAllText(sciezka);
                    Console.WriteLine(content);

                }
                else
                {
                    Console.WriteLine($"Plik z hasłami nie istnieje");
                    Console.WriteLine($"Zarejestruj nowe hasła");
                }
            }
            void ftpplikhasel()
            {
                string sciezka = "C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//hasla//ftphasla.txt";
                if (File.Exists(sciezka))
                {
                    string content = File.ReadAllText(sciezka);
                    Console.WriteLine(content);

                }
                else
                {
                    Console.WriteLine($"Plik z hasłami nie istnieje");
                    Console.WriteLine($"Zarejestruj nowe hasła");
                }
            }
            void txadminplikhasel()
            {
                string sciezka = "C://Users//dawii//source//repos//ConsoleApp1//ConsoleApp1//hasla//txadminhasla.txt";
                if (File.Exists(sciezka))
                {
                    string content = File.ReadAllText(sciezka);
                    Console.WriteLine(content);
                    File.Create(sciezka).Close();

                }
                else
                {
                    Console.WriteLine($"Plik z hasłami nie istnieje");
                    Console.WriteLine($"Zarejestruj nowe hasła");
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
                register(login11, haslo11, kbez);
            }
            /*
            void ssh(int opcjafunkcji)
            {

            }
            void sql(int opcjafunkcji)
            {

            }
            void ftp(int opcjafunkcji)
            {

            }
            void txadmin(int opcjafunkcji)
            {

            }
            */

            void register(string loginnn, string haslooo, string kbezzz)
            {
                kbezzz = kbezzz.Trim();
                kbezzz = kbezzz.ToLower();

                if (kbezzz == "mokotowskitokoks")
                {

                    string cmdText = "insert into users(login,haslo) values('" + loginnn + "','" + haslooo + "');";
                    MySqlCommand cmd = new MySqlCommand(cmdText, con);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    Console.WriteLine($"Podano zły klucz");
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






            for (int counter = 1; counter < 11; counter++)
            {
                Console.WriteLine($"Connecting with database {counter} seconds");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Connecting succesful");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Menu logowania -- 1");
            Console.WriteLine($"Menu ustawień -- 2");



            int menu;
            string servertyp;
            string ciagkolor;
            int opcja;
            string kolor;
            string typ;

            Console.Clear();
            Console.WriteLine($"Podaj login");
            Console.Write($"Login:");
            string login1 = Console.ReadLine();
            Console.WriteLine($"Podaj hasło");
            Console.Write($"Hasło:");
            string haslo1 = Console.ReadLine();
            Console.WriteLine();
            int wejscie = Count(login1, haslo1);
            Console.Clear();
            if (wejscie == 1) // zmienić na check baze danych
            {
                Console.WriteLine($"Menu zarządzania -- 1");
                Console.WriteLine($"Menu ustawień -- 2");
                Console.WriteLine($"Czat -- 3");
                while (true == true)
                {
                    menu = int.Parse(Console.ReadLine());

                    if (menu == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($"Zalogowano pomyślnie");
                        Console.WriteLine($"Połączenia z serverami ssh -- ssh");
                        Console.WriteLine($"Połączenia z serverami sql -- sql");
                        Console.WriteLine($"Połączenia z serverami ftp -- ftp");
                        Console.WriteLine($"Połączenia z serverami txadmin -- txadmin");
                        Console.WriteLine($"Rejestrowanie nowych haseł -- register typ");

                        servertyp = Console.ReadLine();
                        servertyp = servertyp.ToLower();

                        if (servertyp == "ssh")
                        {
                            // funkcja która po podaniu liczby przypisanej do wiersza oraz liczby chęci menu do otowrzenia otwiera połączenie przez moba xterm albo putty 
                            Console.Clear();
                            sshplikhasel();
                            //    ssh(opcja);
                        }
                        else if (servertyp == "sql")
                        {
                            // funkcja która po podaniu liczby przypisanej do wiersza  otwiera połączenie przez hedisql
                            Console.Clear();
                            sqlplikhasel();
                            //  sql(opcja);


                        }
                        else if (servertyp == "ftp")
                        {
                            // funkcja która po podaniu liczby przypisanej do wiersza oraz liczby chęci menu do otowrzenia otwiera połączenie przez winscp albo filezilla 
                            Console.Clear();
                            ftpplikhasel();
                            //  ftp(opcja);

                        }
                        else if (servertyp == "txadmin")
                        {
                            // funkcja która po podaniu liczby przypisanej do wiersza  otwiera połączenie w przeglądarce z txadminem 
                            Console.Clear();
                            txadminplikhasel();
                            // txadmin(opcja);

                        }
                        else
                        {
                            Console.Clear();
                            int dlugosci = servertyp.Length;
                            typ = servertyp.Substring(9, dlugosci - 9);
                            if ((typ == "ssh") || (typ == "sql") || (typ == "ftp") || (typ == "txadmin"))
                            {
                                Tworzhaslo(typ);
                            }
                            else
                            {
                                Console.WriteLine($"Podano złą komendę lub zły parametr");
                            }



                        }
                    }
                    else if (menu == 2)
                    {
                        Console.Clear();
                        Console.WriteLine($"Kolor tła konsoli -- 1");
                        Console.WriteLine($"Kolor tła tekstu -- 2");
                        Console.WriteLine($"schemat podania wybóropcji kolorzdużejpoangilelsku");
                        ciagkolor = Console.ReadLine();
                        int dlu = ciagkolor.Length;
                        opcja = ciagkolor[0];
                        kolor = ciagkolor.Substring(1, dlu-1);
                        Thread.Sleep(2000);
                        Console.WriteLine($"schemat podania wybóropcji kolor");
                        Console.WriteLine(kolor);
                        // DODAĆ FUNKCJE NA USTAWIaNIE TEGO
                        if (opcja == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else if (opcja == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                    }
                    else if (menu == 3)
                    {
                        string war = "true";
                        while (war != "false")
                        {
                            Console.Clear();
                            wczytajczat();
                            Console.Write($"{login1}:");
                            war = Console.ReadLine();
                            if (war == "exit")
                            {
                                break;
                            }
                            else if (war == " " || war == "" )
                            {
                                Console.Clear();
                                wczytajczat();
                            }
                            else
                            {
                                pisznaczacie(login1, war);
                            }
                        }
                    }
                }
            }
            else
            {
                zlehasloo();
            }
        }
    }
}


CREATE TABLE znajomi
(friends VARCHAR(255) KEY REFERENCES users(addfriend)),
(ownernick VARCHAR(36) KEY REFERENCES users(nick)),
(ownertag VARCHAR(36) KEY REFERENCES users(tag))
























