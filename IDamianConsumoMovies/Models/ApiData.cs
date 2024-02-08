using Newtonsoft.Json;

namespace IDamianConsumoMovies.Models
{
    public class ApiData
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public List<Movie> ResultMovies{ get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
    }
}
