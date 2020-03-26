using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace GCores
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class RadioIndexPage : Page
    {
        static ObservableCollection<Volume> oc = new ObservableCollection<Volume>();
        static int page = 1;
        static bool first = true;
        public RadioIndexPage()
        {
            this.InitializeComponent();
            lv_Root.DataContext = oc;
            if (first)
            {
                GetRadios(1);
                first = false;
            }
        }
        async void GetRadios(int pageNumber)
        {
            try
            {
                HttpClient hc = new HttpClient();
                HttpResponseMessage response = await hc.GetAsync(new Uri("http://www.g-cores.com/api/categories/9/originals?page=" + pageNumber + "&auth_exclusive=" + SplashPage.authExclusive));
                string data = await response.Content.ReadAsStringAsync();
                JsonObject obj = JsonObject.Parse(data);
                for (int i = 0; i < obj.GetNamedArray("results").Count; i++)
                {
                    int id = (int)obj.GetNamedArray("results")[i].GetObject().GetNamedNumber("id");
                    string type = obj.GetNamedArray("results")[i].GetObject().GetNamedString("type");
                    string title = obj.GetNamedArray("results")[i].GetObject().GetNamedString("title");
                    string desc = obj.GetNamedArray("results")[i].GetObject().GetNamedString("desc");
                    string thumbUrl = obj.GetNamedArray("results")[i].GetObject().GetNamedString("thumb_url");
                    string coverUrl = obj.GetNamedArray("results")[i].GetObject().GetNamedString("cover_url");
                    string permalink = obj.GetNamedArray("results")[i].GetObject().GetNamedString("permalink");
                    string vol = obj.GetNamedArray("results")[i].GetObject().GetNamedString("vol");
                    int likesNum = (int)obj.GetNamedArray("results")[i].GetObject().GetNamedNumber("likes_num");
                    int commentsNum = (int)obj.GetNamedArray("results")[i].GetObject().GetNamedNumber("comments_num");
                    string createdAt = obj.GetNamedArray("results")[i].GetObject().GetNamedString("created_at");
                    int duration = (int)obj.GetNamedArray("results")[i].GetObject().GetNamedNumber("duration");
                    string category = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("category").GetNamedString("name");
                    string media = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("media").GetNamedArray("mp3")[0].GetString();
                    Volume vo = new Volume(id, type, title, desc, thumbUrl, coverUrl, permalink, vol, likesNum, commentsNum, createdAt, duration, category, media);
                    oc.Add(vo);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Lv_Root_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (e.ClickedItem.ToString() == "GCores.BasicItemBig")
            //{
            //    BasicItemBig bib = (BasicItemBig)e.ClickedItem;
            //    System.Diagnostics.Debug.WriteLine(bib.Title);
            //}
            Volume vl = (Volume)e.ClickedItem;
            ContentPage.wv.Source = new Uri(vl.Permalink);
        }

        private void Btn_Load_Click(object sender, RoutedEventArgs e)
        {
            GetRadios(++page);
        }
    }
}
