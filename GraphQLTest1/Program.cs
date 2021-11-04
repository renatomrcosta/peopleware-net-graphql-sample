using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace GraphQLTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphQlClient = new GraphQLHttpClient("http://localhost:8080/graphql", new NewtonsoftJsonSerializer());
            
            var artistsRequest = new GraphQLRequest {
                Query = @"
                        {
                            artists {
                                id
                                name

                            }
                        }"
            };

            var response = Task.Run(async () => await graphQlClient.SendQueryAsync<dynamic>(artistsRequest)).Result;
            
            Console.WriteLine("Printing response: ");
            Console.WriteLine(response.Data);
            Console.WriteLine("Done");
        }
    }

    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}