using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.API.Configurations
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; } // Nome emitido no token
        public string ValidoEm { get; set; } // Também conhecido como audiência
    }
}
