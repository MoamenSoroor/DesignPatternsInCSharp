using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace Patterns.Creational.SimpleFactoryPattern
{
    public class SimpleFactoryPattern
    {
        public static void Test()
        {
            var factory = new SimplePizzaFactory();

            PizzaStore store = new PizzaStore(factory);

            var mypizza = store.OrderPizza(PizzaType.CheesePizza);

            Console.WriteLine(mypizza);

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
            return $"Pizza: {Name} {NewLine}Daugh: {Dough}, Sauce: {Sauce}{NewLine}Toppings: {string.Join(" , ",Toppings)}{NewLine}";
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
        public CheesePizza() : base(name: "Cheese Pizza", dough: "Regular Crust", sauce: "Marinara Pizza Sauce")
        {
            Toppings.Add("Fresh Mozzarella");
            Toppings.Add("Parmesan");
        }
    }

    public class ClamPizza : Pizza
    {
        public ClamPizza() : base(name: "Clam Pizza", dough: "Thin crust", sauce: "White garlic sauce")
        {
            Toppings.Add("Clams");
            Toppings.Add("Grated parmesan cheese");
        }
    }

    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza() : base(name: "Pepperoni Pizza",dough: "Crust",sauce: "Marinara sauce")
        {
            Toppings.Add("Sliced Pepperoni");
            Toppings.Add("Sliced Onion");
            Toppings.Add("Grated parmesan cheese");
        }
    }

    public class PizzaStore
    {
        private readonly SimplePizzaFactory factory;

        public PizzaStore(SimplePizzaFactory factory)
        {
            this.factory = factory;
        }


        public Pizza OrderPizza(PizzaType type)
        {
            var pizza = factory.CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }




    }


    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(PizzaType type)
        {
            Pizza pizza;
            switch (type)
            {
                case PizzaType.CheesePizza:
                    pizza = new CheesePizza();
                    break;
                case PizzaType.ClamPizza:
                    pizza = new ClamPizza();
                    break;
                case PizzaType.PepperoniPizza:
                    pizza = new PepperoniPizza();
                    break;
                default:
                    pizza = new CheesePizza();
                    break;
            }
            return pizza;
        }
    }





















}