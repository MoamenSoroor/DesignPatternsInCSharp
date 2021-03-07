using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.StrategyPattern
{
    class StrategyPattern
    {
	    public static void Test()
	    {
            // TODO!

            Bird falcon = new Falcons() { Id = 1, Name = "Falcon1" };
            falcon.Perfom();

            (falcon as Falcons).Shoted();
            falcon.Perfom();
            
	    }


        class Bird
        {

            public int Id { get; set; }

            public string Name { get; set; }

            protected IFlyable flyBehaviour;

            public Bird()
            {
                // default behaviour
                flyBehaviour = new FlyWithTwoWings();
            }


            public IFlyable FlyBehaviour { get => flyBehaviour; }

            public void Fly()
            {
                FlyBehaviour.Fly();
            }

            public void Perfom()
            {
                Console.WriteLine($"I am {Name}");
                this.Fly();
            }






        }


        interface IFlyable
        {
            void Fly();
        }

        class NoFly : IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Sorry I can't Fly");
            }
        }

        class FlyWithOneWing : IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Fly With One Wing");
            }
        }

        class FlyWithTwoWings : IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Fly With Two Wing");
            }
        }


        class Duck : Bird
        {
            public Duck()
            {
                this.flyBehaviour = new NoFly();
            }
        }


        class Falcons : Bird
        {
            public Falcons()
            {
                this.flyBehaviour = new FlyWithTwoWings();
            }

            public void Shoted()
            {
                this.flyBehaviour = new FlyWithOneWing();
            }


        }





    }
}