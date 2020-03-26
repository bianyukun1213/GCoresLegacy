using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace GCores
{
    public sealed partial class HomePageGeneralItem : UserControl
    {
        public HomePageGeneralItem()
        {
            this.InitializeComponent();
        }


        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(HomePageGeneralItem), null);


        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Category.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CategoryProperty =
            DependencyProperty.Register("Category", typeof(string), typeof(HomePageGeneralItem), null);


        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string), typeof(HomePageGeneralItem), null);


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(HomePageGeneralItem), null);


        public string Comments
        {
            get { return (string)GetValue(CommentsProperty); }
            set { SetValue(CommentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Comments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentsProperty =
            DependencyProperty.Register("Comments", typeof(string), typeof(HomePageGeneralItem), null);


        public string Likes
        {
            get { return (string)GetValue(LikesProperty); }
            set { SetValue(LikesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Likes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LikesProperty =
            DependencyProperty.Register("Likes", typeof(string), typeof(HomePageGeneralItem), null);


        public string CategoryTitle
        {
            get { return (string)GetValue(CategoryTitleProperty); }
            set { SetValue(CategoryTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CategoryTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CategoryTitleProperty =
            DependencyProperty.Register("CategoryTitle", typeof(string), typeof(HomePageGeneralItem), null);


        public string Subscribes
        {
            get { return (string)GetValue(SubscribesProperty); }
            set { SetValue(SubscribesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Subscribes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubscribesProperty =
            DependencyProperty.Register("Subscribes", typeof(string), typeof(HomePageGeneralItem), null);


        public string Articles
        {
            get { return (string)GetValue(ArticlesProperty); }
            set { SetValue(ArticlesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Articles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArticlesProperty =
            DependencyProperty.Register("Articles", typeof(string), typeof(HomePageGeneralItem), null);


        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(HomePageGeneralItem), null);

        private void Rp_Root_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("以后会完成的，感谢支持！", "还没有完成……");
            md.ShowAsync();
        }
    }
}
