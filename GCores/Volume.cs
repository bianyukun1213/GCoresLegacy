using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCores
{
    class Volume
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
        int duration;
        string category;
        string media;
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
        public int Duration { get => duration; set => duration = value; }
        public string Category { get => category; set => category = value; }
        public string Media { get => media; set => media = value; }
        public Volume(int id, string type, string title, string desc, string thumbUrl, string coverUrl, string permalink, string vol, int likesNum, int commentsNum, string createdAt, int duration, string category, string media)
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
            this.Duration = duration;
            this.Category = category;
            this.Media = media;
        }
    }
}
