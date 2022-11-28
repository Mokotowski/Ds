czat zrobić ludzi
przy zmianie nicku i tagu psują się znajomi 





[117633537855255743421883411886226823,472277527743874176425314222731788887]




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



                Console.WriteLine(znajomizalogowanego + "--znajomizalogowanego");
                Console.WriteLine(odebrane + "--odebrane");
                Console.WriteLine(znajomidodawanego + "--znajomidodawanegoo");
                Console.WriteLine(oczekujace + "--oczekujace");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

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
                    odebrane = odebrane.Remove(odebrane.IndexOf(addfriend), addfriend.Length);
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
                    znajomidodawanego = znajomidodawanego.Remove(znajomidodawanego.Length - 1, 1);
                    znajomidodawanego = znajomidodawanego + "," + zalogowany.Addfriend + "]";
                }
                if (oczekujace.Contains("," + zalogowany.Addfriend))
                {
                    oczekujace = oczekujace.Remove(oczekujace.IndexOf(zalogowany.Addfriend) - 1, zalogowany.Addfriend.Length-1);
                }
                else if (oczekujace.Contains(zalogowany.Addfriend + ","))
                {
                    oczekujace = oczekujace.Remove(oczekujace.IndexOf(zalogowany.Addfriend), zalogowany.Addfriend.Length);
                }
                Console.WriteLine(znajomizalogowanego + "--znajomizalogowanego");
                Console.WriteLine(odebrane + "--odebrane");
                Console.WriteLine(znajomidodawanego + "--znajomidodawanegoo");
                Console.WriteLine(oczekujace + "--oczekujace");

            }