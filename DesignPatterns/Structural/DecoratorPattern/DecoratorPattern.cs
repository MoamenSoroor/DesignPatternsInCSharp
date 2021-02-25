using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural.DecoratorPattern
{
    class DecoratorPattern
    {
	    public static void Test()
	    {
            // TODO!

            IPizza plainpizza = new Pizza(20, "Plain Pizza");

            //IPizza finished = new ZatoonDecorator(new TomatoDecorator(new MozarillaDecorator(plainpizza)));

            IPizza finished = new DecoratorBuilder(plainpizza)
                            .AddMozarilla()
                            .AddTomato()
                            .AddZatoon()
                            .Build();

            Console.WriteLine("Pizza: ");
            Console.WriteLine(finished.Desc);
            Console.WriteLine(finished.Cost);
            
	    }
    }


    class DecoratorBuilder
    {

        private IPizza pizza;

        public DecoratorBuilder(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public DecoratorBuilder AddZatoon()
        {
            this.pizza = new ZatoonDecorator(this.pizza);
            return this;
        }


        public DecoratorBuilder AddMozarilla()
        {
            this.pizza = new MozarillaDecorator(this.pizza);
            return this;
        }

        public DecoratorBuilder AddTomato()
        {
            this.pizza = new TomatoDecorator(this.pizza);
            return this;
        }

        public IPizza Build()
        {
            return this.pizza;
        }


    }


    // this is my Decorator 
    interface IPizza
    {
        decimal Cost { get; }

        string Desc { get; }

    }

    class Pizza : IPizza
    {
        private decimal cost;
        private string desc;

        public Pizza(decimal cost1 , string desc1)
        {
            this.cost = cost1;
            this.desc = desc1;
        }

        public string Desc { get => desc; set => desc = value; }
        public decimal Cost { get => cost; set => cost = value; }
    }

    abstract class Dicorator : IPizza
    {
        protected IPizza pizza;

        public Dicorator(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public abstract decimal Cost { get; }
        public abstract string Desc { get; }
    }



    class ZatoonDecorator : Dicorator
    {
        public ZatoonDecorator(IPizza pizza) : base(pizza) { }
        public override string Desc { get => $"{pizza.Desc}, Zatoon" ; }
        public override decimal Cost { get => pizza.Cost + 1.0m; }
    }


    class MozarillaDecorator : Dicorator
    {
        public MozarillaDecorator(IPizza pizza) : base(pizza) { }
        public override string Desc { get => $"{pizza.Desc}, Mozarilla"; }
        public override decimal Cost { get => pizza.Cost + 3.0m; }
    }

    class TomatoDecorator : Dicorator
    {
        public TomatoDecorator(IPizza pizza) : base(pizza) { }
        public override string Desc { get => $"{pizza.Desc}, Tomato"; }
        public override decimal Cost { get => pizza.Cost + 3.0m; }
    }


}