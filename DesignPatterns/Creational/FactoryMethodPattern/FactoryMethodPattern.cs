using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace Patterns.Creational.FactoryMethodPattern
{
    class FactoryMethodPattern
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


    public abstract class Pizza
    {
        public Pizza()
        {
            Name = "";
            Dough = "";
            Sauce = "";
        }

        public Pizza(string name, string dough, string sauce)
        {
            Name = name;
            Dough = dough;
            Sauce = sauce;
        }

        public string Name { get; }

        public string Dough { get; }

        public string Sauce { get; }

        public List<string> Toppings { get; } = new List<string>();


        public override string ToString()
        {
            return $"Pizza: {Name} {NewLine}Daugh: {Dough}, Sauce: {Sauce}{NewLine}Toppings: {string.Join(" , ", Toppings)}{NewLine}";
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



    public class CairoCheesePizza : Pizza
    {
        public CairoCheesePizza() : base(name: "Cairo Cheese Pizza", dough: "Regular Crust", sauce: "Marinara Pizza Sauce")
        {
            Toppings.Add("Fresh Mozzarella");
            Toppings.Add("Parmesan");
        }
    }

    public class CairoClamPizza : Pizza
    {
        public CairoClamPizza() : base(name: "Cairo Clam Pizza", dough: "Thin crust", sauce: "White garlic sauce")
        {
            Toppings.Add("Clams");
            Toppings.Add("Grated parmesan cheese");
        }
    }

    public class CairoPepperoniPizza : Pizza
    {
        public CairoPepperoniPizza() : base(name: "Cairo Pepperoni Pizza", dough: "Crust", sauce: "Marinara sauce")
        {
            Toppings.Add("Sliced Pepperoni");
            Toppings.Add("Sliced Onion");
            Toppings.Add("Grated parmesan cheese");
        }
    }




    public class AlexCheesePizza : Pizza
    {
        public AlexCheesePizza() : base(name: "Alex Cheese Pizza", dough: "Regular Crust", sauce: "Marinara Pizza Sauce")
        {
            Toppings.Add("Fresh Mozzarella");
            Toppings.Add("Parmesan");
        }
    }

    public class AlexClamPizza : Pizza
    {
        public AlexClamPizza() : base(name: "Alex Clam Pizza", dough: "Thin crust", sauce: "White garlic sauce")
        {
            Toppings.Add("Clams");
            Toppings.Add("Grated parmesan cheese");
        }
    }

    public class AlexPepperoniPizza : Pizza
    {
        public AlexPepperoniPizza() : base(name: "Giza Pepperoni Pizza", dough: "Crust", sauce: "Marinara sauce")
        {
            Toppings.Add("Sliced Pepperoni");
            Toppings.Add("Sliced Onion");
            Toppings.Add("Grated parmesan cheese");
        }
    }



    public abstract class PizzaStore
    {
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

        public CairoPizzaStore()
        {
        }

        protected override Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza;
            switch (type)
            {
                case PizzaType.CheesePizza:
                    pizza = new CairoCheesePizza();
                    break;
                case PizzaType.ClamPizza:
                    pizza = new CairoClamPizza();
                    break;
                case PizzaType.PepperoniPizza:
                    pizza = new CairoPepperoniPizza();
                    break;
                default:
                    pizza = new CairoCheesePizza();
                    break;
            }
            return pizza;
        }
    }


    public class AlexPizzaStore : PizzaStore
    {

        public AlexPizzaStore()
        {
        }

        protected override Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza;
            switch (type)
            {
                case PizzaType.CheesePizza:
                    pizza = new AlexCheesePizza();
                    break;
                case PizzaType.ClamPizza:
                    pizza = new AlexClamPizza();
                    break;
                case PizzaType.PepperoniPizza:
                    pizza = new AlexPepperoniPizza();
                    break;
                default:
                    pizza = new CairoCheesePizza();
                    break;
            }
            return pizza;
        }
    }


    #endregion
}