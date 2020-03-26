using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace GCores
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ContentPage : Page
    {
        public static WebView wv = new WebView();
        public static int num = 0;
        public ContentPage()
        {
            this.InitializeComponent();
            wv.ContentLoading += Wv_ContentLoading;
            wv.DOMContentLoaded += Wv_DOMContentLoaded;
            wv.NavigateToString("<html><body><h1 style=\"text-align:center;color:dodgerblue\">这部分以后会做成内置，现在先使用网页。暂不支持flash player，所以视频看不了（不过如果是手机，应该可以观看）。</h1></body></html>");
            grid_Root.Children.Add(wv);
        }

        private void Wv_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            if (wv.DocumentTitle != "")
            {
                btn_Open.IsEnabled = true;
            }
        }

        private void Wv_ContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            if (num < 2)
            {
                ++num; ;
            }
            btn_Open.IsEnabled = false;
            MainPage.UseRefresh();
        }

        private void Btn_Open_Click(object sender, RoutedEventArgs e)
        {
            Launcher.LaunchUriAsync(wv.Source);
        }
    }
}
