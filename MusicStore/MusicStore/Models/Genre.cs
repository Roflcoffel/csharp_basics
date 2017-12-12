using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models {
    public class Genre {

        public Guid Id { get; set; }

        public Style Name { get; set; }
        public enum Style { JPop, Deathcore, Metal, Rock, Pop, Classical}

        public List<Album> Albums { get; set; }

        //Artist Count
        //Song Count

        public Genre()
        {

        }

        public Genre(Style Name, List<Album> Albums)
        {
            Id = Guid.NewGuid();

            this.Name = Name;
            this.Albums = Albums;
        }
    }
}