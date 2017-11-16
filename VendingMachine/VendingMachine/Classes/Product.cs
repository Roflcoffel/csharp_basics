using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes {
    class Product : IPurchable{
        public Money Prize { get; set; }
        public string Label { get; set; }

        public Product() { }

        public Product(string Label, Money Prize)
        {
            this.Prize = Prize;
            this.Label = Label;
        }

        public override string ToString()
        {
            return $"Label: {Label} - {Prize}Kr";
        }

        public string Examine()
        {
            return ToString();
        }

        public string Purchase(List<Money> pool, User user)
        {
            string input;

            do
            {
                input = Change(pool, user);
            } while (input == "run");

            if (input == "")
            {
                user.Stuff.Add(this);
            }

            return input;
        }

        public virtual string Use()
        {
            return $"You eat/drink the {Label}";
        }

        private string Change(List<Money> pool, User user)
        {

            //First check if the user can afford the item
            if (pool.Sum(x => x.Num) >= Prize.Num)
            {
                //check for equal
                if (pool.Exists(x => x.Value == Prize.Value))
                {
                    pool.Remove(pool.Find(x => x.Value == Prize.Value));
                    //Remove the Money object for x.Value
                    return ""; //Item Removed
                }
                else if(pool.Sum(x => x.Num) == Prize.Num) 
                {
                    //kollar om summan av pool är det exakta värdet;

                    pool.Clear();
                    //Rensar nuvarande listan, kan behöva göra ref

                    return "";
                }
                else
                {
                    //behöver växla
                    //Hitta ett värde som är större än Prize.value i pool
                    if (pool.Exists(x => x.Num > Prize.Num))
                    {
                        //True;
                        //ta bort det värdet och skapa fler money object som
                        //när dem läggs ihop blir dem värdet som togs bort.

                        //Detta fungerar så länge priserna är jämna
                        //med vad man kan stoppa in.
                        Money money = pool.Find(x => x.Num > Prize.Num);
                        switch (money.Value)
                        {
                            case Money.Values.ONE:
                                break;
                            case Money.Values.FIVE:
                                pool.Add(new Money(1));
                                pool.Add(new Money(1));
                                pool.Add(new Money(1));
                                pool.Add(new Money(1));
                                pool.Add(new Money(1));
                                break;
                            case Money.Values.TWENTY:
                                pool.Add(new Money(5));
                                pool.Add(new Money(5));
                                pool.Add(new Money(5));
                                pool.Add(new Money(5));
                                break;
                            case Money.Values.FIFTY:
                                pool.Add(new Money(5));
                                pool.Add(new Money(5));
                                pool.Add(new Money(20));
                                pool.Add(new Money(20));
                                break;
                            case Money.Values.HUNDRED:
                                pool.Add(new Money(50));
                                pool.Add(new Money(50));
                                break;
                            case Money.Values.FIVEHUNDRED:
                                pool.Add(new Money(100));
                                pool.Add(new Money(100));
                                pool.Add(new Money(100));
                                pool.Add(new Money(100));
                                pool.Add(new Money(100));
                                break;
                            case Money.Values.ONETHOUSAND:
                                pool.Add(new Money(500));
                                pool.Add(new Money(500));
                                break;
                            default:
                                break;
                        }

                        pool.Remove(money);

                        return "run"; //Applying Change Calc;
                    }
                    else //Finns inget värde som är större än Prize.Value i pool
                    {
                        //addera värden från poolen så dem
                        //blir ett större gitigt värdet

                        //5*ONE = FIVE
                        if ( Exchange(pool, 5, new Money(5), Money.Values.ONE)) {
                            return "run";
                        }

                        //4*FIVE = 20
                        if ( Exchange(pool, 4, new Money(20), Money.Values.FIVE)) {
                            return "run";
                        }

                        //2*TWENTY = 40
                        if ( Exchange(pool, 2, new Money(0), Money.Values.TWENTY))
                        {
                            //2*FIVE + 40 = 50
                            if ( Exchange(pool, 2, new Money(50), Money.Values.FIVE))
                            {
                                return "run";
                            }
                        }

                        //2*FIFTY = 100
                        if ( Exchange(pool, 2, new Money(100), Money.Values.FIFTY))
                        {
                            return "run";
                        }

                        //5*HUNDRED = 500
                        if ( Exchange(pool, 5, new Money(500), Money.Values.HUNDRED))
                        {
                            return "run";
                        }
                       
                        //2*FIVEHUNDRA = 1000
                        if(Exchange(pool, 2, new Money(1000), Money.Values.FIVEHUNDRED))
                        {
                            return "run";
                        }

                        Console.WriteLine("ERROR");
                        return "ERROR";
                    }
                }
            }
            else {
                return "Not Enough Money!";
            }

           
        }

        private bool Exchange(List<Money> pool, int checkCount, Money newValue, Money.Values checkValue)
        {
            List<Money> temp = new List<Money>();
            List<Money> money = new List<Money>();

            money = pool.FindAll(x => x.Value == checkValue);

            if (money.Count >= checkCount)
            {
                temp = pool.Where(x => x.Value == checkValue).Take(checkCount).ToList();
                pool.RemoveAll(x => temp.Contains(x));

                if (newValue.Value != Money.Values.ZERO)
                {
                    pool.Add(newValue);
                }

                return true;
            }

            return false;
        }
    }
}
