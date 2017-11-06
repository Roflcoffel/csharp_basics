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
            //First check for equal
            if (pool.Exists(x => x.Value == Prize.Value))
            {
                pool.Remove(pool.Find(x => x.Value == Prize.Value));
                //Remove the Money object for x.Value
                return ""; //Item Removed
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
                            pool.Add(new Money(25));
                            pool.Add(new Money(25));
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
                else
                {
                    return "Not Enough Money!";
                }
            }
        }
    }
}
