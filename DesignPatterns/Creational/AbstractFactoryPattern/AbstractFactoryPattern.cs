using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Environment;

namespace Patterns.Creational.AbstractFactoryPattern
{
    class AbstractFactoryPattern
    {
        public static void Test()
        {

            var cairoStore = new CairoPizzaStore();
            var alexStore = new AlexPizzaStore();

            var cairoPizza = cairoStore.OrderPizza(PizzaType.CheesePizza);

            Console.WriteLine(cairoPizza);



            var alexPizza = alexStore.OrderPizza(PizzaType.ClamPizza);
            Console.WriteLine(alexPizza);

        }
    }


    // ingradients
    public abstract class Clams { }
    public abstract class Cheese { }
    public abstract class Pepperon { }
    public abstract class Dough { }
    public abstract class Souce { }


    public class FreshClams : Clams
    {
        public override string ToString()
        {
            return "Fresh Clams";
        }
    }

    


    public class FrozenClams : Clams
    {
        public override string ToString()
        {
            return "Frozen Clams";
        }
    }


    public class ParmesanCheese : Cheese
    {
        public override string ToString()
        {
            return "Parmesan Cheese";
        }
    }


    public class MozzarillaCheese : Cheese
    {
        public override string ToString()
        {
            return "Mozzarilla Cheese";
        }
    }


    public class SlicedPepperoni : Pepperon
    {
        public override string ToString()
        {
            return "Sliced Pepperoni";
        }
    }


    public class ThickCrustDough : Dough
    {
        public override string ToString()
        {
            return "Thick Crust Dough";
        }
    }

    public class ThinCrustDough : Dough
    {
        public override string ToString()
        {
            return "Thin Crust Dough";
        }
    }

    public class MarinaraSouce : Souce
    {
        public override string ToString()
        {
            return "Marinara Souce";
        }
    }

    public class WhiteGarlicSouce : Souce
    {
        public override string ToString()
        {
            return "White garlic Souce";
        }
    }


    //Clams
    //Cheese
    //Pepperon
    //Dough
    //Souce

    public interface IPizzaFactory
    {
        public Clams Clams { get; }
        public Cheese Cheese { get; }
        public Pepperon Pepperon { get; }
        public Dough Dough { get; }
        public Souce Souce { get; }
    }

    public class CairoPizzaFactory : IPizzaFactory
    {
        public Clams Clams => new FreshClams();

        public Cheese Cheese => new MozzarillaCheese();

        public Pepperon Pepperon => new SlicedPepperoni();

        public Dough Dough => new ThickCrustDough();

        public Souce Souce => new MarinaraSouce();
    }


    public class AlexPizzaFactory : IPizzaFactory
    {
        public Clams Clams => new FrozenClams();

        public Cheese Cheese => new ParmesanCheese();

        public Pepperon Pepperon => new SlicedPepperoni();

        public Dough Dough => new ThinCrustDough();

        public Souce Souce => new WhiteGarlicSouce();
    }


    public abstract class Pizza
    {
        protected Pizza(string name, IPizzaFactory factory)
        {
            Name = name;
            Clams = factory.Clams;
            Cheese = factory.Cheese;
            Pepperon = factory.Pepperon;
            Dough = factory.Dough;
            Souce = factory.Souce;
        }

        public string Name { get; set; }

        public Clams Clams { get; }

        public Cheese Cheese { get; }

        public Pepperon Pepperon { get; }

        public Dough Dough { get; }

        public Souce Souce { get; }


        public override string ToString()
        {
            return $"Pizza: {Name,10}, Cheese: {Cheese,10}, Pepperon: {Pepperon,10}, Daugh: {Dough,10}, Sauce: {Souce,10}";
        }


        public void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
        }

        public void Bake()
        {
            Console.WriteLine("Baking " + Name);
        }

        public void Cut()
        {
            Console.WriteLine("Cutting " + Name);
        }

        public void Box()
        {
            Console.WriteLine("Boxing " + Name);
        }

    }

    public enum PizzaType
    {
        CheesePizza, ClamPizza, PepperoniPizza
    }



    public class CheesePizza : Pizza
    {
        public CheesePizza(IPizzaFactory factory):base("Cheese Pizza",factory)
        {
        }

        public CheesePizza(string name, IPizzaFactory factory) : base(name, factory)
        {
        }
    }

    public class ClamPizza : Pizza
    {
        public ClamPizza(IPizzaFactory factory) : base("Clam Pizza", factory)
        {
        }

        public ClamPizza(string name, IPizzaFactory factory) : base(name, factory)
        {
        }
    }

    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza(IPizzaFactory factory) : base("Pepperoni Pizza", factory)
        {
        }

        public PepperoniPizza(string name, IPizzaFactory factory) : base(name, factory)
        {
        }
    }



    public abstract class PizzaStore
    {
        protected IPizzaFactory factory;
        public PizzaStore()
        {
        }


        public Pizza OrderPizza(PizzaType type)
        {

            var pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }


        protected abstract Pizza CreatePizza(PizzaType type);

    }


    #region pizza stores

    // stores
    public class CairoPizzaStore : PizzaStore
    {

        public CairoPizzaStore() : base()
        {
            factory = new CairoPizzaFactory();
        }

        protected override Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza;
            switch (type)
            {
                case PizzaType.CheesePizza:
                    pizza = new CheesePizza("Cairo Cheese Pizza", factory);
                    break;
                case PizzaType.ClamPizza:
                    pizza = new ClamPizza("Cairo clam Pizza", factory);
                    break;
                case PizzaType.PepperoniPizza:
                    pizza = new PepperoniPizza("Cairo Pepperoni Pizza", factory);
                    break;
                default:
                    pizza = new CheesePizza("Cairo Cheese Pizza", factory);
                    break;
            }
            return pizza;
        }
    }


    public class AlexPizzaStore : PizzaStore
    {

        public AlexPizzaStore()
        {
            factory = new AlexPizzaFactory();
        }

        protected override Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza;
            switch (type)
            {
                case PizzaType.CheesePizza:
                    pizza = new CheesePizza("Alex Cheese Pizza", factory);
                    break;
                case PizzaType.ClamPizza:
                    pizza = new ClamPizza("Alex clam Pizza", factory);
                    break;
                case PizzaType.PepperoniPizza:
                    pizza = new PepperoniPizza("Alex Pepperoni Pizza", factory);
                    break;
                default:
                    pizza = new CheesePizza("Alex Cheese Pizza", factory);
                    break;
            }
            return pizza;
        }
    }


    #endregion
}