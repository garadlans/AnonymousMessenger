using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerCoreLib.DbWork
{
    public class DataBaseGetter
    {

        public List<List<object>> DataResult;
        public bool Readable;

        public DataBaseGetter(List<List<object>> dataResult, bool readable)
        {
            DataResult = dataResult;
            Readable = readable;
        }
    }
}
