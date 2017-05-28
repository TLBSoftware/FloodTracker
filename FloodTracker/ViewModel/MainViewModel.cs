using FloodTracker.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FloodTracker.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        #region Private Fields
        /// <summary>
        /// Private string to hold a default site no.
        /// </summary>
        private string _siteString = "06919020";

        /// <summary>
        /// Private String to hold the data returned from the GET Request
        /// </summary>
        private string _dataString;

        /// <summary>
        /// ICommand implementation for the button that performs a GET request for the data
        /// </summary>
        private RelayCommand _getDataButton;
        #endregion

        #region Public Properties
        /// <summary>
        /// String property for the textbox that requires a Stream gage Site No.
        /// </summary>
        public string SiteString
        {
            get { return _siteString; }
            set
            {
                if (_siteString != value)
                {
                    OnPropertyChanged<string>(ref _siteString, value);
                }
            }
        }

        /// <summary>
        /// Data property for the RichTextBox that displays the data
        /// </summary>
        public string DataString
        {
            get
            {
                return _dataString;
            }
            set
            {
                if(_dataString != value)
                {
                    OnPropertyChanged<string>(ref _dataString, value);
                }
            }
        }
        public RelayCommand GetDataButton { get { return _getDataButton; } set { if (_getDataButton != value) OnPropertyChanged(ref _getDataButton, value); } }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            _getDataButton = new RelayCommand(button_RetrieveData);

        }
        #endregion

        #region Methods
        private void button_RetrieveData(object sender)
        {
            //Get site no from textbox
            string siteNo = sender as string;
            if (isDigitsOnly(siteNo))
            {
                //siteNo contains all digits so create the url for the data
                string url = new WaterUrlGenerator(siteNo).GetUrl();
                Console.WriteLine($"URL: {url}");

                //Perform an HTTP GET request to the url to get the data
                string request = RequestData.RetrieveData(url);

                //either display data or parse for further use
                DataString = request;
            }
            else
            {
                //display error message
            }

        }

        private bool isDigitsOnly(object s)
        {
            if(s != null)
            {
                string sstring = s as string;
                if (sstring != null)
                {
                    foreach (char c in (string)s)
                    {
                        if (c < '0' || c > '9') return false;
                    }

                    return true;
                }
                
            }
            return false;
        }
        #endregion

    }
}
