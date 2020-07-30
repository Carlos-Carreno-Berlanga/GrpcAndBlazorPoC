using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
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
            var samurais = await _context.Samurais.Take(1000).ToListAsync();
            foreach (var samurai in samurais)
                //await Task.Delay(5000);
                await responseStream.WriteAsync(new SamuraiReply
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = samurai.Name
                });
        }
    }
}

