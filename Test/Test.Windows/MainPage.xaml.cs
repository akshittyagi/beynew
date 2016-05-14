using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Test.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
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
    public sealed partial class MainPage : Page
    {
        public bool mute;
        private NavigationHelper navigationHelper;
        double screendimx, screendimy;
        double scalex, scaley;

        public MainPage()
        {
            
            scalex =scaley= 1;
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            this.InitializeComponent();

            ResetHighScores();


            //this.
            screendimx = Window.Current.Bounds.Width;
            screendimy = Window.Current.Bounds.Height;
            mediaElement.IsMuted = mute;
            image.Height = screendimy;
            image.Width = screendimx;
            this.SizeChanged += MainPage_SizeChanged;                

        }
        public static async void ResetHighScores()
        {
            StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.CreateFileAsync("HighScores.txt", CreationCollisionOption.OpenIfExists);
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double dimy = e.NewSize.Height;
            double dimx = e.NewSize.Width;
            //scalex = dimx / screendimx;
            //scaley = dimy / screendimy;
            scalex = scaley = Ball.RadiusFunction(99);
            resize(screendimx,screendimy);
            //throw new NotImplementedException();
        }

        public void resize(double x,double y)
        {
            start.Margin = new Thickness(x / 30, y / 15, 0, 0);
            tutorial.Margin = new Thickness(x / 30, y / 7, 0, 0);
            Highscore.Margin = new Thickness(x  / 30, y * 23 / 105, 0, 0);
            options.Margin = new Thickness(x  / 30, y  *31/ 105, 0, 0);

            //image.Width = screendimx;
            Debug.WriteLine("Screendiimx " + screendimx);
            //image.Height = screendimy;
        }

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

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Level_Select), mute.ToString());
        }

        private void tutorial_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Tutorial), mute.ToString());
        }

        private void Highscore_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(High_Score), mute.ToString());
        }

        private void options_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Options), mute.ToString());
        }
    }
}
