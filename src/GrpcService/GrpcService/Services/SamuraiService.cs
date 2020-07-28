using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService
{
    public class SamuraiService : Samurai.SamuraiBase
    {
        private readonly ILogger<SamuraiService> _logger;
        public SamuraiService(ILogger<SamuraiService> logger)
        {
            _logger = logger;
        }

        public override Task GetSamurais(Empty request, IServerStreamWriter<SamuraiReply> responseStream, ServerCallContext context)
        {
            return base.GetSamurais(request, responseStream, context);
        }

    }
}
