using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MusicStore.Models {
    public class Album {

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }

        public string imgPath { get; set; } = "";

        public List<Song> Songlist { get; set; }


        public Album(string Name, string Artist, int Year, List<Song> Songlist)
        {
            Id = Guid.NewGuid();

            this.Artist = Artist;
            this.Name = Name;
            this.Year = Year;
            this.Songlist = Songlist;
        }

        public Album(string Name, string Artist, int Year, List<Song> Songlist, string imgPath)
        {
            Id = Guid.NewGuid();

            this.Artist = Artist;
            this.Name = Name;
            this.Year = Year;
            this.Songlist = Songlist;

            this.imgPath = imgPath;
        }
    }
}