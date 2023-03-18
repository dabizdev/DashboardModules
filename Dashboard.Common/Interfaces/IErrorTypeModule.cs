using Dashboard.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Common.Interfaces
{
    public interface IErrorTypeModule
    {
        public List<Errors> GetData(string integrationPoint);

    }
}
