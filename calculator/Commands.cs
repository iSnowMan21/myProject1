using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ConnectionAPIGUI
{
    internal class Commands
    {
        public static List<Film> films = new List<Film>();

        public static void addFilm(string keyword)
        {
            films.Clear();

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://www.omdbapi.com/")
            };
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            //List<Search> allResults = new List<Search>();
            for (int i = 1; i < 10; i++)
            {
                var response = client.GetAsync($"?apikey=4c711f74&s={keyword}&page={i}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    Answer ans = JsonConvert.DeserializeObject<Answer>(dataObjects);
                    if (ans.Search != null) 
                    foreach (var item in ans.Search)
                    {
                        films.Add(new Film(false, item.Title, item.Year, item.ImdbID, item.Type, item.Poster));
                    }
                }
                else
                {

                //Car car1 = new Car("white", 10000)
                    break;
                }
            }


        }
        public static string DeleteMovie(ConnectionWithDataBase conn,string titleToDelete)
        {
            conn.Delete(titleToDelete);
            return $"Фильм с названием {titleToDelete} удален";
        }
        public static string Count(ConnectionWithDataBase conn)
        {
            int movieCount = conn.Count();
            return $"Количество фильмов в базе данных: {movieCount}";
        }

        
        public static void InfoByTitle(ConnectionWithDataBase conn)
        {
            string partialTitle = Console.ReadLine();
            conn.InfoByTitle(partialTitle);
        }

    }
   }




