using System.Collections.Generic;

namespace ConnectionAPIGUI
{
    internal class Answer
    {
        public List<Search> Search;

        public int TotalResults {  get; set; }

        public bool Response {  get; set; }

        public Answer(List<Search> search, int totalResults, bool response)
        {
            Search = search;
            TotalResults = totalResults;
            Response = response;
        }
    }
}
