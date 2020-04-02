using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.IO;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Design Patterns!");
        }
    }


    class BuildDir
    {
        public static void Build()
        {
            // CreationalPatterns
            string[] creational = {
                 "SingletonPattern"
                ,"PrototypePattern"
                ,"FactoryMethodPattern"
                ,"BuilderPattern"
                ,"AbstractFactoryPattern"
            };

            // StructuralPatterns
            string[] structural = {
                 "ProxyPattern"
                ,"FlyweightPattern"
                ,"CompositePattern"
                ,"BridgePattern"
                ,"FacadePattern"
                ,"DecoratorPattern"
                ,"AdapterPattern"
            };

            // BehavioralPatterns
            string[] behavioral = {
                 "ObserverPattern"
                ,"StrategyPattern"
                ,"TemplateMethodPattern"
                ,"CommandPattern"
                ,"IteratorPattern"
                ,"MementoPattern"
                ,"StatePattern"
                ,"MediatorPattern"
                ,"ChainOfResponsibilityPattern"
                ,"VisitorPattern"
                ,"InterpreterPattern"
            };
            

            Console.WriteLine("Write Files...");

            foreach (var item in creational)
            {
                Directory.CreateDirectory($@"Creational/{item}/");
                using (StreamWriter writer = new StreamWriter(File.Create($@"Creational/{item}/{item}.cs")))
                {
                    writer.Write($@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Creational.{item}
{{
    class {item}
    {{
	    public static void Test()
	    {{
		    // TODO!
            
	    }}
    }}
}}");

                } 


            }

            foreach (var item in structural)
            {
                Directory.CreateDirectory($@"Structural/{item}/");
                using (StreamWriter writer = new StreamWriter(File.Create($@"Structural/{item}/{item}.cs")))
                {
                    writer.Write($@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Structural.{item}
{{
    class {item}
    {{
	    public static void Test()
	    {{
		    // TODO!
            
	    }}
    }}
}}");

                }


            }

            foreach (var item in behavioral)
            {
                Directory.CreateDirectory($@"Behavioral/{item}/");
                using (StreamWriter writer = new StreamWriter(File.Create($@"Behavioral/{item}/{item}.cs")))
                {
                    writer.Write($@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.{item}
{{
    class {item}
    {{
	    public static void Test()
	    {{
		    // TODO!
            
	    }}
    }}
}}");

                }


            }

            Console.WriteLine("Done!!");

        }



    }
}
