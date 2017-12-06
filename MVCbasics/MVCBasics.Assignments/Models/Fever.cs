using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBasics.Assignments.Models {
    public class Fever {
        public static string Check(Temp fever)
        {
            if (fever.Scale == "Celsius")
            {
                if (fever.Temperature >= 38)
                {
                    return "You have a fever";
                }
                else if (fever.Temperature <= 35)
                {
                    return "hypothermia!!!";
                }

                return "you do not have a fever";
            }
            else
            {
                if (fever.Temperature >= 100)
                {
                    return "You have a fever";
                }
                else if (fever.Temperature <= 95)
                {
                    return "hypothermia!!!";
                }

                return "you do not have a fever";
            }
        }
    }
}