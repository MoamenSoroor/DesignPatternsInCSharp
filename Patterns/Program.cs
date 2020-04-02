using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
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




        }

    }
}
