using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        private static int GrpcServiceIndex = 0;
        // The GrpcServiceIndex is an attempt to manually keep track of the service state
        //,since gRpc service is stateless

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            GrpcServiceIndex++;
            return Task.FromResult(new HelloReply
            {
                Message = $"Grpc Service Index is : {GrpcServiceIndex.ToString()}\n " +
                $"Or\nThe GreeterService has been called {GrpcServiceIndex.ToString()} times",
            });
        }
    }
}