using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLDataBaseLayer.DBOperations
{
    public interface ILog
    {
        void LogException(string msg);
    }
          
}
