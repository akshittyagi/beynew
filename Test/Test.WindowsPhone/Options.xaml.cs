﻿using System;
using System.Diagnostics;
using System.Resources;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace Test
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class Options : Page
    {
        //private NavigationHelper navigationHelper;
        //private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public bool mute;
        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        //public ObservableDictionary DefaultViewModel
        //{
        //    get { return this.defaultViewModel; }
        //}

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        //public NavigationHelper NavigationHelper
        //{
        //    get
        //    {
        //        return this.navigationHelper;
        //    }
        //}

        public Options()
        {
            //this.navigationHelper = new NavigationHelper(this);
            //this.navigationHelper.LoadState += navigationHelper_LoadState;
            //this.navigationHelper.SaveState += navigationHelper_SaveState;
            this.InitializeComponent();

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
        //private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        //{
        //    // TODO: Assign a collection of bindable groups to this.DefaultViewModel["Groups"]
        //    String mut = e.NavigationParameter as string;
        //    if (mut.Equals("True"))
        //    {
        //        mute = true;
        //        mediaElement.IsMuted = true;
        //    }
        //    else
        //    {
        //        mute = false;
        //        mediaElement.IsMuted = false;
        //    }
        //}

        //private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        //{

        //}

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

        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    navigationHelper.OnNavigatedFrom(e);
        //}

        #endregion

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), mute.ToString());
            Debug.WriteLine(mute);
        }

        private void on_Click(object sender, RoutedEventArgs e)
        {
            mute = false;
            mediaElement.IsMuted = false;

        }

        private void off_Click(object sender, RoutedEventArgs e)
        {
            mute = true;
            mediaElement.IsMuted = true;
        }
    }
}
