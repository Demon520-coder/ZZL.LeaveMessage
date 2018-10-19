using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.LeaveMessage.Frm
{
    public class SingleInstance
    {
        public readonly static SingleInstance _singleInstance;

        private SingleInstance()
        {

        }

        static SingleInstance()
        {
            _singleInstance = new SingleInstance();
        }
    }
}
