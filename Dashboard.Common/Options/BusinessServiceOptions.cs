using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Common.Options
{
    public class BusinessServiceOptions
    {
        public const string Client = "ClientSettings";
        public int Id { get; set; } = 0;
        public string Name { get; set; } = String.Empty;
        public string Organization { get; set; } = String.Empty;
        public string ServiceType { get; set; } = String.Empty;
        public string Endpoint { get; set; } = String.Empty;
    }
}
