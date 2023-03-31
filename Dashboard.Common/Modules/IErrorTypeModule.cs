using Dashboard.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Common.Modules
{
    public interface IErrorTypeModule
    {
        List<Errors> GetData(string integrationPoint);
    }
}
