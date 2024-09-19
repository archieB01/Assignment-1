using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : TempConService
    {
        public double c2f(double c)
        {
            // Convert Celsius to Fahrenheit: (Celsius * 9/5) + 32
            double cel = ((c * 9.0 / 5.0) + 32);
            return Math.Round(cel, 2);
        }

        public double f2c(double f)
        {
            // Convert Fahrenheit to Celsius: (Fahrenheit - 32) * 5/9
            double far = ((f - 32) * 5.0 / 9.0);
            return Math.Round(far, 2);
        }
    }
}
