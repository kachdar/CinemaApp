using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Certificate { get; set; }
        public string Runtime { get; set; }
        public int Release { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }

        public Movie()
        {
        }
        public Movie(string title, string imageUrl, string genre) 
        {
            Title = title;
            ImageUrl = imageUrl;
            Genre = genre;
        }

    }
}
