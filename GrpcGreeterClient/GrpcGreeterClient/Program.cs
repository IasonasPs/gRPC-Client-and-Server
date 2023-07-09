using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;



namespace GrpcGreeterClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7097");

            var client = new Greeter.GreeterClient(channel);

            bool control = true;

            while (control)
            {
                var message = Console.ReadLine();

                var reply = client.SayHello(
                   new HelloRequest
                   {
                       Name = message,
                   });
                Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
                Console.WriteLine(reply.Message);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - ");
            }
        }
    }
}