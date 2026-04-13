
using Newtonsoft.Json;

namespace JSONDEMO
{
 

    internal class Program
    {


        static async Task Main(string[] args)
        {
            string url = "https://my-json-server.typicode.com/typicode/demo/posts";
            HttpClient httpClient = new HttpClient();

           
            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                // read the string from the response's content.
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                
                //Print the json response
                Console.WriteLine($"Json Structure \n {jsonResponse} \n");

                // Deserialize the json response into a C# array of type Post[]
                var myPosts = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                Console.WriteLine($"Deserialized Data");
                // Print the array
                foreach (var post in myPosts)
                {
                    //print the id and the title of each post
                    Console.WriteLine($"{post.Id} {post.Title}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}
