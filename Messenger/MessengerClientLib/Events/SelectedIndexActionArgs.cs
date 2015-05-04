using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerClientLib.Events
{
    public class SelectedIndexActionArgs
    {
        public int Position { get; set; }

        public SelectedIndexActionArgs(int position)
        {
            Position = position;
        }
    }
}
