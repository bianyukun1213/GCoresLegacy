using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace GCores
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        static ObservableCollection<Object> oc = new ObservableCollection<Object>();
        static Dictionary<BasicItemBig, Article> dic = new Dictionary<BasicItemBig, Article>();
        static int page = 1;
        static bool first = true;
        public HomePage()
        {
            this.InitializeComponent();
            lv_Root.ItemsSource = oc;
            if (first)
            {
                GetItems(1);
                first = false;
            }
        }
        async void GetItems(int pageNumber)
        {
            try
            {
                HttpClient hc = new HttpClient();
                HttpResponseMessage response = await hc.GetAsync(new Uri("http://www.g-cores.com/api/originals/home?page=" + pageNumber + "&auth_exclusive=" + SplashPage.authExclusive));
                string data = await response.Content.ReadAsStringAsync();
                JsonObject obj = JsonObject.Parse(data);
                StackPanel sp = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                ScrollViewer sv = new ScrollViewer()
                {
                    HorizontalScrollMode = ScrollMode.Enabled,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                    VerticalScrollMode = ScrollMode.Disabled,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
                    Content = sp,
                    IsFocusEngagementEnabled = true
                };
                switch (pageNumber)
                {
                    case 1:
                        foreach (JsonValue item in obj.GetNamedArray("results")[0].GetObject().GetNamedArray("data"))
                        {
                            HomePageGeneralItem gi = new HomePageGeneralItem()
                            {
                                Title = item.GetObject().GetNamedString("title"),
                                Image = new BitmapImage(new Uri(item.GetObject().GetNamedString("thumb_url"))),
                                Time = item.GetObject().GetNamedString("created_at"),
                                Likes = item.GetObject().GetNamedNumber("likes_num").ToString(),
                                Comments = item.GetObject().GetNamedNumber("comments_num").ToString(),
                                Category = item.GetObject().GetNamedObject("category").GetNamedString("name")
                            };
                            sp.Children.Add(gi);
                        }
                        oc.Add(sv);
                        break;
                    case 2:
                        foreach (JsonValue item in obj.GetNamedArray("results")[0].GetObject().GetNamedArray("data"))
                        {
                            HomePageGeneralItem gi = new HomePageGeneralItem()
                            {
                                CategoryTitle = item.GetObject().GetNamedString("name"),
                                Image = new BitmapImage(new Uri(item.GetObject().GetNamedString("background_url"))),
                                Articles = item.GetObject().GetNamedNumber("originals_num").ToString(),
                                Subscribes = item.GetObject().GetNamedNumber("subscriptors_num").ToString()
                            };
                            sp.Children.Add(gi);
                        }
                        oc.Add(sv);
                        break;
                    case 3:
                        foreach (JsonValue item in obj.GetNamedArray("results")[0].GetObject().GetNamedArray("data"))
                        {
                            HomePageGeneralItem gi = new HomePageGeneralItem()
                            {
                                Title = item.GetObject().GetNamedString("title"),
                                Image = new BitmapImage(new Uri(item.GetObject().GetNamedString("thumb_url"))),
                                Time = item.GetObject().GetNamedString("created_at"),
                                Likes = item.GetObject().GetNamedNumber("likes_num").ToString(),
                                Comments = item.GetObject().GetNamedNumber("comments_num").ToString()
                            };
                            sp.Children.Add(gi);
                        }
                        oc.Add(sv);
                        break;
                    case 4:
                        foreach (JsonValue item in obj.GetNamedArray("results")[0].GetObject().GetNamedArray("data"))
                        {
                            HomePageGeneralItem gi = new HomePageGeneralItem()
                            {
                                UserName = item.GetObject().GetNamedString("nickname"),
                                Image = new BitmapImage(new Uri(item.GetObject().GetNamedString("thumb_url")))
                            };
                            sp.Children.Add(gi);
                        }
                        oc.Add(sv);
                        break;
                    default:
                        int id = (int)obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedNumber("id");
                        string type = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedString("type");
                        string title = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedString("title");
                        string desc = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedString("desc");
                        string thumbUrl = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedString("thumb_url");
                        string coverUrl = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedString("cover_url");
                        string permalink = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedString("permalink");
                        string vol = null;
                        int likesNum = (int)obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedNumber("likes_num");
                        int commentsNum = (int)obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedNumber("comments_num");
                        string createdAt = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedString("created_at");
                        string category = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedObject("category").GetNamedString("name");
                        string userName = obj.GetNamedArray("results")[0].GetObject().GetNamedObject("data").GetNamedObject("user").GetNamedString("nickname");
                        Article ar = new Article(id, type, title, desc, thumbUrl, coverUrl, permalink, vol, likesNum, commentsNum, createdAt, category, userName);
                        BasicItemBig bib = new BasicItemBig()
                        {
                            Title = title,
                            Desc = desc,
                            Image = new BitmapImage(new Uri(thumbUrl)),
                            Likes = likesNum,
                            Comments = commentsNum,
                            Time = createdAt,
                            User = userName,
                            Category = category
                        };
                        oc.Add(bib);
                        dic.Add(bib, ar);
                        break;
                }
                for (int i = 1; i < obj.GetNamedArray("results").Count; i++)
                {
                    int id = (int)obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedNumber("id");
                    string type = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedString("type");
                    string title = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedString("title");
                    string desc = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedString("desc");
                    string thumbUrl = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedString("thumb_url");
                    string coverUrl = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedString("cover_url");
                    string permalink = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedString("permalink");
                    string vol = null;
                    int likesNum = (int)obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedNumber("likes_num");
                    int commentsNum = (int)obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedNumber("comments_num");
                    string createdAt = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedString("created_at");
                    string category = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedObject("category").GetNamedString("name");
                    string userName = obj.GetNamedArray("results")[i].GetObject().GetNamedObject("data").GetNamedObject("user").GetNamedString("nickname");
                    Article ar = new Article(id, type, title, desc, thumbUrl, coverUrl, permalink, vol, likesNum, commentsNum, createdAt, category, userName);
                    BasicItemBig bib = new BasicItemBig()
                    {
                        Title = title,
                        Desc = desc,
                        Image = new BitmapImage(new Uri(thumbUrl)),
                        Likes = likesNum,
                        Comments = commentsNum,
                        Time = createdAt,
                        User = userName,
                        Category = category
                    };
                    oc.Add(bib);
                    dic.Add(bib, ar);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Btn_Load_Click(object sender, RoutedEventArgs e)
        {
            GetItems(++page);
        }

        private void Lv_Root_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem.ToString() == "GCores.BasicItemBig")
            {
                BasicItemBig bib = (BasicItemBig)e.ClickedItem;
                //System.Diagnostics.Debug.WriteLine(bib.Title);
                ContentPage.wv.Source = new Uri(dic[bib].Permalink);
            }
        }
    }
}
