using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SortNumWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : SortNumService
    {
        public string sort(string s)
        {
            // Split the input string by commas
            string[] numberStrings = s.Split(',');

            // Parse the string array into an array of floats
            float[] numbers = Array.ConvertAll(numberStrings, float.Parse);

            // Sort the array of numbers
            Array.Sort(numbers);

            // Convert the sorted array back to a string joining by commas
            return string.Join(",", numbers);
        }
    }
}
