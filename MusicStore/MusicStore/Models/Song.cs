using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models {
    public class Song {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }
        public string Composer { get; set; } = "";

        public Song(string Name, string Artist)
        {
            Id = Guid.NewGuid();

            this.Name = Name;
            this.Artist = Artist;
        }

        public Song(string Name, string Artist, string Composer)
        {
            Id = Guid.NewGuid();

            this.Name = Name;
            this.Artist = Artist;
            this.Composer = Composer;
        }
    }
}