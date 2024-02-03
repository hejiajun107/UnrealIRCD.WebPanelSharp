using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrealIRCD.JPRC.Client.Model
{
    public class JRPCRequest
    {
        public string Jsonrpc { get; set; } = "2.0";

        public string Method { get; set; }

        public object Params { get; set; }

        public int Id { get; set; }
    }
}
