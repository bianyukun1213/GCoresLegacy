using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCores
{
    class Category
    {
        int id;
        string name;
        string desc;
        string showName;
        string type;
        string specificType;
        string logoUrl;
        string backgroundUrl;
        int subscriptorsNum;
        int originalsNum;
        List<Article> articles;
        List<Volume> volumes;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public string ShowName { get => showName; set => showName = value; }
        public string Type { get => type; set => type = value; }
        public string SpecificType { get => specificType; set => specificType = value; }
        public string LogoUrl { get => logoUrl; set => logoUrl = value; }
        public string BackgroundUrl { get => backgroundUrl; set => backgroundUrl = value; }
        public int SubscriptorsNum { get => subscriptorsNum; set => subscriptorsNum = value; }
        public int OriginalsNum { get => originalsNum; set => originalsNum = value; }
        internal List<Article> Articles { get => articles; set => articles = value; }
        internal List<Volume> Volumes { get => volumes; set => volumes = value; }
        public Category(int id, string name, string desc, string showName, string type, string specificType, string logoUrl, string backgroundUrl, int subscriptorsNum, int originalsNum)
        {
            this.Id = id;
            this.Name = name;
            this.Desc = desc;
            this.ShowName = showName;
            this.Type = type;
            this.SpecificType = specificType;
            this.LogoUrl = logoUrl;
            this.BackgroundUrl = backgroundUrl;
            this.SubscriptorsNum = subscriptorsNum;
            this.OriginalsNum = originalsNum;
        }
    }
}
