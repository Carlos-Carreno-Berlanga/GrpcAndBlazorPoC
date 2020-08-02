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
            int pointer = 0;
            int chunk = 1000;
            List<Samurai> samurais = null;
            do
            {
                samurais = await _context.Samurais.Skip(pointer).Take(chunk).ToListAsync();
                pointer += chunk;
                foreach (var samurai in samurais)
                {

                    await responseStream.WriteAsync(new SamuraiReply
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = samurai.Name
                    });
                }
            } while (samurais.Count > 0);
            _logger.LogInformation("FINISHED");
        }
    }
}

