using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WallpapersHub.Models
{

    public class imageData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Resolution { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int Downloads { get; set; }
    }
    public class DbConnection : DbContext
    {
        public DbSet<imageData> ImageDetails { get; set; }
    }
}