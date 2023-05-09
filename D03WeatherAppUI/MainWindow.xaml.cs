using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace D03WeatherAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // synchronous processing 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cities = txtCityName.Text;
            WeatherManager wm   = new WeatherManager();

            string[] citiesArray = cities.Split("\n");

            txtLogs.Text = "";
            txtTemperature.Text = "";
            try
            {
                foreach (var city in citiesArray)
                {
                    int temp = wm.GetTemperature(city);
                    txtLogs.Text += $"Processing city {city}\n";
                    txtTemperature.Text += $"Temperature in city {city} is {temp.ToString()}\n";
                }
            }
            catch (Exception)
            {
               // throw;
                MessageBox.Show("We cannot process your data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }

        // asynchronous 
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string cities = txtCityName.Text;
            WeatherManager wm = new WeatherManager();

            string[] citiesArray = cities.Split("\n");

            txtLogs.Text = "";
            txtTemperature.Text = "";

            try
            {
                foreach (var city in citiesArray)
                {
                    // int temp = wm.GetTemperature(city);
                    var t = Task.Run(() => wm.GetTemperature(city));

                    t.GetAwaiter().OnCompleted(() =>
                    {
                        txtTemperature.Text += $"Temperature in city {city} is {t.Result.ToString()}\n";
                    });

                    txtLogs.Text += $"Processing city {city}\n";

                }
            }
            catch (Exception)
            {
                MessageBox.Show("We cannot process your data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string cities = txtCityName.Text;
            WeatherManager wm = new WeatherManager();

            string[] citiesArray = cities.Split("\n");

            txtLogs.Text = "";
            txtTemperature.Text = "";

            try
            {
                foreach (var city in citiesArray)
                {
                    // int temp = wm.GetTemperature(city);
                    txtLogs.Text += $"Processing city {city}\n";

                    int t = await Task.Run(() => wm.GetTemperature(city));

                    txtTemperature.Text += $"Temperature in city {city} is {t}\n";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("We cannot process your data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // lunch breake 1:15
    }
}
