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

            user.Stuff.Add(this);
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

                    pool = new List<Money>();
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
                                pool.Add(new Money(250));
                                pool.Add(new Money(250));
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
                        List<Money> money = new List<Money>();

                        money = pool.FindAll(x => x.Value == Money.Values.ONE);

                        //om jag hittar 5 enkroner så kan jag skapa en 5 krona.
                        if (money.Count == 5)
                        {
                            pool.RemoveAll(x => x.Value == Money.Values.ONE);
                            pool.Add(new Money(5));

                            return "run";
                        }

                        money = pool.FindAll(x => x.Value == Money.Values.FIVE);

                        //om jag hittar 4 femkroner så kan jag skapa en 20 krona.
                        if (money.Count == 4)
                        {
                            pool.RemoveAll(x => x.Value == Money.Values.FIVE);
                            pool.Add(new Money(20));

                            return "run";
                        }

                        money = pool.FindAll(x => x.Value == Money.Values.TWENTY);
                        List<Money> moneyExtra = pool.FindAll(x => x.Value == Money.Values.FIVE);
                        //om jag hittar 2 Tjugo lappar + 2 femkroner så kan jag skapa en 50 lapp.
                        if(money.Count == 2 && moneyExtra.Count == 2)
                        {
                            pool.RemoveAll(x => x.Value == Money.Values.TWENTY);
                            pool.RemoveAll(x => x.Value == Money.Values.FIVE);

                            pool.Add(new Money(50));

                            return "run";
                        }

                        money = pool.FindAll(x => x.Value == Money.Values.FIFTY);

                        //om jag hittar 2 femtio lappa kan jag skapa en 100 lapp.
                        if (money.Count == 2)
                        {
                            pool.RemoveAll(x => x.Value == Money.Values.FIFTY);

                            pool.Add(new Money(100));

                            return "run";
                        }

                        money = pool.FindAll(x => x.Value == Money.Values.HUNDRED);

                        //om jag hittar 5 hundra lappa kan jag skapa en 500 lapp.
                        if(money.Count == 5)
                        {
                            pool.RemoveAll(x => x.Value == Money.Values.HUNDRED);

                            pool.Add(new Money(500));

                            return "run";
                        }

                        money = pool.FindAll(x => x.Value == Money.Values.FIVEHUNDRED);

                        //om jag hittar 2 fem hundra lappar kan jag skapa en 100 lapp. 
                        if (money.Count == 2)
                        {
                            pool.RemoveAll(x => x.Value == Money.Values.FIVEHUNDRED);

                            pool.Add(new Money(1000));

                            return "run";
                        }

                        return "run";
                    }
                }
            }
            else {
                return "Not Enough Money!";
            }
            
            
        }
    }
}
