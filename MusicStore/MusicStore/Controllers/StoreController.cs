using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        //Temp DB data
        //Try to create a dictonary<Guid, Genre>

        Genre deathcore = new Genre(
            Genre.Style.Deathcore,
            new List<Album>()
            {
                new Album(
                    "Invade",
                    "Within The Ruins",
                    2010,
                    new List<Song>() {
                        new Song("Designin Oblivion", "Within The Ruins"),
                        new Song("Versus", "Within The Ruins"),
                        new Song("Behold The Harlot", "Within The Ruins"),
                        new Song("Red Flagged", "Within The Ruins"),
                        new Song("Invade", "Within The Ruins"),
                        new Song("Ataxia", "Within The Ruins"),
                        new Song("Cross Buster", "Within The Ruins"),
                        new Song("Feast Or Famine", "Within The Ruins"),
                        new Song("Oath", "Within The Ruins"),
                        new Song("The Carouser", "Within The Ruins"),
                        new Song("Roads", "Within The Ruins"),
                    }
                ),

                new Album(
                    "Phenomena",
                    "Within The Ruins",
                    2014,
                    new List<Song>() {
                        new Song("Gods Amongst Men", "Within The Ruins"),
                        new Song("The Other", "Within The Ruins"),
                        new Song("Calling Card", "Within The Ruins"),
                        new Song("Hegira", "Within The Ruins"),
                        new Song("Ronin", "Within The Ruins"),
                        new Song("Enigma", "Within The Ruins"),
                        new Song("Clockwork", "Within The Ruins"),
                        new Song("Dark Monarch", "Within The Ruins"),
                        new Song("Eternal Shore", "Within The Ruins"),
                        new Song("Sentinel", "Within The Ruins"),
                        new Song("Ataxia III", "Within The Ruins"),
                    }
                ),

                new Album(
                    "Halfway Human",
                    "Within The Ruins",
                    2017,
                    new List<Song>() {
                        new Song("Shape-Shifter", "Within The Ruins"),
                        new Song("Death Of The Rockstar", "Within The Ruins"),
                        new Song("Beautiful Agony", "Within The Ruins"),
                        new Song("Incomplete Harmony", "Within The Ruins"),
                        new Song("Bittersweet", "Within The Ruins"),
                        new Song("Objective Reality", "Within The Ruins"),
                        new Song("Absolution", "Within The Ruins"),
                        new Song("Ivory Tower", "Within The Ruins"),
                        new Song("Sky Splitter", "Within The Ruins"),
                        new Song("Ataxia IV", "Within The Ruins"),
                        new Song("Treadstone", "Within The Ruins"),
                    }
                )

            }
        );
        Genre jpop = new Genre(
                Genre.Style.JPop,
                new List<Album>() {
                    new Album(
                        "カヌレとウルフ",
                        "HoneyWorks",
                        2014,
                        new List<Song>() {
                            new Song("カヌレ", "CHiCO", "HoneyWorks"),
                            new Song("ウルフ", "CHiCO", "HoneyWorks"),
                        }
                    ),

                    new Album(
                        "HoneyWorks Kyoku Utattemita 5",
                        "HoneyWorks",
                        2016,
                        new List<Song>() {
                            new Song("Kinyoubi no Ohayou -another story", "Lon", "HoneyWorks"),
                            new Song("Kokuhaku Rival Sengen", "Gero", "HoneyWorks"),
                            new Song("Sankaku Jealousy", "Sou", "HoneyWorks"),
                            new Song("Owaranai Eiyuu no Kioku", "un:c & kradness", "HoneyWorks"),
                            new Song("Ima Suki ni Naru", "Yamako", "HoneyWorks"),
                            new Song("Miraizu", "Hiiragi Yuka", "HoneyWorks"),
                            new Song("Inokori Sensei", "Kettaro & Koma'n", "HoneyWorks"),
                            new Song("Mama", "Sana", "HoneyWorks"),
                            new Song("Bakatono Hero", "Dasoku & Gero", "HoneyWorks"),
                            new Song("Byoumei Koi Wazurai", "Hanatan", "HoneyWorks"),
                            new Song("Sekai wa Koi ni Ochiteiru", "Capi", "HoneyWorks"),
                            new Song("Kinyoubi no Ohayou", "Kain", "HoneyWorks"),
                            new Song("Sayonara Ryou Kataomoi", "KK", "HoneyWorks"),
                            new Song("Ima Suki ni Naru", "Gom", "HoneyWorks"),
                        }
                    )
                }
            );
       
        // GET: Store
        public ActionResult Index()
        {
            Store store = new Store();
            store.Catalog.Add(jpop);
            store.Catalog.Add(deathcore);

            HttpContext.Session["Store"] = store;

            return View(store);
        }

        public ActionResult Browse(string name)
        {
            //Will be shorted or removed
            Store store = new Store();
            if (HttpContext.Session["Store"] == null)
            {
                store.Catalog.Add(jpop);
                store.Catalog.Add(deathcore);
                HttpContext.Session["Store"] = store;
            }
            else
            {
                store = (Store)HttpContext.Session["Store"];
            }


            //store.Catalog.ForEach(x => Debug.WriteLine(x));

            //Genre selected = store.Catalog.Single(genre => genre.Id == id);
            Genre selected;

            try
            {
                selected = store.Catalog.Single(g => g.Name.ToString() == name);
            }
            catch (Exception e) {
                return new HttpNotFoundResult();
            }
            
            ViewBag.Message = selected.Name;
            return View(selected);
        }

        public ActionResult Detail(string name, Guid albumId)
        {
            //Will be shorted or removed
            Store store = new Store();

            Genre genreSelected;
            Album albumSelected;

            if (HttpContext.Session["Store"] == null)
            {
                store.Catalog.Add(jpop);
                store.Catalog.Add(deathcore);
                HttpContext.Session["Store"] = store;
            }
            else
            {
                store = (Store)HttpContext.Session["Store"];
            }

            if(genreSelected.Name.ToString() == "")
            {

            }

            Genre genreSelected = store.Catalog.Single(genre => genre.Name.ToString() == name);
            Album albumSelected = genreSelected.Albums.Single(album => album.Id == albumId);

            ViewBag.Message = albumSelected.Name + " - " + albumSelected.Year;
            return View(albumSelected);
        }

    }
}