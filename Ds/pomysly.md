﻿wszystko na obektówke
uporządkowanie funkcji




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