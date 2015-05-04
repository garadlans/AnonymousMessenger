using System.Collections.Generic;

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
