using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ChatAPI
{
    public static class Application
    {
        public class General
        {
            public bool ShouldSeedDatabase { get; set; }
        }

        public static IConfiguration Configuration { get; set; }
        public static General GeneralKeys => Configuration.GetSection("General").Get<General>();
    }
}
