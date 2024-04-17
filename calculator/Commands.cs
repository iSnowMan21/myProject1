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

        public static List<Search> addFilm(string keyword)
        {
            
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.omdbapi.com/");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            List<Search> allResults = new List<Search>();
            for (int i = 1; ; i++)
            {
                var response = client.GetAsync($"?apikey=d554bc03&s={keyword}&page={i}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    Answer ans = JsonConvert.DeserializeObject<Answer>(dataObjects);
                    if (ans.search != null)
                    {
                        allResults.AddRange(ans.search);
                    }
                }
                else
                {
                    break;
                }
            }

            return allResults;
            //return strInsert;
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




