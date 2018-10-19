using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZL.LeaveMessage.Test
{
    [TestClass]
    public class Test2
    {
        delegate double CalDelegate(double a, double b);

        private double Add(double a, double b)
        {
            return a + b;
        }

        public double Divide(double a, double b)
        {
            return a - b;
        }

        private double Mulit(double a, double b)
        {
            return a * b;
        }

        private double Cal(CalDelegate calDelegate, double a, double b)
        {
            return calDelegate(a, b);
        }

        [TestMethod]
        public void CalTest()
        {
            var addResult = Cal(new CalDelegate(Add), 4, 5);
            var divdieResult = Cal(new CalDelegate(Divide), 4, 5);
            var multiResult = Cal(new CalDelegate(Mulit), 4, 5);
        }







    }
}
