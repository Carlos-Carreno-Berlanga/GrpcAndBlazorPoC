using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService
{
    public class SamuraiService : SamuraiPackage.SamuraiPackageBase
    {
        private readonly ILogger<SamuraiService> _logger;
        private readonly SamuraiContext _context;
        public SamuraiService(ILogger<SamuraiService> logger,
            SamuraiContext context)
        {
            _logger = logger;
            _context = context;
        }


        public override async Task GetSamurais(Empty request, IServerStreamWriter<SamuraiReply> responseStream, ServerCallContext context)
        {
            //return base.GetSamurais(request, responseStream, context);

            for (int i = 0; i < 1000; i++)
            {
                //await Task.Delay(5000);
                await responseStream.WriteAsync(new SamuraiReply { Id = Guid.NewGuid().ToString(), Name = $"Item-{i}" });
            }
        }

    }
}
