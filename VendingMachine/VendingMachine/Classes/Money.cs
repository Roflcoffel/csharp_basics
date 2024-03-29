﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Money {
        public enum Values {ZERO, ONE, FIVE, TWENTY, FIFTY, HUNDRED, FIVEHUNDRED, ONETHOUSAND}

        public Values Value { get; set; }
        public int Num { get; set; }

        public Money(Values Value)
        {
            this.Value = Value;
            Num = ConvertToInt(Value);
        }

        public Money(int Num)
        {
            //This should garanti that the inputs are valid.
            this.Num = ConvertToInt(ConvertToValue(Num)); 
            Value = ConvertToValue(Num);
            
        }

        private int ConvertToInt(Values value)
        {
            switch (value)
            {
                case Values.ONE:
                    return 1;
                case Values.FIVE:
                    return 5;
                case Values.TWENTY:
                    return 20;
                case Values.FIFTY:
                    return 50;
                case Values.HUNDRED:
                    return 100;
                case Values.FIVEHUNDRED:
                    return 500;
                case Values.ONETHOUSAND:
                    return 1000;
                default:
                    return 0;
            }
        }

        private Values ConvertToValue(int num)
        {
            switch (num)
            {
                case 1:
                    return Values.ONE; 
                case 5:
                    return Values.FIVE;
                case 20:
                    return Values.TWENTY;
                case 50:
                    return Values.FIFTY;
                case 100:
                    return Values.HUNDRED;
                case 500:
                    return Values.FIVEHUNDRED;
                case 1000:
                    return Values.ONETHOUSAND;
                default:
                    return Values.ZERO;
            }
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }
}
