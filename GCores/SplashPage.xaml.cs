using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Data.Json;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Popups;
using Windows.System;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace GCores
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SplashPage : Page
    {
        public static string authExclusive = "dpkynzs2q0wm9o5gi1r83fcabthl4eu";
        public string url;
        public SplashPage()
        {
            this.InitializeComponent();
            GetSplash();
        }
        async public void GetSplash()
        {
            try
            {
                HttpClient hc = new HttpClient();
                HttpResponseMessage response = await hc.GetAsync(new Uri("http://www.g-cores.com/api/app_start_pages/active_page?auth_exclusive=" + authExclusive));
                string data = await response.Content.ReadAsStringAsync();
                JsonObject obj = JsonObject.Parse(data);
                string picPath = obj.GetNamedObject("results").GetNamedString("path");
                url = obj.GetNamedObject("results").GetNamedString("to_url");
                img.Source = new BitmapImage(new Uri("http://image.g-cores.com/" + picPath));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        async private void Img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(url));
        }
    }
}
