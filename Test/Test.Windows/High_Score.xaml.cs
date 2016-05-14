using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Test.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class High_Score : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public bool mute;
        public double[] HighScore = { 3.036, 5.141, 6.131, 8.343, 5.674 };
        //string[] scores;
        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        /// 
        public NavigationHelper NavigationHelper
        {
            get
            {
                return this.navigationHelper;
            }
        }

        public High_Score()
        {
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.InitializeComponent();
            //LoadHighScores();

        }

        //public async void LoadHighScores()
        //{
        //    StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        //    StorageFile sampleFile = await storageFolder.GetFileAsync("HighScores.txt");
        //    string textread = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        //   // Debug.WriteLine("string read is:" + textread);
        //    scores = textread.Split(' ');
        //    //listView.ItemsSource = scores;
        //}

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Assign a collection of bindable groups to this.DefaultViewModel["Groups"]
            String mut = e.NavigationParameter as string;
            if (mut.Equals("True"))
            {
                mute = true;
                mediaElement.IsMuted = true;
            }
            else
            {
                mute = false;
                mediaElement.IsMuted = false;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String mut = e.Parameter as string;
            if (mut.Equals("True"))
            {
                mute = true;
                mediaElement.IsMuted = true;
            }
            else
            {
                mute = false;
                mediaElement.IsMuted = false;
            }

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), mute.ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
            //Db_Helper.DeleteAllContact();
            for (int i = 0; i < 5; i++)
            {
                HighScore[i] = 0;
            }
            textBlock1.Text = "0";
        }

        private void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DatabaseHelperClass db = new DatabaseHelperClass();
            try
            {
                int i = flipView.SelectedIndex;
                textBlock1.Text = HighScore[i].ToString();
            }
            catch (NullReferenceException)
            {
               // textBlock1.Text = HighScore[0].ToString();
            }
        }

    }
}
