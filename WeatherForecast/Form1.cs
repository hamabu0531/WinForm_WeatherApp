using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherForecast
{
    public partial class Form1 : Form
    {
        private const string BaseUrl = "https://api.aoikujira.com/tenki/week.php?fmt=json";
        JObject[] data = new JObject[8]; // 1週間分
        public Form1()
        {
            InitializeComponent();
            GetWeather();
            SetWeather(0);
            
        }
        

        private void GetWeather()
        {
            string json = new HttpClient().GetStringAsync(BaseUrl).Result;
            JObject jobj = JObject.Parse(json);
            if(jobj[locationTextBox.Text] == null)
            {
                MessageBox.Show("別の地点を入力してください");
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                data[i] = (jobj[locationTextBox.Text][i] as JObject);
                locationLabel.Text = locationTextBox.Text;
            }
           
        }
        private void SetWeather(int day)
        {
            // Today
            weatherLabel.Text = (string)(data[day]["forecast"]);
            wavesLabel.Text = (string)(data[day]["waves"]);
            string maxTemp = (string)(data[day]["maxtemp"]);
            string minTemp = (string)(data[day]["mintemp"]);
            tempRichText.Text = "\n" + maxTemp + " ℃" + " / " + minTemp + " ℃";
            tempRichText.Select(1, maxTemp.Length+1);
            tempRichText.SelectionColor = Color.Red;
            tempRichText.Select(maxTemp.Length + 6, minTemp.Length);
            tempRichText.SelectionColor = Color.Blue;
            tempRichText.SelectAll();
            tempRichText.SelectionAlignment = HorizontalAlignment.Center; // 中央揃え
            tempRichText.Padding = new Padding(0, 100, 0, 0);
            tempRichText.Select(0, 0);
            //TempLabel.Text = (string)(data[day]["maxtemp"]) + " ℃" + " / " + (string)(data[day]["mintemp"]) + " ℃";
            dateLabel.Text = (string)(data[day]["date"]) ;
            windsLabel.Text = (string)(data[day]["winds"]);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetWeather();
            SetWeather(7);
        }
    }
}
