using System;
// using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeter;

namespace GrpcGreeterClient
{
    class Program
    {
        private static readonly string SERVER_ADDRESS = "https://localhost:5001";
        // static void Main(string[] args)
        // {
        //     Console.WriteLine("Hello World!");
        // }

        static async Task Main(string[] args)
        {
            GrpcChannel             channel = GrpcChannel.ForAddress(SERVER_ADDRESS);
            Greeter.GreeterClient   client  = new Greeter.GreeterClient(channel);
            HelloReply              reply   = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" } );

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            // Console.ReadKey();
            Console.Read();

        }
    }
}
