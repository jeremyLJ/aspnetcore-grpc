using System;
using Greet;
using Grpc.Net.Client;

namespace MyGrpcNetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress("http://localhost:5000");
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
