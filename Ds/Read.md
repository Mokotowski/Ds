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
//    foreach (var name in names)
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
