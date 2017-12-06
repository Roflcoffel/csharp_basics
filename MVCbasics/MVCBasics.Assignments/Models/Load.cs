using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Used for loading "HighScore" from the session;
namespace MVCBasics.Assignments.Models {
    public class Load {
        public static bool newHighScore { get; set; } = false;

        public static string HighScore(Guesser gb, HttpSessionStateBase hs)
        {
            if (hs["HighScore"] == null)
            {
                hs["HighScore"] = gb.Score;
                newHighScore = false;

                return gb.Score.ToString();
            }
            else
            {

                if (Convert.ToInt32(hs["HighScore"]) < gb.Score)
                {
                    hs["HighScore"] = gb.Score;
                    newHighScore = true;

                    return gb.Score.ToString();

                }

                newHighScore = false;
                return hs["HighScore"].ToString();
            }
        }
        
    }
}