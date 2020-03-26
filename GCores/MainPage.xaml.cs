using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace GCores
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int id1;
        int id2;
        int id3;
        //static VisualStateManager vsm = new VisualStateManager();
        public static event EventHandler Refesh;

        public MainPage()
        {
            this.InitializeComponent();
            fm_Content.Navigate(typeof(ContentPage));
            radio_Frame.Navigate(typeof(RadioIndexPage));
            video_Frame.Navigate(typeof(VideoIndexPage));
            home_Frame.Navigate(typeof(HomePage));
            news_Frame.Navigate(typeof(NewsIndexPage));
            article_Frame.Navigate(typeof(ArticleIndexPage));
            FillFlipView();
            UpdateUi();
            Refesh += MainPage_Refesh;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += BackRequested;
            if ("Windows.Mobile" == Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily)
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            //throw new NotImplementedException();
            Back();
            e.Handled = true;
        }

        private void Back()
        {
            if (fm_Content.Visibility == Visibility.Visible && (vsg_Window.CurrentState==SmallState||vsg_Window.CurrentState==SmallStateMobile))
            {
                fm_Content.Visibility = Visibility.Collapsed;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                btn_Show.Visibility = Visibility.Visible;
            }
        }

        public static void UseRefresh()
        {
            Refesh?.Invoke(new object(), new EventArgs());
        }

        private void MainPage_Refesh(object sender, EventArgs e)
        {
            UpdateUi();
        }

        private void BackRequested(object sender, BackRequestedEventArgs e)
        {
            //throw new NotImplementedException();
            Back();
        }

        async void FillFlipView()
        {
            HttpClient hc = new HttpClient();
            HttpResponseMessage response = await hc.GetAsync(new Uri("http://www.g-cores.com/api/originals/home_slideshow?auth_exclusive=" + SplashPage.authExclusive));
            string data = await response.Content.ReadAsStringAsync();
            JsonObject obj = JsonObject.Parse(data);
            img_1.Source = new BitmapImage(new Uri(obj.GetNamedArray("results")[0].GetObject().GetNamedString("image")));
            img_2.Source = new BitmapImage(new Uri(obj.GetNamedArray("results")[1].GetObject().GetNamedString("image")));
            img_3.Source = new BitmapImage(new Uri(obj.GetNamedArray("results")[2].GetObject().GetNamedString("image")));
            id1 = (int)obj.GetNamedArray("results")[0].GetObject().GetNamedNumber("original_id");
            id2 = (int)obj.GetNamedArray("results")[1].GetObject().GetNamedNumber("original_id");
            id3 = (int)obj.GetNamedArray("results")[2].GetObject().GetNamedNumber("original_id");

        }

        private void Img_1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentPage.wv.Source = new Uri("http://www.g-cores.com/volumes/" + id1);
        }

        private void Img_2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentPage.wv.Source = new Uri("http://www.g-cores.com/volumes/" + id2);

        }

        private void Img_3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentPage.wv.Source = new Uri("http://www.g-cores.com/volumes/" + id3);

        }

        public void UpdateUi()
        {
            if (vsg_Window.CurrentState==SmallState||vsg_Window.CurrentState==SmallStateMobile)
            {
                if (ContentPage.num == 2)
                {
                    fm_Content.Visibility = Visibility.Visible;
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                    //if ("Windows.Mobile" == Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily)
                    //    Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
                }
                else
                {
                    fm_Content.Visibility = Visibility.Collapsed;
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                    //if ("Windows.Mobile" == Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily)
                    //    Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
                    btn_Show.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                fm_Content.Visibility = Visibility.Visible;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                //if ("Windows.Mobile" == Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily)
                //    Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
                btn_Show.Visibility = Visibility.Collapsed;
            }
        }

        private void Vsg_Window_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateUi();
        }

        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            fm_Content.Visibility = Visibility.Visible;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}
