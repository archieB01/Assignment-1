using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTemperatureAsync();

            // default text box 
            textBoxCalc.Text = "Enter a number here!";

            // Navigate the web browser to Google by default
            webBrowser.Navigate("https://www.google.com");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNavigate_Click(object sender, EventArgs e)
        {
            // Get the URL from the textBoxUrl
            string url = textBoxUrl.Text;

            // Check if the URL is not empty
            if (!string.IsNullOrEmpty(url))
            {
                // Navigate the WebBrowser control to the URL
                webBrowser.Navigate(url);
            }
            else
            {
                MessageBox.Show("Please enter a valid URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("www.google.com");
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        double result = 0;
        double currentNumber = 0;
        string operation = "";

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            operation = "+";
            currentNumber = double.Parse(textBoxCalc.Text);
            textBoxCalc.Clear();
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            operation = "-";
            currentNumber = double.Parse(textBoxCalc.Text);
            textBoxCalc.Clear();
        }

        private void buttonMultiply_Click_1(object sender, EventArgs e)
        {
            operation = "*";
            currentNumber = double.Parse(textBoxCalc.Text);
            textBoxCalc.Clear();
        }

        private void buttonDivide_Click_1(object sender, EventArgs e)
        {
            operation = "/";
            currentNumber = double.Parse(textBoxCalc.Text);
            textBoxCalc.Clear();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(textBoxCalc.Text);
            switch (operation)
            {
                case "+":
                    result = currentNumber + secondNumber;
                    break;
                case "-":
                    result = currentNumber - secondNumber;
                    break;
                case "*":
                    result = currentNumber * secondNumber;
                    break;
                case "/":
                    result = secondNumber != 0 ? currentNumber / secondNumber : 0;
                    // MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            textBoxCalc.Text = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxCalc.Clear();
            currentNumber = 0;
            result = 0;
            operation = "";
        }

        private async Task LoadTemperatureAsync()
        {
            try
            {
                // Tempe location coordinates 
                string latitude = "33.4255";
                string longitude = "111.9400";

                // Get the current date-time in UTC format required by the API
                string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                
                // API endpoint for temperature data
                string temperatureEndpoint = $"{date}Z/t_2m:F/{latitude},{longitude}/json";
                string apiUrl = "https://api.meteomatics.com/";

                using (HttpClient client = new HttpClient())
                {
                    // Basic Auth
                    var byteArray = new System.Text.ASCIIEncoding().GetBytes("arizonastateuniversity_bir_archisman:939JwX7sgI");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    HttpResponseMessage response = await client.GetAsync(apiUrl + temperatureEndpoint);
                    response.EnsureSuccessStatusCode();

                    string responseData = await response.Content.ReadAsStringAsync();

                    // Parse JSON response to get temperature
                    dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData);
                    string temperature = jsonResponse.data[0].coordinates[0].dates[0].value;

                    labelTemperature.Text = $"Current Temperature in Tempe: {temperature}°F";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving temperature data: " + ex.Message);
            }
        }
    }
}
