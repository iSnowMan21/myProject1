namespace ConnectionAPIGUI
{
    internal class Search
    {
        //"Title","imdbID","Type","Poster"
        public string Title { get; set; }

        public string Year { get; set; }

        public string ImdbID { get; set; }

        public string Type { get; set;}

        public string Poster { get; set; }

        public Search(string title, string year, string imdbID, string type, string poster)
        {
            Title = title;
            Year = year;
            ImdbID = imdbID;
            Type = type;
            Poster = poster;
        }

        
    }
}
