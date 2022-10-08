using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPIClient{

class Movie{
    [JsonProperty("title")]
    public string Title{ get; set; }

    [JsonProperty("description")]
    public string Description{ get; set; }

    
    [JsonProperty("running_time")]
    public string Time{ get; set; }
}

class Program{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args){
        await ProcessRepositories();
    }

    private static async Task ProcessRepositories(){
        while (true){
            try{
            Console.WriteLine("Enter Movie ID");

            var id = Console.ReadLine();

            if (string.IsNullOrEmpty(id)){
                break;
            }

            var result = await client.GetAsync('https://ghibliapi.herokuapp.com/films/' + id);
            var resultRead = await result.Content.ReadAsStringAsync();

            var Movie = JsonConvert.DeserializeObject<Movie>(resultRead);

            Console.WriteLine("----");
            Console.WriteLine("Movie name: " + Movie.Title);
            Console.WriteLine("Movie description: " + Movie.Description);
            Console.WriteLine("Total running time: " + Movie.Time);

            }
            catch (Exception){
                Console.WriteLine("Error, movie id not found");
            }

            



        }
    }
}
}