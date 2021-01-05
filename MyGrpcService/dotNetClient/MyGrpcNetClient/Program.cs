using System;
using Greet;
using Grpc.Net.Client;

namespace MyGrpcNetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var response = client.SayHello(new HelloRequest
            {
                Name = "gRPC"
            });

            Console.WriteLine(response.Message);

            Console.ReadKey();
        }
    }
}
