using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Test.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace Test
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class Level_Select : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public bool mute;

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
        public NavigationHelper NavigationHelper
        {
            get
            {
                return this.navigationHelper;
            }
        }

        public Level_Select()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.SizeChanged += Level_Select_SizeChanged;
            double dimx = Window.Current.Bounds.Width;
            double dimy = Window.Current.Bounds.Height;

            back.Margin = new Thickness(dimx / 30, dimy / 12, 0, 0);
            flipView.Margin = new Thickness(dimx / 2.4, dimy / 10, 0, 0);
            flipView.Width = dimx * 0.33*10;
            flipView.Height = dimy * 2.3;
            proceed.Margin = new Thickness(dimx / 2.4, dimy / 1.2, 0, 0);
            proceed.Width = back.Width * 2.5;
        }

        private void Level_Select_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double dimx, dimy;
            dimx = e.NewSize.Width;
            dimy = e.NewSize.Height;
            back.Margin = new Thickness(dimx / 30, dimy / 12, 0, 0);
            flipView.Margin = new Thickness(dimx / 2.9, dimy / 3, 0, 0);
            flipView.Width = dimx * 0.33;
            flipView.Height = dimy * 0.23;
            proceed.Margin = new Thickness(dimx / 2.25, dimy / 1.2, 0, 0);
            proceed.Width = back.Width * 2.5;
            //throw new NotImplementedException();
        }

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

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {

        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// and <see cref="Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), mute.ToString());
        }

        private void proceed_Click(object sender, RoutedEventArgs e)
        {
            int i = flipView.SelectedIndex;
            this.Frame.Navigate(typeof(Game), mute.ToString() + " " + i.ToString());
            //Debug.WriteLine(mute.ToString() + " " + i.ToString());
        }
    }
}
