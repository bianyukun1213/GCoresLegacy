using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCores
{
    class Article
    {
        int id;
        string type;
        string title;
        string desc;
        string thumbUrl;
        string coverUrl;
        string permalink;
        string vol;
        int likesNum;
        int commentsNum;
        string createdAt;
        string category;
        string userName;
        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public string Title { get => title; set => title = value; }
        public string Desc { get => desc; set => desc = value; }
        public string ThumbUrl { get => thumbUrl; set => thumbUrl = value; }
        public string CoverUrl { get => coverUrl; set => coverUrl = value; }
        public string Permalink { get => permalink; set => permalink = value; }
        public string Vol { get => vol; set => vol = value; }
        public int LikesNum { get => likesNum; set => likesNum = value; }
        public int CommentsNum { get => commentsNum; set => commentsNum = value; }
        public string CreatedAt { get => createdAt; set => createdAt = value; }
        public string Category { get => category; set => category = value; }
        public string UserName { get => userName; set => userName = value; }
        public Article(int id, string type, string title, string desc, string thumbUrl, string coverUrl, string permalink, string vol, int likesNum, int commentsNum, string createdAt, string category,string userName)
        {
            this.Id = id;
            this.Type = type;
            this.Title = title;
            this.Desc = desc;
            this.ThumbUrl = thumbUrl;
            this.CoverUrl = coverUrl;
            this.Permalink = permalink;
            this.Vol = vol;
            this.LikesNum = likesNum;
            this.CommentsNum = commentsNum;
            this.CreatedAt = createdAt;
            this.Category = category;
            this.UserName = userName;
        }
    }
}
