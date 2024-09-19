using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebApplication1.ConverterServiceReference;    // Reference for Temperature Conversion Service
using MyWebApplication1.SorterServiceReference;    // Reference for Number Sorting Service

namespace MyWebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Event handler for Celsius to Fahrenheit conversion
        protected void ConvertCelsiusToFahrenheit(object sender, EventArgs e)
        {
            // Create a client for the temperature conversion service
            ConverterServiceReference.TempConServiceClient prxy1 = new ConverterServiceReference.TempConServiceClient();

            string c = celsiusInput.Text;
            double celsius = prxy1.c2f(Convert.ToInt32(c));
            lblResult1.Text = Convert.ToString(celsius);
        }

        // Event handler for Fahrenheit to Celsius conversion
        protected void ConvertFahrenheitToCelsius(object sender, EventArgs e)
        {
            // Create a client for the temperature conversion service
            ConverterServiceReference.TempConServiceClient prxy2 = new ConverterServiceReference.TempConServiceClient();

            string f = fahrenheitInput.Text;
            double farenheit = prxy2.f2c(Convert.ToInt32(f));
            lblResult2.Text = Convert.ToString(farenheit);
        }

        // Event handler for sorting numbers
        protected void SortNumbers(object sender, EventArgs e)
        {
            // Create a client for the number sorting service
            SorterServiceReference.SortNumServiceClient prxy3 = new SorterServiceReference.SortNumServiceClient();

            string c = numberInput.Text;
            string sortedNum = prxy3.sort(c);
            lblResult3.Text = sortedNum;
        }
    }
}