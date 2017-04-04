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
using FloodTracker.Utils;
using FloodTracker.Model;

namespace FloodTracker
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

        private void button_RetrieveData(object sender, RoutedEventArgs e)
        {
            //Get site no from textbox
            string siteNo = siteNoTextBox.Text;
            if (isDigitsOnly(siteNo))
            {
                //siteNo contains all digits so create the url for the data
                string url = new WaterUrlGenerator(siteNo).GetUrl();
                Console.WriteLine($"URL: {url}");

                //Perform an HTTP GET request to the url to get the data
                string request = RequestData.RetrieveData(url);

                //either display data or parse for further use
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(request)));
            }else
            {
                //display error message
            }
            
        }

        private bool isDigitsOnly(string s)
        {
            foreach (char c in s)
            {
                if (c < '0' || c > '9') return false;
            }
            return true;
        }
    }
}
